using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace tams4a.Controls
{
    public partial class Panel_Road : Panel_Module
    {
        public Panel_Road()
        {
            InitializeComponent();
            
            numericUpDownSpeedLimit.ValueChanged += moduleValueChanged;
            numericUpDownLanes.ValueChanged += moduleValueChanged;
            textBoxFrom.TextChanged += moduleValueChanged;
            textBoxTo.TextChanged += moduleValueChanged;
            textBoxRoadName.TextChanged += moduleValueChanged;
            comboBoxSurface.TextChanged += moduleValueChanged;
            comboBoxType.TextChanged += moduleValueChanged;
            comboBoxTreatment.TextChanged += moduleValueChanged;
            textBoxPhotoFile.TextChanged += moduleValueChanged;
            inputRsl.TextChanged += moduleValueChanged;
            textBoxWidth.TextChanged += widthChanged;
            textBoxLength.TextChanged += lengthChanged;
            buttonNextPhoto.Click += buttonNextPhoto_Click;
            
            new ToolTip().SetToolTip(buttonNextPhoto, "Get Next Photo");
            new ToolTip().SetToolTip(buttonSuggest, "Get TAMS Suggestion");

            AutoScroll = true;
        }


        private void lengthChanged(object sender, EventArgs e)
        {
            updateArea();
            moduleValueChanged(sender, e);
        }


        private void widthChanged(object sender, EventArgs e)
        {
            updateArea();
            moduleValueChanged(sender, e);
        }


        private void surfaceChanged(object sender, EventArgs e)
        {
            moduleValueChanged(sender, e);
        }


        private void updateArea()
        {
            try
            {
                if (textBoxWidth.Text != "" && textBoxLength.Text != "")
                {
                    Decimal width = Convert.ToDecimal(textBoxWidth.Text);
                    Decimal length = Convert.ToDecimal(textBoxLength.Text);
                    Decimal area = width * length;

                    textBoxWidth.Text = (width == 0) ? "" : width.ToString();
                    textBoxLength.Text = (length == 0) ? "" : length.ToString();
                    textBoxArea.Text = (area == 0) ? "" : area.ToString();
                }
            }
            catch
            { // nothing
            }
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
            }
            catch 
            {
                textBoxPhotoFile.Text = MakePictureNumbered(oldPhoto);
                return;
            }
        }
    }
}
