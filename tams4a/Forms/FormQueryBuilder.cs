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
                Console.WriteLine("Height = " + Height);
                Console.WriteLine("panelRoadTab.Height = " + panelRoadTab.Height);
                Console.WriteLine("tabControlCustom.Height = " + tabControlCustom.Height);
                Console.WriteLine("buttonOK.Location.Y = " + buttonOK.Location.Y);
                Console.WriteLine("buttonCancel.Location.Y = " + buttonCancel.Location.Y);

                Height = ROAD_FORM_HEIGHT;
                panelRoadTab.Height = ROAD_PANEL_HEIGHT;
                tabControlCustom.Height = ROAD_TAB_CONTROL_HEIGHT;
                buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, ROAD_BUTTON_Y_LOCATION);
                buttonOK.Location = new System.Drawing.Point(buttonOK.Location.X, ROAD_BUTTON_Y_LOCATION);
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
    }
}
