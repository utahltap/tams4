using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tams4a.Forms
{
    public partial class FormGetDistress : Form
    {
        public int DistressValue { get; set; }
        public string Title {
            get
            {
                return labelTitle.Text;
            }
            set
            {
                labelTitle.Text = value;
            }
        }
        private int maxDistress { get; set; }
        public int MaxDistress
        {
            get
            {
                return maxDistress;
            }
            set
            {
                if (value > 0 && value < 9)
                {
                    maxDistress = value;
                    enableValues();
                }
            }
        }
        private Bitmap Illustration;


        public FormGetDistress()
        {
            InitializeComponent();
            maxDistress = 9;
            buttonCancel.Select();
        }

        public void setIllustration (Bitmap image)
        {
            try
            {
                Illustration = image;
            }
            catch
            {
                // TODO: ??
                Illustration = Properties.Resources.blank;
            }
            pictureBox.Image = Illustration;
        }


        private void enableValues()
        {
            if (maxDistress < 2) { button2.Visible = false; } else { button2.Visible = true; }
            if (maxDistress < 3) { button3.Visible = false; } else { button3.Visible = true; }
            if (maxDistress < 4) { button4.Visible = false; } else { button4.Visible = true; }
            if (maxDistress < 5) { button5.Visible = false; } else { button5.Visible = true; }
            if (maxDistress < 6) { button6.Visible = false; } else { button6.Visible = true; }
            if (maxDistress < 7) { button7.Visible = false; } else { button7.Visible = true; }
            if (maxDistress < 8) { button8.Visible = false; } else { button8.Visible = true; }
            if (maxDistress < 9) { button9.Visible = false; } else { button9.Visible = true; }
        }

        // allow using keyboard for entry
        private void FormGetDistress_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    cancel();
                    break;
                case Keys.D0:
                case Keys.NumPad0:
                    DistressValue = 0;
                    this.DialogResult = DialogResult.OK;
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    DistressValue = 1;
                    this.DialogResult = DialogResult.OK;
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    DistressValue = 2;
                    this.DialogResult = DialogResult.OK;
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    DistressValue = 3;
                    this.DialogResult = DialogResult.OK;
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    DistressValue = 4;
                    this.DialogResult = DialogResult.OK;
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    DistressValue = 5;
                    this.DialogResult = DialogResult.OK;
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    DistressValue = 6;
                    this.DialogResult = DialogResult.OK;
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    DistressValue = 7;
                    this.DialogResult = DialogResult.OK;
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    DistressValue = 8;
                    this.DialogResult = DialogResult.OK;
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    DistressValue = 9;
                    this.DialogResult = DialogResult.OK;
                    break;
            }
            //if (shortForm)
            //{
            //    if (distressValue > 3)
            //    {
            //        distressValue = -1;
            //        this.DialogResult = DialogResult.Cancel;
            //    }
            //}
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            cancel();
        }

        private void cancel()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonNone_Click(object sender, EventArgs e)
        {
            DistressValue = 0;
            this.DialogResult = DialogResult.OK;
        }

        #region number buttons

        private void button1_Click(object sender, EventArgs e)
        {
            DistressValue = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DistressValue = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DistressValue = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DistressValue = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DistressValue = 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DistressValue = 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DistressValue = 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DistressValue = 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DistressValue = 9;
        }

        #endregion
    }
}
