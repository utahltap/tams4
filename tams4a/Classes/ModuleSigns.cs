using DotSpatial.Controls;
using DotSpatial.Symbology;
using DotSpatial.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using tams4a.Controls;
using tams4a.Forms;

namespace tams4a.Classes
{
    class ModuleSigns : ProjectModule {

        
        private string notes;
        private string postCat;
        private int maxSuppID = 0;
        private int maxSignID = 0;
        private DataTable signsOnPost;
        private List<Dictionary<string, string>> signChanges;
        private Dictionary<string, int> catRank;
        private bool suppressChanges = false;
        private bool inClick = false;

        private const string SignSelectionSql = @"SELECT * from sign_support WHERE support_id IN ([[IDLIST]]);";

        private const string SignListSql = @"SELECT * from sign WHERE support_id IN ([[IDLIST]]);";

        public ModuleSigns(TamsProject theProject, TabPage controlPage, ToolStripMenuItem[] boundButtons) : base(theProject, controlPage, boundButtons, SignSelectionSql) {
            ModuleName = "sign";
            surveyDate = DateTime.Now;
            notes = "";

            Panel_Module_OpenShp signAdd = new Panel_Module_OpenShp("Sign");
            signAdd.Name = "SIGNADD";
            signAdd.SetHandler(new EventHandler(openFileHandler));
            Button createSigns = new Button();
            createSigns.Text = "Create Sign SHP File";
            createSigns.Size = new Size(196, 54);
            createSigns.Location = new Point(10, 74);
            createSigns.Click += newSHPFile;
            signAdd.Controls.Add(createSigns);
            signAdd.Dock = DockStyle.Fill;
            ControlsPage.Controls.Add(signAdd);

            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_file", module: ModuleName));
            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_relative", module: ModuleName));

            FieldSettingToDbColumn = new Dictionary<string, string>()
            {
                { "sign_f_TAMSID", "support_id" },
                { "sign_f_address", "address"},
                { "sign_f_offset", "road_offset" }
            };

            Project.map.ResetBuffer();
            Project.map.Update();

            catRank = new Dictionary<string, int>()
            {
                { "regulatory_rw", 1 },
                { "school_pedestrian", 2 },
                { "rail", 3 },
                { "regulatory_bw", 4 },
                { "warning", 5 },
                { "regulatory_pedestrian", 6 },
                { "worker", 7 },
                { "highway", 8 },
                { "locational", 9 },
                { "location_guide", 9},
                { "service", 10 },
                { "recreation", 11 },
                { "empty_post", 12 }
            };

            boundButtons[0].Click += clickManageFavorites;
            boundButtons[1].Click += failedReport;
            boundButtons[2].Click += generateReport;
            boundButtons[3].Click += obstructedReport;
            boundButtons[4].Click += supportReport;
        }

        public override bool openFile(string thePath = "", string type = "point")
        {
            if (type == "") { type = "point";}
            if (type != "point") { throw new Exception("Signs module requires a point-type shp file"); }

            #region signSettings
            ModuleSettings.Add(new ProjectSetting(name: "sign_f_TAMSID", module: ModuleName, value: "",
                    display_text: "SHP field with a unique identifier (TAMSID).", display_type: "field",
                    description: "Show an Icon instead of a basic shape for sign locations.", required:true));
            ModuleSettings.Add(new ProjectSetting(name: "sign_f_address", module: ModuleName, value: "",
                    display_text: "SHP field with sign address?", display_type: "field",
                    description: "The field in the sign shp file containing the approximate address of the signpost."));
            ModuleSettings.Add(new ProjectSetting(name: "sign_f_offset", module: ModuleName, value: "",
                    display_text: "SHP field with offset from road?", display_type: "field",
                    description: "The field in the sign shp file indicating the distance of the support from the road."));
            #endregion signSettings

            injectSettings();

            if (!base.openFile(thePath, type)) { return false; }

            ControlsPage.Controls.Remove(ControlsPage.Controls["SIGNADD"]);
            Panel_Sign signPanel = new Panel_Sign();
            signPanel.Name = "SIGNCONTROLS";
            signPanel.Dock = DockStyle.Fill;
            ControlsPage.Controls.Add(signPanel);

            #region eventhandlers
            signPanel.setChangedHandler(controlChanged);
            signPanel.toolStripButtonSave.Click += saveHandler;
            signPanel.toolStripButtonCancel.Click += cancelChanges;
            signPanel.buttonInstallDate.Click += chooseInstallDate;
            signPanel.buttonSearchMUTCD.Click += searchMUTCDclick;
            signPanel.buttonAdd.Click += addNewSign;
            signPanel.buttonRemove.Click += removeSign;
            signPanel.buttonFavorite.Click += faveSign;
            signPanel.enterCoordinatesToolStripMenuItem.Click += enterCoordinates;
            signPanel.clickMapToolStripMenuItem.Click += clickMap;
            signPanel.toolStripButtonRemove.Click += deletePost;
            signPanel.toolStripButtonNotes.Click += editNotes;
            signPanel.buttonSignNote.Click += signNote;

            signPanel.setOtherDateToolStripMenuItem.Click += selectRecordDate;
            signPanel.setTodayToolStripMenuItem.Click += resetRecordDate;

            signPanel.textBoxType.TextChanged += setMUTCDvalues;
            signPanel.comboBoxSigns.TextChanged += signChangeHandler;

            signPanel.textBoxType.TextChanged += signValueChanged;
            signPanel.textBoxDescription.TextChanged += signValueChanged;
            signPanel.comboBoxSheeting.TextChanged += signValueChanged;
            signPanel.comboBoxBacking.TextChanged += signValueChanged;
            signPanel.numericUpDownHeightSign.ValueChanged += signValueChanged;
            signPanel.numericUpDownWidth.ValueChanged += signValueChanged;
            signPanel.numericUpDownMountHeight.ValueChanged += signValueChanged;
            signPanel.textBoxInstall.TextChanged += signValueChanged;
            signPanel.textBoxText.TextChanged += signValueChanged;
            signPanel.comboBoxReflectivity.TextChanged += signValueChanged;
            signPanel.comboBoxConditionSign.TextChanged += signValueChanged;
            signPanel.comboBoxDirection.TextChanged += signValueChanged;
            signPanel.textBoxPhotoFile.TextChanged += signValueChanged;
            signPanel.pictureBoxPhoto.Click += clickPhotoBox;
            signPanel.pictureBoxPost.Click += clickPostPhotoBox;
            #endregion eventhandlers

            DataTable supportMaterials = Database.GetDataByQuery(Project.conn, "SELECT * FROM support_materials");
            DataRow blankMaterialRow = supportMaterials.NewRow();
            supportMaterials.Rows.InsertAt(blankMaterialRow, 0);
            signPanel.comboBoxMaterial.DataSource = supportMaterials;
            signPanel.comboBoxMaterial.DisplayMember = "material";
            signPanel.comboBoxMaterial.ValueMember = "id";

            DataTable signBacking = Database.GetDataByQuery(Project.conn, "SELECT * FROM sign_backing");
            DataRow blankBackingRow = signBacking.NewRow();
            signBacking.Rows.InsertAt(blankBackingRow, 0);
            signPanel.comboBoxBacking.DataSource = signBacking;
            signPanel.comboBoxBacking.DisplayMember = "material";
            signPanel.comboBoxBacking.ValueMember = "id";

            DataTable signSheeting = Database.GetDataByQuery(Project.conn, "SELECT * FROM sign_sheeting");
            DataRow blankSheetingRow = signSheeting.NewRow();
            signSheeting.Rows.InsertAt(blankSheetingRow, 0);
            signPanel.comboBoxSheeting.DataSource = signSheeting;
            signPanel.comboBoxSheeting.DisplayMember = "type";
            signPanel.comboBoxSheeting.ValueMember = "id";

            if (((FeatureLayer)Layer).DataSet.NumRows() == 1)
            {
                Layer.Extent.ExpandBy(100, 100);
            }

            Panel_Sign signControls = getSignControls();

            applySymbolizedProperty();
            setSymbolizer();
            disableSignDisplay(signControls);
            resetSignDisplay(signControls);
            resetSaveCondition(signControls);

            return true;
        }

