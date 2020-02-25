using System;
using System.Collections.Generic;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    internal class AnalysisRowPanel : Panel
    {
        public ComboBox comboBoxTreatment = new ComboBox();
        public ComboBox comboBoxFunctionalClassification = new ComboBox();
        public ComboBox comboBoxToRSL = new ComboBox();
        public ComboBox comboBoxFromRSL = new ComboBox();
        public Label labelRowNumber = new Label();
        public Dictionary<int, double> rslArea = new Dictionary<int, double>();
        public bool tableCreated = false;
        public bool tableValid = true;

        public AnalysisRowPanel(int location, string rowNumber)
        {
            // 
            // comboBoxTreatment
            // 
            comboBoxTreatment.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTreatment.FormattingEnabled = true;
            comboBoxTreatment.Location = new System.Drawing.Point(284, 3);
            comboBoxTreatment.Name = "comboBoxTreatment";
            comboBoxTreatment.Size = new System.Drawing.Size(300, 21);
            comboBoxTreatment.TabIndex = 4;
            comboBoxTreatment.SelectedIndexChanged += new EventHandler(comboBoxTreatment_SelectedIndexChanged);
            comboBoxTreatment.Items.AddRange(new object[] {
                "Crack Seal",
                "Fog Coat",
                "High Mineral Asphalt Emulsion",
                "Sand Seal",
                "Scrub Seal",
                "Single Chip Seal",
                "Slurry Seal",
                "Microsurfacing",
                "Plant Mix Seal",
                "Cold In-place Recycling (2 in. with chip seal)",
                "Thin Hot Mix Overlay (<2 in.)",
                "HMA (leveling) & Overlay (<2 in.)",
                "Hot Surface Recycling",
                "Rotomill & Overlay (<2 in.)",
                "Cold In-place Recycling (2/2 in.)",
                "Thick Overlay (3 in.)",
                "Rotomill & Thick Overlay (3 in.)",
                "Base Repair/ Pavement Replacement",
                "Cold Recycling & Overlay (3/3 in.)",
                "Full Depth Reclamation & Overlay (3/3 in.)",
                "Base/ Pavement Replacement (3/3/6 in.)"
            });
            // 
            // comboBoxFunctionalClassification
            // 
            comboBoxFunctionalClassification.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFunctionalClassification.FormattingEnabled = true;
            comboBoxFunctionalClassification.Location = new System.Drawing.Point(141, 3);
            comboBoxFunctionalClassification.Name = "comboBoxFunctionalClassification";
            comboBoxFunctionalClassification.Size = new System.Drawing.Size(137, 21);
            comboBoxFunctionalClassification.TabIndex = 2;
            comboBoxFunctionalClassification.SelectedIndexChanged += new EventHandler(comboBoxFunctionalClassification_SelectedIndexChanged);
            comboBoxFunctionalClassification.Items.AddRange(new object[] {
                "",
                "Major Arterial",
                "Minor Arterial",
                "Major Collector",
                "Minor Collector",
                "Residential",
                "Other"
            });
            // 
            // comboBoxToRSL
            // 
            comboBoxToRSL.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxToRSL.FormattingEnabled = true;
            comboBoxToRSL.Location = new System.Drawing.Point(82, 3);
            comboBoxToRSL.Name = "comboBoxToRSL";
            comboBoxToRSL.Size = new System.Drawing.Size(53, 21);
            comboBoxToRSL.TabIndex = 1;
            comboBoxToRSL.SelectedIndexChanged += new EventHandler(comboBoxToRSL_SelectedIndexChanged);
            comboBoxToRSL.Items.AddRange(new object[] {
                "0",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15",
                "16",
                "17",
                "18",
                "19",
                "20"
            });
            // 
            // comboBoxFromRSL
            // 
            comboBoxFromRSL.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFromRSL.FormattingEnabled = true;
            comboBoxFromRSL.Location = new System.Drawing.Point(20, 3);
            comboBoxFromRSL.Name = "comboBoxFromRSL";
            comboBoxFromRSL.Size = new System.Drawing.Size(56, 21);
            comboBoxFromRSL.TabIndex = 0;
            comboBoxFromRSL.SelectedIndexChanged += new EventHandler(comboBoxFromRSL_SelectedIndexChanged);
            comboBoxFromRSL.Items.AddRange(new object[] {
                "0",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15",
                "16",
                "17",
                "18",
                "19",
                "20"
            });
            //
            // labelRowNumber
            //
            labelRowNumber.AutoSize = true;
            labelRowNumber.Location = new System.Drawing.Point(0, 5);
            labelRowNumber.Name = "labelArea";
            labelRowNumber.Size = new System.Drawing.Size(20, 13);
            labelRowNumber.TabIndex = 25;
            labelRowNumber.Text = rowNumber;

            Controls.Add(comboBoxTreatment);
            Controls.Add(comboBoxFunctionalClassification);
            Controls.Add(comboBoxToRSL);
            Controls.Add(comboBoxFromRSL);
            Controls.Add(labelRowNumber);
            Location = new System.Drawing.Point(5, location);
            Name = "analysisRowPanel";
            Size = new System.Drawing.Size(595, 28);
            TabIndex = 1;
        }

        private void comboBoxTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableValid = false;
        }

        private void comboBoxFunctionalClassification_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableValid = false;
        }

        internal void initRSLAreas()
        {
            rslArea = new Dictionary<int, double>();
            for (int i = getFromRSL(); i <= getToRSL(); ++i)
            {
                rslArea.Add(i, 0.0);
            }
        }

        internal void addRSLArea(int key, double value)
        {
            rslArea[key] += value;
        }

        internal Dictionary<int, double> getRSLAreas()
        {
            return rslArea;
        }

        internal string getTreatment()
        {
            return comboBoxTreatment.Text;
        }

        internal string getFunctionalClassification()
        {
            return comboBoxFunctionalClassification.Text;
        }

        internal int getToRSL()
        {
            return Util.ToInt(comboBoxToRSL.Text);
        }

        internal int getFromRSL()
        {
            return Util.ToInt(comboBoxFromRSL.Text);
        }

        private void comboBoxToRSL_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableValid = false;
            comboBoxTreatment.Items.Clear();
            int toRSL = Util.ToInt(comboBoxToRSL.Text);
            if (!string.IsNullOrEmpty(comboBoxFromRSL.Text))
            {
                int fromRSL = Util.ToInt(comboBoxFromRSL.Text);
                if (toRSL < fromRSL) comboBoxFromRSL.SelectedIndex = toRSL;
            }

            if (toRSL == 0)
            {
                comboBoxTreatment.Items.AddRange(new object[]
                {
                    "Cold In-place Recycling (2/2 in.)",
                    "Thick Overlay (3 in.)",
                    "Rotomill & Thick Overlay (3 in.)",
                    "Base Repair/ Pavement Replacement",
                    "Cold Recycling & Overlay (3/3 in.)",
                    "Full Depth Reclamation & Overlay (3/3 in.)",
                    "Base/ Pavement Replacement (3/3/6 in.)"
                });
            }
            else if (toRSL < 7)
            {
                comboBoxTreatment.Items.AddRange(new object[]
                {
                    "Scrub Seal",
                    "Single Chip Seal",
                    "Slurry Seal",
                    "Microsurfacing",
                    "Plant Mix Seal",
                    "Cold In-place Recycling (2 in. with chip seal)",
                    "Thin Hot Mix Overlay (<2 in.)",
                    "HMA (leveling) & Overlay (<2 in.)",
                    "Hot Surface Recycling",
                    "Rotomill & Overlay (<2 in.)",
                    "Cold In-place Recycling (2/2 in.)",
                    "Thick Overlay (3 in.)",
                    "Rotomill & Thick Overlay (3 in.)",
                    "Base Repair/ Pavement Replacement",
                    "Cold Recycling & Overlay (3/3 in.)",
                    "Full Depth Reclamation & Overlay (3/3 in.)",
                    "Base/ Pavement Replacement (3/3/6 in.)"
                });
            }
            else if (toRSL < 10)
            {
                comboBoxTreatment.Items.AddRange(new object[]
                {
                    "Fog Coat",
                    "High Mineral Asphalt Emulsion",
                    "Sand Seal",
                    "Scrub Seal",
                    "Single Chip Seal",
                    "Slurry Seal",
                    "Microsurfacing",
                    "Plant Mix Seal",
                    "Cold In-place Recycling (2 in. with chip seal)",
                    "Thin Hot Mix Overlay (<2 in.)",
                    "HMA (leveling) & Overlay (<2 in.)",
                    "Hot Surface Recycling",
                    "Rotomill & Overlay (<2 in.)",
                    "Cold In-place Recycling (2/2 in.)",
                    "Thick Overlay (3 in.)",
                    "Rotomill & Thick Overlay (3 in.)",
                    "Base Repair/ Pavement Replacement",
                    "Cold Recycling & Overlay (3/3 in.)",
                    "Full Depth Reclamation & Overlay (3/3 in.)",
                    "Base/ Pavement Replacement (3/3/6 in.)"
                });
            }
            else
            {
                comboBoxTreatment.Items.AddRange(new object[]
                {
                    "Crack Seal",
                    "Fog Coat",
                    "High Mineral Asphalt Emulsion",
                    "Sand Seal",
                    "Scrub Seal",
                    "Single Chip Seal",
                    "Slurry Seal",
                    "Microsurfacing",
                    "Plant Mix Seal",
                    "Cold In-place Recycling (2 in. with chip seal)",
                    "Thin Hot Mix Overlay (<2 in.)",
                    "HMA (leveling) & Overlay (<2 in.)",
                    "Hot Surface Recycling",
                    "Rotomill & Overlay (<2 in.)",
                    "Cold In-place Recycling (2/2 in.)",
                    "Thick Overlay (3 in.)",
                    "Rotomill & Thick Overlay (3 in.)",
                    "Base Repair/ Pavement Replacement",
                    "Cold Recycling & Overlay (3/3 in.)",
                    "Full Depth Reclamation & Overlay (3/3 in.)",
                    "Base/ Pavement Replacement (3/3/6 in.)"
                });
            }
        }

        private void comboBoxFromRSL_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableValid = false;
            int fromRSL = Util.ToInt(comboBoxFromRSL.Text);
            if (!string.IsNullOrEmpty(comboBoxToRSL.Text))
            {
                int toRSL = Util.ToInt(comboBoxToRSL.Text);
                if (toRSL < fromRSL) comboBoxToRSL.SelectedIndex = fromRSL;
            }
        }

    }
}