using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            Util.TableToCSV((DataTable)(dataGridViewReport.DataSource), "TAMS");
        }
    }
}
