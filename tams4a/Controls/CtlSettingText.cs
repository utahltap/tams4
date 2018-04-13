using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Controls
{
    class CtlSettingText : CtlSetting
    {
        private TextBox textBox;

        public CtlSettingText(String key) : base(key)
        {
            textBox = new TextBox();
            textBox.Multiline = false;
            textBox.Dock = DockStyle.Fill;
                //= 120;
            textBox.TabStop = true;

            splitContainer.Panel2.Controls.Add(textBox);
            textBox.TextChanged += new EventHandler(HandleValueChanged);
            textBox.GotFocus += new EventHandler(ux_gotFocus);
        }


        public override Control GetFocusControl()
        {
            return textBox;
        }

        public override void setValue(String value)
        {
            textBox.Enabled = false;
            textBox.Text = value;
            textBox.Enabled = true;
        }


        public override String getValue()
        {
            return textBox.Text;
        }

        //protected override void resetStatus()
        //{

        //}


        // autocomplete options
        public override void setOptions(List<String> values)
        {
            try
            {
                this.options = values;
                //textBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                autoComplete.AddRange(values.ToArray());

                textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

                textBox.AutoCompleteCustomSource = autoComplete;
            }
            catch (Exception e)
            {
#if DEBUG
                MessageBox.Show("Could not set options for " + this.Name + "\n\n" + e.ToString());
#endif
                // do nothing.  TODO:  Do something?
            }
            this.Hide();
        }
    }
}

