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
    public partial class FormHistory : Form
    {
        public FormHistory()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
