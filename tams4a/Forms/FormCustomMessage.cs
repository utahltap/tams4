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
    // replaces messageBox
    // messages are centered on parent (instead of screen)
    // TODO:  Set image based on type (error, warning, SHP, Roads, Signs, etc)
    public partial class FormCustomMessage : Form
    {
        public FormCustomMessage()
        {
            InitializeComponent();
            CenterToScreen();
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
