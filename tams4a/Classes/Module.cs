using System;
using System.Collections.Generic;
using System.Globalization;

using DotSpatial.Controls;
using DotSpatial.Data;
using tams4a.Forms;
using System.Windows.Forms;
using System.Data;
using DotSpatial.Symbology;

namespace tams4a.Classes
{
    public class ProjectModule
    {
        public const String moduleVersion = "4.0.1.2";    // string that can be converted to System.Version

        public String Filepath { get; protected set; } // path to related shapefile
        public IMapLayer Layer { get; protected set; } // DotSpatial layer
        public TabPage ControlsPage { get; protected set; } // where to put controls for this module
        protected TamsProject Project { get; set; }
        public String ModuleName { get; protected set; } // used for settings and ????
        protected Dictionary<String, String> FieldSettingToDbColumn;
        public String IdText { get; protected set; }
        public Boolean UnsavedChanges { get; protected set; }
        protected List<Dictionary<String, String>> selectionValues;
        protected DateTime surveyDate;
        protected FormSurveyDate dateForm;
        // button to enable after shp file is opened
        private ToolStripMenuItem[] linkedComponents;

        // settings required by this module
        // settings may have default values assigned and are added to project (as defined) at load if they
        // are not already present.
        public List<ProjectSetting> ModuleSettings { get; protected set; }

        // sql used to retrieve database information about map selected objects
        protected readonly String SelectionSql;  // TODO: This should only be set at construction.  Readonly doesn't work for inherited classes.
                                                 // http://stackoverflow.com/questions/6037546/assigning-a-value-to-an-inherited-readonly-field


        public ProjectModule(TamsProject theProject, TabPage controlsPage, ToolStripMenuItem[] lcs, String selectionSql = "")
        {
            Project = theProject;
            setControls(controlsPage);  // attempt to select the page appropriate to the current module
            ModuleName = "general";
            UnsavedChanges = false;
            ModuleSettings = new List<ProjectSetting>();
            linkedComponents = lcs;

            // selectionSql can only be set here!
            if (selectionSql == "")
            {
                // Default value for inherited members
                // [[IDLIST]] will be replaced with TAMSIDs from selection at query time
                SelectionSql = "SELECT * FROM [" + ModuleName + "] WHERE TAMSID IN ([[IDLIST]])";
            } else
            {
                SelectionSql = selectionSql;
            }
        }


        // Connects module to its controls (from the main window form)
        public void setControls(TabPage tabPage)
        {
            ControlsPage = tabPage;
            ControlsPage.AutoScroll = true;
        }


        // generic event handler that directs us to the real (possibly derived) function.
        // use to change which function is called when hitting generic "open file" button
        public void openFileHandler(object sender, EventArgs e)
        {
            openNewFile();
        }


