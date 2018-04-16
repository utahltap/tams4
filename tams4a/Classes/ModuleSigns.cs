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

        private DateTime surveyDate;
        private string notes;

        private const string SignSelectionSql = @"SELECT MAX(signinfo.id) AS max_id, signinfo.* 
                    FROM
                    (
                        SELECT TAMSID, MAX(survey_date) AS maxdate
                        FROM sign_support
                        WHERE TAMSID IN ([[IDLIST]])
                        GROUP BY TAMSID
                    ) AS signids
                    JOIN sign AS signinfo
                        ON (
                                signinfo.TAMSID = signids.TAMSID AND
                                signinfo.survey_date = signids.maxdate
                            )
                    GROUP BY signinfo.TAMSID";

        private const string SignListSql = @"SELECT MAX(signinfo.id) AS max_id, signinfo.* 
                    FROM
                    (
                        SELECT TAMSID, MAX(survey_date) AS maxdate
                        FROM sign
                        WHERE TAMSID IN ([[IDLIST]])
                        GROUP BY TAMSID
                    ) AS signids
                    JOIN sign AS signinfo
                        ON (
                                signinfo.TAMSID = signids.TAMSID AND
                                signinfo.survey_date = signids.maxdate
                            )
                    GROUP BY signinfo.TAMSID";

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
                { "sign_f_offset", "offset" }
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
            ModuleSettings.Add(new ProjectSetting(name: "sign_icons", module: ModuleName, value: "true",
                    display_text: "Show Icons?", display_type: "bool",
                    description: "Show an Icon instead of a basic shape for sign locations?"));
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
            signBacking.Rows.InsertAt(blankSheetingRow, 0);
            signPanel.comboBoxSheeting.DataSource = signBacking;
            signPanel.comboBoxSheeting.DisplayMember = "material";
            signPanel.comboBoxSheeting.ValueMember = "id";

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
                controls = (Panel_Sign)ControlsPage.Controls["ROADCONTROLS"];
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
            int maxID = 0;
            int id_incrementer = 1;
            string tamsidCollumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");
            foreach (DataRow row in data.Rows)
            {
                maxID = Math.Max(Util.ToInt(row[tamsidCollumn].ToString()), maxID);
            }
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
                Database.InsertRow(Project.conn, values, "sign_support");
            }
            Cursor.Current = Cursors.Arrow;
        }

        private void setSymbolizer()
        {
            PointScheme sgnScheme = new PointScheme();
        }

        private void disableSignDisplay()
        {
            Panel_Sign signControls = getSignControls();
            resetSaveCondition();
            signControls.groupBoxSupport.Enabled = false;
            signControls.groupBoxSign.Enabled = false;
            signControls.toolStrip.Enabled = false;
        }

        private void resetSaveCondition()
        {
            UnsavedChanges = false;
            Panel_Sign signControls = getSignControls();
            
            signControls.toolStripButtonSave.Enabled = false;
            signControls.toolStripButtonSave.BackColor = default(Color);
        }
    }
}