        private bool createSHPFile(string filename)
        {
            PointShapefile pointLayer = new PointShapefile();
            pointLayer.Projection = DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984;
            pointLayer.DataTable.Columns.Add("FID");
            pointLayer.DataTable.Columns.Add("TAMSID");
            pointLayer.DataTable.Columns.Add("TAMSSIGN");
            pointLayer.DataTable.Columns.Add("address");
            pointLayer.DataTable.Columns.Add("offset");
            try
            {
                pointLayer.SaveAs(filename, true);
            }
            catch (Exception e)
            {
                Log.Error("Could not create ShapeFile" + Environment.NewLine + e.ToString());
                return false;
            }
            return true;
        }

        private void newSHPFile(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "GIS ShapeFile (*.SHP)|*.shp";
            if (save.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string filename = save.FileName;
            if (createSHPFile(filename))
            {
                openFile(filename, "point");
                ProjectSetting shpSetting = new ProjectSetting(name: ModuleName + "_file", value: Filepath, module: ModuleName);
                ProjectSetting shpRelative = new ProjectSetting(name: ModuleName + "_relative", value: Util.MakeRelativePath(Properties.Settings.Default.lastProject, Filepath), module: ModuleName);
                Project.settings.SetSetting(shpSetting);
                Project.settings.SetSetting(shpRelative);
            }
        }

        /// <summary>
        /// Function that sets the install date of the active sign.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseInstallDate(object sender, EventArgs e)
        {
            Forms.FormSurveyDate df = new Forms.FormSurveyDate();
            df.Text = "Select Install Date";
            df.setText("Select the date when this sign was installed.");
            df.ShowDialog();
            getSignControls().textBoxInstall.Text = Util.SortableDate(df.getDate());
            df.Close();
        }

        protected override void controlChanged(object sender, EventArgs e)
        {
            if (suppressChanges)return;           
            Panel_Sign signPanel = getSignControls();

            signPanel.toolStripButtonSave.Enabled = true;
            signPanel.toolStripButtonSave.BackColor = Color.Red;
            UnsavedChanges = true;

            signPanel.toolStripButtonCancel.Enabled = true;
        }

        private Panel_Sign getSignControls()
        {
            Panel_Sign controls;

            try
            {
                controls = (Panel_Sign)ControlsPage.Controls["SIGNCONTROLS"];
            }
            catch (Exception e)
            {
                Log.Error("Could not retrieve controls page.\n" + e.ToString());
                throw new Exception("Could not retrieve controls page.\n" + e.ToString());
            }
            return controls;
        }

        protected override void ShpToDatabase()
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable data;
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            data = selectionLayer.DataSet.DataTable;
            foreach (DataRow row in data.Rows)
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values["survey_date"] = "";
                values["category"] = "empty_post";
                foreach (KeyValuePair<string, string> pair in FieldSettingToDbColumn)
                {
                    if (!Project.settings.Contains(pair.Key))
                    {
                        continue;
                    }

                    string fieldName = Project.settings.GetValue(pair.Key);
                    if (data.Columns.Contains(fieldName))
                    {
                        values[pair.Value] = row[fieldName].ToString();
                    }
                }
                Database.InsertRow(Project.conn, values, "sign_support");
            }
            
            Cursor.Current = Cursors.Arrow;
        }

        /// <summary>
        /// Sets the symbolizer for the signs in the GIS map. These symbols will be images representing the most important sign on the post.
        /// </summary>
        override protected void setSymbolizer()
        {
            int baseWidth = 48;

            PointScheme sgnScheme = new PointScheme();
            
            PointCategory catDef = new PointCategory(Properties.Resources.empty_post, baseWidth);
            catDef.LegendText = "No Sign Info";
            catDef.SelectionSymbolizer.ScaleMode = ScaleMode.Geographic;
            catDef.SelectionSymbolizer.SetOutline(Color.Cyan, baseWidth / 4);
            catDef.Symbolizer.ScaleMode = ScaleMode.Geographic;
            sgnScheme.AddCategory(catDef);

            Image[] images = { Properties.Resources.regulatory_rw, Properties.Resources.regulatory_bw, Properties.Resources.warning, Properties.Resources.regulatory_pedestrian, Properties.Resources.school_pedestrian, Properties.Resources.worker, Properties.Resources.rail, Properties.Resources.highway, Properties.Resources.locational, Properties.Resources.locational, Properties.Resources.service, Properties.Resources.recreation, Properties.Resources.empty_post};
            string[] signCats = { "regulatory_rw", "regulatory_bw", "warning", "regulatory_pedestrian", "school_pedestrian", "worker", "rail", "highway", "locational", "location_guide", "service", "recreation", "empty_post"};

            for (int i = 0; i < images.Length; i++)
            {
                PointCategory cat = new PointCategory(images[i], baseWidth);
                cat.FilterExpression = "[TAMSSIGN] = '" + signCats[i] + "'";
                cat.SelectionSymbolizer.ScaleMode = ScaleMode.Geographic;
                cat.SelectionSymbolizer.SetOutline(Color.Cyan, baseWidth / 4);
                cat.Symbolizer.ScaleMode = ScaleMode.Geographic;
                sgnScheme.AddCategory(cat);
            }

            ((MapPointLayer)Layer).Symbology = sgnScheme;
            ((MapPointLayer)Layer).ApplyScheme(sgnScheme);
        }

