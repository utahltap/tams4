using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormTreatmentEditor : Form
    {
        private DataTable treatments;
        private SQLiteConnection conn;

        public FormTreatmentEditor(SQLiteConnection conn)
        {
            InitializeComponent();
            CenterToScreen();
            this.conn = conn;
            setComboBoxLists();
            new ToolTip().SetToolTip(labelName, "The name of the treatment you want to edit.");
            new ToolTip().SetToolTip(labelCost, "The cost of the treatment in dollars per square yard.");
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRoad.Text = treatments.Rows[comboBoxName.SelectedIndex]["road_applied"].ToString();
            comboBoxCategory.Text = treatments.Rows[comboBoxName.SelectedIndex]["category"].ToString();
            numericUpDownMinRSL.Value = Util.ToInt(treatments.Rows[comboBoxName.SelectedIndex]["min_rsl"].ToString());
            numericUpDownMaxRSL.Value = Util.ToInt(treatments.Rows[comboBoxName.SelectedIndex]["max_rsl"].ToString());
            numericUpDownRSLChange.Value = Util.ToInt(treatments.Rows[comboBoxName.SelectedIndex]["average_boost"].ToString());
            numericUpDownCost.Value = (decimal)Util.ToDouble(treatments.Rows[comboBoxName.SelectedIndex]["cost"].ToString());
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int index = comboBoxName.SelectedIndex;
            var values = new Dictionary<string, string>()
            {
                {"name", "'" + comboBoxName.Text + "'" },
                {"category", "'" + comboBoxCategory.Text + "'" },
                {"road_applied", "'" + comboBoxRoad.Text + "'" },
                {"min_rsl", numericUpDownMinRSL.Value.ToString() },
                {"max_rsl", numericUpDownMaxRSL.Value.ToString() },
                {"average_boost", numericUpDownRSLChange.Value.ToString() },
                {"cost", numericUpDownCost.Value.ToString() }
            };
            try
            {
                Database.UpdateRow(conn, values, "treatments", "name", values["name"]);
                MessageBox.Show("Treatment was updated successfully.", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception err)
            {
                Log.Error("There was a problem updating the treatments in TAMS: " + Environment.NewLine + err.ToString());
            }
            setComboBoxLists();
            comboBoxName.SelectedIndex = index;
        }

        private void setComboBoxLists()
        {
            treatments = Database.GetDataByQuery(conn, "SELECT * FROM treatments;");
            comboBoxName.DataSource = treatments;
            comboBoxName.DisplayMember = "name";
            comboBoxName.ValueMember = "id";
            DataTable surfaceTypes = Database.GetDataByQuery(conn, "SELECT * FROM road_surfaces");
            comboBoxRoad.DataSource = surfaceTypes;
            comboBoxRoad.DisplayMember = "name";
            comboBoxRoad.ValueMember = "id";
        }

        /// <summary>
        /// Invoked to create, a new treatment and insertit into the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            int index = comboBoxName.SelectedIndex;
            string tn = "new treatment";
            if (InputBox("New Treatment Name", "Enter a name for the new treatment.", ref tn) == DialogResult.OK)
            {
                Database.ReplaceRow(conn, new Dictionary<string, string>() { { "name", tn } }, "treatments");
            }
            setComboBoxLists();
            comboBoxName.SelectedIndex = comboBoxName.Items.Count-1;
        }

        /// <summary>
        /// Copied from http://www.csharp-examples.net/inputbox/, seriously, why isn't this a core feature of windows forms alongside MessageBox.Show?
        /// </summary>
        /// <param name="title"></param>
        /// <param name="promptText"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Warning, you are about to delete a treatment from the database. The automatic recomendation feature may not work after this action!", "Delete Treatment?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                Database.DeleteRow(conn, "treatments", "id", treatments.Rows[comboBoxName.SelectedIndex]["id"].ToString());
                setComboBoxLists();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.utahltap.org/software/help/");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
