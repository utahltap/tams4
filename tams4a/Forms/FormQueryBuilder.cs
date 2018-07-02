using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tams4a.Forms
{
    public partial class FormQueryBuilder : Form
    {
        private string TableName;
        private DataTable TableSchema;

        public FormQueryBuilder(string tn, DataTable ts)
        {
            InitializeComponent();
            TableName = tn;
            TableSchema = ts;
            labelTable.Text = "Getting data from " + TableName + " table";
            DataRow blankSurfaceRow = TableSchema.NewRow();
            blankSurfaceRow["cid"] = 0;
            blankSurfaceRow["name"] = "";
            TableSchema.Rows.InsertAt(blankSurfaceRow, 0);
            comboBoxColumn.DataSource = TableSchema;
            comboBoxColumn.DisplayMember = "name";
            comboBoxColumn.ValueMember = "cid";
        }

        public string getQuery()
        {
            if (string.IsNullOrWhiteSpace(comboBoxColumn.Text) || string.IsNullOrWhiteSpace(comboBoxComparision.Text) || string.IsNullOrWhiteSpace(textBoxValue.Text))
            {
                MessageBox.Show("An option was left blank and the resulting query is invalid. Instead, this tool will show your " + TableName + " data without any filters.");
                return "SELECT * FROM " + TableName;
            }
            string valueText = "";
            try
            {
                int i = Convert.ToInt32(textBoxValue.Text);
                valueText = textBoxValue.Text;
            }
            catch (Exception e)
            {
                valueText = "'" + textBoxValue.Text.Replace('\'', ' ') + "'";
            }

            return "SELECT * FROM " + TableName + " WHERE " + comboBoxColumn.Text + " " + comboBoxComparision.Text + " " + valueText;
        }

        private string getColumn()
        {
            return comboBoxColumn.Text;
        }

        private string getComparision()
        {
            return comboBoxComparision.Text;
        }

        private string getValue()
        {
            return textBoxValue.Text;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }
    }
}
