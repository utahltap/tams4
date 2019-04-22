using System;
using System.Windows.Forms;

namespace tams4a.Forms
{
    public partial class FormAnalysis : Form
    {
        public FormAnalysis()
        {
            InitializeComponent();
        }

        private void checkBox0_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown0.Enabled = checkBox0.Checked;
            comboBox0.Enabled = checkBox0.Checked;
            comboBoxTreatment0.Enabled = checkBox0.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = checkBox1.Checked;
            comboBox1.Enabled = checkBox1.Checked;
            comboBoxTreatment1.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = checkBox2.Checked;
            comboBox2.Enabled = checkBox2.Checked;
            comboBoxTreatment2.Enabled = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown3.Enabled = checkBox3.Checked;
            comboBox3.Enabled = checkBox3.Checked;
            comboBoxTreatment3.Enabled = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown4.Enabled = checkBox4.Checked;
            comboBox4.Enabled = checkBox4.Checked;
            comboBoxTreatment4.Enabled = checkBox4.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown5.Enabled = checkBox5.Checked;
            comboBox5.Enabled = checkBox5.Checked;
            comboBoxTreatment5.Enabled = checkBox5.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown6.Enabled = checkBox6.Checked;
            comboBox6.Enabled = checkBox6.Checked;
            comboBoxTreatment6.Enabled = checkBox6.Checked;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown7.Enabled = checkBox7.Checked;
            comboBox7.Enabled = checkBox7.Checked;
            comboBoxTreatment7.Enabled = checkBox7.Checked;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown8.Enabled = checkBox8.Checked;
            comboBox8.Enabled = checkBox8.Checked;
            comboBoxTreatment8.Enabled = checkBox8.Checked;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown9.Enabled = checkBox9.Checked;
            comboBox9.Enabled = checkBox9.Checked;
            comboBoxTreatment9.Enabled = checkBox9.Checked;
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown10.Enabled = checkBox10.Checked;
            comboBox10.Enabled = checkBox10.Checked;
            comboBoxTreatment10.Enabled = checkBox10.Checked;
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown11.Enabled = checkBox11.Checked;
            comboBox11.Enabled = checkBox11.Checked;
            comboBoxTreatment11.Enabled = checkBox11.Checked;
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown12.Enabled = checkBox12.Checked;
            comboBox12.Enabled = checkBox12.Checked;
            comboBoxTreatment12.Enabled = checkBox12.Checked;
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown13.Enabled = checkBox13.Checked;
            comboBox13.Enabled = checkBox13.Checked;
            comboBoxTreatment13.Enabled = checkBox13.Checked;
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown14.Enabled = checkBox14.Checked;
            comboBox14.Enabled = checkBox14.Checked;
            comboBoxTreatment14.Enabled = checkBox14.Checked;
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown15.Enabled = checkBox15.Checked;
            comboBox15.Enabled = checkBox15.Checked;
            comboBoxTreatment15.Enabled = checkBox15.Checked;
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown16.Enabled = checkBox16.Checked;
            comboBox16.Enabled = checkBox16.Checked;
            comboBoxTreatment16.Enabled = checkBox16.Checked;
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown17.Enabled = checkBox17.Checked;
            comboBox17.Enabled = checkBox17.Checked;
            comboBoxTreatment17.Enabled = checkBox17.Checked;
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown18.Enabled = checkBox18.Checked;
            comboBox18.Enabled = checkBox18.Checked;
            comboBoxTreatment18.Enabled = checkBox18.Checked;
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown19.Enabled = checkBox19.Checked;
            comboBox19.Enabled = checkBox19.Checked;
            comboBoxTreatment19.Enabled = checkBox19.Checked;
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown20.Enabled = checkBox20.Checked;
            comboBox20.Enabled = checkBox20.Checked;
            comboBoxTreatment20.Enabled = checkBox20.Checked;
        }

        //************************************************************************************************

