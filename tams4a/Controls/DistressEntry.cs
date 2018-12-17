 using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace tams4a.Controls
{
    public partial class DistressEntry : UserControl
    {
        // members ===============================
        public int Value
        {
            get
            {
                if (!this.Enabled) { return -1; }
                try
                { return Convert.ToInt16(textBox.Text); }
                catch
                { return -1; }
            }
            set
            {
                try
                {
                    if (value == -1) { textBox.Text = ""; }
                    else { textBox.Text = value.ToString(); }
                }
                catch
                {
                    textBox.Text = "";
                    value = -1;
                }
            }
        }

        public string Label
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public int DataId { get; set; }    
        public String IllustrationName { get; set; }
        public String Description { get; set; }

        public int MaxDistress { get; set; }



        // methods ===============================
        public DistressEntry()
        {
            InitializeComponent();
            Value = -1; // no default distress value
            Description = "";
            MaxDistress = 9;
        }

        // ValueChanged
        [Category("PropertyChanged")]
        [Description("Fires on user selecting a value.")]
        public event EventHandler<CustomEventArgs> ValueChanged;
        // function to call to raise the ValueChanged event
        protected virtual void OnValueChanged(CustomEventArgs e)
        {
            // raise the event
            ValueChanged?.Invoke(this, e);
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            Forms.FormGetDistress getDistress = new Forms.FormGetDistress();
            getDistress.Title = this.Label;
            getDistress.textDescription.Text = Description;
            getDistress.MaxDistress = MaxDistress;

            if (!String.IsNullOrWhiteSpace(IllustrationName))
            {
                    Object image = Properties.Resources.ResourceManager.GetObject(IllustrationName);
                    getDistress.setIllustration((Bitmap)image);
            }
            //distressForm.Style = Form;

            if (getDistress.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.Value = getDistress.DistressValue;
                } catch {
                    // TODO:
                }
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            OnValueChanged(new CustomEventArgs());

            int val;
            try
            {
                if (!String.IsNullOrWhiteSpace(textBox.Text))
                {
                    val = Convert.ToInt16(textBox.Text);
                    if (val > MaxDistress || val < -1)
                    {
                        MessageBox.Show("Please enter a number between 0-" + MaxDistress);
                        textBox.Text = "";
                    } else
                    {
                        textBox.Text = val.ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter a number between 0-" + MaxDistress);
                textBox.Text = "";
            }
        }

        public void stringToValue(String valueString)
        {
            try
            {
                Value = Convert.ToInt16(valueString);
            } catch { // don't need to do anything here
                Value = -1;
            }
        }
    }
}