        // opens file specified in parameter OR already specified in "filepath" member
        // TODO:  Is there a case where we need the 2nd option?
        public virtual Boolean openFile(String thePath="", String type="")
        {
            if (isOpen())
            {
                Log.Error("Module " + ModuleName + "attempted to open file (" + thePath + ") when file was already opened (" + Filepath + ")"); // Shouldn't even get here.
                return false;
            }
            
            // if we didn't specify a path in this call, check the data member "Filepath"
            if (thePath == "")
            {
                thePath = Filepath;
            }

            if (String.IsNullOrEmpty(thePath))
            {
                FormCustomMessage.ShowDialog("Invalid filename specified");
                this.close();
                return false;
            }

            try
            {
                // try to add the file to the map
                Layer = Project.map.AddLayer(thePath);
                FeatureLayer L = Layer as FeatureLayer;
                L.Name = ModuleName;
                if (Layer.Projection != DotSpatial.Projections.KnownCoordinateSystems.Projected.World.WebMercator)
                {
                    // SHP File is not in Web Mercator projection.  Attempting to reproject.
                    Layer.Reproject(DotSpatial.Projections.KnownCoordinateSystems.Projected.World.WebMercator);
                    Log.Warning("Attempted to reproject " + thePath + "\nRESULT: " + Layer.Projection.ToString());

                    if (Layer.Projection != DotSpatial.Projections.KnownCoordinateSystems.Projected.World.WebMercator)
                    {
                        MessageBox.Show("Could not reproject SHP file.  Please adjust the projection to WebMercator in a GIS program (such as ArcMap or MapWindow).");
                        this.close();
                        return false;
                    }
                }
                foreach (var comp in linkedComponents)
                {
                    comp.Enabled = true;
                }
                Project.map.ZoomToMaxExtent();
                Filepath = thePath;
            }
            catch (Exception e)
            {
                FormCustomMessage.ShowDialog("Could not open " + thePath + Environment.NewLine + e.ToString());
                Log.Error("Could not open SHP file (" + thePath + ") for module " + ModuleName);
                this.close();

                return false;
            }

            // set shpfile setting for this module
            ProjectSetting shpSetting = new ProjectSetting(name:ModuleName+"_file", value:Filepath, module:ModuleName);
            ProjectSetting shpRelative = new ProjectSetting(name: ModuleName + "_relative", value: Util.MakeRelativePath(Properties.Settings.Default.lastProject, Filepath), module:ModuleName);
            Project.settings.SetSetting(shpSetting);
            Project.settings.SetSetting(shpRelative);


            List<String> fields = shpFields();
            foreach (ProjectSetting setting in ModuleSettings)
            {
                if (setting.Display_Type == "field")
                {
                    setting.options = fields;
                }
            }

            checkSettings();
            select();
            
            Log.Note("Loaded road file " + thePath);
            return true;
        }

        public void select()
        {
            if (Layer != null)
            {
                Project.map.Layers.SelectedLayer = Layer;
            }
        }

        /// <summary>
        /// Selects a SHP file,
        /// uses openFile to open the selected file and verifes the file is the corect type
        /// </summary>
        /// <param name="type">The name of the file that we are trying to open</param>
        /// <returns></returns>
        public virtual Boolean openNewFile(String type = "")
        {
            if (isOpen()) { return false; }

            // User select file
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "SHP Files|*.shp";
            openDialog.Multiselect = false;

            String prettyType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(type);
            if (prettyType != "") { prettyType += " "; } // add space to make it look right

            openDialog.Title = "Open " + prettyType + "SHP File";
            DialogResult openDialogResult = openDialog.ShowDialog();
            if (openDialogResult != DialogResult.OK) { return false; }

            // now try to open the file
            if (!openFile(openDialog.FileName, type)) { return false; }

            // @TO-DO load data from shpfile to db
            if (Properties.Settings.Default.newProject)
            {
                ShpToDatabase();
                Properties.Settings.Default.newProject = false;
                Properties.Settings.Default.Save();
                foreach (var comp in linkedComponents)
                {
                    comp.Enabled = true;
                }
            }

            return true;
        }

        /// <summary>
        /// Called once when a new project is created, puts a database entry for each shape in the .shp file.
        /// </summary>
        protected virtual void ShpToDatabase()
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable data;
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            data = selectionLayer.DataSet.DataTable;
            foreach (DataRow row in data.Rows)
            {
                Dictionary<String, String> values = new Dictionary<string, string>();
                values["survey_date"] = "";
                foreach (KeyValuePair<String, String> pair in FieldSettingToDbColumn)
                {
                    if (!Project.settings.Contains(pair.Key))
                    {
                        continue;
                    }

                    String fieldName = Project.settings.GetValue(pair.Key);
                    if (data.Columns.Contains(fieldName))
                    {
                        // make a copy in the correct location of anything we DO need
                        values[pair.Value] = row[fieldName].ToString();
                    }
                }
                Database.InsertRow(Project.conn, values, ModuleName);
            }
            Cursor.Current = Cursors.Arrow;
        }

        protected virtual void injectSettings()
        {
            foreach (ProjectSetting setting in ModuleSettings)
            {
                Project.settings.Inject(setting.Name, setting);
            }
            Project.settings.LoadValues();  // get any values from the database.
        }


