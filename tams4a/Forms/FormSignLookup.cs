using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace tams4a.Forms
{
    public partial class FormSignLookup : Form
    {
        private DataTable referenceTable;
        private DataTable searchTable;
        private List<RadioButton> options;
        private List<Label> signTexts;
        private List<Label> descriptions;
        private List<PictureBox> categoryIndicator;
        private int returnSignIndex = -1;

        public FormSignLookup()
        {
            InitializeComponent();
            CenterToScreen();
        }

        /// <summary>
        /// The table that will be used to select a sign
        /// </summary>
        /// <param name="signsTable">Must have the columns 'mutcd_code', 'description', 'sign_text', and 'category'</param>
        public void setData(DataTable signsTable)
        {
            referenceTable = signsTable;
            searchTable = signsTable.Copy();
            setDisplay();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string[] searchTerms = textBoxFilter.Text.Split(' ');
            searchTable = referenceTable.Clone();
            foreach (DataRow row in referenceTable.Rows)
            {
                bool exclude = false;
                for (int i = 0; i < searchTerms.Length; ++i)
                {
                    if (row["mutcd_code"].ToString().Contains(searchTerms[i]) || row["category"].ToString().Contains(searchTerms[i]) || row["sign_text"].ToString().Contains(searchTerms[i]) || row["description"].ToString().Contains(searchTerms[i]))
                    {
                        continue;
                    }
                    exclude = true;
                }
                if (exclude) { continue; }
                DataRow nr = searchTable.NewRow();
                foreach (DataColumn col in referenceTable.Columns)
                {
                    nr[col.ColumnName] = row[col.ColumnName];
                }
                searchTable.Rows.Add(nr);
            }
            setDisplay();
        }

        private void setDisplay()
        {
            panelSigns.Controls.Clear();
            Dictionary<string, Image> images = new Dictionary<string, Image>()
            {
                { "regulatory_rw", Properties.Resources.regulatory_rw },
                { "regulatory_bw", Properties.Resources.regulatory_bw },
                { "regulatory_pedestrian", Properties.Resources.regulatory_pedestrian },
                { "empty_post", Properties.Resources.empty_post },
                { "warning", Properties.Resources.warning },
                { "worker", Properties.Resources.worker },
                { "service", Properties.Resources.service },
                { "school_pedestrian", Properties.Resources.school_pedestrian },
                { "rail", Properties.Resources.rail },
                { "highway", Properties.Resources.highway },
                { "locational", Properties.Resources.locational },
                { "location_guide", Properties.Resources.locational },
                { "recreation", Properties.Resources.recreation }
            };
            descriptions = new List<Label>();
            signTexts = new List<Label>();
            categoryIndicator = new List<PictureBox>();
            options = new List<RadioButton>();
            for (int i = 0; i < searchTable.Rows.Count; ++i)
            {
                options.Add(new RadioButton());
                options[i].Text = searchTable.Rows[i]["mutcd_code"].ToString();
                options[i].Location = new Point(36, 16 + 32 * i);
                options[i].Size = new Size(108, 24);
                options[i].Click += radio_Click;
                panelSigns.Controls.Add(options[i]);
                descriptions.Add(new Label());
                descriptions[i].Text = searchTable.Rows[i]["description"].ToString();
                descriptions[i].Location = new Point(144, 16 + 32 * i);
                descriptions[i].Size = new Size(252, 24);
                panelSigns.Controls.Add(descriptions[i]);
                signTexts.Add(new Label());
                signTexts[i].Text = searchTable.Rows[i]["sign_text"].ToString();
                signTexts[i].Location = new Point(396, 16 + 32 * i);
                signTexts[i].Size = new Size(350, 24);
                panelSigns.Controls.Add(signTexts[i]);
                categoryIndicator.Add(new PictureBox());
                string cat = (searchTable.Rows[i]["category"].ToString());
                string mut = (searchTable.Rows[i]["mutcd_code"].ToString());
                categoryIndicator[i].Image = images[string.IsNullOrWhiteSpace(searchTable.Rows[i]["category"].ToString())? "empty_post": searchTable.Rows[i]["category"].ToString()];
                categoryIndicator[i].Location = new Point(756, 8 + 32 * i);
                categoryIndicator[i].Size = new Size(32, 32);
                panelSigns.Controls.Add(categoryIndicator[i]);
            }
        }

        private void buttonCanel_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.Cancel;
        }

        private void radio_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < options.Count; ++i)
            {
                if (options[i].Checked)
                {
                    returnSignIndex = i;
                    return;
                }
            }
        }

        public Dictionary<string, string> getSelection()
        {
            if (returnSignIndex >= 0)
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach (DataColumn col in searchTable.Columns)
                {
                    result[col.ColumnName] = searchTable.Rows[returnSignIndex][col.ColumnName].ToString();
                }
                return result;
            }

            return null;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Hide();
            DialogResult = DialogResult.OK;
        }

        private void pressEnter(object sender, KeyEventArgs e)
        {
            if (textBoxFilter.Focused && e.KeyCode == Keys.Enter)
            {
                buttonSearch_Click(sender, e);
            }
        }
    }
}
