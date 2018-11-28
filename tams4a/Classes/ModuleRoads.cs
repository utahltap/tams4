using DotSpatial.Symbology;
using DotSpatial.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using tams4a.Controls;
using tams4a.Forms;

namespace tams4a.Classes
{
    public class ModuleRoads : ProjectModule
    {
        public new const string moduleVersion = "4.0.1.1";    // string that can be converted to System.Version
        public string roadColors = "RSL";
        public Color labelColor = Color.Black;
        private string[] distressAsphalt = { "Fatigue", "Edge Cracks", "Longitudinal", "Patches", "Potholes", "Drainage", "Transverse", "Blocking", "Rutting" };
        private string[] distressGravel = { "Potholes", "Rutting", "X-section", "Drainage", "Dust", "Aggregate", "Corrugation" };
        private string[] distressConcrete = { "Spalling", "Joint Seals", "Corners", "Breaks", "Faulting", "Longitudinal", "Transverse", "Map Cracks", "Patches" };

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

            boundButtons[1].Click += generalReport;
            boundButtons[2].Click += potholeReport;
            boundButtons[3].Click += openBudgetTool;
            boundButtons[4].Click += customReport;

            boundButtons[6].Click += graphRoadType;
            boundButtons[7].Click += graphRoadCategory;
            boundButtons[8].Click += graphGoverningDistress;
            boundButtons[9].Click += graphRSL;
            
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
            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_f_TAMSID", module: ModuleName, value: "",
                    display_text: "SHP field with unique identifier.",
                    display_type: "field", required: true));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_streetname", module: ModuleName, value: "",
                    display_text: "SHP Field for road name", display_type: "field",
                    description: "Field in the SHP file for the street name.  e.g. 100 South, Main, Oak Ave."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_width", module: ModuleName, value: "",
                    display_text: "SHP Field for width (ft)", display_type: "field",
                    description: "Field in the SHP file for the road width."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_length", module: ModuleName, value: "",
                    display_text: "SHP Field for length (ft)", display_type: "field",
                    description: "Field in the SHP file for segment length."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_speedlimit", module: ModuleName, value: "",
                    display_text: "SHP Field for speed limit", display_type: "field",
                    description: "Field in the SHP file for speed limit."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_startaddr", module: ModuleName, value: "",
                    display_text: "SHP Field for starting address number", display_type: "field",
                    description: "Field in the SHP file for starting address number."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_endaddr", module: ModuleName, value: "",
                    display_text: "SHP Field for ending address number", display_type: "field",
                    description: "Field in the SHP file for ending address number."));
            ModuleSettings.Add(new ProjectSetting(name: "road_f_surfacetype", module: ModuleName, value: "",
                    display_text: "SHP Field for road surface", display_type: "field",
                    description: "Field in the SHP file for the pavement used by the road, e.g. asphalt."));
            ModuleSettings.Add(new ProjectSetting(name: "road_labels", module: ModuleName, value: "true",
                    display_text: "Show Labels?", display_type: "bool",
                    description: "Showing street labels (names) may slow down the display."));
            ModuleSettings.Add(new ProjectSetting(name: "road_colors", module: ModuleName, value: "true",
                    display_text: "Use Colors?", display_type: "bool",
                    description: "Color the streets based on observed RSL."));
            //ModuleSettings.Add(new ProjectSetting(name: "road_f_rsl", module: ModuleName, value: "true",
            //        display_text: "SHP Field that holds observed RSL", display_type: "field",
            //        description: "Field in the SHP file RSL."));

            #endregion
            injectSettings();

            if (!base.openFile(thePath, type)) { return false; }
            Project.map.Layers.Move(Layer, 0);

            ControlsPage.Controls.Remove(ControlsPage.Controls["ROADADD"]);
            Panel_Road roadPanel = new Panel_Road();
            roadPanel.Name = "ROADCONTROLS";
            roadPanel.Dock = DockStyle.Fill;
            ControlsPage.Controls.Add(roadPanel);

            #region eventhandlers
            roadPanel.buttonSave.Click += saveHandler;
            roadPanel.buttonReset.Click += cancelChanges;
            roadPanel.pictureBoxPhoto.Click += clickPhotoBox;
            roadPanel.toolStripButtonAnalysis.Click += reportSelected;
            roadPanel.toolStripButtonSidewalk.Click += setSideWalkInfo;

            roadPanel.btnNotes.Click += editNotes;
            roadPanel.buttonSuggest.Click += automaticTreatmentSuggestion;

            roadPanel.comboBoxSurface.SelectionChangeCommitted += surfaceChanged;
            roadPanel.setChangedHandler(controlChanged);

            roadPanel.distress1.ValueChanged += distressChanged;
            roadPanel.distress2.ValueChanged += distressChanged;
            roadPanel.distress3.ValueChanged += distressChanged;
            roadPanel.distress4.ValueChanged += distressChanged;
            roadPanel.distress5.ValueChanged += distressChanged;
            roadPanel.distress6.ValueChanged += distressChanged;
            roadPanel.distress7.ValueChanged += distressChanged;
            roadPanel.distress8.ValueChanged += distressChanged;
            roadPanel.distress9.ValueChanged += distressChanged;

            roadPanel.buttonHistory.Click += showHistory;
            roadPanel.setOtherDateToolStripMenuItem.Click += selectRecordDate;
            roadPanel.setTodayToolStripMenuItem.Click += resetRecordDate;
            dateForm = new FormSurveyDate();
            dateForm.Hide();
            dateForm.buttonConfirm.Click += setDate;

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

            applyColorizedProperties();
            setSymbolizer();
            disableRoadDisplay();
            resetRoadDisplay();
            resetSaveCondition();
            return true;
        }

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
            if (!isOpen()) { return; }

            if (UnsavedChanges)
            {
                DialogResult rslt = MessageBox.Show("Unsaved Changes Detected! Would you like to save the changes? Otherwise, they will be discared", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (rslt == DialogResult.Yes)
                {
                    saveHandler(null, null);
                    return;
                }
                if (rslt == DialogResult.Cancel) return;
            }
            resetRoadDisplay();

            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            ISelection shpSelection = selectionLayer.Selection;

            if (shpSelection.Count <= 0) {
                disableRoadDisplay();
                return;
            }

            enableControls();
            Dictionary<string, string> values = setSegmentValues(selectionLayer.Selection.ToFeatureSet().DataTable);

            updateRoadDisplay(values);

            if (values.ContainsKey("TAMSID") && !string.IsNullOrWhiteSpace(values["TAMSID"]))
            {
                IdText = values["TAMSID"];
            } else
            {
                IdText = "";
            }

            Panel_Road roadControls = getRoadControls();
            if (shpSelection.Count > 1)
            {
                roadControls.labelName.ForeColor = SystemColors.HighlightText;
                roadControls.labelName.BackColor = SystemColors.Highlight;
                roadControls.labelName.Text = "Multiple";
                roadControls.textBoxRoadName.Enabled = false;
                roadControls.textBoxRoadName.Text = "";
            }


            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");
            tamsids = new List<string>();
            foreach (DataRow row in selectionLayer.Selection.ToFeatureSet().DataTable.Rows)
            {
                tamsids.Add(row[tamsidcolumn].ToString());
            }
        }

        private void cancelChanges(object sender, EventArgs e)
        {
            resetSaveCondition();
            selectionChanged();
        }

        // returns the ROADCONTROLS collection of controls.
        // does not include the toolstrip
        private Panel_Road getRoadControls()
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
            roadControls.numericUpDownSpeedLimit.Value = Util.ToInt(Util.DictionaryItemString(values, "speed_limit"));
            roadControls.numericUpDownLanes.Value = Util.ToInt(Util.DictionaryItemString(values, "lanes"));
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

            //if (roadControls.distress1.Value > -1) roadControls.comboBoxSurface.Enabled = false;
            //else roadControls.comboBoxSurface.Enabled = true;
            //Console.WriteLine("##########################################");
            //Console.WriteLine(roadControls.distress1.Value.ToString());
            //Console.WriteLine("##########################################");


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
            roadControls.labelName.Text = "Road";
        }


        // disables controls of the road panel
        private void disableRoadDisplay()
        {
            Panel_Road roadControls = getRoadControls();
            resetSaveCondition();
            roadControls.groupBoxInfo.Enabled = false;
            roadControls.groupBoxDistress.Enabled = false;
            roadControls.toolStrip.Enabled = false;
        }


        // enables controls for when at least 1 segment is selected
        // some controls depend on whether we've selected multiple items, so optional parameter
        private void enableControls(Boolean multiple = false)
        {
            Panel_Road roadControls = getRoadControls();

            if (multiple)
            {
                roadControls.textBoxPhotoFile.Enabled = false;
                roadControls.buttonNextPhoto.Enabled = false;
            } else
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
            Panel_Road roadControls = getRoadControls();

            roadControls.buttonSave.Enabled = true;
            roadControls.buttonSave.BackColor = Color.Red;
            UnsavedChanges = true;

            roadControls.buttonHistory.Enabled = true;
            roadControls.buttonReset.Enabled = true;
        }


        /// <summary>
        /// Event called to save the data as entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveHandler(object sender, EventArgs e)
        {
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            ISelection shpSelection = selectionLayer.Selection;
            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");

            Panel_Road roadControls = getRoadControls();
            Dictionary<string, string> values = new Dictionary<string, string>();
            values["name"] = roadControls.textBoxRoadName.Text;
            values["survey_date"] = Util.SortableDate(surveyDate);
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

            if (roadControls.comboBoxTreatment.Visible) { values["suggested_treatment"] = roadControls.comboBoxTreatment.Text; }

            if (!string.IsNullOrWhiteSpace(roadControls.inputRsl.Text.ToString())) {
                values["rsl"] = roadControls.inputRsl.Text.ToString();

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

            Properties.Settings.Default.Save();

            selectionLayer.ClearSelection();
            setSymbolizer();
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
                roadControls.distress9.Value > -1
                )
            {

                DialogResult result = MessageBox.Show("Warning: Changing road surface will delete all distress data for the selected roads. Are you sure you want to do this?" +
                "\n \n (Note: Changes are not permanent until saved)", "Changing Road Surface", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
            if (roadControls.comboBoxSurface.Text != "")
            {
                roadControls.inputRsl.Text = calcRsl().ToString();

                // change save condition
                controlChanged(sender, e);
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

        protected void resetRecordDate(object sender, EventArgs e)
        {
            surveyDate = DateTime.Now;
            Panel_Road roadControls = getRoadControls();
            roadControls.setTodayToolStripMenuItem.Checked = true;
            roadControls.setOtherDateToolStripMenuItem.Checked = false;
        }

        /// <summary>
        /// Sets the data properties used to color surveyed roads on the map. Roads are colored based RSL
        /// </summary>
        private void applyColorizedProperties()
        {
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            UnsavedChanges = false;
            selectionLayer.SelectAll();
            ISelection shpSelection = selectionLayer.Selection;
            DataTable selectionTable = shpSelection.ToFeatureSet().DataTable;
            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");
            selectionTable.DefaultView.Sort = tamsidcolumn + " asc";
            selectionTable = selectionTable.DefaultView.ToTable();
            string[] symbols = { "TAMSROADRSL", "TAMSTREATMENT" };
            PrepareDatatable(selectionTable, symbols);
            string roadSQL = SelectionSql.Replace("[[IDLIST]]", extractTAMSIDs(selectionTable));
            DataTable tamsTable = Database.GetDataByQuery(Project.conn, roadSQL);
            tamsTable.DefaultView.Sort = "TAMSID asc";
            tamsTable = tamsTable.DefaultView.ToTable();
            for (int i = 0; i < selectionTable.Rows.Count; i++)
            {
                selectionTable.Rows[i]["TAMSROADRSL"] = i >= tamsTable.Rows.Count ? -1 : string.IsNullOrWhiteSpace(tamsTable.Rows[i]["rsl"].ToString()) ? -1 : Util.ToInt(tamsTable.Rows[i]["rsl"].ToString());
                selectionTable.Rows[i]["TAMSTREATMENT"] = i >= tamsTable.Rows.Count ? -1 : tamsTable.Rows[i]["suggested_treatment"];
            }
            selectionLayer.DataSet.DataTable = selectionTable;
        }

        new public void setSymbolizer()
        {
            double baseWidth = 20.0;
            double baseOutlineWidth = 10.0;
            double adjWidth = baseWidth;
            double adjOutlineWidth = baseOutlineWidth;

            LineScheme rdScheme = new LineScheme();

            LineSymbolizer catSelSym = new LineSymbolizer();
            catSelSym.ScaleMode = ScaleMode.Geographic;
            catSelSym.SetWidth(adjWidth);
            catSelSym.SetOutline(Color.Blue, adjOutlineWidth);
            catSelSym.SetFillColor(Color.White);
            
            LineSymbolizer symDef = new LineSymbolizer();
            symDef.ScaleMode = ScaleMode.Geographic;
            symDef.SetWidth(adjWidth);
            symDef.SetOutline(Color.Black, adjOutlineWidth);
            symDef.SetFillColor(Color.Gray);
            
            LineCategory catDef = new LineCategory();
            catDef.LegendText = "No RSL Info";

            catDef.SelectionSymbolizer = catSelSym;
            catDef.Symbolizer = symDef;
            rdScheme.AddCategory(catDef);



            int[] rslfloor = { 0, 1, 4, 7, 10, 13, 16, 19 };
            int[] rslceil = { 0, 3, 6, 9, 12, 15, 18, 20 };

            int[] r = new int[30];
            int[] g = new int[30];
            int[] b = new int[30];
            r[0] = 139; r[1] = 255; r[2] = 255; r[3] = 255; r[4] = 50; r[5] = 0; r[6] = 0; r[7] = 0;
            g[0] = 0; g[1] = 0; g[2] = 165; g[3] = 255; g[4] = 205; g[5] = 128; g[6] = 191; g[7] = 0;
            b[0] = 0; b[1] = 0; b[2] = 0; b[3] = 0; b[4] = 50; b[5] = 0; b[6] = 255; b[7] = 255;

            if (Project.settings.GetValue("road_colors").Contains("t"))
            {
                if (roadColors == "RSL")
                {
                    int j = 0;
                    for (int i = 0; i < 21; i++)
                    {
                        while (i > rslceil[j])
                        {
                            j++;
                        }
                        // create a category
                        LineCategory colorCat = new LineCategory();
                        colorCat.FilterExpression = "[TAMSROADRSL] = '" + i.ToString() + "'";

                        LineSymbolizer colorSym = new LineSymbolizer();
                        colorSym.ScaleMode = ScaleMode.Geographic;
                        colorSym.SetWidth(adjWidth);
                        colorSym.SetOutline(Color.DarkGray, adjOutlineWidth);
                        colorSym.SetFillColor(Color.FromArgb(r[j], g[j], b[j]));

                        colorCat.Symbolizer = colorSym;

                        // assign (default) selection symbolizer
                        colorCat.SelectionSymbolizer = catSelSym;

                        // done
                        rdScheme.AddCategory(colorCat);
                    }
                }

                if (roadColors == "Treatment")
                {
                    DataTable nameToTreatment = Database.GetDataByQuery(Project.conn, "SELECT name, category FROM treatments;");
                    string[] treatments = new string[30];
                    int j = 0;
                    foreach (DataRow row in nameToTreatment.Rows)
                    {
                        treatments[j] = row["name"].ToString();
                        if (row["category"].ToString() == "routine") r[j] = 0; g[j] = 0; b[j] = 255;
                        if (row["category"].ToString() == "patch") r[j] = 50; g[j] = 205; b[j] = 50;
                        if (row["category"].ToString() == "preventative") r[j] = 255; g[j] = 255; b[j] = 0;
                        if (row["category"].ToString() == "rehabilitation") r[j] = 255; g[j] = 0; b[j] = 0;
                        if (row["category"].ToString() == "reconstruction") r[j] = 139; g[j] = 0; b[j] = 0;
                        j++;
                    }
                    treatments[24] = "Routine"; r[24] = 0; g[24] = 0; b[24] = 255;
                    treatments[25] = "Patching"; r[25] = 50; g[25] = 205; b[25] = 50;
                    treatments[26] = "Preventative"; r[26] = 255; g[26] = 255; b[26] = 0;
                    treatments[27] = "Preventative with Patching"; r[27] = 255; g[27] = 165; b[27] = 0;
                    treatments[28] = "Rehabilitation"; r[28] = 255; g[28] = 0; b[28] = 0;
                    treatments[29] = "Reconstruction"; r[29] = 139; g[29] = 0; b[29] = 0;

                    for (int i = 0; i < treatments.Length; i++)
                    {
                        LineCategory colorCat = new LineCategory();
                        colorCat.FilterExpression = "[TAMSTREATMENT] = '" + treatments[i] + "'";

                        LineSymbolizer colorSym = new LineSymbolizer();
                        colorSym.ScaleMode = ScaleMode.Geographic;
                        colorSym.SetWidth(adjWidth);
                        colorSym.SetOutline(Color.DarkGray, adjOutlineWidth);
                        colorSym.SetFillColor(Color.FromArgb(r[i], g[i], b[i]));

                        colorCat.Symbolizer = colorSym;

                        // assign (default) selection symbolizer
                        colorCat.SelectionSymbolizer = catSelSym;

                        // done
                        rdScheme.AddCategory(colorCat);
                    }
                }
            }
            ((MapLineLayer)Layer).ShowLabels = false;

            FeatureLayer roadFeatures = Layer as FeatureLayer;
            
            if (!string.IsNullOrEmpty(Project.settings.GetValue("road_labels")))
            {
                roadFeatures.AddLabels("[" + Project.settings.GetValue(ModuleName + "_f_streetname") + "]",
                        new Font("Tahoma", (float)8.0), labelColor);
                roadFeatures.ShowLabels = Project.settings.GetValue("road_labels").Contains("true");
            }

            ((MapLineLayer)Layer).Symbology = rdScheme;
            ((MapLineLayer)Layer).ApplyScheme(rdScheme);
        }

        private void clickPhotoBox(object sender, EventArgs e)
        { 
            Panel_Road roadControls = getRoadControls();
            enlargePicture(roadControls.textBoxPhotoFile.Text);
        }

        public void showHistory(object sender, EventArgs e)
        {
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            ISelection shpSelection = selectionLayer.Selection;
            DataTable selectionTable = shpSelection.ToFeatureSet().DataTable;
            string histring = @"SELECT * FROM road WHERE TAMSID IN (" + extractTAMSIDs(selectionTable) + ") ORDER BY TAMSID ASC, survey_date DESC;";
            try
            {
                DataTable history = Database.GetDataByQuery(Project.conn, histring);

                history.Columns["id"].ColumnName = "ID";
                history.Columns["survey_date"].ColumnName = "Survey Date";
                history.Columns["name"].ColumnName = "Name";
                history.Columns["speed_limit"].ColumnName = "Speed Limit";
                history.Columns["lanes"].ColumnName = "Lanes";
                history.Columns["width"].ColumnName = "Width";
                history.Columns["length"].ColumnName = "Length";
                history.Columns["surface"].ColumnName = "Surface";
                history.Columns["type"].ColumnName = "Functional Classification";
                history.Columns["from_address"].ColumnName = "From Address";
                history.Columns["to_address"].ColumnName = "To Address";
                history.Columns["photo"].ColumnName = "Photo";
                history.Columns["rsl"].ColumnName = "RSL";
                history.Columns["suggested_treatment"].ColumnName = "Suggested Treatment";
                history.Columns["notes"].ColumnName = "Notes";

                int surface_id = 0;
                string surface_type = history.Rows[0]["surface"].ToString();
                if (surface_type == "asphalt")surface_id = 1;
                if (surface_type == "gravel")
                {
                    surface_id = 2;
                    history.Columns.Remove("distress8");
                    history.Columns.Remove("distress9");
                }
                if (surface_type == "concrete")surface_id = 3;

                DataTable distresses = Database.GetDataByQuery(Project.conn, "SELECT name, dbkey FROM road_distresses WHERE surface_id = " + surface_id.ToString());
                for (int i = 0; i < distresses.Rows.Count; i++)
                {
                    string distressNumber = distresses.Rows[i]["dbkey"].ToString();
                    history.Columns[distressNumber].ColumnName = distresses.Rows[i]["name"].ToString();
                }

                FormOutput histForm = new FormOutput(Project);
                histForm.Text = "Road History";
                histForm.dataGridViewReport.DataSource = history;
                histForm.Show();
            }
            catch (Exception err)
            {
                Log.Error("Malformed request " + err.ToString());
                MessageBox.Show("An error occured when attempting to show history. Roads Database may be corrupted.");
            }
        }

         public void generalReport(object sender, EventArgs e)
         {
            DataTable general = new DataTable();
            general.Columns.Add("ID");
            general.Columns.Add("Name");
            general.Columns.Add("Width (ft)");
            general.Columns.Add("Length (ft)");
            general.Columns.Add("From Address");
            general.Columns.Add("To Address");
            general.Columns.Add("Surface");
            general.Columns.Add("Governing Distress");
            general.Columns.Add("Treatment");
            general.Columns.Add("Cost");
            general.Columns.Add("Area");
            general.Columns.Add("RSL");
            general.Columns.Add("Functional Classification");
            general.Columns.Add("Notes");
            general.Columns.Add("Survey Date");
            general.Columns.Add("Fat/Spa/Pot");
            general.Columns.Add("Edg/Joi/Rut");
            general.Columns.Add("Lon/Cor/X-S");
            general.Columns.Add("Pat/Bro/Dra");
            general.Columns.Add("Pot/Fau/Dus");
            general.Columns.Add("Dra/Lon/Agg");
            general.Columns.Add("Tra/Tra/Cor");
            general.Columns.Add("Block/Crack");
            general.Columns.Add("Rutti/Patch");

            string thisSql = getSelectAllSQL();
            try
             {
                DataTable resultsTable = Database.GetDataByQuery(Project.conn, thisSql);

                foreach (DataRow row in resultsTable.Rows)
                {
                    string note = row["notes"].ToString().Split(new[] { '\r', '\n' }).FirstOrDefault(); //retrive most recent note

                    int oldNoteLength = note.Length;
                    int maxLength = 17;
                    if (!string.IsNullOrEmpty(note))
                    {
                        note = note.Substring(0, Math.Min(oldNoteLength, maxLength));
                        if(note.Length == maxLength)note += "...";
                    }
                    DataRow nr = general.NewRow();
                    nr["ID"] = row["TAMSID"];
                    nr["Name"] = row["name"];
                    nr["Width (ft)"] = row["width"];
                    nr["Length (ft)"] = row["length"];
                    nr["From Address"] = row["from_address"];
                    nr["To Address"] = row["to_address"];
                    nr["Surface"] = row["surface"];
                    nr["RSL"] = row["rsl"];
                    nr["Functional Classification"] = row["type"];
                    nr["Notes"] = note;
                    nr["Survey Date"] = row["survey_date"];
                    nr["Fat/Spa/Pot"] = row["distress1"];
                    nr["Edg/Joi/Rut"] = row["distress2"];
                    nr["Lon/Cor/X-S"] = row["distress3"];
                    nr["Pat/Bro/Dra"] = row["distress4"];
                    nr["Pot/Fau/Dus"] = row["distress5"];
                    nr["Dra/Lon/Agg"] = row["distress6"];
                    nr["Tra/Tra/Cor"] = row["distress7"];
                    nr["Block/Crack"] = row["distress8"];
                    nr["Rutti/Patch"] = row["distress9"];

                    int[] dvs = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        dvs[i] = Util.ToInt(row["distress" + (i + 1).ToString()].ToString());     
                    }
                    nr["Governing Distress"] = getGoverningDistress(dvs, row["surface"].ToString());
                    if (!row["suggested_treatment"].ToString().Contains("null") && !string.IsNullOrWhiteSpace(row["suggested_treatment"].ToString()))
                    {
                        nr["Treatment"] = row["suggested_treatment"];
                    }
                    nr["Area"] = Util.ToDouble(row["width"].ToString()) * Util.ToDouble(row["length"].ToString());
                    general.Rows.Add(nr);
                }

                general.DefaultView.Sort = "Name asc, Treatment asc, From Address asc";
                general = general.DefaultView.ToTable();

                FormOutput report = new FormOutput(Project);
                report.dataGridViewReport.DataSource = general;
                report.Text = "Treatment Report";
                report.Show();
             }
             catch (Exception err)
             {
                 Log.Error("Could not get database values for " + ModuleName + " module.\n" + err.ToString());
                 MessageBox.Show("An error has occured while trying to consolidate data.");
             }
         }

        public void potholeReport(object sender, EventArgs e)
        {
            string[] pd = { "less than 1\"", "less than 2\"", "more than 2\"" };
            string[] pq = { "less than 2", "less than 5", "more than 5" };
            DataTable potholes = new DataTable("Potholes");
            potholes.Columns.Add("ID");
            potholes.Columns.Add("Name");
            potholes.Columns.Add("From Address");
            potholes.Columns.Add("To Address");
            potholes.Columns.Add("Depth");
            potholes.Columns.Add("Quantity");
            potholes.Columns.Add("Suggested Treatment");
            string thisSql = getSelectAllSQL();
            try
            {
                DataTable resultsTable = Database.GetDataByQuery(Project.conn, thisSql);
                if (resultsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no roads with potholes where found.");
                    return;
                }
                foreach (DataRow row in resultsTable.Rows)
                {
                    if (Util.ToInt(row["distress5"].ToString()) <= 0)
                    {
                        continue;
                    }
                    DataRow nr = potholes.NewRow();
                    nr["ID"] = row["TAMSID"];
                    nr["Name"] = row["name"];
                    nr["From Address"] = row["from_address"];
                    nr["To Address"] = row["to_address"];
                    nr["Depth"] = (Util.ToInt(row["distress5"].ToString()) > 0 ? pd[(Util.ToInt(row["distress5"].ToString()) - 1) / 3] : "None");
                    nr["Quantity"] = (Util.ToInt(row["distress5"].ToString()) > 0 ? pq[(Util.ToInt(row["distress5"].ToString()) - 1) % 3] : "None");
                    nr["Suggested Treatment"] = row["suggested_treatment"].ToString();
                    potholes.Rows.InsertAt(nr, potholes.Rows.Count);
                }
                potholes.DefaultView.Sort = "Name asc, From Address asc";
                FormOutput report = new FormOutput(Project);
                report.dataGridViewReport.DataSource = potholes.DefaultView.ToTable();
                report.Text = "Potholes Report";
                report.Show();
            }
            catch (Exception err)
            {
                Log.Error("Could not get database values for " + ModuleName + " module.\n" + err.ToString());
                MessageBox.Show("An error has occured while trying to consolidate data.");
            }
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

        private void reportSelected(object sender, EventArgs e)
        {
            DataTable general = new DataTable();
            general.Columns.Add("ID");
            general.Columns.Add("Name");
            general.Columns.Add("From Address");
            general.Columns.Add("To Address");
            general.Columns.Add("Surface");
            general.Columns.Add("Governing Distress");
            general.Columns.Add("Treatment");
            general.Columns.Add("Cost");
            general.Columns.Add("Area");
            FeatureLayer selectionLayer = (FeatureLayer)Layer; 
            ISelection shpSelection = selectionLayer.Selection;
            DataTable selectionTable = shpSelection.ToFeatureSet().DataTable;
            string thisSql = SelectionSql.Replace("[[IDLIST]]", extractTAMSIDs(selectionTable));
            try
            {
                DataTable resultsTable = Database.GetDataByQuery(Project.conn, thisSql);
                double totalCost = 0;
                foreach (DataRow row in resultsTable.Rows)
                {
                    DataRow nr = general.NewRow();
                    nr["ID"] = row["TAMSID"];
                    nr["Name"] = row["name"];
                    nr["From Address"] = row["from_address"];
                    nr["To Address"] = row["to_address"];
                    nr["Surface"] = row["surface"];
                    int[] dvs = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        dvs[i] = Util.ToInt(row["distress" + (i + 1).ToString()].ToString());
                    }
                    nr["Governing Distress"] = getGoverningDistress(dvs, row["surface"].ToString());
                    nr["Cost"] = 0;
                    if (!row["suggested_treatment"].ToString().Contains("null") && !string.IsNullOrWhiteSpace(row["suggested_treatment"].ToString()))
                    {
                        nr["Treatment"] = row["suggested_treatment"];
                        string treatmentCost = Database.GetDataByQuery(Project.conn, "SELECT cost FROM treatments WHERE name = '" + row["suggested_treatment"].ToString() + "';").Rows[0]["cost"].ToString();
                        double estCost = Util.ToDouble(row["width"].ToString()) * Util.ToDouble(row["length"].ToString()) * Util.ToDouble(treatmentCost) / 9;//Note: Treatment cost is per square yard. Road dimensions are in yd.
                        if (estCost > 1000000)
                        {
                            nr["Cost"] = Math.Round(estCost / 1000000, 2).ToString() + "M";
                        }
                        else if (estCost > 1000)
                        {
                            nr["Cost"] = Math.Round(estCost / 1000).ToString() + "k";
                        }
                        else
                        {
                            nr["Cost"] = Math.Round(estCost).ToString();
                        }
                        totalCost += (int)estCost;
                    }
                    nr["Area"] = Util.ToDouble(row["width"].ToString()) * Util.ToDouble(row["length"].ToString());
                    general.Rows.Add(nr);
                }
                general.DefaultView.Sort = "Name asc, Treatment asc, From Address asc";
                general = general.DefaultView.ToTable();
                DataRow totals = general.NewRow();
                totals["Name"] = "Total";
                totals["From Address"] = "Estimated";
                totals["To Address"] = "Cost";
                if (totalCost > 1000000)
                {
                    totals["Cost"] = Math.Round(totalCost / 1000000, 2).ToString() + "M";
                }
                else if (totalCost > 1000)
                {
                    totals["Cost"] = Math.Round(totalCost / 1000).ToString() + "k";
                }
                else
                {
                    totals["Cost"] = Math.Round(totalCost).ToString();
                }
                general.Rows.Add(totals);
                FormOutput report = new FormOutput(Project);
                report.dataGridViewReport.DataSource = general.DefaultView.ToTable();
                report.Text = "Treatment Report";
                report.Show();
            }
            catch (Exception err)
            {
                Log.Error("Could not get database values for " + ModuleName + " module.\n" + err.ToString());
                MessageBox.Show("An error has occured while trying to consolidate data.");
            }
        }

        private string getGoverningDistress(int[] distValues, string surfType)
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
            FormBudgetEstimator budget = new FormBudgetEstimator();
            if (budget.setData(roads.DefaultView.ToTable(), treatments.DefaultView.ToTable()))
            {
                budget.Show();
            }
            else
            {
                budget.Close();
            }

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

        private void customReport(object sender, EventArgs e)
        {
            FormQueryBuilder tableFilters = new FormQueryBuilder("road");
            if (tableFilters.ShowDialog() == DialogResult.OK)
            {
                string surfaceType = tableFilters.getSurface();
                string query = tableFilters.getQuery() + " GROUP BY TAMSID ORDER BY TAMSID ASC, survey_date DESC;";
                DataTable results = Database.GetDataByQuery(Project.conn, query);
                if (results.Rows.Count == 0)
                {
                    MessageBox.Show("No roads matching the given description were found.");
                    return;
                }
                DataTable outputTable = new DataTable();
                outputTable.Columns.Add("ID");
                outputTable.Columns.Add("Name");
                outputTable.Columns.Add("Speed Limit");
                outputTable.Columns.Add("Lanes");
                outputTable.Columns.Add("Width (ft)");
                outputTable.Columns.Add("Length (ft)");
                outputTable.Columns.Add("From Address");
                outputTable.Columns.Add("To Address");
                outputTable.Columns.Add("Surface");
                outputTable.Columns.Add("Governing Distress");
                outputTable.Columns.Add("Treatment");
                outputTable.Columns.Add("Cost");
                outputTable.Columns.Add("Area");
                outputTable.Columns.Add("RSL");
                outputTable.Columns.Add("Functional Classification");
                outputTable.Columns.Add("Notes");
                outputTable.Columns.Add("Survey Date");
                if (surfaceType == "")
                {
                    outputTable.Columns.Add("Fat/Spa/Pot");
                    outputTable.Columns.Add("Edg/Joi/Rut");
                    outputTable.Columns.Add("Lon/Cor/X-S");
                    outputTable.Columns.Add("Pat/Bro/Dra");
                    outputTable.Columns.Add("Pot/Fau/Dus");
                    outputTable.Columns.Add("Dra/Lon/Agg");
                    outputTable.Columns.Add("Tra/Tra/Cor");
                    outputTable.Columns.Add("Block/Crack");
                    outputTable.Columns.Add("Rutti/Patch");
                }
                if (surfaceType == "Asphalt")
                {
                    outputTable.Columns.Add("Fatigue");
                    outputTable.Columns.Add("Edge");
                    outputTable.Columns.Add("Longitudinal");
                    outputTable.Columns.Add("Patches");
                    outputTable.Columns.Add("Potholes");
                    outputTable.Columns.Add("Drainage");
                    outputTable.Columns.Add("Transverse");
                    outputTable.Columns.Add("Block");
                    outputTable.Columns.Add("Rutting");
                }
                if (surfaceType == "Concrete")
                {
                    outputTable.Columns.Add("Spalling");
                    outputTable.Columns.Add("Joint Seal");
                    outputTable.Columns.Add("Corners");
                    outputTable.Columns.Add("Broken");
                    outputTable.Columns.Add("Faulting");
                    outputTable.Columns.Add("Longitudinal");
                    outputTable.Columns.Add("Transverse");
                    outputTable.Columns.Add("Cracking");
                    outputTable.Columns.Add("Patches");
                }

                if (surfaceType == "Gravel")
                {
                    outputTable.Columns.Add("Potholes");
                    outputTable.Columns.Add("Rutting");
                    outputTable.Columns.Add("X-Section");
                    outputTable.Columns.Add("Drainage");
                    outputTable.Columns.Add("Dust");
                    outputTable.Columns.Add("Aggregate");
                    outputTable.Columns.Add("Corrugate");
                }

                FormOutput report = new FormOutput(Project);
                foreach (DataRow row in results.Rows)
                {
                    DataRow nr = outputTable.NewRow();
                    string note = row["notes"].ToString().Split(new[] { '\r', '\n' }).FirstOrDefault(); //retrive most recent note

                    int oldNoteLength = note.Length;
                    int maxLength = 17;
                    if (!string.IsNullOrEmpty(note))
                    {
                        note = note.Substring(0, Math.Min(oldNoteLength, maxLength));
                        if (note.Length == maxLength) note += "...";
                    }
                    double area = Util.ToDouble(row["width"].ToString()) * Util.ToDouble(row["length"].ToString());

                    nr["ID"] = row["TAMSID"];
                    nr["Name"] = row["name"];
                    nr["Speed Limit"] = row["speed_limit"];
                    nr["Lanes"] = row["lanes"];
                    nr["Width (ft)"] = row["width"];
                    nr["Length (ft)"] = row["length"];
                    nr["From Address"] = row["from_address"];
                    nr["To Address"] = row["to_address"];
                    nr["Surface"] = row["surface"];
                    nr["Area"] = area;
                    nr["RSL"] = row["rsl"];
                    nr["Functional Classification"] = row["type"];
                    nr["Notes"] = note;
                    nr["Survey Date"] = row["survey_date"];
                    if (surfaceType == "")
                    {
                        nr["Fat/Spa/Pot"] = row["distress1"];
                        nr["Edg/Joi/Rut"] = row["distress2"];
                        nr["Lon/Cor/X-S"] = row["distress3"];
                        nr["Pat/Bro/Dra"] = row["distress4"];
                        nr["Pot/Fau/Dus"] = row["distress5"];
                        nr["Dra/Lon/Agg"] = row["distress6"];
                        nr["Tra/Tra/Cor"] = row["distress7"];
                        nr["Block/Crack"] = row["distress8"];
                        nr["Rutti/Patch"] = row["distress9"];
                    }
                    if (surfaceType == "Asphalt")
                    {
                        nr["Fatigue"] = row["distress1"];
                        nr["Edge"] = row["distress2"];
                        nr["Longitudinal"] = row["distress3"];
                        nr["Patches"] = row["distress4"];
                        nr["Potholes"] = row["distress5"];
                        nr["Drainage"] = row["distress6"];
                        nr["Transverse"] = row["distress7"];
                        nr["Block"] = row["distress8"];
                        nr["Rutting"] = row["distress9"];
                    }
                    if (surfaceType == "Concrete")
                    {
                        nr["Spalling"] = row["distress1"];
                        nr["Joint Seal"] = row["distress2"];
                        nr["Corners"] = row["distress3"];
                        nr["Broken"] = row["distress4"];
                        nr["Faulting"] = row["distress5"];
                        nr["Longitudinal"] = row["distress6"];
                        nr["Transverse"] = row["distress7"];
                        nr["Cracking"] = row["distress8"];
                        nr["Patches"] = row["distress9"];
                    }

                    if (surfaceType == "Gravel")
                    {
                        nr["Potholes"] = row["distress1"];
                        nr["Rutting"] = row["distress2"];
                        nr["X-Section"] = row["distress3"];
                        nr["Drainage"] = row["distress4"];
                        nr["Dust"] = row["distress5"];
                        nr["Aggregate"] = row["distress6"];
                        nr["Corrugate"] = row["distress7"];
                    }

                    int[] dvs = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        dvs[i] = Util.ToInt(row["distress" + (i + 1).ToString()].ToString());
                    }
                    nr["Governing Distress"] = getGoverningDistress(dvs, row["surface"].ToString());
                    nr["Cost"] = 0;
                    if (!row["suggested_treatment"].ToString().Contains("null") && !string.IsNullOrWhiteSpace(row["suggested_treatment"].ToString()))
                    {
                        nr["Treatment"] = row["suggested_treatment"];
                        string treatment = row["suggested_treatment"].ToString();

                        double treatmentCost = 0.0;
                        if (treatment == "Routine") treatmentCost = 0.56;
                        if (treatment == "Patching") treatmentCost = 0.67;
                        if (treatment == "Preventative") treatmentCost = 2.08;
                        if (treatment == "Preventative with Patching") treatmentCost = 2.75;
                        if (treatment == "Rehabilitation") treatmentCost = 9.57;
                        if (treatment == "Reconstruction") treatmentCost = 18.4;
                        try
                        {
                            if (treatmentCost == 0.0 && treatment != "Nothing")
                            {
                                DataTable tc = Database.GetDataByQuery(Project.conn, "SELECT cost FROM treatments " + "WHERE name LIKE '" + treatment + "';");
                                treatmentCost = Util.ToDouble(tc.Rows[0]["cost"].ToString());
                            }
                        }
                        catch (Exception err)
                        {
                            Log.Error("Problem getting data from database " + err.ToString());
                        }


                        double estCost = area * treatmentCost / 9;
                        if (estCost > 1000000)
                        {
                            nr["Cost"] = Math.Round(estCost / 1000000, 2).ToString() + "M";
                        }
                        else if (estCost > 1000)
                        {
                            nr["Cost"] = Math.Round(estCost / 1000).ToString() + "k";
                        }
                        else
                        {
                            nr["Cost"] = Math.Round(estCost).ToString();
                        }
                    }
                    outputTable.Rows.Add(nr);
                }
                report.dataGridViewReport.DataSource = outputTable;
                report.Text = "Treatment Report";
                report.Show();
            }
            tableFilters.Close();
        }

        private string getSelectAllSQL()
        {
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            selectionLayer.SelectAll();
            ISelection shpSelection = selectionLayer.Selection;
            DataTable selectionTable = shpSelection.ToFeatureSet().DataTable;
            string thisSql = SelectionSql.Replace("[[IDLIST]]", extractTAMSIDs(selectionTable));
            selectionLayer.ClearSelection();
            return thisSql;
        }

        private void graphRoadType(object sender, EventArgs e)
        {
            string[] roadTypes = { "asphalt", "concrete", "gravel" };
            Color[] c = { Color.Black, Color.LightGray, Color.FromArgb(150, 75, 0) };
            makeTypeGraph(roadTypes, "surface", "Road Surface Distribution", c);
        }

        private void graphRoadCategory(object sender, EventArgs e)
        {
            string[] roadTypes = { "Major Arterial", "Minor Arterial", "Major Collector", "Minor Collector", "Residential", "Other" };
            makeTypeGraph(roadTypes, "type", "Distribution of Functional Classification");
        }

        private void makeTypeGraph(string[] roadTypes, string column, string title, Color[] c = null)
        {
            string thisSql = getSelectAllSQL();
            try
            {
                DataTable roadTable = Database.GetDataByQuery(Project.conn, thisSql);
                if (roadTable.Rows.Count == 0)
                {
                    MessageBox.Show("No graph could be generated because no roads have a road type set.", "No Roads", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Dictionary<string, double> roadArea = new Dictionary<string, double>();
                for (int i = 0; i < roadTypes.Length; i++)
                {
                    roadArea.Add(roadTypes[i], 0.0);
                }
                double totalArea = 0.0;
                foreach (DataRow row in roadTable.Rows)
                {
                    for (int i = 0; i < roadTypes.Length; i++)
                    {
                        if (row[column].ToString().Contains(roadTypes[i]))
                        {
                            totalArea += Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                            roadArea[roadTypes[i]] += Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                        }
                    }
                }
                DataTable results = new DataTable();
                results.Columns.Add("Distribution");
                for (int i = 0; i < roadTypes.Length; i++)
                {
                    results.Columns.Add(Util.UppercaseFirst(roadTypes[i]));
                }
                DataRow totalsRow = results.NewRow();
                DataRow percentageRow = results.NewRow();
                totalsRow["Distribution"] = "Area (sqr. ft.)";
                percentageRow["Distribution"] = "Percentage";
                string[] domain = new string[roadTypes.Length];
                double[] range = new double[roadTypes.Length];
                for (int i = 0; i < roadTypes.Length; i++)
                {
                    totalsRow[Util.UppercaseFirst(roadTypes[i])] = roadArea[roadTypes[i]];
                    percentageRow[Util.UppercaseFirst(roadTypes[i])] = Math.Round(roadArea[roadTypes[i]] / totalArea, 3) * 100;
                    domain[i] = roadTypes[i];
                    range[i] = Math.Round(roadArea[roadTypes[i]] / totalArea, 3) * 100;
                }
                results.Rows.Add(totalsRow);
                results.Rows.Add(percentageRow);
                FormGraphDisplay graph = new FormGraphDisplay(results, domain, range, title, c);
                graph.Show();
            }
            catch (Exception err)
            {
                Log.Error("Problem getting data from database " + err.ToString());
            }
        }

        private void graphGoverningDistress(object sender, EventArgs e)
        {
            ChooseRoadForm roadChooser = new ChooseRoadForm("What Road Type?", "Select a Road Surface Type");
            string thisSql = getSelectAllSQL();
            if (roadChooser.ShowDialog()== DialogResult.OK)
            {
                try
                {
                    string roadType = roadChooser.chooseRoad();
                    DataTable roadTable = Database.GetDataByQuery(Project.conn, thisSql);
                    var roads = roadTable.Select("surface = '" + roadType + "'");
                    if (roads.Length == 0)
                    {
                        MessageBox.Show("No graph could be generated because there are no roads of type " + roadType + ".", "No Roads", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Dictionary<string, string[]> distressGroup = new Dictionary<string, string[]>()
                    {
                        {"Asphalt", distressAsphalt },
                        {"Gravel", distressGravel },
                        {"Concrete", distressConcrete }
                    };
                    Dictionary<string, double> distressedArea = new Dictionary<string, double>();
                    double totalArea = 0.0;
                    double noDistress = 0.0;
                    for (int i = 0; i < distressGroup[roadType].Length; i++)
                    {
                        distressedArea.Add(distressGroup[roadType][i], 0.0);
                    }
                    foreach (DataRow row in roads)
                    {
                        double area = Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                        totalArea += area;
                        int[] dvs = new int[9];
                        for (int i = 0; i < 9; i++)
                        {
                            dvs[i] = Util.ToInt(row["distress" + (i + 1).ToString()].ToString());
                        }
                        string governingDistress = getGoverningDistress(dvs, row["surface"].ToString());
                        if (string.IsNullOrEmpty(governingDistress))
                        {
                            noDistress += area;
                        }
                        else
                        {
                            distressedArea[governingDistress] += area;
                        }
                    }
                    DataTable results = new DataTable();
                    results.Columns.Add("Distribution");
                    for (int i = 0; i < distressGroup[roadType].Length; i++)
                    {
                        results.Columns.Add(distressGroup[roadType][i]);
                    }
                    results.Columns.Add("No Distress");
                    DataRow totalsRow = results.NewRow();
                    DataRow percentageRow = results.NewRow();
                    totalsRow["Distribution"] = "Area (sqr. ft.)";
                    percentageRow["Distribution"] = "Percentage";
                    string[] domain = new string[distressGroup[roadType].Length + 1];
                    double[] range = new double[distressGroup[roadType].Length + 1];
                    for (int i = 0; i < distressGroup[roadType].Length; i++)
                    {
                        totalsRow[distressGroup[roadType][i]] = distressedArea[distressGroup[roadType][i]];
                        percentageRow[distressGroup[roadType][i]] = Math.Round(distressedArea[distressGroup[roadType][i]] / totalArea, 3) * 100;
                        domain[i] = distressGroup[roadType][i];
                        range[i] = Math.Round(distressedArea[distressGroup[roadType][i]] / totalArea, 3) * 100;
                    }
                    totalsRow["No Distress"] = noDistress;
                    percentageRow["No Distress"] = Math.Round(noDistress / totalArea, 3) * 100;
                    results.Rows.Add(totalsRow);
                    results.Rows.Add(percentageRow);
                    domain[distressGroup[roadType].Length] = "No Distress";
                    range[distressGroup[roadType].Length] = Math.Round(noDistress / totalArea, 3) * 100;
                    FormGraphDisplay graph = new FormGraphDisplay(results, domain, range, Util.UppercaseFirst(roadType) + " Road Governing Distress Distribution");
                    graph.Show();
                }
                catch (Exception err)
                {
                    Log.Error("Problem getting data from database " + err.ToString());
                }
            }
        }

        private void graphRSL(object sender, EventArgs e)
        {
            ChooseRoadForm roadChooser = new ChooseRoadForm("What Road Type?", "Select a road surface type.");
            string thisSql = getSelectAllSQL();
            if (roadChooser.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string roadType = roadChooser.chooseRoad();
                    string[] categories = { "0", "1-3", "4-6", "7-9", "10-12", "13-15", "16-18", "19-20" };
                    int[] caps = { 0, 3, 6, 9, 12, 15, 18, 20 };
                    DataTable roadTable = Database.GetDataByQuery(Project.conn, thisSql);
                    var roads = roadTable.Select("surface = '" + roadType + "'");
                    if (roads.Length == 0)
                    {
                        MessageBox.Show("No graph could be generated because there are no roads of type " + roadType + ".", "No Roads", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    Dictionary<string, double> rslArea = new Dictionary<string, double>();
                    double totalArea = 0.0;
                    for (int i = 0; i < categories.Length; i++)
                    {
                        rslArea.Add(categories[i], 0.0);
                    }
                    
                    foreach (DataRow row in roads)
                    {
                        int rsl = Util.ToInt(row["rsl"].ToString());
                        if (rsl == -1)
                        {
                            continue;
                        }
                        for (int i = 0; i < categories.Length; i++)
                        {
                            if (rsl <= caps[i])
                            {
                                totalArea += Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                                rslArea[categories[i]] += Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                                break;
                            }
                        }
                    }
                    DataTable results = new DataTable();
                    results.Columns.Add("Distribution");
                    for (int i = 0; i < categories.Length; i++)
                    {
                        results.Columns.Add(categories[i]);
                    }
                    DataRow totalsRow = results.NewRow();
                    DataRow percentageRow = results.NewRow();
                    totalsRow["Distribution"] = "Area (sqr. ft.)";
                    percentageRow["Distribution"] = "Percentage";
                    string[] domain = new string[categories.Length];
                    double[] range = new double[categories.Length];
                    for (int i = 0; i < categories.Length; i++)
                    {
                        totalsRow[categories[i]] = rslArea[categories[i]];
                        percentageRow[categories[i]] = Math.Round(rslArea[categories[i]] / totalArea, 3) * 100;
                        domain[i] = categories[i];
                        range[i] = Math.Round(rslArea[categories[i]] / totalArea, 3) * 100;
                    }
                    results.Rows.Add(totalsRow);
                    results.Rows.Add(percentageRow);
                    Color[] color = { Color.DarkRed, Color.Red, Color.Orange, Color.Yellow, Color.LimeGreen, Color.Green, Color.DeepSkyBlue, Color.Blue };
                    FormGraphDisplay graph = new FormGraphDisplay(results, domain, range, "Road RSL Distribution", color);
                    graph.Show();
                }
                catch (Exception err)
                {
                    Log.Error("Problem getting data from database " + err.ToString());
                }
            }
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
