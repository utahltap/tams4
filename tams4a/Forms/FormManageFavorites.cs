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
    public partial class FormManageFavorites : Form
    {
        private int virtualSigns = 0;
        private int maxSignID;
        private int sIndex;
        private bool suppressChanges;
        private DataTable favorites;
        private Dictionary<string, string> selectedSign;
        private System.Data.SQLite.SQLiteConnection conn;

        public FormManageFavorites(System.Data.SQLite.SQLiteConnection c, int maxID)
        {
            InitializeComponent();
            CenterToScreen();
            maxSignID = maxID;
            conn = c;
            DataTable sheeting = Database.GetDataByQuery(conn, "SELECT * FROM sign_sheeting");
            DataRow blankSheetingRow = sheeting.NewRow();
            sheeting.Rows.InsertAt(blankSheetingRow, 0);
            comboBoxSheeting.DataSource = sheeting;
            comboBoxSheeting.DisplayMember = "type";
            comboBoxSheeting.ValueMember = "id";
            DataTable backing = Database.GetDataByQuery(conn, "SELECT * FROM sign_backing");
            DataRow blankBackingRow = backing.NewRow();
            backing.Rows.InsertAt(blankBackingRow, 0);
            comboBoxBacking.DataSource = backing;
            comboBoxBacking.DisplayMember = "material";
            comboBoxBacking.ValueMember = "id";
            setSigns();
            selectSign(0);
            new ToolTip().SetToolTip(buttonCreate, "Create virtual sign to add to your favorites from input parameters.");
            new ToolTip().SetToolTip(buttonRemove, "Remove sign from your favorites.");
            new ToolTip().SetToolTip(buttonClear, "Resets parameters to origninal values.");
            new ToolTip().SetToolTip(buttonUpdate, "Update values for selected sign.");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void setSigns()
        {
            favorites = Database.GetDataByQuery(conn, "SELECT * FROM sign WHERE favorite='true'");
            comboBoxSign.DataSource = favorites;
            comboBoxSign.DisplayMember = "description";
            comboBoxSign.ValueMember = "TAMSID";
        }

        /// <summary>
        /// sets parameters according to the currently selected sign.
        /// </summary>
        /// <param name="i">index of the selected sign.</param>
        private void selectSign(int i)
        {
            sIndex = i;
            selectedSign = new Dictionary<string, string>();
            if (favorites.Rows.Count == 0)
            {
                return;
            }
            foreach (DataColumn col in favorites.Columns)
            {
                selectedSign[col.ColumnName] = favorites.Rows[i][col.ColumnName].ToString();
            }
            suppressChanges = true;
            textBoxMUTCD.Text = selectedSign["mutcd_code"];
            textBoxDescription.Text = selectedSign["description"];
            textBoxText.Text = selectedSign["sign_text"];
            comboBoxSheeting.Text = selectedSign["sheeting"];
            comboBoxBacking.Text = selectedSign["backing"];
            numericUpDownHeight.Value = (decimal)Util.ToDouble(selectedSign["height"]);
            numericUpDownWidth.Value = (decimal)Util.ToDouble(selectedSign["width"]);
            numericUpDownMountHeight.Value = (decimal)Util.ToDouble(selectedSign["mount_height"]);
            suppressChanges = false;
        }

        private void selectedSignChanged(object sender, EventArgs e)
        {
            selectSign(comboBoxSign.SelectedIndex);
        }

        /// <summary>
        /// Event to call when one of the paramters is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void parameterChanged(object sender, EventArgs e)
        {
            if (suppressChanges)
            {
                return;
            }
            selectedSign["mutcd_code"] = textBoxMUTCD.Text;
            selectedSign["description"] = textBoxDescription.Text;
            selectedSign["sign_text"] = textBoxText.Text;
            selectedSign["sheeting"] = comboBoxSheeting.Text;
            selectedSign["backing"] = comboBoxBacking.Text;
            selectedSign["height"] = numericUpDownHeight.Value.ToString();
            selectedSign["width"] = numericUpDownWidth.Value.ToString();
            selectedSign["mount_height"] = numericUpDownMountHeight.Value.ToString();
            DataTable signValues = Database.GetDataByQuery(conn, "SELECT * FROM mutcd_lookup WHERE mutcd_code = '" + textBoxMUTCD.Text + "';");
            if (signValues.Rows.Count == 1)
            {
                selectedSign["category"] = signValues.Rows[0]["category"].ToString();
            }
            else {
                selectedSign["category"] = "empty_post";
            }
        }

        /// <summary>
        /// Gets the number of virtual signs that were created in the database so that it can be added to the maxSignID
        /// </summary>
        /// <returns></returns>
        public int virtualSignsCreated()
        {
            return virtualSigns;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (comboBoxSign.Items.Count == 0)
            {
                return;
            }
            if (selectedSign["support_id"] != "-2")
            {
                Database.UpdateRow(conn, new Dictionary<string, string>() { { "favorite", "false" } }, "sign", "TAMSID", selectedSign["TAMSID"]);
                selectedSign["support_id"] = "-2";
                virtualSigns++;
                selectedSign["TAMSID"] = (maxSignID + virtualSigns).ToString();
                sIndex = favorites.Rows.Count - 1;
            }
            selectedSign["favorite"] = "true";
            Database.ReplaceRow(conn, selectedSign, "sign");
            setSigns();
            selectSign(sIndex);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            selectedSign["support_id"] = "-2";
            selectedSign["favorite"] = "true";
            virtualSigns++;
            selectedSign["TAMSID"] = (maxSignID + virtualSigns).ToString();
            Database.ReplaceRow(conn, selectedSign, "sign");
            setSigns();
            selectSign(favorites.Rows.Count - 1);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            selectSign(sIndex);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (comboBoxSign.Items.Count == 0)
            {
                return;
            }
            if (selectedSign["support_id"] == "-2")
            {
                Database.DeleteRow(conn, "sign", "TAMSID", selectedSign["TAMSID"]);
            }
            else
            {
                Database.UpdateRow(conn, new Dictionary<string, string>() { { "favorite", "false" } }, "sign", "TAMSID", selectedSign["TAMSID"]);
            }
            setSigns();
            selectSign(0);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FormSignLookup mutcd = new FormSignLookup();
            mutcd.setData(Database.GetDataByQuery(conn, "SELECT * FROM mutcd_lookup"));
            if (mutcd.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, string> result = mutcd.getSelection();
                if (result != null)
                {
                    textBoxMUTCD.Text = result["mutcd_code"];
                    textBoxDescription.Text = result["description"];
                    selectedSign["category"] = result["category"];
                }
            }
        }
    }
}
