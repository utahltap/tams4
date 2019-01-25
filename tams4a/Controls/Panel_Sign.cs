using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace tams4a.Controls
{
    public partial class Panel_Sign : Panel_Module
    {
        public Panel_Sign()
        {
            InitializeComponent();

            textBoxAddress.TextChanged += moduleValueChanged;
            comboBoxMaterial.SelectionChangeCommitted += moduleValueChanged;
            comboBoxCondition.SelectionChangeCommitted += moduleValueChanged;
            comboBoxObstruction.SelectedValueChanged += moduleValueChanged;
            numericUpDownOffset.ValueChanged += moduleValueChanged;
            comboBoxSupportRecommendation.SelectedValueChanged += moduleValueChanged;
            textBoxType.TextChanged += moduleValueChanged;
            textBoxDescription.TextChanged += moduleValueChanged;
            comboBoxSheeting.SelectedValueChanged += moduleValueChanged;
            comboBoxBacking.SelectedValueChanged += moduleValueChanged;
            numericUpDownHeightSign.ValueChanged += moduleValueChanged;
            numericUpDownWidth.ValueChanged += moduleValueChanged;
            numericUpDownMountHeight.ValueChanged += moduleValueChanged;
            textBoxInstall.TextChanged += moduleValueChanged;
            textBoxText.TextChanged += moduleValueChanged;
            comboBoxReflectivity.SelectionChangeCommitted += moduleValueChanged;
            comboBoxConditionSign.SelectedValueChanged += moduleValueChanged;
            comboBoxDirection.SelectedValueChanged += moduleValueChanged;
            textBoxPhotoFile.TextChanged += moduleValueChanged;
            buttonNextPhoto.Click += buttonNextPhoto_Click;

            new ToolTip().SetToolTip(buttonAdd, "Add New Sign to Post");
            new ToolTip().SetToolTip(buttonRemove, "Remove Sign from Post");
            new ToolTip().SetToolTip(buttonInstallDate, "Set Install Date of Sign");
            new ToolTip().SetToolTip(buttonFavorite, "Add Sign to Favorites");
            new ToolTip().SetToolTip(buttonSignNote, "Add Note to Sign");
            new ToolTip().SetToolTip(buttonNextPhoto, "Get Next Photo");

            AutoScroll = true;
        }

        private void buttonNextPhoto_Click(object sender, EventArgs e)
        {
            string oldPhoto = Properties.Settings.Default.lastPhoto;
            if (string.IsNullOrWhiteSpace(oldPhoto))
            {
                textBoxPhotoFile.Text = "0001";
                return;
            }

            string pattern = @"(.*?)(\d+)(.*)";
            Regex rex = new Regex(pattern, RegexOptions.IgnoreCase);

            Match mat = rex.Match(oldPhoto);
            if (!mat.Success)
            {
                textBoxPhotoFile.Text = MakePictureNumbered(oldPhoto);
                Properties.Settings.Default.lastPhoto = textBoxPhotoFile.Text;
                return;
            }

            try
            {
                string nextPhoto = mat.Groups[1].ToString();
                string numPart = mat.Groups[2].ToString();
                int num = Convert.ToInt16(numPart);
                num++;
                string numFormat = "D" + numPart.Length.ToString();
                nextPhoto += num.ToString(numFormat);

                nextPhoto += mat.Groups[3].ToString();

                textBoxPhotoFile.Text = nextPhoto;
                Properties.Settings.Default.lastPhoto = textBoxPhotoFile.Text;
            }
            catch
            {
                textBoxPhotoFile.Text = MakePictureNumbered(oldPhoto);
                Properties.Settings.Default.lastPhoto = textBoxPhotoFile.Text;
                return;
            }
        }

        private void comboBoxSigns_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