        /// <summary>
        /// Adds the properties to the map layer that are used to display the sign icons on the map.
        /// </summary>
        private void applySymbolizedProperty()
        {
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            DataTable data = selectionLayer.DataSet.DataTable;
            maxSuppID = 0;
            int idIncrementer = 1;
            string tamsidCollumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");
            foreach (DataRow row in data.Rows)
            {
                maxSuppID = Math.Max(Util.ToInt(row[tamsidCollumn].ToString()), maxSuppID);
            }
            foreach (DataRow row in data.Rows)
            {
                if (string.IsNullOrWhiteSpace(row[tamsidCollumn].ToString()) || row[tamsidCollumn].ToString().Contains("null") || (!row[tamsidCollumn].ToString().Contains("0") && Util.ToInt(row[tamsidCollumn].ToString()) == 0))
                {
                    row[tamsidCollumn] = maxSuppID + idIncrementer;
                    idIncrementer++;
                }
            }
            maxSuppID = idIncrementer + maxSuppID;
            var tmp = Database.GetDataByQuery(Project.conn, "SELECT MAX(TAMSID) FROM sign");
            maxSignID = tmp.Rows.Count > 0 ? Util.ToInt(tmp.Rows[0]["MAX(TAMSID)"].ToString()) : 0;

            selectionLayer.DataSet.DataTable = data;
            selectionLayer.DataSet.Save();
            selectionLayer.SelectAll();
            ISelection shpSelection = selectionLayer.Selection;
            DataTable selectionTable = shpSelection.ToFeatureSet().DataTable;
            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");
            string[] ts = { "TAMSSIGN" };
            if (selectionTable.Rows.Count == 0)
            {
                PrepareDatatable(selectionTable, ts);
                return;
            }
            selectionTable.DefaultView.Sort = tamsidcolumn + " asc";
            selectionTable = selectionTable.DefaultView.ToTable();
            PrepareDatatable(selectionTable, ts);
            string postSQL = SelectionSql.Replace("[[IDLIST]]", extractTAMSIDs(selectionTable));
            DataTable tamsTable = Database.GetDataByQuery(Project.conn, postSQL);
            tamsTable.DefaultView.Sort = "support_id asc";
            tamsTable = tamsTable.DefaultView.ToTable();
            for (int i = 0; i < selectionTable.Rows.Count; i++)
            {
                selectionTable.Rows[i]["TAMSSIGN"] = (i >= tamsTable.Rows.Count) ? "empty_post" : tamsTable.Rows[i]["category"];
            }
            selectionLayer.DataSet.DataTable = selectionTable; //Is this necessary?
        }

        /// <summary>
        /// Disables sign controls.
        /// </summary>
        private void disableSignDisplay(Panel_Sign signControls)
        {
            resetSaveCondition(signControls);
            signControls.groupBoxSupport.Enabled = false;
            signControls.groupBoxSign.Enabled = false;
            signControls.toolStripButtonSave.Enabled = false;
            signControls.toolStripButtonCancel.Enabled = false;
            signControls.toolStripButtonSurveyDate.Enabled = false;
            signControls.toolStripButtonNotes.Enabled = false;
            signControls.toolStripButtonRemove.Enabled = false;
        }

        /// <summary>
        /// Resets the save condition on the controls panel.
        /// </summary>
        private void resetSaveCondition(Panel_Sign signControls)
        {
            UnsavedChanges = false;
            
            signControls.toolStripButtonSave.Enabled = false;
            signControls.toolStripButtonSave.BackColor = default(Color);
        }

        protected void selectRecordDate(object sender, EventArgs e)
        {
            dateForm.Show();
            Panel_Sign signControls = getSignControls();
            signControls.setTodayToolStripMenuItem.Checked = false;
            signControls.setOtherDateToolStripMenuItem.Checked = true;
        }


        protected void resetRecordDate(object sender, EventArgs e)
        {
            surveyDate = DateTime.Now;
            Panel_Sign signControls = getSignControls();
            signControls.setTodayToolStripMenuItem.Checked = true;
            signControls.setOtherDateToolStripMenuItem.Checked = false;
        }

        override public void selectionChanged()
        {    
            if (!isOpen()) { return; }
            if (UnsavedChanges){}
            Panel_Sign signControls = getSignControls();

            resetSignDisplay(signControls);
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            ISelection shpSelection = selectionLayer.Selection;

            if (shpSelection.Count <= 0)
            {
                disableSignDisplay(signControls);
                return;
            }

            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");
            tamsids = new List<string>();
            foreach (DataRow row in selectionLayer.Selection.ToFeatureSet().DataTable.Rows)
            {
                tamsids.Add(row[tamsidcolumn].ToString());
            }

            enableControls(signControls);
            Dictionary<string, string> values = setSegmentValues(selectionLayer.Selection.ToFeatureSet().DataTable);
            updateSignDisplay(values, signControls);
            getSigns(signControls);
        }

        private void cancelChanges(object sender, EventArgs e)
        {
            resetSaveCondition(getSignControls());
            selectionChanged();
        }

        public void setMUTCDvalues(object sender, EventArgs e)
        {
            if (suppressChanges)
            {
                return;
            }
            Panel_Sign signControls = getSignControls();
            DataTable signValues = Database.GetDataByQuery(Project.conn, "SELECT * FROM mutcd_lookup WHERE mutcd_code = '" + signControls.textBoxType.Text + "';");
            if (signValues.Rows.Count == 1)
            {
                signChanges[signControls.comboBoxSigns.SelectedIndex]["category"] = signValues.Rows[0]["category"].ToString();
            }
            else {
                signChanges[signControls.comboBoxSigns.SelectedIndex]["category"] = "empty_post";
            }
            determinePostCat();
        }

        private void updateSignDisplay(Dictionary<string, string> values, Panel_Sign signControls)
        {
            suppressChanges = true;
            signControls.labelSurveyDate.Text = "As of " + Util.DictionaryItemString(values, "survey_date");
            signControls.textBoxAddress.Text = Util.DictionaryItemString(values, "address");
            signControls.comboBoxMaterial.Text = Util.DictionaryItemString(values, "material");
            signControls.comboBoxCondition.Text = Util.DictionaryItemString(values, "condition");
            signControls.comboBoxObstruction.Text = Util.DictionaryItemString(values, "obstructions");
            signControls.numericUpDownOffset.Value = (decimal)Util.ToDouble(Util.DictionaryItemString(values, "road_offset"));
            signControls.comboBoxRecommendation.Text = Util.DictionaryItemString(values, "recommendation");
            signControls.textBoxPhotoPost.Text = Util.DictionaryItemString(values, "photo");
            updatePhotoPreview(signControls.pictureBoxPost, signControls.textBoxPhotoPost.Text);
            notes = Util.DictionaryItemString(values, "notes");
            postCat = Util.DictionaryItemString(values, "category");
            if (!string.IsNullOrEmpty(notes))
            {
                signControls.toolStripButtonNotes.Checked = true;
            }
            suppressChanges = false;
        }