        /// <summary>
        /// Loads the module
        /// </summary>
        public virtual void load()
        {
            injectSettings();
            if (Project.settings.Contains(ModuleName + "_relative") && !string.IsNullOrWhiteSpace(Project.settings.GetValue(ModuleName + "_relative")))
            {
                string filename = System.IO.Path.Combine(Project.projectFolderPath, Project.settings.GetValue(ModuleName + "_relative"));
                {
                    if (!openFile(filename))
                    {
                        MessageBox.Show("Could not load " + ModuleName + " file (" + filename + ")");
                    }
                }
            }
            else if (Project.settings.Contains(ModuleName + "_file"))
            {
                string filename = Project.settings.GetValue(ModuleName + "_file");
                if (!string.IsNullOrEmpty(filename))
                {
                    if (!openFile(filename))
                    {
                        MessageBox.Show("Could not load " + ModuleName + " file (" + filename + ")");
                    }
                }
                
            }
        }
        
        public bool checkSettings()
        {
            return Project.settings.CheckRequired(ModuleName);
        }

        /// <summary>
        /// Checks whether a file for the module is availaible.
        /// </summary>
        /// <returns>false if file path is null or empty.</returns>
        public Boolean isOpen()
        {
            if (String.IsNullOrEmpty(Filepath))
            {
                return false;
            }
            return true;
        }


        // try to determine the type of file
        // point, line, poly, or none (invalid)
        protected String getShpType()
        {
            //roadModule = (MapLineLayer)uxMap.AddLayer(roadShpFilename);
            // TODO:  I don't know if converting this to string and checking that is best way.
            String mapType;
            try
            { mapType = Layer.GetType().ToString(); }
            catch
            { return "none"; }

            switch (mapType)
            {
                case "DotSpatial.Controls.MapLineLayer":
                    return "line";
                case "DotSpatial.Controls.MapPolygonLayer":
                    return "poly";
                case "DotSpatial.Controls.MapPointLayer":
                    return "point";
                default:
                    return "none";
            }
        }


        // returns list of column names in layer (or blank if not opened)
        public List<String> shpFields()
        {
            if (!isOpen())
            {
                throw new Exception("No file open");
            }
            List<String> returnList = new List<string>();
            IFeatureSet featureSet = (IFeatureSet)Layer.DataSet;

            foreach (DataColumn column in featureSet.GetColumns())
            {
                returnList.Add(column.ColumnName);
            }
            return returnList;
        }


        public virtual void selectionChanged(object sender, EventArgs e)
        {
            UnsavedChanges = false;
            // generic module does nothing on selection change.
            // TODO:  Perhaps allow editting item attributes in SHP file directly?
        }


        // remove this module from project.
        public void close()
        {
            if (!this.isOpen())
            {
                return;
            }

            Project.map.Layers.Remove(Layer);
            Filepath = "";
            Layer = null;

            // TODO: Should also remove settings that were added at open
        }


