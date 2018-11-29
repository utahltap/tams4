using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using tams4a.Forms;
using System.Linq;

namespace tams4a.Classes
{
    public class ProjectSettings
    {
        // Members
        private Dictionary<String, ProjectSetting> Settings;
        private SQLiteConnection Conn;

        public ProjectSettings(SQLiteConnection tamsconn)
        {
            Settings = new Dictionary<String, ProjectSetting>();
            Conn = tamsconn;
        }


        // Attempts to update all setting values from the database.
        // if database entry is not in Settings then it's ignored.
        // If "module" is not empty, only load settings for module.
        public void LoadValues(String module="")
        {
            if (!Database.IsOpen(Conn)) { throw new Exception("Can't load values without connection."); }

            try
            {
                String sql = "SELECT * FROM settings";
                DataTable results = Database.GetDataByQuery(Conn, sql, new Dictionary<String, String>());

                foreach(DataRow row in results.Rows)
                {
                    if (module == "" || row["module"].ToString() == module)
                    {
                        String settingName = row["name"].ToString();

                        // only settings that have already been added to the settings list will be set.
                        // anything else in the settings table is ignored.
                        if (Settings.ContainsKey(settingName))
                        {
                            // set it directly since calls to setvalue also update the database (which we're working with currently).
                            Settings[settingName].Value = row["value"].ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Could not load project settings.\n" + e.ToString());
            }
        }


        // get only the value based on string.  TODO:  Necessary?
        public string GetValue(String key)
        {
            String value;
            try
            {
                if (!Settings.ContainsKey(key)) { throw new Exception("Invalid ProjectSetting key (" + key + ") in GetValue request."); }
                if (String.IsNullOrEmpty(Settings[key].Value))
                {
                    value = "";
                }
                else
                {
                    value = Settings[key].Value;
                }
            }
            catch
            {
                throw new Exception("Unable to retrieve value for ProjectSetting " + key);
            }
            return value;
        }


        public Boolean Contains(String key)
        {
            if (Settings.ContainsKey(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // add a NEW setting into project settings.  (or ignore if already there)
        // does NOT save the setting to the database.
        public void Inject(String key, ProjectSetting setting)
        {
            if (!Settings.ContainsKey(key))
            {
                Settings.Add(key, setting);
            }
        }


        // Insert or update key to = value (doesn't change other parts or the setting)
        public void SetValue(String key, String value)
        {
            if (!Database.IsOpen(Conn)) { throw new Exception("Settings database not connected"); }
            if (String.IsNullOrEmpty(key)) { throw new Exception("Invalid key"); }

            // this limitation is arbitrary although the database may have some limitations
            if (key.Length > 128 || value.Length > 1024) { throw new Exception("Invalid setting size"); }

            ProjectSetting setting;
            if (Settings.ContainsKey(key))
            {
                setting = Settings[key];
            }
            else
            {
                setting = new ProjectSetting(key);
            }
            
            setting.Value = value;

            try
            {
                SetSetting(key, setting);
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not update setting with key: " + key);
                Log.Error("Could not update setting with key:" + key + "\n\n" + e.ToString());
            }
        }


        public List<ProjectSetting> List()
        {
            return Settings.Values.ToList<ProjectSetting>();
        }


        // REPLACEs (insert or update) a setting in the settings list 
        public void SetSetting(String key, ProjectSetting setting)
        {
            if (!Database.IsOpen(Conn)) { throw new Exception("Settings database not connected"); }
            if (String.IsNullOrEmpty(key)) { throw new Exception("Invalid key"); }
            if (key.Length > 128 || setting.Value.Length > 1024) { throw new Exception("Invalid setting size"); }

            // update the database, then the setting
            try
            {
                Dictionary<String, String> values = new Dictionary<string, string>();
                values.Add("name", setting.Name);
                values.Add("value", setting.Value);
                values.Add("module", setting.Module);
                values.Add("display_name", setting.Display_Name);
                values.Add("display_type", setting.Display_Type);
                values.Add("display_weight", setting.Display_Weight.ToString());
                values.Add("description", setting.Description);

                if (!Database.ReplaceRow(Conn, values, "settings"))
                {
                    MessageBox.Show("Could not replace database row.  We suggest you exit TAMS and check the project file.");
                }

                Settings[key] = setting;
                //Settings.TryGetValue(key, out setting);
                //setting.Value = value;
            }
            catch (Exception e)
            {
                Log.Error("Could not update setting.\n" + e.ToString());
                MessageBox.Show("Could not update setting " + key);
            }
            // update settings dictionary
        }


        // seems like this version is really all we need?
        public void SetSetting(ProjectSetting setting)
        {
            String key = setting.Name;
            SetSetting(key, setting);
        }

        // Checks that all ProjectSetting with required=true have an assigned (non-empty) value
        // returns true if so, otherwise false.
        public Boolean HaveRequired(String moduleName="")
        {
            foreach (KeyValuePair<String, ProjectSetting> pair in Settings)
            {
                if (moduleName == "" || pair.Value.Module == moduleName)
                {
                    if (pair.Value.Required)
                    {
                        if (String.IsNullOrWhiteSpace(pair.Value.Value))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        /// <summary>
        /// Checks HaveRequired
        /// If its false, presents the settings dialog
        /// Returns true unless settings dialog is cancelled.
        /// </summary>
        public Boolean CheckRequired(String moduleName = "")
        {
            if (HaveRequired(moduleName)) { return true; }

            DialogResult result = showDialog(moduleName);
            if (result != DialogResult.OK)
            {
                MessageBox.Show("TAMS may not work properly if all required settings are not set.");
                return false;
            }
            return true;
        }


        public DialogResult showDialog(String selectedTab="road")
        {
            LoadValues();
            FormSettings settingsForm = new FormSettings(this);
            settingsForm.Init();
            settingsForm.TrySelectTab(selectedTab);
            DialogResult settingsResult = settingsForm.ShowDialog();

            if (HaveRequired() && settingsResult == DialogResult.OK)
            {
                return DialogResult.OK;
            } else
            {
                return DialogResult.Cancel;
            }

        }
    }
}
