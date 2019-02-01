using System.Windows.Forms;

namespace tams4a.Forms
{
    public partial class FormImportReport : Form
    {
        public FormImportReport()
        {
            InitializeComponent();
        }
        public bool cancel = false;

        private void buttonContinue_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            cancel = true;
            Close();
        }
    }
}
