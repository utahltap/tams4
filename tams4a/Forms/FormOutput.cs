using System;
using System.Data;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormOutput : Form
    {
        
        public FormOutput()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void csvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.TableToCSV((DataTable)(dataGridViewReport.DataSource), "TAMS");
        }

        private void pngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.TableToPNG(dataGridViewReport);
        }
    }
}
