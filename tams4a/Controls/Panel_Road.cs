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

            // These can't be set in UI because they're in the base class
            numericUpDownSpeedLimit.ValueChanged += moduleValueChanged;
            numericUpDownLanes.ValueChanged += moduleValueChanged;
            textBoxFrom.TextChanged += moduleValueChanged;
            textBoxTo.TextChanged += moduleValueChanged;
            comboBoxType.SelectionChangeCommitted += moduleValueChanged;
            comboBoxTreatment.SelectionChangeCommitted += moduleValueChanged;
            textBoxPhotoFile.TextChanged += moduleValueChanged;
            this.AutoScroll = true;
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
            String oldPhoto = Properties.Settings.Default.lastPhoto;
            if (String.IsNullOrWhiteSpace(oldPhoto))
            {
                textBoxPhotoFile.Text = "0001";     // We'll just choose this as our default starting point
                return;
            }

            // if there's a number, then attempt to find the pattern and increment by one
            String pattern = @"(.*?)(\d+)(.*)";
            Regex rex = new Regex(pattern, RegexOptions.IgnoreCase);

            Match mat = rex.Match(oldPhoto);
            if (!mat.Success)
            {
                textBoxPhotoFile.Text = oldPhoto + "_0001";     // We'll just choose this as our default starting point
                return;
            }

            try
            {
                String nextPhoto = mat.Groups[1].ToString();    // start with the first bit, whatever it may look like

                // This is the number part.  We'll try to increment it
                String numPart = mat.Groups[2].ToString();  
                int num = Convert.ToInt16(numPart);
                num++;
                String numFormat = "D" + numPart.Length.ToString();
                nextPhoto += num.ToString(numFormat);

                // add on the remaining filename
                nextPhoto += mat.Groups[3].ToString();

                textBoxPhotoFile.Text = nextPhoto;
            }
            catch 
            {
                textBoxPhotoFile.Text = oldPhoto + "0001";     // We'll just choose this as our default starting point
                return;
            }
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSurface_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSetDate_Click(object sender, EventArgs e)
        {

        }

        private void setSurveyDateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void setTodayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
