using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Controls
{
    class CtlSettingInfo : CtlSetting
    {
        private Label valueText;

        public CtlSettingInfo(String key) : base(key)
        {
            valueText = new Label();
            valueText.Dock = DockStyle.Fill;
            valueText.TabStop = false;

            splitContainer.Panel2.Controls.Add(valueText);
        }

        public override void setValue(String value)
        {
            valueText.Text = value;
        }


        public override String getValue()
        {
            return valueText.Text;
        }

        public override Control GetFocusControl()
        {
            return valueText;
        }
    }
}

