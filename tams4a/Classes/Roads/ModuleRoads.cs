using DotSpatial.Symbology;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using tams4a.Controls;
using tams4a.Forms;
using tams4a.Classes.Roads;

namespace tams4a.Classes
{
    public class ModuleRoads : ProjectModule
    {
        public new const string moduleVersion = "4.0.1.1";    // string that can be converted to System.Version
        public string roadColors = "RSL";
        public Color labelColor = Color.Black;

        private TamsProject project;
        private RoadReports reports;
        private RoadGraphs graphs;
        public RoadSymbols symbols;
        new private FormSurveyDate dateForm = new FormSurveyDate();

        private string[] distressAsphalt = { "Fatigue", "Edge Cracks", "Longitudinal", "Patches", "Potholes", "Drainage", "Transverse", "Blocking", "Rutting" };
        private string[] distressGravel = { "Potholes", "Rutting", "X-section", "Drainage", "Dust", "Aggregate", "Corrugation" };
        private string[] distressConcrete = { "Spalling", "Joint Seals", "Corners", "Breaks", "Faulting", "Longitudinal", "Transverse", "Map Cracks", "Patches" };

        private int selectionCount = 0;
        private bool colorsOn = true;
        private DataTable surfaceTypes;
        private DataTable surfaceDistresses;
        private string previousSurface;
        private string notes;
        static private readonly string RoadSelectionSql = @"SELECT MAX(roadinfo.id) AS max_id, roadinfo.* 
                    FROM
                    (
                        SELECT TAMSID, MAX(survey_date) AS maxdate
                        FROM road
                        WHERE TAMSID IN ([[IDLIST]])
                        GROUP BY TAMSID
                    ) AS roadids
                    JOIN road AS roadinfo
                        ON (
                                roadinfo.TAMSID = roadids.TAMSID AND
                                roadinfo.survey_date = roadids.maxdate
                            )
                    GROUP BY roadinfo.TAMSID";

        public ModuleRoads(TamsProject theProject, TabPage controlPage, ToolStripMenuItem[] boundButtons) : base(theProject, controlPage, boundButtons, RoadSelectionSql)
        {
            ModuleName = "road";
            surveyDate = DateTime.Now;
            notes = "";
            reports = new RoadReports(theProject, this);
            graphs = new RoadGraphs(theProject, this, distressAsphalt, distressGravel, distressConcrete);
            symbols = new RoadSymbols(theProject, this);
            project = theProject;
            boundButtons[1].Click += reports.generalReport;
            boundButtons[2].Click += reports.potholeReport;
            boundButtons[3].Click += openBudgetTool;

            boundButtons[5].Click += graphs.graphRoadType;
            boundButtons[6].Click += graphs.graphRoadCategory;
            boundButtons[7].Click += graphs.graphGoverningDistress;
            boundButtons[8].Click += graphs.graphRSL;
            
            Panel_Module_OpenShp roadAdd = new Panel_Module_OpenShp("Road");
            roadAdd.Name = "ROADADD";
            roadAdd.SetHandler(new EventHandler(openFileHandler));
            roadAdd.Dock = DockStyle.Fill;
            ControlsPage.Controls.Add(roadAdd);

            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_file", module: ModuleName));
            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_relative", module: ModuleName));
            
            FieldSettingToDbColumn = new Dictionary<string, string>()
            {
                { "road_f_TAMSID", "TAMSID" },
                { "road_f_streetname", "name"},
                { "road_f_rsl", "rsl" },
                { "road_f_width", "width" },
                { "road_f_length", "length" },
                { "road_f_speedlimit", "speed_limit" },
                { "road_f_startaddr", "from_address" },
                { "road_f_endaddr", "to_address" },
                { "road_f_surfacetype", "surface" }
            };
            
            Project.map.ResetBuffer();
            Project.map.Update();
        }

