using DotSpatial.Controls;
using DotSpatial.Symbology;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tams4a.Controls;

namespace tams4a.Classes
{
    class ModuleSigns : ProjectModule {

        
        private string notes;
        private int maxSuppID;
        private int maxSignID;
        private DataTable signsOnPost;

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
            createSigns.Size = new System.Drawing.Size(196, 54);
            createSigns.Location = new System.Drawing.Point(10, 74);
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
        }

        public override bool openFile(string thePath = "", string type = "point")
        {
            if (type == "") { type = "point";}
            if (type != "point") { throw new Exception("Signs module requires a point-type shp file"); }

            #region signSettings
            ModuleSettings.Add(new ProjectSetting(name: ModuleName + "_f_TAMSID", module: ModuleName, value: "",
                    display_text: "SHP field with a unique identifier.", display_type: "field",
                    description: "Show an Icon instead of a basic shape for sign locations.", required:true));
            ModuleSettings.Add(new ProjectSetting(name: "sign_offset", module: ModuleName, value: "",
                    display_text: "SHP field with offset from road?", display_type: "field",
                    description: "The field in the sign shp file indicating the distance of the support from the road."));
            ModuleSettings.Add(new ProjectSetting(name: "sign_address", module: ModuleName, value: "",
                    display_text: "SHP field with sign address?", display_type: "field",
                    description: "The field in the sign shp file containing the approximate address of the signpost."));
            //ModuleSettings.Add(new ProjectSetting(name: "sign_icons", module: ModuleName, value: "true",
            //        display_text: "Show Icons?", display_type: "bool",
            //        description: "Show an Icon instead of a basic shape for sign locations?"));
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
            signPanel.toolStripButtonSave.Click += selectionChanged;

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

            applySymbolizedProperty();
            setSymbolizer();
            disableSignDisplay();

            return true;
        }

        protected override void controlChanged(object sender, EventArgs e)
        {
            Panel_Sign signPanel = getSignControls();
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
                        // make a copy in the correct location of anything we DO need
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
        private void setSymbolizer()
        {
            int baseWidth = 32;

            PointScheme sgnScheme = new PointScheme();
            
            PointCategory catDef = new PointCategory(Properties.Resources.empty_post, baseWidth);
            catDef.LegendText = "No Sign Info";
            catDef.SelectionSymbolizer.ScaleMode = ScaleMode.Geographic;
            catDef.SelectionSymbolizer.SetOutline(Color.Cyan, baseWidth / 4);
            catDef.Symbolizer.ScaleMode = ScaleMode.Geographic;
            sgnScheme.AddCategory(catDef);

            Image[] images = { Properties.Resources.regulatory_rw, Properties.Resources.regulatory_bw, Properties.Resources.warning, Properties.Resources.regulatory_pedestrian, Properties.Resources.school_pedestrian, Properties.Resources.worker, Properties.Resources.rail, Properties.Resources.highway, Properties.Resources.locational, Properties.Resources.service, Properties.Resources.recreation, Properties.Resources.empty_post};
            string[] signCats = { "regulatory_rw", "regulatory_bw", "warning", "regulatory_pedestrian", "school_pedestrian", "worker", "rail", "highway", "locational", "service", "recreation", "empty_post"};

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
                if (string.IsNullOrWhiteSpace(row[tamsidCollumn].ToString()) || row[tamsidCollumn].ToString().Contains("null") || row[tamsidCollumn].ToString().Contains("*"))
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
            selectionTable.DefaultView.Sort = tamsidcolumn + " asc";
            selectionTable = selectionTable.DefaultView.ToTable();
            if (!selectionTable.Columns.Contains("TAMSSIGN"))
            {
                selectionTable.Columns.Add("TAMSSIGN");
            }
            string postSQL = SelectionSql.Replace("[[IDLIST]]", extractTAMSIDs(selectionTable));
            DataTable tamsTable = Database.GetDataByQuery(Project.conn, postSQL);
            tamsTable.DefaultView.Sort = "support_id asc";
            tamsTable = tamsTable.DefaultView.ToTable();
            for (int i = 0; i < selectionTable.Rows.Count; i++)
            {
                selectionTable.Rows[i]["TAMSSIGN"] = i >= tamsTable.Rows.Count ? "empty_post" : tamsTable.Rows[i]["category"];
            }
            selectionLayer.DataSet.DataTable = selectionTable;
        }

        /// <summary>
        /// Disables road controls.
        /// </summary>
        private void disableSignDisplay()
        {
            Panel_Sign signControls = getSignControls();
            resetSaveCondition();
            signControls.groupBoxSupport.Enabled = false;
            signControls.groupBoxSign.Enabled = false;
            signControls.toolStrip.Enabled = false;
        }

        /// <summary>
        /// Resets the save condition on the controls panel.
        /// </summary>
        private void resetSaveCondition()
        {
            UnsavedChanges = false;
            Panel_Sign signControls = getSignControls();
            
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

        override public void selectionChanged(object sender, EventArgs e)
        {
            if (!isOpen()) { return; }

            if (UnsavedChanges)
            {
                

            }

            resetSignDisplay();
            FeatureLayer selectionLayer = (FeatureLayer)Layer;
            ISelection shpSelection = selectionLayer.Selection;

            if (shpSelection.Count <= 0)
            {
                disableSignDisplay();
                return;
            }

            enableControls();
            Dictionary<string, string> values = setSegmentValues(selectionLayer.Selection.ToFeatureSet().DataTable);
            updateSignDisplay(values);
            
            Panel_Sign signControls = getSignControls();

        }

        private void updateSignDisplay(Dictionary<string, string> values)
        {
            Panel_Sign signControls = getSignControls();

            signControls.textBoxAddress.Text = values["address"];
        }

        private void enableControls()
        {
            Panel_Sign signControls = getSignControls();

            signControls.groupBoxSign.Enabled = true;
            signControls.toolStrip.Enabled = true;
            signControls.groupBoxSupport.Enabled = true;
        }

        private void resetSignDisplay()
        {
            Panel_Sign signControls = getSignControls();

            signControls.labelSurveyDate.Text = "";
            signControls.textBoxAddress.Text = "";
            signControls.comboBoxCondition.SelectedIndex = 0;
            signControls.comboBoxMaterial.SelectedIndex = 0;
            signControls.numericUpDownOffset.Value = 0;
            signControls.numericUpDownHeight.Value = 0;
            signControls.textBoxType.Text = "";
            signControls.textBoxDescription.Text = "";
            signControls.comboBoxSheeting.SelectedIndex = 0;
            signControls.comboBoxBacking.SelectedIndex = 0;
            signControls.numericUpDownWidth.Value = 0;
            signControls.numericUpDownHeigthSign.Value = 0;
            signControls.numericUpDownMountHeight.Value = 0;
            signControls.textBoxInstall.Text = "";
            signControls.textBoxText.Text = "";
            signControls.comboBoxReflectivity.SelectedIndex = 0;
            signControls.comboBoxDirection.SelectedIndex = 0;
            signControls.comboBoxConditionSign.SelectedIndex = 0;
            signControls.textBoxPhotoFile.Text = "";

            signControls.labelAddress.ForeColor = default(Color);
            signControls.labelAddress.BackColor = default(Color);
            signControls.textBoxAddress.Enabled = true;
            signControls.labelAddress.Text = "Address";
        }
    }
}
