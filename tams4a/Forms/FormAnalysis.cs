using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormAnalysis : Form
    {
        private DataTable roads;
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private List<ComboBox> comboBoxTreatments = new List<ComboBox>();
        private Dictionary<int, double> rslArea = new Dictionary<int, double>();
        private Dictionary<string, double> pricePerYard = new Dictionary<string, double>();
        private double estBudget = 0.00;

        public FormAnalysis(TamsProject Project)
        {
            InitializeComponent();
            roads = Database.GetDataByQuery(Project.conn, "SELECT rsl, width, length FROM road GROUP BY TAMSID;");
            checkBoxes.Add(checkBox0);
            checkBoxes.Add(checkBox1);
            checkBoxes.Add(checkBox2);
            checkBoxes.Add(checkBox3);
            checkBoxes.Add(checkBox4);
            checkBoxes.Add(checkBox5);
            checkBoxes.Add(checkBox6);
            checkBoxes.Add(checkBox7);
            checkBoxes.Add(checkBox8);
            checkBoxes.Add(checkBox9);
            checkBoxes.Add(checkBox10);
            checkBoxes.Add(checkBox11);
            checkBoxes.Add(checkBox12);
            checkBoxes.Add(checkBox13);
            checkBoxes.Add(checkBox14);
            checkBoxes.Add(checkBox15);
            checkBoxes.Add(checkBox16);
            checkBoxes.Add(checkBox17);
            checkBoxes.Add(checkBox18);
            checkBoxes.Add(checkBox19);
            checkBoxes.Add(checkBox20);
            comboBoxTreatments.Add(comboBoxTreatment0);
            comboBoxTreatments.Add(comboBoxTreatment1);
            comboBoxTreatments.Add(comboBoxTreatment2);
            comboBoxTreatments.Add(comboBoxTreatment3);
            comboBoxTreatments.Add(comboBoxTreatment4);
            comboBoxTreatments.Add(comboBoxTreatment5);
            comboBoxTreatments.Add(comboBoxTreatment6);
            comboBoxTreatments.Add(comboBoxTreatment7);
            comboBoxTreatments.Add(comboBoxTreatment8);
            comboBoxTreatments.Add(comboBoxTreatment9);
            comboBoxTreatments.Add(comboBoxTreatment10);
            comboBoxTreatments.Add(comboBoxTreatment11);
            comboBoxTreatments.Add(comboBoxTreatment12);
            comboBoxTreatments.Add(comboBoxTreatment13);
            comboBoxTreatments.Add(comboBoxTreatment14);
            comboBoxTreatments.Add(comboBoxTreatment15);
            comboBoxTreatments.Add(comboBoxTreatment16);
            comboBoxTreatments.Add(comboBoxTreatment17);
            comboBoxTreatments.Add(comboBoxTreatment18);
            comboBoxTreatments.Add(comboBoxTreatment19);
            comboBoxTreatments.Add(comboBoxTreatment20);
            for (int i = 0; i <= 20; i++)
            {
                rslArea.Add(i, 0.0);
            }
            pricePerYard.Add("", 0.0);
            pricePerYard.Add("Crack Seal", 0.45);
            pricePerYard.Add("Fog Coat", 0.68);
            pricePerYard.Add("High Mineral Asphalt Emulsion", 1.80);
            pricePerYard.Add("Sand Seal", 0.98);
            pricePerYard.Add("Scrub Seal", 1.50);
            pricePerYard.Add("Single Chip Seal", 1.95);
            pricePerYard.Add("Slurry Seal", 2.63);
            pricePerYard.Add("Microsurfacing", 3.60);
            pricePerYard.Add("Plant Mix Seal", 8.40);
            pricePerYard.Add("Cold In-place Recycling (2 in. with chip seal)", 7.50);
            pricePerYard.Add("Thin Hot Mix Overlay (<2 in.)", 10.13);
            pricePerYard.Add("HMA (leveling) & Overlay (<2 in.)", 11.25);
            pricePerYard.Add("Hot Surface Recycling", 7.50);
            pricePerYard.Add("Rotomill & Overlay (<2 in.)", 12.60);
            pricePerYard.Add("Cold In-place Recycling (2/2 in.)", 15.45);
            pricePerYard.Add("Thick Overlay (3 in.)", 15.00);
            pricePerYard.Add("Rotomill & Thick Overlay (3 in.)", 16.50);
            pricePerYard.Add("Base Repair/ Pavement Replacement", 18.00);
            pricePerYard.Add("Cold Recycling & Overlay (3/3 in.)", 16.73);
            pricePerYard.Add("Full Depth Reclamation & Overlay (3/3 in.)", 19.88);
            pricePerYard.Add("Base/ Pavement Replacement (3/3/6 in.)", 28.50);

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
                        "Microsurfacing",
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
                        "Microsurfacing"
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
                else if (comboBoxTreatment.Text == "Microsurfacing")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("2");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Microsurfacing"); ;
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

        private void rsl4to6Treatments(ComboBox comboBoxRSL, ComboBox comboBoxTreatment, string changed)
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
                        "Microsurfacing",
                        "Plant Mix Seal",
                        "Cold In-place Recycling (2 in. with chip seal)",
                        "Thin Hot Mix Overlay (<2 in.)",
                        "HMA (leveling) & Overlay (<2 in.)",
                        "Hot Surface Recycling",
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "3")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Scrub Seal",
                        "Single Chip Seal",
                        "Slurry Seal",
                        "Microsurfacing"
                    });
                }
                else if (comboBoxRSL.Text == "4")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Plant Mix Seal",
                        "Cold In-place Recycling (2 in. with chip seal)"
                    });
                }
                else if (comboBoxRSL.Text == "5")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Hot Surface Recycling"
                    });
                }
                else if (comboBoxRSL.Text == "6")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Thin Hot Mix Overlay (<2 in.)",
                        "HMA (leveling) & Overlay (<2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "7")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
            }
            else if (changed == "Treatment")
            {
                if (comboBoxTreatment.Text == "Scrub Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("3");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Scrub Seal");
                }
                else if (comboBoxTreatment.Text == "Single Chip Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("3");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Single Chip Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Slurry Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("3");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Slurry Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Microsurfacing")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("3");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Microsurfacing"); ;
                }
                else if (comboBoxTreatment.Text == "Plant Mix Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("4");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Plant Mix Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Cold In-place Recycling (2 in. with chip seal)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("4");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Cold In-place Recycling (2 in. with chip seal)"); ;
                }
                else if (comboBoxTreatment.Text == "Thin Hot Mix Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("6");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Thin Hot Mix Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "HMA (leveling) & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("6");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("HMA (leveling) & Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "Hot Surface Recycling")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Hot Surface Recycling"); ;
                }
                else if (comboBoxTreatment.Text == "Rotomill & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Rotomill & Overlay (<2 in.)"); ;
                }
            }
        }

        private void rsl7to9Treatments(ComboBox comboBoxRSL, ComboBox comboBoxTreatment, string changed)
        {
            if (changed == "RSL")
            {
                comboBoxTreatment.Items.Clear();
                if (comboBoxRSL.Text == "")
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
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "1")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Fog Coat",
                        "High Mineral Asphalt Emulsion",
                        "Sand Seal"
                    });
                }
                else if (comboBoxRSL.Text == "5")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Scrub Seal",
                        "Single Chip Seal",
                        "Slurry Seal",
                        "Microsurfacing",
                        "Plant Mix Seal",
                        "Cold In-place Recycling (2 in. with chip seal)"
                    });
                }
                else if (comboBoxRSL.Text == "7")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Thin Hot Mix Overlay (<2 in.)",
                        "Hot Surface Recycling"
                    });
                }
                else if (comboBoxRSL.Text == "8")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "HMA (leveling) & Overlay (<2 in.)",
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
            }
            else if (changed == "Treatment")
            {
                if (comboBoxTreatment.Text == "Fog Coat")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("1");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Fog Coat");
                }
                else if (comboBoxTreatment.Text == "High Mineral Asphalt Emulsion")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("1");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("High Mineral Asphalt Emulsion"); ;
                }
                else if (comboBoxTreatment.Text == "Sand Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("1");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Sand Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Scrub Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Scrub Seal");
                }
                else if (comboBoxTreatment.Text == "Single Chip Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Single Chip Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Slurry Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Slurry Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Microsurfacing")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Microsurfacing"); ;
                }
                else if (comboBoxTreatment.Text == "Plant Mix Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Plant Mix Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Cold In-place Recycling (2 in. with chip seal)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Cold In-place Recycling (2 in. with chip seal)"); ;
                }
                else if (comboBoxTreatment.Text == "Thin Hot Mix Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Thin Hot Mix Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "HMA (leveling) & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("HMA (leveling) & Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "Hot Surface Recycling")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Hot Surface Recycling"); ;
                }
                else if (comboBoxTreatment.Text == "Rotomill & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Rotomill & Overlay (<2 in.)"); ;
                }
            }
        }

        private void rsl10to12Treatments(ComboBox comboBoxRSL, ComboBox comboBoxTreatment, string changed)
        {
            if (changed == "RSL")
            {
                comboBoxTreatment.Items.Clear();
                if (comboBoxRSL.Text == "")
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
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "1")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Crack Seal",
                        "Fog Coat"
                    });
                }
                else if (comboBoxRSL.Text == "2")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "High Mineral Asphalt Emulsion",
                        "Sand Seal"
                    });
                }
                else if (comboBoxRSL.Text == "5")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Scrub Seal",
                        "Single Chip Seal",
                        "Slurry Seal"
                    });
                }
                else if (comboBoxRSL.Text == "6")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Cold In-place Recycling (2 in. with chip seal)"
                    });
                }
                else if (comboBoxRSL.Text == "7")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Microsurfacing",
                        "Plant Mix Seal",
                        "Thin Hot Mix Overlay (<2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "8")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "HMA (leveling) & Overlay (<2 in.)",
                        "Hot Surface Recycling",
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
            }
            else if (changed == "Treatment")
            {
                if (comboBoxTreatment.Text == "Crack Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("1");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Crack Seal");
                }
                else if (comboBoxTreatment.Text == "Fog Coat")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("1");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Fog Coat");
                }
                else if (comboBoxTreatment.Text == "High Mineral Asphalt Emulsion")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("2");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("High Mineral Asphalt Emulsion"); ;
                }
                else if (comboBoxTreatment.Text == "Sand Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("2");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Sand Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Scrub Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Scrub Seal");
                }
                else if (comboBoxTreatment.Text == "Single Chip Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Single Chip Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Slurry Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Slurry Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Microsurfacing")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Microsurfacing"); ;
                }
                else if (comboBoxTreatment.Text == "Plant Mix Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Plant Mix Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Cold In-place Recycling (2 in. with chip seal)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("6");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Cold In-place Recycling (2 in. with chip seal)"); ;
                }
                else if (comboBoxTreatment.Text == "Thin Hot Mix Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Thin Hot Mix Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "HMA (leveling) & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("HMA (leveling) & Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "Hot Surface Recycling")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Hot Surface Recycling"); ;
                }
                else if (comboBoxTreatment.Text == "Rotomill & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Rotomill & Overlay (<2 in.)"); ;
                }
            }
        }

        private void rsl13to15Treatments(ComboBox comboBoxRSL, ComboBox comboBoxTreatment, string changed)
        {
            if (changed == "RSL")
            {
                comboBoxTreatment.Items.Clear();
                if (comboBoxRSL.Text == "")
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
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "2")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Crack Seal",
                        "Fog Coat",
                        "Sand Seal"
                    });
                }
                else if (comboBoxRSL.Text == "3")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "High Mineral Asphalt Emulsion",
                    });
                }
                else if (comboBoxRSL.Text == "5")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Scrub Seal",
                        "Single Chip Seal",
                        "Slurry Seal"
                    });
                }
                else if (comboBoxRSL.Text == "7")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Microsurfacing",
                        "Plant Mix Seal",
                        "Cold In-place Recycling (2 in. with chip seal)",
                        "Thin Hot Mix Overlay (<2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "8")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "HMA (leveling) & Overlay (<2 in.)",
                        "Hot Surface Recycling",
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
            }
            else if (changed == "Treatment")
            {
                if (comboBoxTreatment.Text == "Crack Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("2");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Crack Seal");
                }
                else if (comboBoxTreatment.Text == "Fog Coat")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("2");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Fog Coat");
                }
                else if (comboBoxTreatment.Text == "High Mineral Asphalt Emulsion")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("3");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("High Mineral Asphalt Emulsion"); ;
                }
                else if (comboBoxTreatment.Text == "Sand Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("2");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Sand Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Scrub Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Scrub Seal");
                }
                else if (comboBoxTreatment.Text == "Single Chip Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Single Chip Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Slurry Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Slurry Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Microsurfacing")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Microsurfacing"); ;
                }
                else if (comboBoxTreatment.Text == "Plant Mix Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Plant Mix Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Cold In-place Recycling (2 in. with chip seal)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Cold In-place Recycling (2 in. with chip seal)"); ;
                }
                else if (comboBoxTreatment.Text == "Thin Hot Mix Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Thin Hot Mix Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "HMA (leveling) & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("HMA (leveling) & Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "Hot Surface Recycling")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Hot Surface Recycling"); ;
                }
                else if (comboBoxTreatment.Text == "Rotomill & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Rotomill & Overlay (<2 in.)"); ;
                }
            }
        }

        private void rsl16to18Treatments(ComboBox comboBoxRSL, ComboBox comboBoxTreatment, string changed)
        {
            if (changed == "RSL")
            {
                comboBoxTreatment.Items.Clear();
                if (comboBoxRSL.Text == "")
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
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "2")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Fog Coat",
                        "Sand Seal"
                    });
                }
                else if (comboBoxRSL.Text == "3")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Crack Seal"
                    });
                }
                else if (comboBoxRSL.Text == "5")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "High Mineral Asphalt Emulsion",
                        "Scrub Seal",
                        "Single Chip Seal",
                        "Slurry Seal"
                    });
                }
                else if (comboBoxRSL.Text == "7")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Microsurfacing",
                        "Plant Mix Seal",
                        "Cold In-place Recycling (2 in. with chip seal)",
                        "Thin Hot Mix Overlay (<2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "8")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "HMA (leveling) & Overlay (<2 in.)",
                        "Hot Surface Recycling",
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
            }
            else if (changed == "Treatment")
            {
                if (comboBoxTreatment.Text == "Crack Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("3");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Crack Seal");
                }
                else if (comboBoxTreatment.Text == "Fog Coat")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("2");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Fog Coat");
                }
                else if (comboBoxTreatment.Text == "High Mineral Asphalt Emulsion")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("High Mineral Asphalt Emulsion"); ;
                }
                else if (comboBoxTreatment.Text == "Sand Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("2");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Sand Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Scrub Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Scrub Seal");
                }
                else if (comboBoxTreatment.Text == "Single Chip Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Single Chip Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Slurry Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Slurry Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Microsurfacing")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Microsurfacing"); ;
                }
                else if (comboBoxTreatment.Text == "Plant Mix Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Plant Mix Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Cold In-place Recycling (2 in. with chip seal)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Cold In-place Recycling (2 in. with chip seal)"); ;
                }
                else if (comboBoxTreatment.Text == "Thin Hot Mix Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Thin Hot Mix Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "HMA (leveling) & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("HMA (leveling) & Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "Hot Surface Recycling")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Hot Surface Recycling"); ;
                }
                else if (comboBoxTreatment.Text == "Rotomill & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Rotomill & Overlay (<2 in.)"); ;
                }
            }
        }

        private void rsl19to20Treatments(ComboBox comboBoxRSL, ComboBox comboBoxTreatment, string changed)
        {
            if (changed == "RSL")
            {
                comboBoxTreatment.Items.Clear();
                if (comboBoxRSL.Text == "")
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
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "2")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Crack Seal",
                        "Fog Coat",
                        "Sand Seal"
                    });
                }

                else if (comboBoxRSL.Text == "5")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "High Mineral Asphalt Emulsion",
                        "Scrub Seal",
                        "Single Chip Seal",
                        "Slurry Seal"
                    });
                }
                else if (comboBoxRSL.Text == "7")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "Microsurfacing",
                        "Plant Mix Seal",
                        "Cold In-place Recycling (2 in. with chip seal)",
                        "Thin Hot Mix Overlay (<2 in.)"
                    });
                }
                else if (comboBoxRSL.Text == "8")
                {
                    comboBoxTreatment.Items.AddRange(new object[]
                    {
                        "HMA (leveling) & Overlay (<2 in.)",
                        "Hot Surface Recycling",
                        "Rotomill & Overlay (<2 in.)"
                    });
                }
            }
            else if (changed == "Treatment")
            {
                if (comboBoxTreatment.Text == "Crack Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("2");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Crack Seal");
                }
                else if (comboBoxTreatment.Text == "Fog Coat")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("2");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Fog Coat");
                }
                else if (comboBoxTreatment.Text == "High Mineral Asphalt Emulsion")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("High Mineral Asphalt Emulsion"); ;
                }
                else if (comboBoxTreatment.Text == "Sand Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("2");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Sand Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Scrub Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Scrub Seal");
                }
                else if (comboBoxTreatment.Text == "Single Chip Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Single Chip Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Slurry Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("5");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Slurry Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Microsurfacing")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Microsurfacing"); ;
                }
                else if (comboBoxTreatment.Text == "Plant Mix Seal")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Plant Mix Seal"); ;
                }
                else if (comboBoxTreatment.Text == "Cold In-place Recycling (2 in. with chip seal)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Cold In-place Recycling (2 in. with chip seal)"); ;
                }
                else if (comboBoxTreatment.Text == "Thin Hot Mix Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("7");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Thin Hot Mix Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "HMA (leveling) & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("HMA (leveling) & Overlay (<2 in.)"); ;
                }
                else if (comboBoxTreatment.Text == "Hot Surface Recycling")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Hot Surface Recycling"); ;
                }
                else if (comboBoxTreatment.Text == "Rotomill & Overlay (<2 in.)")
                {
                    comboBoxRSL.SelectedIndex = comboBoxRSL.FindStringExact("8");
                    comboBoxTreatment.SelectedIndex = comboBoxTreatment.FindStringExact("Rotomill & Overlay (<2 in.)"); ;
                }
            }
        }

        //************************************************************************************************

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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl4to6Treatments(comboBox4, comboBoxTreatment4, "RSL");
            reconstructionTreatments(comboBox4, comboBoxTreatment4, "RSL");
        }

        private void comboBoxTreatment4_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl4to6Treatments(comboBox4, comboBoxTreatment4, "Treatment");
            reconstructionTreatments(comboBox4, comboBoxTreatment4, "Treatment");
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl4to6Treatments(comboBox5, comboBoxTreatment5, "RSL");
            reconstructionTreatments(comboBox5, comboBoxTreatment5, "RSL");
        }

        private void comboBoxTreatment5_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl4to6Treatments(comboBox5, comboBoxTreatment5, "Treatment");
            reconstructionTreatments(comboBox5, comboBoxTreatment5, "Treatment");
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl4to6Treatments(comboBox6, comboBoxTreatment6, "RSL");
            reconstructionTreatments(comboBox6, comboBoxTreatment6, "RSL");
        }

        private void comboBoxTreatment6_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl4to6Treatments(comboBox6, comboBoxTreatment6, "Treatment");
            reconstructionTreatments(comboBox6, comboBoxTreatment6, "Treatment");
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl7to9Treatments(comboBox7, comboBoxTreatment7, "RSL");
            reconstructionTreatments(comboBox7, comboBoxTreatment7, "RSL");
        }

        private void comboBoxTreatment7_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl7to9Treatments(comboBox7, comboBoxTreatment7, "Treatment");
            reconstructionTreatments(comboBox7, comboBoxTreatment7, "Treatment");
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl7to9Treatments(comboBox8, comboBoxTreatment8, "RSL");
            reconstructionTreatments(comboBox8, comboBoxTreatment8, "RSL");
        }

        private void comboBoxTreatment8_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl7to9Treatments(comboBox8, comboBoxTreatment8, "Treatment");
            reconstructionTreatments(comboBox8, comboBoxTreatment8, "Treatment");
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl7to9Treatments(comboBox9, comboBoxTreatment9, "RSL");
            reconstructionTreatments(comboBox9, comboBoxTreatment9, "RSL");
        }

        private void comboBoxTreatment9_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl7to9Treatments(comboBox9, comboBoxTreatment9, "Treatment");
            reconstructionTreatments(comboBox9, comboBoxTreatment9, "Treatment");
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl10to12Treatments(comboBox10, comboBoxTreatment10, "RSL");
            reconstructionTreatments(comboBox10, comboBoxTreatment10, "RSL");
        }

        private void comboBoxTreatment10_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl10to12Treatments(comboBox10, comboBoxTreatment10, "Treatment");
            reconstructionTreatments(comboBox10, comboBoxTreatment10, "Treatment");
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl10to12Treatments(comboBox11, comboBoxTreatment11, "RSL");
            reconstructionTreatments(comboBox11, comboBoxTreatment11, "RSL");
        }

        private void comboBoxTreatment11_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl10to12Treatments(comboBox11, comboBoxTreatment11, "Treatment");
            reconstructionTreatments(comboBox11, comboBoxTreatment11, "Treatment");
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl10to12Treatments(comboBox12, comboBoxTreatment12, "RSL");
            reconstructionTreatments(comboBox12, comboBoxTreatment12, "RSL");
        }

        private void comboBoxTreatment12_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl10to12Treatments(comboBox12, comboBoxTreatment12, "Treatment");
            reconstructionTreatments(comboBox12, comboBoxTreatment12, "Treatment");
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl13to15Treatments(comboBox13, comboBoxTreatment13, "RSL");
            reconstructionTreatments(comboBox13, comboBoxTreatment13, "RSL");
        }

        private void comboBoxTreatment13_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl13to15Treatments(comboBox13, comboBoxTreatment13, "Treatment");
            reconstructionTreatments(comboBox13, comboBoxTreatment13, "Treatment");
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl13to15Treatments(comboBox14, comboBoxTreatment14, "RSL");
            reconstructionTreatments(comboBox14, comboBoxTreatment14, "RSL");
        }

        private void comboBoxTreatment14_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl13to15Treatments(comboBox14, comboBoxTreatment14, "Treatment");
            reconstructionTreatments(comboBox14, comboBoxTreatment14, "Treatment");
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl13to15Treatments(comboBox15, comboBoxTreatment15, "RSL");
            reconstructionTreatments(comboBox15, comboBoxTreatment15, "RSL");
        }

        private void comboBoxTreatment15_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl13to15Treatments(comboBox15, comboBoxTreatment15, "Treatment");
            reconstructionTreatments(comboBox15, comboBoxTreatment15, "Treatment");
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl16to18Treatments(comboBox16, comboBoxTreatment16, "RSL");
            reconstructionTreatments(comboBox16, comboBoxTreatment16, "RSL");
        }

        private void comboBoxTreatment16_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl16to18Treatments(comboBox16, comboBoxTreatment16, "Treatment");
            reconstructionTreatments(comboBox16, comboBoxTreatment16, "Treatment");
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl16to18Treatments(comboBox17, comboBoxTreatment17, "RSL");
            reconstructionTreatments(comboBox17, comboBoxTreatment17, "RSL");
        }

        private void comboBoxTreatment17_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl16to18Treatments(comboBox17, comboBoxTreatment17, "Treatment");
            reconstructionTreatments(comboBox17, comboBoxTreatment17, "Treatment");
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl16to18Treatments(comboBox18, comboBoxTreatment18, "RSL");
            reconstructionTreatments(comboBox18, comboBoxTreatment18, "RSL");
        }

        private void comboBoxTreatment18_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl16to18Treatments(comboBox18, comboBoxTreatment18, "Treatment");
            reconstructionTreatments(comboBox18, comboBoxTreatment18, "Treatment");
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl19to20Treatments(comboBox19, comboBoxTreatment19, "RSL");
            reconstructionTreatments(comboBox19, comboBoxTreatment19, "RSL");
        }

        private void comboBoxTreatment19_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl19to20Treatments(comboBox19, comboBoxTreatment19, "Treatment");
            reconstructionTreatments(comboBox19, comboBoxTreatment19, "Treatment");
        }

        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl19to20Treatments(comboBox20, comboBoxTreatment20, "RSL");
            reconstructionTreatments(comboBox20, comboBoxTreatment20, "RSL");
        }

        private void comboBoxTreatment20_SelectedIndexChanged(object sender, EventArgs e)
        {
            rsl19to20Treatments(comboBox20, comboBoxTreatment20, "Treatment");
            reconstructionTreatments(comboBox20, comboBoxTreatment20, "Treatment");
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            clearBudgetControlTable();

            double totalArea = 0;
            double totalCost = 0;
            foreach (DataRow row in roads.Rows)
            {
                int i = 0;
                foreach (CheckBox checkBox in checkBoxes)
                {
                    if (checkBox.Checked && Util.ToInt(row["rsl"].ToString()) == i)
                    {
                        double area = Util.ToDouble(row["width"].ToString()) * Util.ToDouble(row["length"].ToString());
                        rslArea[i] += area;
                        totalArea += area;
                        totalCost += pricePerYard[comboBoxTreatments[i].Text] * (area / 9);
                    }
                    i++;
                }
            }
            double roundedCost = Math.Round(totalCost, 2);

            if (roundedCost > estBudget)
            {
                labelOverBudget.Text = "$" + String.Format("{0:n0}", (roundedCost - estBudget)) + " over budget!"; 
                labelOverBudget.Visible = true;
            }
            else
            {
                labelOverBudget.Visible = false;
            }
            textBoxTotalArea.Text = String.Format("{0:n0}", (Math.Round(totalArea/9, 2))) + " yds\u00b2"; 
            textBoxTotalCost.Text = "$" + String.Format("{0:n0}", roundedCost);

            foreach (int i in rslArea.Keys)
            {
                if (rslArea[i] > 0)
                {
                    RowStyle temp = tableBudgetControl.RowStyles[0];
                    tableBudgetControl.RowCount++;
                    tableBudgetControl.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                    tableBudgetControl.Height += (int)(temp.Height - 25);
                    tableBudgetControl.Controls.Add(new TextBox() { Text = i.ToString(), ReadOnly = true }, 0, tableBudgetControl.RowCount - 1);
                    tableBudgetControl.Controls.Add(new NumericUpDown() { Minimum = 0, Maximum = 999999999999, Value = (decimal)(pricePerYard[comboBoxTreatments[i].Text] * (rslArea[i] / 9)) }, 1, tableBudgetControl.RowCount - 1);
                    tableBudgetControl.Controls.Add(new NumericUpDown() { Minimum = 0, Maximum = 999999999999, Value = (decimal)(rslArea[i] / 9) }, 2, tableBudgetControl.RowCount - 1);
                }
            }
            
            for (int i = 0; i <= 20; i++)
            {
                rslArea[i] = 0;
            }
        }

        private void clearBudgetControlTable()
        {
            tableBudgetControl.RowCount = 1;
            tableBudgetControl.Controls.Clear();
            tableBudgetControl.RowStyles.Clear();
            tableBudgetControl.ColumnCount = 3;
            tableBudgetControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.40541F));
            tableBudgetControl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.5946F));
            tableBudgetControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 103F));
            tableBudgetControl.Controls.Add(labelAreaCovered, 2, 0);
            tableBudgetControl.Controls.Add(labelRSLx, 0, 0);
            tableBudgetControl.Controls.Add(labelBudgetUsed, 1, 0);
            tableBudgetControl.Location = new System.Drawing.Point(14, 95);
            tableBudgetControl.Name = "tableBudgetControl";
            tableBudgetControl.RowCount = 1;
            tableBudgetControl.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableBudgetControl.Size = new System.Drawing.Size(247, 15);
            tableBudgetControl.TabIndex = 32;
        }

        private void textBoxBudget_RemovePlaceholder(object sender, EventArgs e)
        {
            if (estBudget != 0.0)
            {
                textBoxBudget.Text = estBudget.ToString();
                return;
            }
            textBoxBudget.Text = "";
        }

        private void textBoxBudget_AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBudget.Text))
            {
                estBudget = 0.0;
                textBoxBudget.Text = "$0.00";
            }
            else
            {
                estBudget = Util.ToDouble(textBoxBudget.Text);
                textBoxBudget.Text = "$" + String.Format("{0:n0}", estBudget);
            }
            buttonCalculate_Click(sender, null);
        }

        private void textBoxBudget_EnterPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                panelCalculator.Focus();
            }
        }
    }
}
