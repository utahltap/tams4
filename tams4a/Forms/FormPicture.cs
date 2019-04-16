using System;
using System.Windows.Forms;

namespace tams4a.Forms
{
    public partial class FormPicture : Form
    {
        public FormPicture()
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
