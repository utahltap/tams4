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
    public partial class Panel_Module_OpenShp : UserControl
    {
        public Panel_Module_OpenShp()
        {
            InitializeComponent();
        }

        // any changes that need to be made
        public Panel_Module_OpenShp(String type) : this()
        {            
            switch (type)
            {
                case "Road":
                    buttonOpen.Text = "Open Road SHP File";
                    break;
                case "Sign":
                    buttonOpen.Text = "Open Sign SHP File";
                    break;
                default:
                    break;
            }
        }

        // what will handle clicking the open button
        public void SetHandler(EventHandler handler)
        {
            buttonOpen.Click += handler;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            
        }
    }
}