        /// <summary>
        /// Gets the table of signs associated with the selected sign support if only one sign support is selected.
        /// </summary>
        private void getSigns(Panel_Sign signControls)
        {
            signsOnPost = null;
            if (selectionValues.Count == 1)
            {
                signsOnPost = Database.GetDataByQuery(Project.conn, SignListSql.Replace("[[IDLIST]]", selectionValues[0]["support_id"]));

                clearSignChanges();

                //int i = 1;
                //foreach (DataRow row in signsOnPost.Rows)
                //{
                //    row["description"] = i.ToString() + ". " + row["description"];
                //    i++;    
                //}

                signControls.comboBoxSigns.Enabled = true;
                signControls.buttonAdd.Enabled = true;
                signControls.buttonRemove.Enabled = (signsOnPost.Rows.Count > 0);
                signControls.buttonFavorite.Enabled = (signsOnPost.Rows.Count > 0);
                signControls.toolStripButtonRemove.Enabled = (tamsids.Count == 1);
                signControls.comboBoxSigns.DataSource = signsOnPost;
                signControls.comboBoxSigns.DisplayMember = "AHHHH";//"description";
                signControls.comboBoxSigns.ValueMember = "TAMSID";

                clearSignChanges();
                changeSign(signControls);
                foreach (DataRow row in signsOnPost.Rows)
                {
                    row["description"] = row["description"].ToString().Remove(0, 3);
                }
                determinePostCat();
                
            }
            else
            {
                signControls.comboBoxSigns.Enabled = false;
                signControls.buttonAdd.Enabled = false;
                signControls.buttonRemove.Enabled = false;
                signControls.buttonFavorite.Enabled = false;
            }
        }

        private void changeSign(Panel_Sign signPanel)
        {
            if (signsOnPost == null || signsOnPost.Rows.Count == 0)
            {
                signPanel.groupBoxSign.Enabled = false;
                return;
            }
            signPanel.groupBoxSign.Enabled = true;
            suppressChanges = true;
            int index = signPanel.comboBoxSigns.SelectedIndex;
            signPanel.textBoxType.Text = signChanges[index]["mutcd_code"];
            signPanel.textBoxDescription.Text = signChanges[index]["description"];
            signPanel.comboBoxSheeting.Text = signChanges[index]["sheeting"];
            signPanel.comboBoxBacking.Text = signChanges[index]["backing"];
            signPanel.numericUpDownHeightSign.Value = (decimal)Util.ToDouble(signChanges[index]["height"]);
            signPanel.numericUpDownWidth.Value = (decimal)Util.ToDouble(signChanges[index]["width"]);
            signPanel.numericUpDownMountHeight.Value = (decimal)Util.ToDouble(signChanges[index]["mount_height"]);
            signPanel.textBoxInstall.Text = signChanges[index]["install_date"];
            signPanel.textBoxText.Text = signChanges[index]["sign_text"].ToString();
            signPanel.comboBoxReflectivity.Text = signChanges[index]["reflectivity"];
            signPanel.comboBoxConditionSign.Text = signChanges[index]["condition"];
            signPanel.comboBoxDirection.Text = signChanges[index]["direction"];
            signPanel.textBoxPhotoFile.Text = signChanges[index]["photo"];
            signPanel.buttonFavorite.BackColor = signChanges[index]["favorite"].Contains("true") ? Color.DeepPink : Control.DefaultBackColor;
            suppressChanges = false;
            updatePhotoPreview(signPanel.pictureBoxPhoto, signPanel.textBoxPhotoFile.Text);
        }

        /// <summary>
        /// sets the values in sign changes to the original values from the sign database.
        /// </summary>
        private void clearSignChanges()
        {
            signChanges = new List<Dictionary<string, string>>();
            for (int i = 0; i < signsOnPost.Rows.Count; i++)
            {
                signChanges.Add(new Dictionary<string, string>());
                foreach (DataColumn col in signsOnPost.Columns)
                {
                    signChanges[i][col.ColumnName] = signsOnPost.Rows[i][col.ColumnName].ToString();
                }
            }
        }

        /// <summary>
        /// activates the controls when a sign is selected.
        /// </summary>
        private void enableControls(Panel_Sign signControls)
        {
            signControls.groupBoxSign.Enabled = true;
            signControls.toolStrip.Enabled = true;
            signControls.groupBoxSupport.Enabled = true;
            signControls.toolStripButtonSurveyDate.Enabled = true;
            signControls.toolStripButtonNotes.Enabled = true;
        }

        /// <summary>
        /// resests the sign control panel back to blank values.
        /// </summary>
        private void resetSignDisplay(Panel_Sign signControls)
        {
            suppressChanges = true;
            signControls.labelSurveyDate.Text = "";
            signControls.textBoxAddress.Text = "";
            signControls.comboBoxMaterial.SelectedIndex = 0;
            signControls.comboBoxCondition.SelectedIndex = 0;
            signControls.comboBoxObstruction.Text = "";
            signControls.numericUpDownOffset.Value = 0;
            signControls.comboBoxRecommendation.Text = "";
            signControls.comboBoxSigns.Text = "";
            signControls.textBoxType.Text = "";
            signControls.textBoxDescription.Text = "";
            signControls.comboBoxSheeting.SelectedIndex = 0;
            signControls.comboBoxBacking.SelectedIndex = 0;
            signControls.numericUpDownWidth.Value = 0;
            signControls.numericUpDownHeightSign.Value = 0;
            signControls.numericUpDownMountHeight.Value = 0;
            signControls.textBoxInstall.Text = "";
            signControls.textBoxText.Text = "";
            signControls.comboBoxReflectivity.SelectedIndex = 0;
            signControls.comboBoxDirection.SelectedIndex = 0;
            signControls.comboBoxConditionSign.SelectedIndex = 0;
            signControls.textBoxPhotoFile.Text = "";
            signControls.textBoxPhotoPost.Text = "";
            signControls.pictureBoxPhoto.Image = null;
            signControls.pictureBoxPost.Image = null;
            signControls.pictureBoxPhoto.ImageLocation = null;
            signControls.pictureBoxPost.ImageLocation = null;
            suppressChanges = false;
            signControls.labelAddress.ForeColor = default(Color);
            signControls.labelAddress.BackColor = default(Color);
            signControls.textBoxAddress.Enabled = true;
            signControls.toolStripButtonNotes.Checked = true;
            signControls.labelAddress.Text = "Address";
            signControls.buttonFavorite.BackColor = Control.DefaultBackColor;
        }

        protected override void clearControlPanel()
        {
            ControlsPage.Controls.Remove(ControlsPage.Controls["SIGNCONTROLS"]);
            Panel_Module_OpenShp signAdd = new Panel_Module_OpenShp("Sign");
            signAdd.Name = "SIGNADD";
            signAdd.SetHandler(new EventHandler(openFileHandler));
            Button createSigns = new Button();
            createSigns.Text = "Create Sign SHP File";
            createSigns.Size = new Size(196, 54);
            createSigns.Location = new Point(10, 74);
            signAdd.Controls.Add(createSigns);
            signAdd.Dock = DockStyle.Fill;
            ControlsPage.Controls.Add(signAdd);
        }