        /// <summary>
        /// Must be a "line" type shapefile for roads.
        /// </summary>
        /// <param name="thePath"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public override Boolean openFile(string thePath = "", string type = "line")
        {
            if (type == "") { type = "line"; }
            if (type != "line") { throw new Exception("Roads module requires a line-type shp file"); }

            #region Additional module settings
            ModuleSettings.Add(new ProjectSetting(name: "road_zoom", module: ModuleName, value: "true", display_weight: 13,
                    display_text: "Zoom to Selection?", display_type: "bool",
                    description: "Fit map to selected roads."));
            ModuleSettings.Add(new ProjectSetting(name: "road_colors", module: ModuleName, value: "true", display_weight: 12,
                    display_text: "Use Colors?", display_type: "bool",
                    description: "Color the streets based on observed RSL."));
            ModuleSettings.Add(new ProjectSetting(name: "road_labels", module: ModuleName, value: "true", display_weight: 11,
                    display_text: "Show Labels?", display_type: "bool",
                    description: "Showing street labels (names) may slow down the display."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_rsl", module: ModuleName, value: "true",
                    display_text: "SHP Field for 'Observed RSL'", display_type: "field", display_weight: 10,
                    description: "Field in the SHP file RSL."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_type", module: ModuleName, value: "true",
                    display_text: "SHP Field for 'Functional Classification'", display_type: "field", display_weight: 9,
                    description: "Field in the SHP file for functional classification."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_width", module: ModuleName, value: "",
                    display_text: "SHP Field for 'Width' (ft)", display_type: "field", display_weight: 8,
                    description: "Field in the SHP file for the road width."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_length", module: ModuleName, value: "",
                    display_text: "SHP Field for 'Length' (ft)", display_type: "field", display_weight: 7,
                    description: "Field in the SHP file for segment length."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_speedlimit", module: ModuleName, value: "",
                    display_text: "SHP Field for 'Speed Limit'", display_type: "field", display_weight: 6,
                    description: "Field in the SHP file for speed limit."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_endaddr", module: ModuleName, value: "",
                    display_text: "SHP Field for 'To Address Number'", display_type: "field", display_weight: 5,
                    description: "Field in the SHP file for to address number."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_startaddr", module: ModuleName, value: "",
                    display_text: "SHP Field for 'From Address Number'", display_type: "field", display_weight: 4,
                    description: "Field in the SHP file for from address number."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_surfacetype", module: ModuleName, value: "",
                    display_text: "SHP Field for 'Road Surface'", display_type: "field", display_weight: 3,
                    description: "Field in the SHP file for the pavement used by the road, e.g. asphalt."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_streetname", module: ModuleName, value: "",
                    display_text: "SHP Field for 'Road Name'", display_type: "field", display_weight: 2,
                    description: "Field in the SHP file for the street name.  e.g. 100 South, Main, Oak Ave."));
            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_f_TAMSID", module: ModuleName, value: "",
                    display_text: "SHP Field with a 'Unique Identifier' (TAMSID)",
                    display_type: "field", display_weight: 1, required: true));
            #endregion
            injectSettings();

            if (!base.openFile(thePath, type)) { return false; }
            Project.map.Layers.Move(Layer, 0);

            ControlsPage.Controls.Remove(ControlsPage.Controls["ROADADD"]);
            Panel_Road roadPanel = new Panel_Road(project);
            roadPanel.Name = "ROADCONTROLS";
            roadPanel.Dock = DockStyle.Fill;
            ControlsPage.Controls.Add(roadPanel);

            #region eventhandlers
            //roadPanel.KeyDown += new KeyEventHandler(checkHotKey);
            roadPanel.buttonSave.Click += saveHandler;
            roadPanel.buttonReset.Click += cancelChanges;
            roadPanel.pictureBoxPhoto.Click += clickPhotoBox;
            roadPanel.toolStripButtonAnalysis.Click += reports.reportSelected;
            roadPanel.toolStripButtonSidewalk.Click += setSideWalkInfo;

            roadPanel.btnNotes.Click += editNotes;
            roadPanel.buttonSuggest.Click += automaticTreatmentSuggestion;

            roadPanel.comboBoxSurface.SelectionChangeCommitted += surfaceChanged;
            //roadPanel.setChangedHandler(controlChanged);

            roadPanel.distress1.ValueChanged += distressChanged;
            roadPanel.distress2.ValueChanged += distressChanged;
            roadPanel.distress3.ValueChanged += distressChanged;
            roadPanel.distress4.ValueChanged += distressChanged;
            roadPanel.distress5.ValueChanged += distressChanged;
            roadPanel.distress6.ValueChanged += distressChanged;
            roadPanel.distress7.ValueChanged += distressChanged;
            roadPanel.distress8.ValueChanged += distressChanged;
            roadPanel.distress9.ValueChanged += distressChanged;

            roadPanel.buttonHistory.Click += reports.showHistory;
            roadPanel.setOtherDateToolStripMenuItem.Click += selectRecordDate;
            roadPanel.setTodayToolStripMenuItem.Click += resetRecordDate;
            dateForm.FormClosing += updateSurveyDate;
            #endregion eventhandlers

            #region road controls settings
            surfaceTypes = Database.GetDataByQuery(Project.conn, "SELECT * FROM road_surfaces");
            roadPanel.comboBoxSurface.Items.Add("");
            foreach (DataRow row in surfaceTypes.Rows)
            {
                roadPanel.comboBoxSurface.Items.Add(Util.UppercaseFirst(row["name"].ToString()));
            }

            surfaceDistresses = Database.GetDataByQuery(Project.conn, "SELECT rd.*, rs.name AS surface FROM road_distresses AS rd JOIN road_surfaces AS rs ON rd.surface_id = rs.id ORDER BY rd.id");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = surfaceDistresses.Columns["id"];
            surfaceDistresses.PrimaryKey = keys;

            roadPanel.comboBoxType.Items.Add("");
            roadPanel.comboBoxType.Items.Add("Major Arterial");
            roadPanel.comboBoxType.Items.Add("Minor Arterial");
            roadPanel.comboBoxType.Items.Add("Major Collector");
            roadPanel.comboBoxType.Items.Add("Minor Collector");
            roadPanel.comboBoxType.Items.Add("Residential");
            roadPanel.comboBoxType.Items.Add("Other");
            #endregion

