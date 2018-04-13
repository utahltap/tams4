using System;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Controls
{
    class CtlSettingBool : CtlSetting
    {
        private CheckBox checkbox;

        public CtlSettingBool(String key) : base(key)
        {
            checkbox = new CheckBox();
            checkbox.Dock = DockStyle.Top;
            splitContainer.Panel2.Controls.Add(checkbox);
        }

        public override void setValue(String value)
        {
            if (value == "true")
            {
                checkbox.Checked = true;
            } else
            {
                checkbox.Checked = false;
            }
        }

        public void setValue(Boolean value)
        {
            if (value)
            {
                checkbox.Checked = true;
            } else
            {
                checkbox.Checked = false;
            }
        }

        public override String getValue()
        {
            if (checkbox.Checked)
            {
                return "true";
            } else
            {
                return "false";
            }
        }

        public override Control GetFocusControl()
        {
            return checkbox;
        }
    }
}