        // modifies returnDictionary to have any new values included in DataTable data
        // consolidates data 
        // data.column-name = returnDictionary.key
        // Only adds values if data.column[value] == returnDictionary.value (both ToString)
        //  for all rows in [data]
        // TODO: Should I just return the dictionary instead of having a ref?
        protected void consolidateDictionary(DataTable data, ref Dictionary<String, String> returnDictionary)
        {
            List<String> columnNames = new List<string>(data.Columns.Count);
            foreach (DataColumn column in data.Columns)
            {
                columnNames.Add(column.ColumnName);
            }

            List<String> removeKeys = new List<string>(); // keys that will be removed after processing [data]
            String thisValue;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                foreach (String columnName in columnNames)
                {
                    // once we've decided to remove a dictionary entry, no need to continue to check it.
                    if (!removeKeys.Contains(columnName))
                    {
                        thisValue = data.Rows[i][columnName].ToString();
                        if (!returnDictionary.ContainsKey(columnName))  // hasn't been set, so first time to encounter this
                        {
                            returnDictionary[columnName] = thisValue;
                        }
                        else if (thisValue != returnDictionary[columnName]) // has been set, and to something different
                        {
                            removeKeys.Add(columnName);
                        }
                        // otherwise, leave it as-is (it's the same)
                    }
                }
            }
            // now remove any dictionary entries included in removeKeys
            // couldn't do it before or we'd have the possibility of removing
            // an item, then adding it back in.
            foreach (String key in removeKeys)
            {
                returnDictionary[key] = "";
            }
        }


        /// <summary>
        /// returns a dictionary of values based on the selection
        /// </summary>
        /// <param name="selectionTable">The table of selected shapes on the map</param>
        /// <returns></returns>
        protected Dictionary<String, String> setSegmentValues(DataTable selectionTable)
        {
            Dictionary<String, String> shpValues = new Dictionary<string, string>();
            selectionValues = new List<Dictionary<string, string>>();
            
            // load up values from shp file (to be overridden if present in DB)
            consolidateDictionary(selectionTable, ref shpValues);
            
            // set column names to the correct ones specified in settings file.  
            // TODO:  This assumes that we won't ever have an unused field in the shp file that is the same as the 
            // DB columns that we DO use.  If that happens, we might (depending on order) lose the shp field value for 
            // those columns.  Not the end of the world, but not ideal.

            // Correct the keys in shpValues (using project settings mapping of shp fields to db columns
            /*Dictionary<String, String> shpValuesKeyed = new Dictionary<string, string>();
            
            foreach (KeyValuePair<String, String> pair in FieldSettingToDbColumn)
            {
                if (!Project.settings.Contains(pair.Key))
                {
                    continue;
                }

                String fieldName = Project.settings.GetValue(pair.Key);
                if (shpValues.ContainsKey(fieldName))
                {
                    // make a copy in the correct location of anything we DO need
                    shpValuesKeyed[pair.Value] = shpValues[fieldName];
                }
            }*/

            // Get list of TAMSIDs from selection to use for DB selection
            String thisSql = SelectionSql.Replace("[[IDLIST]]", extractTAMSIDs(selectionTable));

            Dictionary<String, String> returnDictionary = new Dictionary<string, string>();

            try
            {
                DataTable resultsTable = Database.GetDataByQuery(Project.conn, thisSql);
                
                // HERE:  Problem is that if the shp file has one value and DB has a different value, 
                // then this won't work.
                foreach (DataRow row in resultsTable.Rows)
                {
                    Dictionary<String, String> v = new Dictionary<string, string>();
                    foreach (DataColumn col in resultsTable.Columns)
                    {
                        v[col.ToString()] = row[col.ToString()].ToString();
                    }
                    selectionValues.Add(v);
                }
                if (resultsTable.Rows.Count == selectionTable.Rows.Count)
                {
                    consolidateDictionary(resultsTable, ref returnDictionary);
                }
            }
            catch (Exception e)
            {
                Log.Error("Could not get database values for " + ModuleName + " module.\n" + e.ToString());
            }
            return returnDictionary;
        }

        /// <summary>
        /// Convenience Function, extracts the TAMSIDs from the current selection into a single string for use SQL statement
        /// </summary>
        /// <param name="selection">the selected shapes on the map</param>
        /// <returns></returns>
        protected String extractTAMSIDs(DataTable selection)
        {
            String tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");
            String tamsids = "";
            foreach (DataRow row in selection.Rows)
            {
                if (tamsids != "") { tamsids += ","; }
                tamsids += row[tamsidcolumn].ToString();
            }
            return tamsids;
        }
        
        protected String extractTAMSIDs(DataTable selection, string tamsidcolumn)
        {
            String tamsids = "";
            foreach (DataRow row in selection.Rows)
            {
                if (tamsids != "") { tamsids += ","; }
                tamsids += row[tamsidcolumn].ToString();
            }
            return tamsids;
        }

        // handler for changed controls
        protected virtual void controlChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        public void deactivate()
        {
            if (Layer != null)
            {
                Layer.SelectionEnabled = false;
            }
        }

        /// <summary>
        /// set's the module as the current active module.
        /// </summary>
        public void activate()
        {
            if (Layer != null)
            {
                Layer.SelectionEnabled = true;
            }
        }

        /// <summary>
        /// Sets the survey date for the module to the current selected date in the dateform
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void setDate(object sender, EventArgs args)
        {
            surveyDate = dateForm.getDate();
        }
    }
}
