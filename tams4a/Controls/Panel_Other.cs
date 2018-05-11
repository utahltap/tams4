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
    public partial class Panel_Other : Panel_Module
    {
        public Panel_Other()
        {
            InitializeComponent();

            new ToolTip().SetToolTip(buttonNextPhoto, "Get Next Photo");
            new ToolTip().SetToolTip(comboBoxIcon, "Select Icon to Show on Map");
        }
    }
}
