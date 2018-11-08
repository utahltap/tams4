using System;
using System.Data;
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
            CenterToScreen();
            TableName = tn;
            TableSchema = ts;
            labelTable.Text = "Getting data from " + TableName + " table";
            DataRow blankSurfaceRow = TableSchema.NewRow();
            blankSurfaceRow["cid"] = 0;
            blankSurfaceRow["name"] = "";
            TableSchema.Rows.InsertAt(blankSurfaceRow, 0);
            //comboBoxColumn.DataSource = TableSchema;
            //comboBoxColumn.DisplayMember = "name";
            //comboBoxColumn.ValueMember = "cid";
            
        }

        public string getQuery()
        {
            if (string.IsNullOrWhiteSpace(comboBoxColumn.Text) || string.IsNullOrWhiteSpace(comboBoxComparision.Text) || string.IsNullOrWhiteSpace(comboBoxValue.Text))
            {
                MessageBox.Show("An option was left blank and the resulting query is invalid. Instead, this tool will show your " + TableName + " data without any filters.");
                return "SELECT * FROM " + TableName;
            }
            string valueText = "";
            try
            {
                int i = Convert.ToInt32(comboBoxValue.Text);
                valueText = comboBoxValue.Text;
            }
            catch (Exception)
            {
                valueText = "'" + comboBoxValue.Text.Replace('\'', ' ') + "'";
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
            return comboBoxValue.Text;
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

        private void comboBoxColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxValue.Items.Clear();
            textBoxValue.Hide();
            comboBoxValue.Show();
            comboBoxComparision.Enabled = false;
            comboBoxComparision.SelectedIndex = 0;
            if (comboBoxColumn.Text == "Functional Classification")
            {
                comboBoxValue.Items.Add("Major Arterial");
                comboBoxValue.Items.Add("Minor Arterial");
                comboBoxValue.Items.Add("Major Collector");
                comboBoxValue.Items.Add("Minor Collecter");
                comboBoxValue.Items.Add("Residential");
                return;
            }
            if (comboBoxColumn.Text == "Surface")
            {
                comboBoxValue.Items.Add("Asphalt");
                comboBoxValue.Items.Add("Concrete");
                comboBoxValue.Items.Add("Gravel");
                return;
            }
            if (comboBoxColumn.Text == "Suggested Treatment")
            {
                comboBoxValue.Items.Add("Nothing");
                comboBoxValue.Items.Add("Routine");
                comboBoxValue.Items.Add("Patching");
                comboBoxValue.Items.Add("Preventative");
                comboBoxValue.Items.Add("Preventative with Patching");
                comboBoxValue.Items.Add("Rehabilitation");
                comboBoxValue.Items.Add("Reconstruction");
                return;
            }
            comboBoxComparision.Enabled = true;
            comboBoxValue.Hide();
            textBoxValue.Show();
        }
    }
}
