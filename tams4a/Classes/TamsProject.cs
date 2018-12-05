using DotSpatial.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace tams4a.Classes
{
    public class TamsProject
    {
        // Members -----------------------------------------------------------------------

        // Modules
        public Dictionary<String, ProjectModule> modules { get; protected set; }
        public String currentModuleName { get; protected set; }    // which module we're currently on

        // Settings
        public Map map { get; protected set; }  // we'll need the map for various drawing things.
        public String projectFilePath { get; protected set; }   // path to project file
        public String projectFolderPath { get; protected set; }  // path to project folder
        public Boolean isOpen { get; protected set; }

        // Database
        public SQLiteConnection conn { get; protected set; }
        public ProjectSettings settings { get; protected set; }


        // Methods ------------------------------------------------------------------------
        /// <summary>
        /// Constructor: initializes the tams project with Map
        /// </summary>
        /// <param name="tamsMap">A dotspacial map for roads (and later signs)</param>
        public TamsProject(Map tamsMap)
        {
            isOpen = false;
            modules = new Dictionary<String, ProjectModule>();
            currentModuleName = "";
            map = tamsMap;
            conn = new SQLiteConnection();
        }

        /// <summary>
        /// Attemps to open the project "filename", returns true of successful
        /// </summary>
        /// <param name="filename">The file name of the project to load</param>
        /// <returns>true if successful</returns>
        public bool open(String filename)
        {
            try
            {
                conn = Database.Connect(filename);
            }
            catch (Exception e)
            {
                Log.Error("Could not connect to database. \n" + e.ToString());
                return false;
            }

            Database.UpdateDatabase(conn);
            try
            {
                settings = new ProjectSettings(conn, this);
                settings.LoadValues();
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not load settings.");
                Log.Error("Could not load settings." + e.ToString());
                return false;
            }

            foreach (KeyValuePair<String, ProjectModule> pair in modules)
            {
                pair.Value.load();      // this should also load the module settings
                                        // ??? change modules to load on instantion?
                                        // no?  have to have project open before can load module settings.
            }

            if (!settings.HaveRequired())
            {
                throw new Exception("Missing required settings");
            }

            Properties.Settings.Default.lastProject = filename;
            Properties.Settings.Default.projectFolder = Path.GetDirectoryName(filename) + Path.DirectorySeparatorChar;
            Properties.Settings.Default.Save();

            projectFilePath = filename;
            projectFolderPath = new DirectoryInfo(filename).Parent.FullName.ToString();

            settings.SetSetting("progversion", new ProjectSetting(name: "TAMS Version", module: "general", value: Program.GetVersion()));
            settings.SetSetting("version", new ProjectSetting(name: "DB Version", module:"general", value:Properties.Settings.Default.dbVersion.ToString()));
           

            isOpen = true;
            return true;
        }
        
        public void close()
        {
            if (!isOpen)
            {
                return;
            }

            Database.Close(conn);
            isOpen = false;
        }

        /// <summary>
        /// Attempts to create a project and connect to a new database
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public Boolean startNew(String filename)
        {
            try
            {
                File.WriteAllBytes(filename, Properties.Resources.blank_db_v6);
            }
            catch
            {
                MessageBox.Show("Could not create project file: " + filename, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!open(filename))
            {
                return false;
            }
            
            return true;
        }


        public void mapSelectionChanged()
        {
            if (String.IsNullOrEmpty(currentModuleName))
            {
                return; // shouldn't happen.  nothing to do
            }

            ProjectModule module;

            try
            {
                module = modules[currentModuleName];
                // TODO: Select correct layer if possible.
            }
            catch (Exception exception)
            {
                MessageBox.Show("Requested invalid module" + Environment.NewLine + exception.ToString());
                return;
            }

            module.selectionChanged();
        }

        /// <summary>
        /// Adds module and associated tab to the project modules with the given name, Throws an exception of module of the same name already exists 
        /// </summary>
        /// <param name="module">the module to add</param>
        /// <param name="name">module name - must be unique.</param>
        /// <param name="tabControl">the associated tab control</param>
        public void addModule(ProjectModule module, String name, TabControl tabControl)
        {
            if (modules.ContainsKey(name))
            {
                throw new Exception("Module already in project");
            }

            modules.Add(name, module);
            tabControl.TabPages.Add(module.ControlsPage);
            module.load();

            if (String.IsNullOrEmpty(currentModuleName))
            {
                selectModule(name);
            }
        }

        /// <summary>
        /// Select's a module by name
        /// </summary>
        /// <param name="name"></param>
        public void selectModule(string name)
        {
            foreach (string key in modules.Keys)
            {
                modules[key].deactivate();
            }
            currentModuleName = name;
            modules[name].ControlsPage.Select();
            modules[name].activate();
        }

        // check version, upgrade if necessary
        // this is the overall version.
        // ??? TODO ??? treat the general settings (and version) as the base module?
        //      and check version there?
        private void checkVersion()
        {
            if (!settings.Contains("version"))
            {
                MessageBox.Show("Project database is missing version number.  Unable to continue.");
                isOpen = false;
                Database.Close(conn);
            }

            // use PRAGMA table_info([tablename]);
        }
    }
}