            symbols.applyColorizedProperties();
            symbols.setSymbolizer();
            disableRoadDisplay();
            resetRoadDisplay();
            resetSaveCondition();
            return true;
        }

        //private void checkHotKey(object sender, KeyEventArgs e)
        //{
        //    Console.WriteLine("Event fired!");
        //    if (e.KeyCode == Keys.S) saveHandler(sender, e);
        //}

        private void setSideWalkInfo(object sender, EventArgs e)
        {
            RoadSidewalkForm rsf = new RoadSidewalkForm(Util.ToInt(tamsids[0]));
            rsf.prePopField(Project);
            rsf.setSidewalkData(Project);
        }

        /// <summary>
        /// When map selection changes, set enabled controls, update display, etc
        /// @TO-DO determine if this layer is active layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void selectionChanged()
        {
            if (!isOpen()) return;
            
            if (UnsavedChanges)
            {
                DialogResult rslt = MessageBox.Show("Unsaved changes detected! Would you like to save the changes? Otherwise, they will be discared",
                    "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (rslt == DialogResult.Yes) saveHandler(null, null);
                if (rslt == DialogResult.Cancel) return;
            }
            resetRoadDisplay();

            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            ISelection shpSelection = selectionLayer.Selection;
            selectionCount = shpSelection.Count;
            if (selectionCount <= 0)
            {
                disableRoadDisplay();
                return;
            }

            if (Project.settings.GetValue("road_zoom") == "true")
            {
                selectionLayer.ZoomToSelectedFeatures();
                Project.map.ZoomOut();
                Project.map.Refresh();
            }

            bool mulitple = false;
            if (selectionCount > 1) mulitple = true;

            enableControls(mulitple);

            //Note: Pulls data from most recent survey_date, not highest id.
            Dictionary<string, string> values = setSegmentValues(selectionLayer.Selection.ToFeatureSet().DataTable);

            updateRoadDisplay(values);

            if (values.ContainsKey("TAMSID") && !string.IsNullOrWhiteSpace(values["TAMSID"]))
            {
                IdText = values["TAMSID"];
            } else
            {
                IdText = "";
            }

            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");
            tamsids = new List<string>();
            foreach (DataRow row in selectionLayer.Selection.ToFeatureSet().DataTable.Rows)
            {
                tamsids.Add(row[tamsidcolumn].ToString());
            }

            getRoadControls().setChangedHandler(controlChanged);
        }

        private void cancelChanges(object sender, EventArgs e)
        {
            resetSaveCondition();
            selectionChanged();
        }

        // returns the ROADCONTROLS collection of controls.
        // does not include the toolstrip
        public Panel_Road getRoadControls()
        {
            Panel_Road controls;

            try
            {
                controls = (Panel_Road)ControlsPage.Controls["ROADCONTROLS"];
            }
            catch (Exception e)
            {
                Log.Error("Could not retrieve controls page.\n" + e.ToString());
                throw new Exception("Could not retrieve controls page.\n" + e.ToString());
            }
            return controls;
        }


        // Sets the values of the various controls
        private void updateRoadDisplay(Dictionary<string, string> values)
        {
            Panel_Road roadControls = getRoadControls();

            roadControls.textBoxRoadName.Text = Util.DictionaryItemString(values, "name");
            roadControls.labelSurveyDate.Text = "As of " + Util.DictionaryItemString(values, "survey_date");
            try
            {
                roadControls.numericUpDownSpeedLimit.Value = Util.ToInt(Util.DictionaryItemString(values, "speed_limit"));
            }
            catch
            {
                MessageBox.Show("The 'speed limit' value for this selection is corrupted. Enter the correct speed limit to fix this, or change the shape field assigned to speed limit under settings",
                    "Warning! Corrupt Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);    
            }
            try
            {
                roadControls.numericUpDownLanes.Value = Util.ToInt(Util.DictionaryItemString(values, "lanes"));
            }
            catch
            {
                MessageBox.Show("The 'lanes' value for this selection is corrupted. Enter the correct number of lanes to fix this.",
                    "Warning! Corrupt Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            roadControls.textBoxFrom.Text = Util.DictionaryItemString(values, "from_address");
            roadControls.textBoxTo.Text = Util.DictionaryItemString(values, "to_address");
            roadControls.textBoxWidth.Text = Util.DictionaryItemString(values, "width");
            roadControls.textBoxLength.Text = Util.DictionaryItemString(values, "length");

            roadControls.comboBoxType.Text = Util.DictionaryItemString(values, "type");
            previousSurface = roadControls.comboBoxSurface.Text = Util.DictionaryItemString(values, "surface");
            roadControls.textBoxPhotoFile.Text = Util.DictionaryItemString(values, "photo");
            roadControls.toolTip.SetToolTip(roadControls.pictureBoxPhoto, "");
            updatePhotoPreview(roadControls.pictureBoxPhoto, roadControls.textBoxPhotoFile.Text);

            // distress controls
            if (string.IsNullOrWhiteSpace(roadControls.comboBoxSurface.Text))
            {
                roadControls.groupBoxDistress.Enabled = false;
            } else {
                roadControls.groupBoxDistress.Enabled = true;
                // Update the visible distresses based on surface type
                updateDistressControls(roadControls.comboBoxSurface.Text.ToLower());
            }
            roadControls.distress1.Value = Util.DictionaryItemInt(values, "distress1");
            roadControls.distress2.Value = Util.DictionaryItemInt(values, "distress2");
            roadControls.distress3.Value = Util.DictionaryItemInt(values, "distress3");
            roadControls.distress4.Value = Util.DictionaryItemInt(values, "distress4");
            roadControls.distress5.Value = Util.DictionaryItemInt(values, "distress5");
            roadControls.distress6.Value = Util.DictionaryItemInt(values, "distress6");
            roadControls.distress7.Value = Util.DictionaryItemInt(values, "distress7");
            roadControls.distress8.Value = Util.DictionaryItemInt(values, "distress8");
            roadControls.distress9.Value = Util.DictionaryItemInt(values, "distress9");
            roadControls.comboBoxTreatment.Text = Util.DictionaryItemString(values, "suggested_treatment");
            // we're taking RSL from DB to later allow manual entry
            roadControls.inputRsl.Text = Util.DictionaryItemString(values, "rsl");

            notes = Util.DictionaryItemString(values, "notes");
            if (!string.IsNullOrEmpty(notes))
            {
                roadControls.btnNotes.Checked = true;
            }

            resetSaveCondition();
        }
        
        // Set everything as though no changes have been made
        private void resetSaveCondition()
        {
            UnsavedChanges = false;
            Panel_Road roadControls = getRoadControls();

            // resets the save button since we've just reset the values
            roadControls.buttonSave.Enabled = false;
            roadControls.buttonSave.BackColor = default(Color);
        }


        // sets the various distress controls based on the surface
        private void updateDistressControls(string surface)
        {
            Panel_Road roadControls = getRoadControls();

            // hide all controls
            foreach (Control control in roadControls.groupBoxDistress.Controls)
            {
                control.Enabled = false;
                control.Hide();
            }
            roadControls.comboBoxTreatment.Enabled = false;
            roadControls.comboBoxTreatment.Visible = false;
            if (surface == "") { return; }

            roadControls.groupBoxDistress.Enabled = true;
            roadControls.inputRsl.Visible = true;
            roadControls.inputRsl.Enabled = true;
            roadControls.buttonSuggest.Visible = true;
            roadControls.buttonSuggest.Enabled = true;
            roadControls.comboBoxTreatment.Visible = true;
            roadControls.labelSuggestedTreatment.Visible = true;
            roadControls.labelSuggestedTreatment.Enabled = true;
            roadControls.comboBoxTreatment.Enabled = true;

            foreach (DataRow row in surfaceDistresses.Rows)
            {
                if (row["surface"].ToString() == surface)
                {
                    try
                    {
                        string dbkey = row["dbkey"].ToString();
                        DistressEntry thisEntry = (DistressEntry)roadControls.groupBoxDistress.Controls[dbkey];
                        thisEntry.Label = row["name"].ToString();
                        thisEntry.MaxDistress = Convert.ToInt16(row["max_distress"]);
                        thisEntry.IllustrationName = row["imageName"].ToString();
                        thisEntry.Description = row["description"].ToString();
                        thisEntry.Show();
                        thisEntry.Value = -1;
                        thisEntry.DataId = Convert.ToInt16(row["id"]);
                        thisEntry.Enabled = true;
                    }
                    catch
                    {

                    }
                }
            }

            //var treatments = Database.GetDataByQuery(Project.conn, "SELECT id, name FROM treatments WHERE road_applied='" + surface + "';");
            //DataRow blankSurfaceRow = treatments.NewRow();      //
            //blankSurfaceRow["id"] = 0;                          // add empty row
            //blankSurfaceRow["name"] = "";                       //
            //treatments.Rows.InsertAt(blankSurfaceRow, 0);       //
            //roadControls.comboBoxTreatment.DataSource = treatments;    //
            //roadControls.comboBoxTreatment.DisplayMember = "name";     // sets options
            //roadControls.comboBoxTreatment.ValueMember = "id";         //
            
        }


        // clears the road module controls
        private void resetRoadDisplay()
        {
            Panel_Road roadControls = getRoadControls();

            roadControls.textBoxRoadName.Text = "";
            roadControls.labelSurveyDate.Text = "";
            roadControls.numericUpDownSpeedLimit.Value = 0;
            roadControls.numericUpDownLanes.Value = 0;
            roadControls.textBoxFrom.Text = "";
            roadControls.textBoxTo.Text = "";
            roadControls.textBoxWidth.Text = "";
            roadControls.textBoxLength.Text = "";
            roadControls.textBoxArea.Text = "";
            roadControls.comboBoxType.Text = "";
            roadControls.comboBoxSurface.Text = "";
            roadControls.textBoxPhotoFile.Text = "";
            roadControls.pictureBoxPhoto.Image = null;
            roadControls.distress1.Value = -1;
            roadControls.distress2.Value = -1;
            roadControls.distress3.Value = -1;
            roadControls.distress4.Value = -1;
            roadControls.distress5.Value = -1;
            roadControls.distress6.Value = -1;
            roadControls.distress7.Value = -1;
            roadControls.distress8.Value = -1;
            roadControls.distress9.Value = -1;
            roadControls.comboBoxTreatment.Text = "";
            roadControls.inputRsl.Text = "";
            roadControls.btnNotes.Checked = false;

            roadControls.labelName.ForeColor = default(Color);
            roadControls.labelName.BackColor = default(Color);
            roadControls.textBoxRoadName.Enabled = true;
            roadControls.labelSurveyDate.Visible = true;
            roadControls.labelName.Text = "Road";
        }


        // disables controls of the road panel
        private void disableRoadDisplay()
        {
            Panel_Road roadControls = getRoadControls();
            resetSaveCondition();
            roadControls.setChangedHandler(null);
            roadControls.groupBoxInfo.Enabled = false;
            roadControls.groupBoxDistress.Enabled = false;
            roadControls.toolStrip.Enabled = false;
        }


        // enables controls for when at least 1 segment is selected
        // some controls depend on whether we've selected multiple items, so optional parameter
        private void enableControls(bool multiple)
        {
            Panel_Road roadControls = getRoadControls();

            if (multiple)
            {
                roadControls.textBoxPhotoFile.Enabled = false;
                roadControls.buttonNextPhoto.Enabled = false;
                roadControls.labelName.ForeColor = SystemColors.HighlightText;
                roadControls.labelName.BackColor = SystemColors.Highlight;
                roadControls.labelName.Text = "Multiple";
                roadControls.textBoxRoadName.Enabled = false;
                roadControls.textBoxRoadName.Text = "";
                roadControls.labelSurveyDate.Visible = false;
            }
            else
            {
                roadControls.textBoxPhotoFile.Enabled = true;
                roadControls.buttonNextPhoto.Enabled = true;
            }

            roadControls.groupBoxInfo.Enabled = true;
            roadControls.groupBoxDistress.Enabled = true;
            roadControls.toolStrip.Enabled = true;
            bool hasSWModule = false;
            for (int i = 0; i < Project.map.Layers.Count; i++)
            {
                if (((FeatureLayer)Project.map.Layers[i]).Name == "miscellaneous") {
                    hasSWModule = true;
                }
            }
            roadControls.toolStripButtonSidewalk.Visible = hasSWModule;
            roadControls.toolStripButtonSidewalk.Enabled = hasSWModule && selectionValues != null && selectionValues.Count == 1;
        }

        // handler for changed controls
        protected override void controlChanged(object sender, EventArgs e)
        {
            if (selectionCount <= 0) return;
            Panel_Road roadControls = getRoadControls();

            roadControls.buttonSave.Enabled = true;
            roadControls.buttonSave.BackColor = Color.Red;
            UnsavedChanges = true;

            roadControls.buttonHistory.Enabled = true;
            roadControls.buttonReset.Enabled = true;
            roadControls.setChangedHandler(null);
        }


        /// <summary>
        /// Event called to save the data as entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void saveHandler(object sender, EventArgs e)
        {
            Panel_Road roadControls = getRoadControls();
            if (!roadControls.buttonSave.Enabled) return;
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            ISelection shpSelection = selectionLayer.Selection;
            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");

            Dictionary<string, string> values = new Dictionary<string, string>();

            string[] dateFormat = surveyDate.GetDateTimeFormats();
            values["survey_date"] = dateFormat[46];
            values["name"] = roadControls.textBoxRoadName.Text;
            values["speed_limit"] = roadControls.numericUpDownSpeedLimit.Value != 0 ? roadControls.numericUpDownSpeedLimit.Value.ToString() : "";
            values["lanes"] = roadControls.numericUpDownLanes.Value != 0 ? roadControls.numericUpDownLanes.Value.ToString() : "";
            values["width"] = roadControls.textBoxWidth.Text;
            values["length"] = roadControls.textBoxLength.Text;
            values["from_address"] = roadControls.textBoxFrom.Text;
            values["to_address"] = roadControls.textBoxTo.Text;
            values["surface"] = roadControls.comboBoxSurface.Text.ToLower();
            values["photo"] = roadControls.textBoxPhotoFile.Text;

            foreach (string value in values.Values)
            {
                if (string.IsNullOrEmpty(value))
                {
                    MessageBox.Show("Some properties have not been set for this road. The analysis and report may be incomplete as a result.", "Warning: Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            values["notes"] = notes;
            values["type"] = roadControls.comboBoxType.Text;

            if (!string.IsNullOrWhiteSpace(roadControls.textBoxPhotoFile.Text))
            {
                Properties.Settings.Default.lastPhoto = roadControls.textBoxPhotoFile.Text;
            }
            //  Asphalt         Unpaved         Concrete
            if (roadControls.distress1.Visible) { values["distress1"] = roadControls.distress1.Value.ToString(); }   //  Fatigue         Potholes       Spalling
            if (roadControls.distress2.Visible) { values["distress2"] = roadControls.distress2.Value.ToString(); }   //  Edge            Rutting        Joint Seals
            if (roadControls.distress3.Visible) { values["distress3"] = roadControls.distress3.Value.ToString(); }   //  Longitudional   X-section      Corners
            if (roadControls.distress4.Visible) { values["distress4"] = roadControls.distress4.Value.ToString(); }   //  Patches         Drainage       Broken
            if (roadControls.distress5.Visible) { values["distress5"] = roadControls.distress5.Value.ToString(); }   //  PotHoles        Dust           Faulting
            if (roadControls.distress6.Visible) { values["distress6"] = roadControls.distress6.Value.ToString(); }   //  Drainage        Aggregate      Longitudinal
            if (roadControls.distress7.Visible) { values["distress7"] = roadControls.distress7.Value.ToString(); }   //  Transverse      Corrugation    Transverse
            if (roadControls.distress8.Visible) { values["distress8"] = roadControls.distress8.Value.ToString(); }   //  Block                          Cracking
            if (roadControls.distress9.Visible) { values["distress9"] = roadControls.distress9.Value.ToString(); }   //  Rutting                        Patches

            //if (roadControls.comboBoxTreatment.Visible) { values["suggested_treatment"] = roadControls.comboBoxTreatment.Text; }

            if (!string.IsNullOrWhiteSpace(roadControls.inputRsl.Text) || !string.IsNullOrWhiteSpace(roadControls.comboBoxTreatment.Text)) {
                values["rsl"] = roadControls.inputRsl.Text;
                values["suggested_treatment"] = roadControls.comboBoxTreatment.Text;

                string tamsidsCSV = string.Join(",", tamsids.ToArray());
                foreach (DataRow row in selectionLayer.DataSet.DataTable.Select(tamsidcolumn + " IN (" + tamsidsCSV + ")"))
                {
                    row["TAMSROADRSL"] = values["rsl"];
                    row["TAMSTREATMENT"] = values["suggested_treatment"];
                }
            }

            for (int i = 0; i < tamsids.Count; i++)
            {
                values["TAMSID"] = tamsids[i];
                Dictionary<string, string> v = new Dictionary<string, string>();

                foreach (string key in values.Keys)
                {
                    v[key] = values[key];
                    if ((string.IsNullOrWhiteSpace(values[key]) || values[key].Contains("multi") || values[key].Contains("-1")) && selectionValues.Count > 1)
                    {
                        if (i < selectionValues.Count && selectionValues[i].ContainsKey(key))
                        {
                            v[key] = selectionValues[i][key];
                        }
                    }
                }

                if (!Database.InsertRow(Project.conn, v, ModuleName))
                {
                    MessageBox.Show("Could not save data!");
                }
            }
            resetSaveCondition();
            resetRoadDisplay();
            disableRoadDisplay();
            Properties.Settings.Default.Save();
            selectionLayer.ClearSelection();
            symbols.setSymbolizer();
            Project.map.Invalidate();
            Project.map.Refresh();
            Project.map.ResetBuffer();
            Project.map.Update();
        }


        /// <summary>
        /// Changes the display of the road controls to reflect the currently selected road.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void surfaceChanged(object sender, EventArgs e)
        {
            Panel_Road roadControls = getRoadControls();

            if (roadControls.distress1.Value > -1 ||
                roadControls.distress2.Value > -1 ||
                roadControls.distress3.Value > -1 ||
                roadControls.distress4.Value > -1 ||
                roadControls.distress5.Value > -1 ||
                roadControls.distress6.Value > -1 ||
                roadControls.distress7.Value > -1 ||
                roadControls.distress8.Value > -1 ||
                roadControls.distress9.Value > -1 ||
                roadControls.labelName.Text == "Multiple"
                )
            {
                DialogResult result = MessageBox.Show("Changing road surface will delete all distress data for the selected roads. Are you sure you want to do this?" +
                "\n\n(Note: Changes are not permanent until saved)", "Warning: Changing Road Surface", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    roadControls.comboBoxSurface.Text = previousSurface;
                    return;
                }
            }

            updateDistressControls(roadControls.comboBoxSurface.Text.ToLower());

        }


        /// <summary>
        /// Changes controls to reflect a change made to a distress control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void distressChanged(object sender, CustomEventArgs e)
        {
            Panel_Road roadControls = getRoadControls();
            controlChanged(sender, e);
            if (roadControls.comboBoxSurface.Text != "")
            {
                roadControls.inputRsl.Text = calcRsl().ToString();
            }
        }


        // calculates RSL from values in the (enabled) distress controls
        private int calcRsl()
        {
            Panel_Road roadControls = getRoadControls();
            List<DistressEntry> distresses = new List<DistressEntry>()
            {   roadControls.distress1, roadControls.distress2, roadControls.distress3,
                roadControls.distress4, roadControls.distress5, roadControls.distress6,
                roadControls.distress7, roadControls.distress8, roadControls.distress9
            };

            bool RoadNotSurveyed = true;
            int minrsl = 20; // TODO: get actual minimum from from road surface

            foreach (DistressEntry entry in distresses)
            {
                if (entry.Enabled && entry.Value > 0)       // if = 0, then we don't look it up as it's whatever the default RSL is 
                {
                    RoadNotSurveyed = false;
                    try
                    {
                        string column = "rsl" + entry.Value.ToString();
                        int thisRsl = Convert.ToInt16(surfaceDistresses.Rows.Find(entry.DataId)[column]);

                        if (thisRsl < minrsl)
                        {
                            minrsl = thisRsl;
                        }
                        roadControls.toolTip.SetToolTip(entry, "RSL: " + thisRsl.ToString());
                    }
                    catch
                    {
                        roadControls.toolTip.SetToolTip(entry, "No change to RSL.");

                        // Not all distresses have an RSL value.
                        string distress = entry.Value.ToString();
                        string dbkey = entry.DataId.ToString();
                        string distressName = entry.Name.ToString();
                        string message = "Couldn't find entry #" + distress + " for " + distressName + " (id:" + dbkey + ")";

                    }
                }
                else if (entry.Enabled && entry.Value == 0)
                {
                    RoadNotSurveyed = false;
                }
                else
                {
                    roadControls.toolTip.SetToolTip(entry, "");
                }
            }
            if (RoadNotSurveyed)
            {
                return -1;
            }
            return minrsl;
        }

        /// <summary>
        /// Displays the form for adding notes about the road to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editNotes(object sender, EventArgs e)
        {
            FormNotes noteForm = new FormNotes();
            noteForm.Value = notes;
            DialogResult result = noteForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                Panel_Road roadControls = getRoadControls();
                roadControls.btnNotes.Checked = true;
                controlChanged(sender, e);

                notes = noteForm.Value;
            }
            noteForm.Close();
        }

        protected void selectRecordDate(object sender, EventArgs e)
        {
            dateForm.Show();
            Panel_Road roadControls = getRoadControls();
            roadControls.setTodayToolStripMenuItem.Checked = false;
            roadControls.setOtherDateToolStripMenuItem.Checked = true;
        }

        private void updateSurveyDate(object sender, EventArgs e)
        {
            Panel_Road roadControls = getRoadControls();
            surveyDate = dateForm.getDate();
            string[] dateFormats = surveyDate.GetDateTimeFormats();
            roadControls.labelSurveyDate.Text = "As of " + dateFormats[58];
            controlChanged(sender, e);
        }

        protected void resetRecordDate(object sender, EventArgs e)
        {
            surveyDate = DateTime.Now;
            Panel_Road roadControls = getRoadControls();
            string[] dateFormats = surveyDate.GetDateTimeFormats();
            roadControls.labelSurveyDate.Text = "As of " + dateFormats[58];
            roadControls.setTodayToolStripMenuItem.Checked = true;
            roadControls.setOtherDateToolStripMenuItem.Checked = false;
        }

        private void clickPhotoBox(object sender, EventArgs e)
        { 
            Panel_Road roadControls = getRoadControls();
            string subPath = Database.GetDataByQuery(Project.conn, "SELECT road_photos FROM photo_paths;").Rows[0][0].ToString();
            enlargePicture(roadControls.textBoxPhotoFile.Text, subPath);
        }

        private void automaticTreatmentSuggestion(object sender, EventArgs e)
        {
            Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>()
            {
                { "asphalt", new Dictionary<string, int>() { { "Fatigue", 1 }, { "Edge Cracks", 2 }, { "Longitudinal", 3 }, {"Patches", 4 }, { "Potholes", 5 }, { "Drainage", 6 }, { "Transverse", 7 }, { "Blocking", 8 }, { "Rutting", 9 } } },
                { "gravel", new Dictionary<string, int>() { { "Potholes", 1 }, { "Rutting", 2 }, { "X-section", 3 }, {"Drainage", 4 }, { "Dust", 5 }, { "Aggregate", 6 }, { "Corrugation", 7 } } },
                { "concrete", new Dictionary<string, int>() { { "Spalling", 1 }, { "Joint Seals", 2 }, { "Corners", 3 }, {"Breaks", 4 }, { "Faulting", 5 }, { "Longitudinal", 6 }, { "Transverse", 7 }, { "Map Cracks", 8 }, { "Patches", 9 } } }
            };
            var roadControls = getRoadControls();
            int[] dvs;
            if (roadControls.comboBoxSurface.Text.ToLower().Contains("gravel"))
            {
                dvs = new int[7] { roadControls.distress1.Value, roadControls.distress2.Value, roadControls.distress3.Value, roadControls.distress4.Value, roadControls.distress5.Value, roadControls.distress6.Value, roadControls.distress7.Value };
            }
            else
            {
                dvs = new int[9] { roadControls.distress1.Value, roadControls.distress2.Value, roadControls.distress3.Value, roadControls.distress4.Value, roadControls.distress5.Value, roadControls.distress6.Value, roadControls.distress7.Value, roadControls.distress8.Value, roadControls.distress9.Value };
            }
            string gd = getGoverningDistress(dvs, roadControls.comboBoxSurface.Text.ToLower());
            if (string.IsNullOrWhiteSpace(gd)) { return; }
            int index = data[roadControls.comboBoxSurface.Text.ToLower()][gd] - 1;
            DataTable suggestion = Database.GetDataByQuery(Project.conn, "SELECT treatment FROM auto_suggest WHERE governing_distress='" + gd + "' AND distress_value=" + dvs[index].ToString() + ";");
            if (suggestion.Rows.Count > 0)
            {
                roadControls.comboBoxTreatment.Text = suggestion.Rows[0]["treatment"].ToString();
            }
            else
            {
                roadControls.comboBoxTreatment.Text = "";
            }
        }



        public string getGoverningDistress(int[] distValues, string surfType)
        {
            string[] seld = distressAsphalt;
            int distID = 1;
            int maxRSL = 20;
            if (surfType.Contains("asphalt"))
            {
                distID = 1;
                maxRSL = 20;
                seld = distressAsphalt;
            }
            else if (surfType.Contains("gravel"))
            {
                distID = 2;
                maxRSL = 10;
                seld = distressGravel;
            }
            else if (surfType.Contains("concrete"))
            {
                distID = 3;
                maxRSL = 20;
                seld = distressConcrete;
            }
            DataTable distresses = Database.GetDataByQuery(Project.conn, "SELECT * FROM road_distresses WHERE surface_id = " + distID.ToString());
            string gd = "";
            for (int i = 1; i <= distresses.Rows.Count; i++)
            {;
                if (distValues[i - 1] <= 0)
                {
                    continue;
                }
                int rsl = Util.ToInt(distresses.Rows[i - 1]["rsl" + distValues[i - 1]].ToString());
                if (rsl < maxRSL)
                {
                    maxRSL = rsl;
                    gd = seld[i - 1];
                }
            }
            return gd;
        }

        protected void openBudgetTool(object sender, EventArgs e)
        {
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            string roadSQL = getSelectAllSQL();
            string treatmentSQL = "SELECT * FROM treatments";
            DataTable roads = Database.GetDataByQuery(Project.conn, roadSQL);
            DataTable treatments = Database.GetDataByQuery(Project.conn, treatmentSQL);
            roads.DefaultView.Sort = "rsl asc";
            treatments.DefaultView.Sort = "id asc";
            FormAnalysis analysis = new FormAnalysis(Project, this);
            //if (analysis.setData(roads.DefaultView.ToTable(), treatments.DefaultView.ToTable()))
            //{
            analysis.ShowDialog();
            //}
            //else
            //{
            //    analysis.Close();
            //}

        }

        protected void toggleColors(object sender, EventArgs e)
        {
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            bool reselect = false;
            string id = "1";
            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");
            if (selectionLayer.Selection.Count > 0)
            {
                reselect = true;
                id = selectionLayer.Selection.ToFeatureSet().DataTable.Rows[0][tamsidcolumn].ToString();
            }
            colorsOn = colorsOn ? false : true;
            setSymbolizer();
            if (reselect)
            {
                selectionLayer.SelectByAttribute(tamsidcolumn + " = " + id);
            }
        }

        protected override void clearControlPanel()
        {
            ControlsPage.Controls.Remove(ControlsPage.Controls["ROADCONTROLS"]);
            Panel_Module_OpenShp roadAdd = new Panel_Module_OpenShp("Road");
            roadAdd.Name = "ROADADD";
            roadAdd.SetHandler(new EventHandler(openFileHandler));
            roadAdd.Dock = DockStyle.Fill;
            ControlsPage.Controls.Add(roadAdd);
        }

        public string getSelectAllSQL()
        {
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            selectionLayer.SelectAll();
            ISelection shpSelection = selectionLayer.Selection;
            DataTable selectionTable = shpSelection.ToFeatureSet().DataTable;
            string thisSql = SelectionSql.Replace("[[IDLIST]]", extractTAMSIDs(selectionTable));
            selectionLayer.ClearSelection();
            return thisSql;
        }        
    }

    internal class ChooseRoadForm
    {
        private FormCustomMessage roadChooser;
        private RadioButton asphalt;
        private RadioButton gravel;
        private RadioButton concrete;
        private RadioButton[] buttons;

        public ChooseRoadForm(string title, string text)
        {
            roadChooser = new FormCustomMessage();
            roadChooser.Text = title;
            roadChooser.labelMessage.Text = text;
            asphalt = new RadioButton();
            asphalt.Text = "Asphalt";
            asphalt.Location = new Point(240, 40);
            gravel = new RadioButton();
            gravel.Text = "Gravel";
            gravel.Location = new Point(240, 64);
            concrete = new RadioButton();
            concrete.Text = "Concrete";
            concrete.Location = new Point(240, 90);
            roadChooser.groupBoxUser.Controls.Add(asphalt);
            roadChooser.groupBoxUser.Controls.Add(gravel);
            roadChooser.groupBoxUser.Controls.Add(concrete);
            RadioButton[] b = { asphalt, gravel, concrete};
            buttons = b;
            asphalt.Checked = true;
        }

        public string chooseRoad()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    return buttons[i].Text;
                }
            }
            return "";
        }

        public DialogResult ShowDialog()
        {
            return roadChooser.ShowDialog();
        }
    }
}