        public void signValueChanged(object sender, EventArgs e)
        {
            if (suppressChanges) return;
            Panel_Sign signControls = getSignControls();
            int index = signControls.comboBoxSigns.SelectedIndex;
            if (index == -1) return;
            signChanges[index]["mutcd_code"] = signControls.textBoxType.Text;
            signChanges[index]["sheeting"] = signControls.comboBoxSheeting.Text;
            signChanges[index]["backing"] = signControls.comboBoxBacking.Text;
            signChanges[index]["condition"] = signControls.comboBoxConditionSign.Text;
            signChanges[index]["height"] = signControls.numericUpDownHeightSign.Value.ToString();
            signChanges[index]["width"] = signControls.numericUpDownWidth.Value.ToString();
            signChanges[index]["mount_height"] = signControls.numericUpDownMountHeight.Value.ToString();
            signChanges[index]["sign_text"] = signControls.textBoxText.Text;
            signChanges[index]["survey_date"] = Util.SortableDate(surveyDate);
            signChanges[index]["photo"] = signControls.textBoxPhotoFile.Text;
            signChanges[index]["reflectivity"] = signControls.comboBoxReflectivity.Text;
            signChanges[index]["description"] = signControls.textBoxDescription.Text;
            signChanges[index]["install_date"] = signControls.textBoxInstall.Text;
            signChanges[index]["direction"] = signControls.comboBoxDirection.Text;
            var result = Database.GetDataByQuery(Project.conn, "SELECT category FROM mutcd_lookup WHERE mutcd_code = '" + signControls.textBoxType.Text + "';");
            signChanges[index]["category"] = result.Rows.Count > 0 ? result.Rows[0]["category"].ToString() : "empty_post";

        }

        public void determinePostCat()
        {
            postCat = "empty_post";
            if (signsOnPost == null || signsOnPost.Rows.Count == 0)return;
            postCat = signChanges[0]["category"];
            for (int i = 0; i < signChanges.Count; i++)
            {
                if (catRank[postCat] > catRank[signChanges[i]["category"]])
                {
                    postCat = signChanges[i]["category"];
                }
            }
        }

        public void signChangeHandler(object sender, EventArgs e)
        {
            changeSign(getSignControls());
        }

        public void saveHandler(object sender, EventArgs e)
        {
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            ISelection shpSelection = selectionLayer.Selection;
            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");

            Panel_Sign signControls = getSignControls();
            Dictionary<string, string> values = new Dictionary<string, string>();
            values["survey_date"] = Util.SortableDate(surveyDate);
            values["address"] = signControls.textBoxAddress.Text;
            values["material"] = signControls.comboBoxMaterial.Text;
            values["condition"] = signControls.comboBoxCondition.Text;
            values["obstructions"] = signControls.comboBoxObstruction.Text;
            values["road_offset"] = signControls.numericUpDownOffset.Value.ToString();
            values["recommendation"] = signControls.comboBoxRecommendation.Text;
            values["photo"] = signControls.textBoxPhotoPost.Text;
            values["notes"] = notes;
            values["category"] = postCat;

            if (signsOnPost != null && signsOnPost.Rows.Count > 0)
            {
                for (int i = 0; i < signChanges.Count; i++)
                {
                    if (!Database.ReplaceRow(Project.conn, signChanges[i], ModuleName))
                    {
                        MessageBox.Show("Could not save data!");
                    }
                }
                if (!string.IsNullOrWhiteSpace(postCat))
                {
                    string tamsidsCSV = string.Join(",", tamsids.ToArray());
                    foreach (DataRow row in selectionLayer.DataSet.DataTable.Select(tamsidcolumn + " IN (" + tamsidsCSV + ")"))
                    {
                        row["TAMSSIGN"] = postCat;
                        if (!string.IsNullOrWhiteSpace(Project.settings.GetValue("sign_f_address")))
                        {
                            row[Project.settings.GetValue("sign_f_address")] = values["address"];
                        }
                        if (!string.IsNullOrWhiteSpace(Project.settings.GetValue("sign_f_offset")))
                        {
                            row[Project.settings.GetValue("sign_f_offset")] = values["road_offset"];
                        }
                    }
                }
            }

            for (int i = 0; i < tamsids.Count; i++)
            {
                values["support_id"] = tamsids[i];
                Dictionary<string, string> v = new Dictionary<string, string>();

                foreach (string key in values.Keys)
                {
                    v[key] = values[key];
                    if ((string.IsNullOrWhiteSpace(values[key]) || values[key].Equals("multi") || values[key].Equals("-1") || key.Equals("category")) && selectionValues.Count > 1)
                    {
                        if (i < selectionValues.Count && selectionValues[i].ContainsKey(key))
                        {
                            v[key] = selectionValues[i][key];
                        }
                    }
                }

                if (!Database.ReplaceRow(Project.conn, v, ModuleName + "_support"))
                {
                    MessageBox.Show("Could not save data!");
                }
            }
            
            resetSaveCondition(signControls);
            
            Properties.Settings.Default.Save();
            selectionLayer.ClearSelection();
            selectionLayer.DataSet.Save();
            setSymbolizer();
            Project.map.Invalidate();
            Project.map.Refresh();
            Project.map.ResetBuffer();
            Project.map.Update();
        }

        private void searchMUTCDclick(object sender, EventArgs e)
        {
            Dictionary<string, string> results = searchMUTCDlist();
            if (results != null)
            {
                getSignControls().textBoxType.Text = results["mutcd_code"];
                getSignControls().textBoxDescription.Text = results["description"];
            }
        }

        private void addNewSign(object sender, EventArgs e)
        {
            FormNewSign newSignForm = new FormNewSign();
            Panel_Sign signControls = getSignControls();
            if (newSignForm.ShowDialog() == DialogResult.OK)
            {
                if (newSignForm.radioButtonMUTCD.Checked)
                {
                    Dictionary<string, string> newSign = searchMUTCDlist();
                    if (newSign != null)
                    {
                        maxSignID++;
                        newSign["TAMSID"] = maxSignID.ToString();
                        newSign["support_id"] = tamsids[0];
                        Database.ReplaceRow(Project.conn, newSign, "sign");
                        getSigns(signControls);
                        signControls.comboBoxSigns.SelectedIndex = signControls.comboBoxSigns.Items.Count - 1;
                        changeSign(signControls);
                        determinePostCat();
                    }
                }
                else if (newSignForm.radioButtonFavorites.Checked)
                {
                    FormSignLookup fave = new FormSignLookup();
                    DataTable favorites = Database.GetDataByQuery(Project.conn, "SELECT * FROM sign WHERE favorite='true'");
                    if (favorites.Rows.Count == 0)
                    {
                        MessageBox.Show("You cannot create a sign from favorites because you have no favorite signs.", "No Favorite Signs");
                        return;
                    }
                    fave.setData(favorites);
                    if (fave.ShowDialog() == DialogResult.OK)
                    {
                        Dictionary<string, string> newSign = fave.getSelection();
                        if (newSign != null)
                        {
                            maxSignID++;
                            newSign["TAMSID"] = maxSignID.ToString();
                            newSign["support_id"] = tamsids[0];
                            newSign["condition"] = "";
                            newSign["reflectivity"] = "";
                            newSign["install_date"] = "";
                            newSign["survey_date"] = Util.SortableDate(surveyDate);
                            newSign["photo"] = "";
                            newSign["barcode"] = "";
                            newSign["favorite"] = "false";
                            Database.ReplaceRow(Project.conn, newSign, "sign");
                            getSigns(signControls);
                            signControls.comboBoxSigns.SelectedIndex = signControls.comboBoxSigns.Items.Count - 1;
                            changeSign(signControls);
                            determinePostCat();
                        }
                    }
                }
                else if (newSignForm.radioButtonBlank.Checked)
                {
                    maxSignID++;
                    Dictionary<string, string> newSign = new Dictionary<string, string>()
                    {
                        {"TAMSID", maxSignID.ToString() },
                        {"description", "new sign" },
                        {"support_id", tamsids[0] },
                        {"category", "empty_post" }
                    };
                    Database.ReplaceRow(Project.conn, newSign, "sign");
                    getSigns(signControls);
                    signControls.comboBoxSigns.SelectedIndex = signControls.comboBoxSigns.Items.Count - 1;
                    changeSign(signControls);
                }
                controlChanged(sender, e);
            }
            newSignForm.Close();
        }

