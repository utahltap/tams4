using System;
using System.Data;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormQueryBuilder : Form
    {
        private string TableName;
        private string query;
        private bool firstOption = true;

        private const int ROAD_FORM_HEIGHT = 465;
        private const int ROAD_PANEL_HEIGHT = 354;
        private const int ROAD_TAB_CONTROL_HEIGHT = 380;
        private const int ROAD_PANEL_BELOW_SURFACE_POSITION = 240;
        private const int ROAD_BUTTON_Y_LOCATION = 386;

        private const int SIGN_FORM_HEIGHT = 545;
        private const int SIGN_PANEL_HEIGHT = 434;
        private const int SIGN_TAB_CONTROL_HEIGHT = 460;
        private const int SIGN_BUTTON_Y_LOCATION = 466;

        private const int SUPPORT_FORM_HEIGHT = 387;
        private const int SUPPORT_PANEL_HEIGHT = 276;
        private const int SUPPORT_TAB_CONTROL_HEIGHT = 302;
        private const int SUPPORT_BUTTON_Y_LOCATION = 308;

        private const int OTHER_FORM_HEIGHT = 390;
        private const int OTHER_PANEL_HEIGHT = 278;
        private const int OTHER_TAB_CONTROL_HEIGHT = 306;
        private const int OTHER_BUTTON_Y_LOCATION = 312;


        public FormQueryBuilder(TamsProject Project, int tab)
        {
            InitializeComponent();
            CenterToScreen();
            DataTable mutcdCodes = Database.GetDataByQuery(Project.conn, "SELECT mutcd_code FROM mutcd_lookup;");
            comboBoxMUTCDCodeValue.DataSource = mutcdCodes;
            comboBoxMUTCDCodeValue.DisplayMember = "mutcd_code";
            tabControlCustom.SelectedIndex = tab;
            TableName = tabControlCustom.SelectedTab.Text.ToLower();
            if (TableName == "road")
            {
                Height = ROAD_FORM_HEIGHT;
                panelRoadTab.Height = ROAD_PANEL_HEIGHT;
                tabControlCustom.Height = ROAD_TAB_CONTROL_HEIGHT;
                buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, ROAD_BUTTON_Y_LOCATION);
                buttonOK.Location = new System.Drawing.Point(buttonOK.Location.X, ROAD_BUTTON_Y_LOCATION);
            }
            if (TableName == "other")
            {
                Height = OTHER_FORM_HEIGHT;
                panelRoadTab.Height = OTHER_PANEL_HEIGHT;
                tabControlCustom.Height = OTHER_TAB_CONTROL_HEIGHT;
                buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, OTHER_BUTTON_Y_LOCATION);
                buttonOK.Location = new System.Drawing.Point(buttonOK.Location.X, OTHER_BUTTON_Y_LOCATION);
            }
        }

        public string getSurface()
        {
            string surfaceType = "";
            if (surface.Checked)
            {
                surfaceType = comboBoxSurfaceValue.Text;
            }
            return surfaceType;
        }

        public string getQuery()
        {
            query = "SELECT * FROM " + TableName + " WHERE ";
            if (TableName == "road") query = getRoadQuery(query);
            if (TableName == "sign") query = getSignQuery(query);
            if (TableName == "support")
            {
                TableName = "sign_support";
                query = getSupportQuery("SELECT * FROM sign_support WHERE ");
            }
            if (TableName == "other")
            {
                TableName = "miscellaneous";
                if (comboBoxLandmarkType.Text == "Roads with Sidewalks")
                    TableName = "road_sidewalks";
                query = getOtherQuery("SELECT * FROM " + TableName + " WHERE ");
            }

            if (firstOption)
            {
                MessageBox.Show("No options were selected. This tool will show your " + TableName + " data without any filters.");
                return "SELECT * FROM " + TableName;
            }

            return query;
        }

        private string getRoadQuery(string query)
        {
            if (id.Checked && comboBoxIDComparison.Text != "")
            {
                if (firstOption) firstOption = false;
                query += "TAMSID " + comboBoxIDComparison.Text + " " + numericUpDownIDValue.Value.ToString();
            }

            if (name.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "name LIKE \"%" + textBoxNameValue.Text + "%\"";
            }

            if (speed_limit.Checked && comboBoxSpeedLimitComparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "speed_limit " + comboBoxSpeedLimitComparison.Text + " " + numericUpDownSpeedLimitValue.Value.ToString();
            }

            if (lanes.Checked && comboBoxLanesComparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "lanes " + comboBoxLanesComparison.Text + " " + numericUpDownLanesValue.Value.ToString();
            }

            if (width.Checked && comboBoxWidthComparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "width " + comboBoxWidthComparison.Text + " " + numericUpDownWidthValue.Value.ToString();
            }

            if (length.Checked && comboBoxLengthComparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "length " + comboBoxLengthComparison.Text + " " + numericUpDownLengthValue.Value.ToString();
            }

            if (type.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "type LIKE \"" + comboBoxFunctionalClassificationValue.Text + "\"";
            }

            if (surface.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "surface LIKE \"" + comboBoxSurfaceValue.Text + "\"";
            }

            if (distress1.Checked && comboBoxDistress1Comparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "distress1 " + comboBoxDistress1Comparison.Text + " " + numericUpDownDistress1Value.Value.ToString();
                query += " AND distress1 != \"\"";
            }

            if (distress2.Checked && comboBoxDistress2Comparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "distress2 " + comboBoxDistress2Comparison.Text + " " + numericUpDownDistress2Value.Value.ToString();
                query += " AND distress2 != \"\"";
            }

            if (distress3.Checked && comboBoxDistress3Comparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "distress3 " + comboBoxDistress3Comparison.Text + " " + numericUpDownDistress3Value.Value.ToString();
                query += " AND distress3 != \"\"";
            }

            if (distress4.Checked && comboBoxDistress4Comparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "distress4 " + comboBoxDistress4Comparison.Text + " " + numericUpDownDistress4Value.Value.ToString();
                query += " AND distress4 != \"\"";
            }

            if (distress5.Checked && comboBoxDistress5Comparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "distress5 " + comboBoxDistress5Comparison.Text + " " + numericUpDownDistress5Value.Value.ToString();
                query += " AND distress5 != \"\"";
            }

            if (distress6.Checked && comboBoxDistress6Comparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "distress6 " + comboBoxDistress6Comparison.Text + " " + numericUpDownDistress6Value.Value.ToString();
                query += " AND distress6 != \"\"";
            }

            if (distress7.Checked && comboBoxDistress7Comparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "distress7 " + comboBoxDistress7Comparison.Text + " " + numericUpDownDistress7Value.Value.ToString();
                query += " AND distress7 != \"\"";
            }

            if (distress8.Checked && comboBoxDistress8Comparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "distress8 " + comboBoxDistress8Comparison.Text + " " + numericUpDownDistress8Value.Value.ToString();
                query += " AND distress8 != \"\"";
            }

            if (distress9.Checked && comboBoxDistress9Comparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "distress9 " + comboBoxDistress9Comparison.Text + " " + numericUpDownDistress9Value.Value.ToString();
                query += " AND distress9 != \"\"";
            }

            if (from_address.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "from_address LIKE \"%" + textBoxFromAddressValue.Text + "%\"";
            }

            if (to_address.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "to_address LIKE \"%" + textBoxToAddressValue.Text + "%\"";
            }

            if (rsl.Checked && comboBoxRSLComparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "rsl " + comboBoxRSLComparison.Text + " " + numericUpDownRSLValue.Value.ToString();
            }

            if (suggested_treatment.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "suggested_treatment LIKE \"" + comboBoxSuggestedTreatmentValue.Text + "\"";
            }

            return query;
        }

        private string getSignQuery(string query)
        {
            if (SignID.Checked && comboBoxSignIDComparison.Text != "")
            {
                if (firstOption) firstOption = false;
                query += "TAMSID " + comboBoxSignIDComparison.Text + " " + numericUpDownSignIDValue.Value.ToString();
            }

            if (Sign_SupportID.Checked && comboBoxSign_SupportIDComparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "support_id " + comboBoxSign_SupportIDComparison.Text + " " + numericUpDownSign_SupportIDValue.Value.ToString();
            }

            if (MUTCDCode.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "mutcd_code LIKE \"" + comboBoxMUTCDCodeValue.Text + "\"";
            }

            if (SignText.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "sign_text LIKE \"%" + textBoxSignTextValue.Text + "%\"";
            }

            if (SignCondition.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "condition LIKE \"" + comboBoxSignConditionValue.Text + "\"";
            }

            if (SignRecommendation.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "recommendation LIKE \"" + comboBoxSignRecommendationValue.Text + "\"";
            }

            if (Reflectivity.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "reflectivity LIKE \"" + comboBoxReflectivityValue.Text + "\"";
            }

            if (Sheeting.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "sheeting LIKE \"" + comboBoxSheetingValue.Text + "\"";
            }

            if (Backing.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "backing LIKE \"" + comboBoxBackingValue.Text + "\"";
            }

            if (SignHeight.Checked && comboBoxSignHeightComparison.Text != "")
            {
                if (firstOption) firstOption = false;
                query += "height " + comboBoxSignHeightComparison.Text + " " + numericUpDownSignHeightValue.Value.ToString();
            }

            if (SignWidth.Checked && comboBoxSignWidthComparison.Text != "")
            {
                if (firstOption) firstOption = false;
                query += "width " + comboBoxSignWidthComparison.Text + " " + numericUpDownSignWidthValue.Value.ToString();
            }

            if (MountHeight.Checked && comboBoxMountHeightComparison.Text != "")
            {
                if (firstOption) firstOption = false;
                query += "mount_height " + comboBoxMountHeightComparison.Text + " " + numericUpDownMountHeightValue.Value.ToString();
            }

            if (Direction.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "direction LIKE \"" + comboBoxDirectionValue.Text + "\"";
            }

            if (Category.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "category LIKE \"" + comboBoxCategoryValue.Text + "\"";
            }

            if (Favorite.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "favorite LIKE \"" + comboBoxFavoriteValue.Text + "\"";
            }

            return query;
        }

        private string getSupportQuery(string query)
        {
            if (SupportID.Checked && comboBoxSupportIDComparison.Text != "")
            {
                if (firstOption) firstOption = false;
                query += "support_id " + comboBoxSupportIDComparison.Text + " " + numericUpDownSupportIDValue.Value.ToString();
            }

            if (Material.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "material LIKE \"" + comboBoxMaterialValue.Text + "\"";
            }

            if (Address.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "address LIKE \"%" + textBoxAddressValue.Text + "%\"";
            }

            if (SupportCondition.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "condition LIKE \"" + comboBoxSupportConditionValue.Text + "\"";
            }

            if (Obstructions.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "obstructions LIKE \"" + comboBoxObstructionsValue.Text + "\"";
            }

            if (SupportRecommendation.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "recommendation LIKE \"" + comboBoxSupportRecommendationValue.Text + "\"";
            }

            if (SupportCategory.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "category LIKE \"" + comboBoxSupportCategoryValue.Text + "\"";
            }

            if (SupportHeight.Checked && comboBoxSupportHeightComparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "height " + comboBoxSupportHeightComparison.Text + " " + numericUpDownSupportHeightValue.Value.ToString();
            }

            if (RoadOffset.Checked && comboBoxRoadOffsetComparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "road_offset " + comboBoxRoadOffsetComparison.Text + " " + numericUpDownRoadOffsetValue.Value.ToString();
            }

            return query;
        }

        private string getOtherQuery(string query)
        {
            if (comboBoxLandmarkType.Text != "" && comboBoxLandmarkType.Text != "Roads with Sidewalks")
            {
                query += "type = '" + comboBoxLandmarkType.Text + "'";
                firstOption = false;
            }

            if (OtherID.Checked && comboBoxOtherIDComparison.Text != "")
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                if (comboBoxLandmarkType.Text == "Roads with Sidewalks") query += "road_ID " + comboBoxOtherIDComparison.Text + " " + numericUpDownOtherID.Value.ToString();
                else query += "TAMSID " + comboBoxOtherIDComparison.Text + " " + numericUpDownOtherID.Value.ToString();
            }

            if (OtherAddress.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                if (comboBoxLandmarkType.Text == "Roads with Sidewalks") query += "installed LIKE \"%" + comboBoxInstalledValue.Text + "%\"";
                else query += "address LIKE \"%" + textBoxOtherAddressValue.Text + "%\"";
            }

            if (OtherDescription.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                if (comboBoxLandmarkType.Text == "Roads with Sidewalks") query += "comments LIKE \"%" + textBoxOtherAddressValue.Text + "%\"";
                else query += "description LIKE \"%" + textBoxOtherDescriptionValue.Text + "%\"";
            }

            if (OtherNotes.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "notes LIKE \"%" + textBoxOtherNotesValue.Text + "%\"";
            }

            if (Property1.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                if (comboBoxProperty1Value.Visible)
                    query += "property1 LIKE \"" + comboBoxProperty1Value.Text + "\"";
                else query += "property1 LIKE \"%" + textBoxProperty1Value.Text + "%\"";
            }

            if (Property2.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                if (comboBoxProperty1Value.Visible)
                    query += "property2 LIKE \"" + comboBoxProperty2Value.Text + "\"";
                else query += "property2 LIKE \"%" + textBoxProperty2Value.Text + "%\"";
            }

            if (Property3.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "property3 LIKE \"" + comboBoxProperty3Value.Text + "\"";
            }

            if (Property4.Checked)
            {
                if (!firstOption) query += " AND ";
                else firstOption = false;
                query += "property4 LIKE \"" + comboBoxProperty4Value.Text + "\"";
            }

            return query;
        }

        public string getType()
        {
            return comboBoxLandmarkType.Text;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void id_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxIDComparison.Enabled = id.Checked;
            numericUpDownIDValue.Enabled = id.Checked;
        }

        private void name_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNameValue.Enabled = name.Checked;
        }

        private void speed_limit_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSpeedLimitComparison.Enabled = speed_limit.Checked;
            numericUpDownSpeedLimitValue.Enabled = speed_limit.Checked;
        }

        private void lanes_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxLanesComparison.Enabled = lanes.Checked;
            numericUpDownLanesValue.Enabled = lanes.Checked;
        }

        private void width_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxWidthComparison.Enabled = width.Checked;
            numericUpDownWidthValue.Enabled = width.Checked;
        }

        private void length_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxLengthComparison.Enabled = length.Checked;
            numericUpDownLengthValue.Enabled = length.Checked;
        }

        private void type_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxFunctionalClassificationValue.Enabled = type.Checked;
            if (!type.Checked) comboBoxFunctionalClassificationValue.Text = "";
        }

        private void surface_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSurfaceValue.Enabled = surface.Checked;
            if (!surface.Checked)
            {
                adjustDistressHeight();
                comboBoxSurfaceValue.Text = "";
            }
        }

        private void from_address_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFromAddressValue.Enabled = from_address.Checked;
        }

        private void to_address_CheckedChanged(object sender, EventArgs e)
        {
            textBoxToAddressValue.Enabled = to_address.Checked;
        }

        private void rsl_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxRSLComparison.Enabled = rsl.Checked;
            numericUpDownRSLValue.Enabled = rsl.Checked;
        }

        private void suggested_treatment_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSuggestedTreatmentValue.Enabled = suggested_treatment.Checked;
            if (!suggested_treatment.Checked) comboBoxSuggestedTreatmentValue.Text = "";
        }

        private void distress1_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxDistress1Comparison.Enabled = distress1.Checked;
            numericUpDownDistress1Value.Enabled = distress1.Checked;
            if (!distress1.Checked) comboBoxDistress1Comparison.Text = "";
        }

        private void distress2_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxDistress2Comparison.Enabled = distress2.Checked;
            numericUpDownDistress2Value.Enabled = distress2.Checked;
            if (!distress2.Checked) comboBoxDistress2Comparison.Text = "";
        }

        private void distress3_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxDistress3Comparison.Enabled = distress3.Checked;
            numericUpDownDistress3Value.Enabled = distress3.Checked;
            if (!distress3.Checked) comboBoxDistress3Comparison.Text = "";
        }

        private void distress4_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxDistress4Comparison.Enabled = distress4.Checked;
            numericUpDownDistress4Value.Enabled = distress4.Checked;
            if (!distress4.Checked) comboBoxDistress4Comparison.Text = "";
        }

        private void distress5_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxDistress5Comparison.Enabled = distress5.Checked;
            numericUpDownDistress5Value.Enabled = distress5.Checked;
            if (!distress5.Checked) comboBoxDistress5Comparison.Text = "";
        }

        private void distress6_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownDistress6Value.Enabled = distress6.Checked;
            comboBoxDistress6Comparison.Enabled = distress6.Checked;
            if (!distress6.Checked) comboBoxDistress6Comparison.Text = "";
        }

        private void distress7_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxDistress7Comparison.Enabled = distress7.Checked;
            numericUpDownDistress7Value.Enabled = distress7.Checked;
            if (!distress7.Checked) comboBoxDistress7Comparison.Text = "";
        }

        private void distress8_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxDistress8Comparison.Enabled = distress8.Checked;
            numericUpDownDistress8Value.Enabled = distress8.Checked;
            if (!distress8.Checked) comboBoxDistress8Comparison.Text = "";
        }

        private void distress9_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownDistress9Value.Enabled = distress9.Checked;
            comboBoxDistress9Comparison.Enabled = distress9.Checked;
            if (!distress9.Checked) comboBoxDistress9Comparison.Text = "";
        }

        private void comboBoxSurfaceValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSurfaceValue.Text == "") return;
            int growHeight = panelDistresses.Height;
            if (comboBoxSurfaceValue.Text == "Gravel") growHeight -= 52;
            Height = ROAD_FORM_HEIGHT + growHeight;
            panelRoadTab.Height = ROAD_PANEL_HEIGHT + growHeight;
            tabControlCustom.Height = ROAD_TAB_CONTROL_HEIGHT + growHeight;
            panelBelowSurface.Location = new System.Drawing.Point(panelBelowSurface.Location.X, ROAD_PANEL_BELOW_SURFACE_POSITION + growHeight);
            buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, ROAD_BUTTON_Y_LOCATION + growHeight);
            buttonOK.Location = new System.Drawing.Point(buttonOK.Location.X, ROAD_BUTTON_Y_LOCATION + growHeight);
            panelDistresses.Show();
            distress8.Show();
            distress9.Show();
            comboBoxDistress9Comparison.Show();
            comboBoxDistress8Comparison.Show();
            numericUpDownDistress8Value.Show();
            numericUpDownDistress9Value.Show();


            if (comboBoxSurfaceValue.Text == "Asphalt")
            {
                distress1.Text = "Fatigue";
                distress2.Text = "Edge";
                distress3.Text = "Longitudinal";
                distress4.Text = "Patches";
                distress5.Text = "Potholes";
                distress6.Text = "Drainage";
                distress7.Text = "Transverse";
                distress8.Text = "Block";
                distress9.Text = "Rutting";
            }
            if (comboBoxSurfaceValue.Text == "Concrete")
            {
                distress1.Text = "Spalling";
                distress2.Text = "Joint Seal";
                distress3.Text = "Corners";
                distress4.Text = "Broken";
                distress5.Text = "Faulting";
                distress6.Text = "Longitudinal";
                distress7.Text = "Transverse";
                distress8.Text = "Cracking";
                distress9.Text = "Patches";
            }
            if (comboBoxSurfaceValue.Text == "Gravel")
            {
                distress1.Text = "Potholes";
                distress2.Text = "Rutting";
                distress3.Text = "X-Section";
                distress4.Text = "Drainage";
                distress5.Text = "Dust";
                distress6.Text = "Aggregate";
                distress7.Text = "Corrugate";
                distress8.Hide();
                distress9.Hide();
                comboBoxDistress9Comparison.Hide();
                comboBoxDistress8Comparison.Hide();
                numericUpDownDistress8Value.Hide();
                numericUpDownDistress9Value.Hide();
            }

        }

        private void tabControlCustom_SelectedIndexChanged(Object sender, EventArgs e)
        {
            TableName = tabControlCustom.SelectedTab.Text.ToLower();
            if (TableName == "road")
            {
                Height = ROAD_FORM_HEIGHT;
                panelRoadTab.Height = ROAD_PANEL_HEIGHT;
                tabControlCustom.Height = ROAD_TAB_CONTROL_HEIGHT;
                buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, ROAD_BUTTON_Y_LOCATION);
                buttonOK.Location = new System.Drawing.Point(buttonOK.Location.X, ROAD_BUTTON_Y_LOCATION);
                comboBoxSurfaceValue_SelectedIndexChanged(sender, e);
            }
            if (TableName == "sign")
            {
                adjustDistressHeight();
                Height = SIGN_FORM_HEIGHT;
                panelRoadTab.Height = SIGN_PANEL_HEIGHT;
                tabControlCustom.Height = SIGN_TAB_CONTROL_HEIGHT;
                buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, SIGN_BUTTON_Y_LOCATION);
                buttonOK.Location = new System.Drawing.Point(buttonOK.Location.X, SIGN_BUTTON_Y_LOCATION);
            }
            if (TableName == "support")
            {
                adjustDistressHeight();
                Height = SUPPORT_FORM_HEIGHT;
                panelRoadTab.Height = SUPPORT_PANEL_HEIGHT;
                tabControlCustom.Height = SUPPORT_TAB_CONTROL_HEIGHT;
                buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, SUPPORT_BUTTON_Y_LOCATION);
                buttonOK.Location = new System.Drawing.Point(buttonOK.Location.X, SUPPORT_BUTTON_Y_LOCATION);
            }
            if (TableName == "other")
            {
                adjustDistressHeight();
                Height = OTHER_FORM_HEIGHT;
                panelRoadTab.Height = OTHER_PANEL_HEIGHT;
                tabControlCustom.Height = OTHER_TAB_CONTROL_HEIGHT;
                buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, OTHER_BUTTON_Y_LOCATION);
                buttonOK.Location = new System.Drawing.Point(buttonOK.Location.X, OTHER_BUTTON_Y_LOCATION);
            }
        }

        private void adjustDistressHeight()
        {
            panelDistresses.Hide();
            Height = ROAD_FORM_HEIGHT;
            panelRoadTab.Height = ROAD_PANEL_HEIGHT;
            tabControlCustom.Height = ROAD_TAB_CONTROL_HEIGHT;
            panelBelowSurface.Location = new System.Drawing.Point(panelBelowSurface.Location.X, ROAD_PANEL_BELOW_SURFACE_POSITION);
            buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, ROAD_BUTTON_Y_LOCATION);
            buttonOK.Location = new System.Drawing.Point(buttonOK.Location.X, ROAD_BUTTON_Y_LOCATION);
        }

        private void SignID_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSignIDComparison.Enabled = SignID.Checked;
            numericUpDownSignIDValue.Enabled = SignID.Checked;
        }

        private void Sign_SupportID_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSign_SupportIDComparison.Enabled = Sign_SupportID.Checked;
            numericUpDownSign_SupportIDValue.Enabled = Sign_SupportID.Checked;
        }

        private void MUTCDCode_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMUTCDCodeComparison.Enabled = MUTCDCode.Checked;
            comboBoxMUTCDCodeValue.Enabled = MUTCDCode.Checked;
        }

        private void SignText_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSignTextComparison.Enabled = SignText.Checked;
            textBoxSignTextValue.Enabled = SignText.Checked;
        }

        private void SignCondition_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSignConditionComparison.Enabled = SignCondition.Checked;
            comboBoxSignConditionValue.Enabled = SignCondition.Checked;
        }

        private void SignRecommendation_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSignRecommendationComparison.Enabled = SignRecommendation.Checked;
            comboBoxSignRecommendationValue.Enabled = SignRecommendation.Checked;
        }

        private void Reflectivity_CheckedChanged(object sender, EventArgs e)
        {
            textBoxReflectivityComparison.Enabled = Reflectivity.Checked;
            comboBoxReflectivityValue.Enabled = Reflectivity.Checked;
        }

        private void Sheeting_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSheetingComparison.Enabled = Sheeting.Checked;
            comboBoxSheetingValue.Enabled = Sheeting.Checked;
        }

        private void Backing_CheckedChanged(object sender, EventArgs e)
        {
            textBoxBackingComparison.Enabled = Backing.Checked;
            comboBoxBackingValue.Enabled = Backing.Checked;
        }

        private void SignHeight_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSignHeightComparison.Enabled = SignHeight.Checked;
            numericUpDownSignHeightValue.Enabled = SignHeight.Checked;
        }

        private void SignWidth_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSignWidthComparison.Enabled = SignWidth.Checked;
            numericUpDownSignWidthValue.Enabled = SignWidth.Checked;
        }

        private void MountHeight_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxMountHeightComparison.Enabled = MountHeight.Checked;
            numericUpDownMountHeightValue.Enabled = MountHeight.Checked;
        }

        private void Direction_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDirectionComparison.Enabled = Direction.Checked;
            comboBoxDirectionValue.Enabled = Direction.Checked;
        }

        private void Category_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCategoryComparison.Enabled = Category.Checked;
            comboBoxCategoryValue.Enabled = Category.Checked;
        }

        private void Favorite_CheckedChanged(object sender, EventArgs e)
        {
            textBoxFavoriteComparison.Enabled = Favorite.Checked;
            comboBoxFavoriteValue.Enabled = Favorite.Checked;
        }

        private void SupportID_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSupportIDComparison.Enabled = SupportID.Checked;
            numericUpDownSupportIDValue.Enabled = SupportID.Checked;
        }

        private void Material_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMaterialComparison.Enabled = Material.Checked;
            comboBoxMaterialValue.Enabled = Material.Checked;
        }

        private void Address_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAddressComparison.Enabled = Address.Checked;
            textBoxAddressValue.Enabled = Address.Checked;
        }

        private void SupportCondition_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSupportConditionComparison.Enabled = SupportCondition.Checked;
            comboBoxSupportConditionValue.Enabled = SupportCondition.Checked;
        }

        private void Obstructions_CheckedChanged(object sender, EventArgs e)
        {
            textBoxObstructionsComparison.Enabled = Obstructions.Checked;
            comboBoxObstructionsValue.Enabled = Obstructions.Checked;
        }

        private void SupportRecommendation_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSupportRecommendationComparison.Enabled = SupportRecommendation.Checked;
            comboBoxSupportRecommendationValue.Enabled = SupportRecommendation.Checked;
        }

        private void SupportCategory_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSupportCategoryComparison.Enabled = SupportCategory.Checked;
            comboBoxSupportCategoryValue.Enabled = SupportCategory.Checked;
        }

        private void SupportHeight_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSupportHeightComparison.Enabled = SupportHeight.Checked;
            numericUpDownSupportHeightValue.Enabled = SupportHeight.Checked;
        }

        private void RoadOffset_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxRoadOffsetComparison.Enabled = RoadOffset.Checked;
            numericUpDownRoadOffsetValue.Enabled = RoadOffset.Checked;
        }

        private void comboBoxLandmarkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Property1.Visible = true;
            Property2.Visible = true;
            Property3.Visible = true;
            Property4.Visible = true;
            OtherNotes.Visible = true;
            textBoxProperty1Comparison.Visible = true;
            textBoxProperty2Comparison.Visible = true;
            textBoxProperty3Comparison.Visible = true;
            textBoxProperty4Comparison.Visible = true;
            textBoxOtherNotesComparison.Visible = true;
            comboBoxProperty1Value.Visible = true;
            comboBoxProperty2Value.Visible = true;
            comboBoxProperty3Value.Visible = true;
            comboBoxProperty4Value.Visible = true;
            textBoxOtherNotesValue.Visible = true;
            textBoxProperty1Value.Visible = false;
            textBoxProperty2Value.Visible = false;
            textBoxProperty1Comparison.Text = "=";
            textBoxProperty2Comparison.Text = "=";
            textBoxOtherAddressValue.Visible = true;
            comboBoxInstalledValue.Visible = false;
            OtherAddress.Text = "Address";
            textBoxOtherAddressComparison.Text = "includes";
            OtherDescription.Text = "Description";
            comboBoxProperty1Value.Items.Clear();
            comboBoxProperty2Value.Items.Clear();
            comboBoxProperty3Value.Items.Clear();
            comboBoxProperty4Value.Items.Clear();

            if (String.IsNullOrWhiteSpace(comboBoxLandmarkType.Text))
            {
                Property1.Visible = false;
                Property2.Visible = false;
                Property3.Visible = false;
                Property4.Visible = false;
                textBoxProperty1Comparison.Visible = false;
                textBoxProperty2Comparison.Visible = false;
                textBoxProperty3Comparison.Visible = false;
                textBoxProperty4Comparison.Visible = false;
                comboBoxProperty1Value.Visible = false;
                comboBoxProperty2Value.Visible = false;
                comboBoxProperty3Value.Visible = false;
                comboBoxProperty4Value.Visible = false;
                comboBoxInstalledValue.Visible = false;
            }
            if (comboBoxLandmarkType.Text == "Sidewalk")
            {
                Property1.Text = "Faults";
                comboBoxProperty1Value.Items.AddRange(new object[] {
                    "",
                    "Less than 0.25 in.",
                    "0.25 - 0.5 in.",
                    "0.5 - 1 in.",
                    "More than 1 in."
                });

                Property2.Text = "Breaks";
                comboBoxProperty2Value.Items.AddRange(new object[] {
                    "",
                    "Low",
                    "Moderate",
                    "Severe"
                });

                Property3.Text = "Recommendation";
                comboBoxProperty3Value.Items.AddRange(new object[] {
                    "",
                    "Grind",
                    "Replace",
                    "Watch",
                    "Other (see notes)"
                });

                Property4.Text = "Surface";
                comboBoxProperty4Value.Items.AddRange(new object[] {
                    "",
                    "Asphalt",
                    "Concrete",
                    "Pervious",
                    "Not Paved",
                    "Multiple",
                    "Other"
                });
            }
            if (comboBoxLandmarkType.Text == "Roads with Sidewalks")
            {
                Property1.Visible = false;
                Property2.Visible = false;
                Property3.Visible = false;
                Property4.Visible = false;
                OtherNotes.Visible = false;
                textBoxProperty1Comparison.Visible = false;
                textBoxProperty2Comparison.Visible = false;
                textBoxProperty3Comparison.Visible = false;
                textBoxProperty4Comparison.Visible = false;
                textBoxOtherNotesComparison.Visible = false;
                comboBoxProperty1Value.Visible = false;
                comboBoxProperty2Value.Visible = false;
                comboBoxProperty3Value.Visible = false;
                comboBoxProperty4Value.Visible = false;
                textBoxOtherNotesValue.Visible = false;

                textBoxOtherAddressValue.Visible = false;
                comboBoxInstalledValue.Visible = true;

                OtherAddress.Text = "Installed";
                textBoxOtherAddressComparison.Text = "=";
                OtherDescription.Text = "Comments";
            }
            if (comboBoxLandmarkType.Text == "Severe Road Distress")
            {
                Property1.Text = "Distress";
                textBoxProperty1Comparison.Text = "includes";
                comboBoxProperty1Value.Visible = false;
                textBoxProperty1Value.Visible = true;

                Property2.Text = "Recommendation";
                textBoxProperty2Comparison.Text = "includes";
                comboBoxProperty2Value.Visible = false;
                textBoxProperty2Value.Visible = true;

                Property3.Visible = false;
                textBoxProperty3Comparison.Visible = false;
                comboBoxProperty3Value.Visible = false;

                Property4.Visible = false;
                textBoxProperty4Comparison.Visible = false;
                comboBoxProperty4Value.Visible = false;
            }
            if (comboBoxLandmarkType.Text == "ADA Ramp")
            {
                Property1.Text = "Condition";
                comboBoxProperty1Value.Items.AddRange(new object[] {
                    "",
                    "Good",
                    "Acceptable",
                    "Bad"
                });

                Property2.Text = "Compliant";
                comboBoxProperty2Value.Items.AddRange(new object[] {
                    "",
                    "Yes",
                    "No"
                });

                Property3.Text = "Has Tiles";
                comboBoxProperty3Value.Items.AddRange(new object[] {
                    "",
                    "Yes",
                    "No"
                });

                Property4.Visible = false;
                textBoxProperty4Comparison.Visible = false;
                comboBoxProperty4Value.Visible = false;
            }
            if (comboBoxLandmarkType.Text == "Drainage")
            {
                Property1.Text = "Type";
                comboBoxProperty1Value.Items.AddRange(new object[] {
                    "",
                    "Curb and Gutter",
                    "Roadway Ponding",
                    "Unpaved Shoulder",
                    "Turf Shoulder",
                    "Storm Grate",
                    "Other"
                });

                Property2.Text = "Recommendation";
                textBoxProperty2Comparison.Text = "includes";
                comboBoxProperty2Value.Visible = false;
                textBoxProperty2Value.Visible = true;

                Property3.Visible = false;
                textBoxProperty3Comparison.Visible = false;
                comboBoxProperty3Value.Visible = false;

                Property4.Visible = false;
                textBoxProperty4Comparison.Visible = false;
                comboBoxProperty4Value.Visible = false;
            }
            if (comboBoxLandmarkType.Text == "Accident")
            {
                Property1.Text = "Date";
                textBoxProperty1Comparison.Text = "includes";
                comboBoxProperty1Value.Visible = false;
                textBoxProperty1Value.Visible = true;

                Property2.Text = "Type";
                textBoxProperty2Comparison.Text = "includes";
                comboBoxProperty2Value.Visible = false;
                textBoxProperty2Value.Visible = true;

                Property3.Text = "Severity";
                comboBoxProperty3Value.Items.AddRange(new object[] {
                    "",
                    "Injury",
                    "Death",
                    "Property Damage"
                });

                Property4.Visible = false;
                textBoxProperty4Comparison.Visible = false;
                comboBoxProperty4Value.Visible = false;
            }
            if (comboBoxLandmarkType.Text == "Other")
            {
                Property1.Text = "Property 1";
                textBoxProperty1Comparison.Text = "includes";
                comboBoxProperty1Value.Visible = false;
                textBoxProperty1Value.Visible = true;

                Property2.Text = "Property 2";
                textBoxProperty2Comparison.Text = "includes";
                comboBoxProperty2Value.Visible = false;
                textBoxProperty2Value.Visible = true;

                Property3.Visible = false;
                textBoxProperty3Comparison.Visible = false;
                comboBoxProperty3Value.Visible = false;

                Property4.Visible = false;
                textBoxProperty4Comparison.Visible = false;
                comboBoxProperty4Value.Visible = false;
            }
        }

        private void checkBoxOtherAddress_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOtherAddressComparison.Enabled = OtherAddress.Checked;
            textBoxOtherAddressValue.Enabled = OtherAddress.Checked;
            comboBoxInstalledValue.Enabled = OtherAddress.Checked;
        }

        private void checkBoxOtherDescription_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOtherDescriptionComparison.Enabled = OtherDescription.Checked;
            textBoxOtherDescriptionValue.Enabled = OtherDescription.Checked;
        }

        private void checkBoxOtherNotes_CheckedChanged(object sender, EventArgs e)
        {
            textBoxOtherNotesComparison.Enabled = OtherNotes.Checked;
            textBoxOtherNotesValue.Enabled = OtherNotes.Checked;
        }

        private void checkBoxProperty1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxProperty1Comparison.Enabled = Property1.Checked;
            textBoxProperty1Value.Enabled = Property1.Checked;
            comboBoxProperty1Value.Enabled = Property1.Checked;
        }

        private void checkBoxProperty2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxProperty2Comparison.Enabled = Property2.Checked;
            textBoxProperty2Value.Enabled = Property2.Checked;
            comboBoxProperty2Value.Enabled = Property2.Checked;
        }

        private void checkBoxProperty3_CheckedChanged(object sender, EventArgs e)
        {
            textBoxProperty3Comparison.Enabled = Property3.Checked;
            comboBoxProperty3Value.Enabled = Property3.Checked;
        }

        private void checkBoxProperty4_CheckedChanged(object sender, EventArgs e)
        {
            textBoxProperty4Comparison.Enabled = Property4.Checked;
            comboBoxProperty4Value.Enabled = Property4.Checked;
        }

        private void checkBoxOtherID_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxOtherIDComparison.Enabled = OtherID.Checked;
            numericUpDownOtherID.Enabled = OtherID.Checked;
        }
    }
}
