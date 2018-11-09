using System;
using System.Data;
using System.Windows.Forms;

namespace tams4a.Forms
{
    public partial class FormQueryBuilder : Form
    {
        private string TableName;
        private DataTable TableSchema;
        private string columnName;

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
        }

        public string getQuery()
        {
            if (string.IsNullOrWhiteSpace(comboBoxColumn.Text) || string.IsNullOrWhiteSpace(comboBoxComparision.Text)
                || (string.IsNullOrWhiteSpace(comboBoxValue.Text) && string.IsNullOrWhiteSpace(textBoxValue.Text)))
            {
                MessageBox.Show("An option was left blank and the resulting query is invalid. Instead, this tool will show your " + TableName + " data without any filters.");
                return "SELECT * FROM " + TableName;
            }
            string valueText = "";


            //TODO: fix whatever is going on here...
            //Value is a custom input
            if (string.IsNullOrWhiteSpace(comboBoxValue.Text))
            {
                try
                {
                    int i = Convert.ToInt32(comboBoxValue.Text);
                    valueText = comboBoxValue.Text;
                }
                catch (Exception)
                {
                    valueText = "'" + comboBoxValue.Text.Replace('\'', ' ') + "'";
                }
            }
            else
            {
                valueText = comboBoxValue.Text;
                if (comboBoxColumn.Text == "Surface") valueText.ToLower();

            }
            Console.WriteLine("#####################################################################");
            Console.WriteLine("SELECT * FROM " + TableName + " WHERE " + columnName + " like \"" + valueText + "\"");
            Console.WriteLine("#####################################################################");
            return "SELECT * FROM " + TableName + " WHERE " + columnName + " like \"" + valueText + "\"";

            return "";
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
            textBoxValue.Text = "";
            comboBoxValue.Show();
            comboBoxComparision.Enabled = false;
            comboBoxComparision.SelectedIndex = 0;
            if (comboBoxColumn.Text == "Functional Classification")
            {
                columnName = "type";
                comboBoxValue.Items.Add("Major Arterial");
                comboBoxValue.Items.Add("Minor Arterial");
                comboBoxValue.Items.Add("Major Collector");
                comboBoxValue.Items.Add("Minor Collecter");
                comboBoxValue.Items.Add("Residential");
                return;
            }
            if (comboBoxColumn.Text == "Surface")
            {
                columnName = "surface";
                comboBoxValue.Items.Add("Asphalt");
                comboBoxValue.Items.Add("Concrete");
                comboBoxValue.Items.Add("Gravel");
                return;
            }
            if (comboBoxColumn.Text == "Suggested Treatment")
            {
                columnName = "suggested_treatment";
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