        private void removeSign(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to delete a sign from this post, this action cannot be undone.", "Warning: Delete Sign", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                return;
            }
            Panel_Sign signControls = getSignControls();
            int index = signControls.comboBoxSigns.SelectedIndex;
            if (signChanges[index]["favorite"].Contains("true"))
            {
                signChanges[index]["support_id"] = "-2";
                Database.UpdateRow(Project.conn, signChanges[index], "sign", "TAMSID", signChanges[index]["TAMSID"]);
            }
            else
            {
                Database.DeleteRow(Project.conn, "sign", "TAMSID", signChanges[index]["TAMSID"]);
            }
            getSigns(signControls);
            changeSign(signControls);
            determinePostCat();
            controlChanged(sender, e);
        }

        private void faveSign(object sender, EventArgs e)
        {
            Panel_Sign signControls = getSignControls();
            int index = signControls.comboBoxSigns.SelectedIndex;
            signChanges[index]["favorite"] = signChanges[index]["favorite"].Contains("true") ? "false" : "true";
            signControls.buttonFavorite.BackColor = signChanges[index]["favorite"].Contains("true") ? Color.Pink : Control.DefaultBackColor;
            controlChanged(sender, e);
        }

        private void addPost(double lat, double lon)
        {
            MapPointLayer mpl = (MapPointLayer)Layer;
            double[] xy = { lon, lat};
            double[] z = { 0 };
            DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984, mpl.Projection, 0, 1);
            DotSpatial.Topology.Point newPost = new DotSpatial.Topology.Point(xy[0], xy[1]);
            IFeature np = mpl.DataSet.AddFeature(newPost);
            maxSuppID++;
            if (!np.DataRow.Table.Columns.Contains("FID"))
            {
                np.DataRow.Table.Columns.Add("FID");
            }
            if (!np.DataRow.Table.Columns.Contains(Project.settings.GetValue(ModuleName + "_f_TAMSID"))) {
                np.DataRow.Table.Columns.Add(Project.settings.GetValue(ModuleName + "_f_TAMSID"));
            }
            if (!np.DataRow.Table.Columns.Contains("TAMSSIGN"))
            {
                np.DataRow.Table.Columns.Add("TAMSSIGN");
            }
            if (!np.DataRow.Table.Columns.Contains(Project.settings.GetValue("sign_f_address")))
            {
                np.DataRow.Table.Columns.Add(Project.settings.GetValue("sign_f_address"));
            }
            if (!np.DataRow.Table.Columns.Contains(Project.settings.GetValue("sign_f_offset")))
            {
                np.DataRow.Table.Columns.Add(Project.settings.GetValue("sign_f_offset"));
            }
            np.DataRow["FID"] = maxSuppID;
            np.DataRow[Project.settings.GetValue(ModuleName + "_f_TAMSID")] = maxSuppID;
            np.DataRow["TAMSSIGN"] = "empty_post";
            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                {"support_id", maxSuppID.ToString() },
                {"category", "empty_post" }
            };
            Database.ReplaceRow(Project.conn, values, "sign_support");
            mpl.DataSet.Save();
            mpl.ClearSelection();
            setSymbolizer();
            Project.map.Invalidate();
            Project.map.Refresh();
            Project.map.ResetBuffer();
            Project.map.Update();
            if (mpl.DataSet.NumRows() == 1)
            {
                mpl.Extent.SetValues(xy[0] - 100, xy[1] - 100, xy[0] + 100, xy[1] + 100);
                Project.map.ViewExtents = mpl.Extent;
            }
        }

        private void enterCoordinates(object sender, EventArgs e)
        {
            FormLatLon dlg = new FormLatLon();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                double lat, lon;
                if (dlg.tabControlDegree.SelectedTab == dlg.tabPageDecimal)
                {
                    lat = Util.ToDouble(dlg.textBoxLatitude.Text) * (dlg.radioButtonNorth1.Checked? 1 : -1);
                    lon = Util.ToDouble(dlg.textBoxLongitude.Text) * (dlg.radioButtonEast1.Checked ? 1 : -1);
                }
                else
                {
                    lat = (Util.ToDouble(dlg.textBoxLatDeg.Text) + Util.ToDouble(dlg.textBoxLatMin.Text)/60 + Util.ToDouble(dlg.textBoxLatSec.Text)/3600) * (dlg.radioButtonNorth2.Checked ? 1 : -1);
                    lon = (Util.ToDouble(dlg.textBoxLonDeg.Text) + Util.ToDouble(dlg.textBoxLonMin.Text)/60 + Util.ToDouble(dlg.textBoxLonSec.Text)/3600) * (dlg.radioButtonEast2.Checked ? 1 : -1);
                }
                addPost(lat, lon);
            }
            dlg.Close();
        }

        /// <summary>
        /// Brings up a form to allow the user to search for signs.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> searchMUTCDlist()
        {
            FormSignLookup mutcd = new FormSignLookup();
            Dictionary<string, string> returnValue = null;
            mutcd.setData(Database.GetDataByQuery(Project.conn, "SELECT * FROM mutcd_lookup"));
            if (mutcd.ShowDialog() == DialogResult.OK)
            {
                returnValue = mutcd.getSelection();
            }
            mutcd.Close();
            return returnValue;
        }

        private void editNotes(object sender, EventArgs e)
        {
            FormNotes noteForm = new FormNotes();
            noteForm.Value = notes;
            DialogResult result = noteForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                controlChanged(sender, e);

                notes = noteForm.Value;
            }
            noteForm.Close();
        }

        private void signNote(object sender, EventArgs e)
        {
            FormNotes noteForm = new FormNotes();
            noteForm.Value = signChanges[getSignControls().comboBoxSigns.SelectedIndex]["notes"];
            DialogResult result = noteForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                controlChanged(sender, e);

                signChanges[getSignControls().comboBoxSigns.SelectedIndex]["notes"] = noteForm.Value;
            }
            noteForm.Close();
        }

        private void clickManageFavorites(object sender, EventArgs e)
        {
            FormManageFavorites faves = new FormManageFavorites(Project.conn, maxSignID);
            faves.ShowDialog();
            maxSignID += faves.virtualSignsCreated();
        }

        /// <summary>
        /// Generates a list of all signs to export to .csv file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateReport(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data.Columns.Add("ID");
            data.Columns.Add("Sign");
            data.Columns.Add("Address");
            data.Columns.Add("Installed");
            data.Columns.Add("Sheeting");
            data.Columns.Add("Backing");
            data.Columns.Add("Reflectivity");
            data.Columns.Add("Condition");
            data.Columns.Add("Recommendation");
            try
            {
                DataTable signsTable = Database.GetDataByQuery(Project.conn, "SELECT sign.*, sign_support.address FROM sign LEFT JOIN sign_support ON sign.support_id = sign_support.support_id");
                if (signsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no signs where found.");
                    return;
                }
                foreach (DataRow row in signsTable.Rows)
                {
                    DataRow nr = data.NewRow();
                    nr["ID"] = row["TAMSID"].ToString();
                    nr["Sign"] = row["description"].ToString();
                    nr["Address"] = row["address"].ToString();
                    nr["Installed"] = row["install_date"].ToString();
                    nr["Sheeting"] = row["sheeting"].ToString();
                    nr["Backing"] = row["backing"].ToString();
                    nr["Reflectivity"] = row["reflectivity"].ToString();
                    nr["Condition"] = row["condition"].ToString();
                    int age = DateTime.Now.Year - Util.ToInt(row["install_date"].ToString().Split('-')[0]);
                    nr["Recommendation"] = "";
                    
                    data.Rows.Add(nr);
                }
                data.DefaultView.Sort = "Address asc, ID asc, Installed asc";
                FormOutput report = new FormOutput();
                report.dataGridViewReport.DataSource = data.DefaultView.ToTable();
                report.Text = "Sign Report";
                report.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show("An error occured while trying to generate the report.");
                Log.Error("Report failed to generate." + Environment.NewLine + err.ToString());
            }
        }

        /// <summary>
        /// Show only signs that have faild the reflectivity tests.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void failedReport(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data.Columns.Add("ID");
            data.Columns.Add("Sign");
            data.Columns.Add("Address");
            data.Columns.Add("Installed");
            data.Columns.Add("Sheeting");
            data.Columns.Add("Backing");
            data.Columns.Add("Reflectivity");
            data.Columns.Add("Condition");
            data.Columns.Add("Comment");
            try
            {
                DataTable signsTable = Database.GetDataByQuery(Project.conn, "SELECT sign.*, sign_support.address FROM sign LEFT JOIN sign_support ON sign.support_id = sign_support.support_id");
                if (signsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no signs that require attention could be found.");
                    return;
                }
                signsTable = signsTable.Select("condition = 'damaged' OR condition='other' OR reflectivity='fail'").CopyToDataTable();
                if (signsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no signs that require attention could be found.");
                    return;
                }
                foreach (DataRow row in signsTable.Rows)
                {
                    DataRow nr = data.NewRow();
                    nr["ID"] = row["TAMSID"].ToString();
                    nr["Sign"] = row["description"].ToString();
                    nr["Address"] = row["address"].ToString();
                    nr["Installed"] = row["install_date"].ToString();
                    nr["Sheeting"] = row["sheeting"].ToString();
                    nr["Backing"] = row["backing"].ToString();
                    nr["Reflectivity"] = row["reflectivity"].ToString();
                    nr["Condition"] = row["notes"].ToString();
                    int age = DateTime.Now.Year - Util.ToInt(row["install_date"].ToString().Split('-')[0]);
                    data.Rows.Add(nr);
                }
                data.DefaultView.Sort = "Address asc, ID asc, Installed asc";
                FormOutput report = new FormOutput();
                report.dataGridViewReport.DataSource = data.DefaultView.ToTable();
                report.Text = "Sign Report";
                report.Show();
            }
            catch (Exception err)
            {
                ReportErrMsg(err);
            }
        }

        /// <summary>
        /// lists only signs that are at least partially obstructed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void obstructedReport(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data.Columns.Add("ID");
            data.Columns.Add("Sign");
            data.Columns.Add("Address");
            data.Columns.Add("Installed");
            data.Columns.Add("Sheeting");
            data.Columns.Add("Backing");
            data.Columns.Add("Obstructions");
            data.Columns.Add("Recommendation");
            try
            {
                DataTable signsTable = Database.GetDataByQuery(Project.conn, "SELECT sign.*, sign_support.address FROM sign LEFT JOIN sign_support ON sign.support_id = sign_support.support_id");
                if (signsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no obstructed signs were found.");
                    return;
                }
                foreach (DataRow row in signsTable.Rows)
                {
                    DataRow nr = data.NewRow();
                    nr["ID"] = row["TAMSID"].ToString();
                    nr["Sign"] = row["description"].ToString();
                    nr["Address"] = row["address"].ToString();
                    nr["Installed"] = row["install_date"].ToString();
                    nr["Sheeting"] = row["sheeting"].ToString();
                    nr["Backing"] = row["backing"].ToString();
                    nr["Obstructions"] = row["obstructions"].ToString();
                    if (nr["Obstructions"].ToString().Contains("partial") || nr["Obstructions"].ToString().Contains("severe"))
                    {
                        nr["Recommendation"] = "remove obstructions";
                        data.Rows.Add(nr);
                    }
                }
                data.DefaultView.Sort = "Address asc, ID asc, Installed asc";
                FormOutput report = new FormOutput();
                report.dataGridViewReport.DataSource = data.DefaultView.ToTable();
                report.Text = "Sign Report";
                report.Show();
            }
            catch (Exception err)
            {
                ReportErrMsg(err);
            }
        }

        /// <summary>
        /// Show only signs that are considered old based, on the expected life sheeting type.
        /// Old signs may still be servicable as long as they meet the reflectity guidelines.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oldSignsReport(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data.Columns.Add("ID");
            data.Columns.Add("Sign");
            data.Columns.Add("Address");
            data.Columns.Add("Installed");
            data.Columns.Add("Sheeting");
            data.Columns.Add("Backing");
            data.Columns.Add("Reflectivity");
            data.Columns.Add("Recommendation");
            try
            {
                DataTable signsTable = Database.GetDataByQuery(Project.conn, "SELECT sign.*, sign_support.address FROM sign LEFT JOIN sign_support ON sign.support_id = sign_support.support_id");
                if (signsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no signs that were old or of unknown age were found.");
                    return;
                }
                foreach (DataRow row in signsTable.Rows)
                {
                    DataRow nr = data.NewRow();
                    nr["ID"] = row["TAMSID"].ToString();
                    nr["Sign"] = row["description"].ToString();
                    nr["Address"] = row["address"].ToString();
                    nr["Installed"] = row["install_date"].ToString();
                    nr["Sheeting"] = row["sheeting"].ToString();
                    nr["Backing"] = row["backing"].ToString();
                    nr["Reflectivity"] = row["reflectivity"].ToString();
                    int age = DateTime.Now.Year - Util.ToInt(row["install_date"].ToString().Split('-')[0]);
                    nr["Recommendation"] = "monitor";
                    if (nr["Reflectivity"].ToString().Contains("fail"))
                    {
                        nr["Recommendation"] = "replace sign";
                    }
                    if ((age > 5 && (nr["Sheeting"].ToString().Equals("I") || nr["Sheeting"].ToString().Equals("V"))) || age > 9)
                    {
                        data.Rows.Add(nr);
                    }
                }
                data.DefaultView.Sort = "Address asc, ID asc, Installed asc";
                FormOutput report = new FormOutput();
                report.dataGridViewReport.DataSource = data.DefaultView.ToTable();
                report.Text = "Sign Report";
                report.Show();
            }
            catch (Exception err)
            {
                ReportErrMsg(err);
            }
        }

        /// <summary>
        /// Shows only signs that are damaged.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brokenReport(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data.Columns.Add("ID");
            data.Columns.Add("Sign");
            data.Columns.Add("Address");
            data.Columns.Add("Installed");
            data.Columns.Add("Sheeting");
            data.Columns.Add("Backing");
            data.Columns.Add("Condition");
            data.Columns.Add("Recommendation");
            try
            {
                DataTable signsTable = Database.GetDataByQuery(Project.conn, "SELECT sign.*, sign_support.address FROM sign LEFT JOIN sign_support ON sign.support_id = sign_support.support_id");
                if (signsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no damaged signs were found.");
                    return;
                }
                foreach (DataRow row in signsTable.Rows)
                {
                    DataRow nr = data.NewRow();
                    nr["ID"] = row["TAMSID"];
                    nr["Sign"] = row["description"];
                    nr["Address"] = row["address"];
                    nr["Installed"] = row["install_date"];
                    nr["Sheeting"] = row["sheeting"];
                    nr["Backing"] = row["backing"];
                    nr["Condition"] = row["condition"];
                    if (!nr["Condition"].ToString().Contains("broken") && !nr["Condition"].ToString().Contains("damaged"))
                    {
                        continue;
                    }
                    if (nr["Condition"].ToString().Contains("broken"))
                    {
                        nr["Recommendation"] = "replace";
                    }
                    else
                    {
                        nr["Recommendaiton"] = "";
                    }
                    data.Rows.Add(nr);
                }
                data.DefaultView.Sort = "Address asc, ID asc, Installed asc";
                FormOutput report = new FormOutput();
                report.dataGridViewReport.DataSource = data.DefaultView.ToTable();
                report.Text = "Sign Report";
                report.Show();
            }
            catch (Exception err)
            {
                ReportErrMsg(err);
            }
        }

        private void supportReport(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data.Columns.Add("ID");
            data.Columns.Add("Address");
            data.Columns.Add("Signs");
            data.Columns.Add("Material");
            data.Columns.Add("Condition");
            data.Columns.Add("Obstructions");
            data.Columns.Add("Comment");
            try
            {
                DataTable supportTable = Database.GetDataByQuery(Project.conn, "SELECT * FROM sign_support");
                foreach (DataRow row in supportTable.Rows)
                {
                    DataRow nr = data.NewRow();
                    nr["ID"] = row["support_id"];
                    nr["Addres"] = row["address"];
                    nr["signs"] = Database.GetDataByQuery(Project.conn, "SELECT COUNT(suppord_id) FROM sign WHERE support_id = " + nr["ID"].ToString() + ";");
                    nr["Material"] = row["material"];
                    nr["Condtion"] = row["condition"];
                    nr["Obstructions"] = row["obstructions"];
                    data.Rows.Add(nr);
                }
                data.DefaultView.Sort = "Address asc, ID asc, Installed asc";
                FormOutput report = new FormOutput();
                report.dataGridViewReport.DataSource = data.DefaultView.ToTable();
                report.Text = "Support Report";
                report.Show();
            }
            catch (Exception err)
            {
                ReportErrMsg(err);
            }
        }

        private void supportAttention(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data.Columns.Add("ID");
            data.Columns.Add("Address");
            data.Columns.Add("Signs");
            data.Columns.Add("Material");
            data.Columns.Add("Condition");
            data.Columns.Add("Obstructions");
            data.Columns.Add("Comment");
            try
            {
                DataTable supportTable = Database.GetDataByQuery(Project.conn, "SELECT * FROM sign_support");
                if (supportTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no signs that require attention could be found.");
                    return;
                }
                supportTable = supportTable.Select("condition = 'damaged' OR condition='other' OR reflectivity='fail'").CopyToDataTable();
                if (supportTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no signs that require attention could be found.");
                    return;
                }
                foreach (DataRow row in supportTable.Rows)
                {
                    DataRow nr = data.NewRow();
                    nr["ID"] = row["support_id"];
                    nr["Addres"] = row["address"];
                    nr["signs"] = Database.GetDataByQuery(Project.conn, "SELECT COUNT(suppord_id) FROM sign WHERE support_id = " + nr["ID"].ToString() + ";");
                    nr["Material"] = row["material"];
                    nr["Condtion"] = row["condition"];
                    nr["Obstructions"] = row["obstructions"];
                    data.Rows.Add(nr);
                }
                data.DefaultView.Sort = "Address asc, ID asc, Installed asc";
                FormOutput report = new FormOutput();
                report.dataGridViewReport.DataSource = data.DefaultView.ToTable();
                report.Text = "Support Report";
                report.Show();
            }
            catch (Exception err)
            {
                ReportErrMsg(err);
            }
        }

        private void clickPhotoBox(object sender, EventArgs e)
        {
            Panel_Sign signControls = getSignControls();
            enlargePicture(signControls.textBoxPhotoFile.Text);
        }

        private void clickPostPhotoBox(object sender, EventArgs e)
        {
            Panel_Sign signControls = getSignControls();
            enlargePicture(signControls.textBoxPhotoPost.Text);
        }

        private void clickMap(object sender, EventArgs e)
        {
            if (inClick)
            {
                return;
            }
            bool hasStreetMap = false;
            for (int i = 0; i < Project.map.Layers.Count; i++)
            {
                if (((FeatureLayer)Project.map.Layers[i]).Name.Contains("road"))
                {
                    hasStreetMap = true;
                }
            }
            if (Project.map.GetMaxExtent().IsEmpty() || (Layer.Extent.IsEmpty() && !hasStreetMap))
            {
                MessageBox.Show("Map has no view extent, please open a road SHP file or add sign support by coordinates.", "No view extent", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Project.map.Click += addPostByClick;
        }

        private void addPostByClick(object sender, EventArgs e)
        {
            var clickCoords = Project.map.PixelToProj(Project.map.PointToClient(Cursor.Position));
            double[] xy = { clickCoords.X, clickCoords.Y };
            double[] z = { clickCoords.Z};
            DotSpatial.Projections.Reproject.ReprojectPoints(xy, z, Project.map.Projection, DotSpatial.Projections.KnownCoordinateSystems.Geographic.World.WGS1984, 0, 1);
            inClick = false;
            if (double.IsInfinity(xy[0]) || double.IsInfinity(xy[1]))
            {
                MessageBox.Show("There appears to be a problem with the projection of your shapefile. Consider reprojecting your shapefiles using ArcMap or MapWindow.");
                Log.Error("Coordinate is Infinity or NaN " + Environment.NewLine + Environment.StackTrace);
            }
            try
            {
                addPost(xy[1], xy[0]);
            }
            catch (Exception err)
            {
                Log.Error("something went terribly wrong: " + err.ToString());
            }
            Project.map.Click -= addPostByClick;
        }

        private void deletePost(object sender, EventArgs e)
        {
            string[] tables = { "sign_support", ModuleName };
            deleteShape(tamsids[0], tables, "support_id");
        }
    }
}
