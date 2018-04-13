using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tams4a.Controls
{
    public partial class LabeledInput : UserControl
    {
        private String label;
        public String Label {
            get { return label; }
            set { setLabel(value); }
        }

        public String Value {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        private Boolean readOnly;
        public Boolean ReadOnly
        {
            get { return readOnly; }
            set { readOnly = textBox.ReadOnly = value; }
        }

        public LabeledInput()
        {
            InitializeComponent();
        }

        private void setLabel(String value)
        {
            label = value;
            label1.Text = value;
        }

    }
}
