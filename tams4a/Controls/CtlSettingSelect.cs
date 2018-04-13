using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tams4a.Controls
{
    class CtlSettingSelect : CtlSetting
    {
        private ComboBox comboBox;

        public CtlSettingSelect(String key) : base(key)
        {
            comboBox = new ComboBox();
            comboBox.SelectedIndex = -1;    // set the selection to empty.
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FlatStyle = FlatStyle.System;

            splitContainer.Panel2.Controls.Add(comboBox);
            comboBox.SelectionChangeCommitted += new EventHandler(HandleValueChanged);
            comboBox.TextChanged += new EventHandler(HandleValueChanged);
        }

        public override Control GetFocusControl()
        {
            return comboBox;
        }

        public override void setValue(String value)
        {
            comboBox.Enabled = false;
            comboBox.SelectedIndex = comboBox.FindString(value);
            comboBox.Enabled = true;
        }


        public override String getValue()
        {
            return comboBox.Text;
        }

        //protected override void resetStatus()
        //{

        //}

        public override void setOptions(List<String> values)
        {
            try
            {
                options = values;
                this.comboBox.DataSource = values;
                AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                autoComplete.AddRange(values.ToArray());
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