        private void reconstructionTreatments(ComboBox comboBoxRSL, ComboBox comboBoxTreatment, string changed)
        {
            if (changed == "RSL")
            {
                if(comboBoxRSL == comboBox0) comboBoxTreatment.Items.Clear();
                if (comboBoxRSL.Text == "")
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
                else if (comboBoxRSL.Text == "12")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                    "Thick Overlay (3 in.)",
                    "Rotomill & Thick Overlay (3 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "14")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                    "Cold Recycling & Overlay (3/3 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "15")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                    "Cold In-place Recycling (2/2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "16")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                    "Base Repair/ Pavement Replacement"
                    });
                }
                else if (comboBoxRSL.Text == "20")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                    "Full Depth Reclamation & Overlay (3/3 in.)",
                    "Base/ Pavement Replacement (3/3/6 in.)"
                    });
                }
            }
            else if (changed == "Treatment")
            {
                if (comboBoxTreatment.Text == "Cold In-place Recycling (2/2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("15");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Cold In-place Recycling (2/2 in.)");
                }
                else if (comboBoxTreatment.Text == "Thick Overlay (3 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("12");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Thick Overlay (3 in.)");
                }
                else if (comboBoxTreatment.Text == "Rotomill & Thick Overlay (3 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("12");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Rotomill & Thick Overlay (3 in.)");
                }
                else if (comboBoxTreatment.Text == "Base Repair/ Pavement Replacement")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("16");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Base Repair/ Pavement Replacement");
                }
                else if (comboBoxTreatment.Text == "Cold Recycling & Overlay (3/3 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("14");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Cold Recycling & Overlay (3/3 in.)");
                }
                else if (comboBoxTreatment.Text == "Full Depth Reclamation & Overlay (3/3 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("20");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Full Depth Reclamation & Overlay (3/3 in.)");
                }
                else if (comboBoxTreatment.Text == "Base/ Pavement Replacement (3/3/6 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("20");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Base/ Pavement Replacement (3/3/6 in.)");
                }
            }
        }

        private void rsl1to3Treatments(ComboBox comboBoxRSL, ComboBox comboBoxTreatment, string changed)
        {
            if (changed == "RSL")
            {
                comboBoxTreatment.Items.Clear();
                if (comboBoxRSL.Text == "")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Scrub Seal",
                        "Single Chip Seal",
                        "Slurry Seal",
                        "Miscrosurfacing",
                        "Plant Mix Seal",
                        "Cold In-place Recycling (2 in. with chip seal)",
                        "Thin Hot Mix Overlay (<2 in.)",
                        "HMA (leveling) & Overlay (<2 in.)",
                        "Hot Surface Recycling",
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "1")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Scrub Seal",
                        "Single Chip Seal",
                        "Slurry Seal"
                    });
                }
                else if (comboBoxRSL.Text == "2")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Miscrosurfacing"
                    });
                }
                else if (comboBoxRSL.Text == "3")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Plant Mix Seal",
                        "Cold In-place Recycling (2 in. with chip seal)",
                        "Hot Surface Recycling"
                    });
                }
                else if (comboBoxRSL.Text == "4")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Thin Hot Mix Overlay (<2 in.)",
                        "HMA (leveling) & Overlay (<2 in.)",
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
            }
            else if (changed == "Treatment")
            {
                if (comboBoxTreatment.Text == "Scrub Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("1");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Scrub Seal");
                }
                else if (comboBoxTreatment.Text == "Single Chip Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("1");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Single Chip Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Slurry Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("1");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Slurry Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Miscrosurfacing")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("2");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Miscrosurfacing"); ;
                }
                else if (comboBoxTreatment.Text == "Plant Mix Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("3");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Plant Mix Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Cold In-place Recycling (2 in. with chip seal)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("3");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Cold In-place Recycling (2 in. with chip seal)"); ;
                }
                else if (comboBoxTreatment.Text == "Thin Hot Mix Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("4");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Thin Hot Mix Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "HMA (leveling) & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("4");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("HMA (leveling) & Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "Hot Surface Recycling")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("3");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Hot Surface Recycling"); ;
                }
                else if (comboBoxTreatment.Text == "Rotomill & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("4");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Rotomill & Overlay (<2 in.)"); ;
                }
            }
        }

        private void comboBox0_SelectedIndexChanged(object sender, EventArgs e)
        {
            reconstructionTreatments(comboBox0, comboBoxTreatment0, "RSL");
        }

        private void comboBoxTreatment0_SelectedIndexChanged(object sender, EventArgs e)
        {
            reconstructionTreatments(comboBox0, comboBoxTreatment0, "Treatment");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl1to3Treatments(comboBox1, comboBoxTreatment1, "RSL");
            reconstructionTreatments(comboBox1, comboBoxTreatment1, "RSL");
        }

        private void comboBoxTreatment1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl1to3Treatments(comboBox1, comboBoxTreatment1, "Treatment");
            reconstructionTreatments(comboBox1, comboBoxTreatment1, "Treatment");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl1to3Treatments(comboBox2, comboBoxTreatment2, "RSL");
            reconstructionTreatments(comboBox2, comboBoxTreatment2, "RSL");
        }

        private void comboBoxTreatment2_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl1to3Treatments(comboBox2, comboBoxTreatment2, "Treatment");
            reconstructionTreatments(comboBox2, comboBoxTreatment2, "Treatment");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl1to3Treatments(comboBox3, comboBoxTreatment3, "RSL");
            reconstructionTreatments(comboBox3, comboBoxTreatment3, "RSL");
        }

        private void comboBoxTreatment3_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl1to3Treatments(comboBox3, comboBoxTreatment3, "Treatment");
            reconstructionTreatments(comboBox3, comboBoxTreatment3, "Treatment");
        }
    }
}
