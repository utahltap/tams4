using System.Windows.Forms;

namespace tams4a.Forms
{
    internal class AnalysisRowPanel : Panel
    {
        private ComboBox comboBoxTreatment = new ComboBox();
        private ComboBox comboBoxYears = new ComboBox();
        private ComboBox comboBoxFunctionalClassification = new ComboBox();
        private ComboBox comboBoxToRSL = new ComboBox();
        private ComboBox comboBoxFromRSL = new ComboBox();

        public AnalysisRowPanel(int location)
        {
            // 
            // comboBoxTreatment
            // 
            comboBoxTreatment.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTreatment.FormattingEnabled = true;
            comboBoxTreatment.Location = new System.Drawing.Point(325, 3);
            comboBoxTreatment.Name = "comboBoxTreatment";
            comboBoxTreatment.Size = new System.Drawing.Size(250, 21);
            comboBoxTreatment.TabIndex = 4;
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
            // comboBoxYears
            // 
            comboBoxYears.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxYears.FormattingEnabled = true;
            comboBoxYears.Location = new System.Drawing.Point(267, 3);
            comboBoxYears.Name = "comboBoxYears";
            comboBoxYears.Size = new System.Drawing.Size(52, 21);
            comboBoxYears.TabIndex = 3;
            comboBoxYears.Items.AddRange(new object[] {
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
            // comboBoxFunctionalClassification
            // 
            comboBoxFunctionalClassification.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFunctionalClassification.FormattingEnabled = true;
            comboBoxFunctionalClassification.Location = new System.Drawing.Point(124, 3);
            comboBoxFunctionalClassification.Name = "comboBoxFunctionalClassification";
            comboBoxFunctionalClassification.Size = new System.Drawing.Size(137, 21);
            comboBoxFunctionalClassification.TabIndex = 2;
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
            comboBoxToRSL.Location = new System.Drawing.Point(65, 3);
            comboBoxToRSL.Name = "comboBoxToRSL";
            comboBoxToRSL.Size = new System.Drawing.Size(53, 21);
            comboBoxToRSL.TabIndex = 1;
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
            comboBoxFromRSL.Location = new System.Drawing.Point(3, 3);
            comboBoxFromRSL.Name = "comboBoxFromRSL";
            comboBoxFromRSL.Size = new System.Drawing.Size(56, 21);
            comboBoxFromRSL.TabIndex = 0;
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

            Controls.Add(comboBoxTreatment);
            Controls.Add(comboBoxYears);
            Controls.Add(comboBoxFunctionalClassification);
            Controls.Add(comboBoxToRSL);
            Controls.Add(comboBoxFromRSL);
            Location = new System.Drawing.Point(5, location);
            Name = "panel1";
            Size = new System.Drawing.Size(578, 28);
            TabIndex = 1;
        }
    }
}