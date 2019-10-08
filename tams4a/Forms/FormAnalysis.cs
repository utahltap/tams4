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
        private DataTable treatments;
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private List<ComboBox> comboBoxFunctionalClassifications = new List<ComboBox>();
        private List<ComboBox> comboBoxTreatments = new List<ComboBox>();
        private Dictionary<int, double> rslArea = new Dictionary<int, double>();
        private Dictionary<NumericUpDown, decimal> costBreakdown = new Dictionary<NumericUpDown, decimal>();
        private Dictionary<NumericUpDown, decimal> areaBreakdown = new Dictionary<NumericUpDown, decimal>();
        private TamsProject Project;
        private int numberOfRows = 1;
        private double estBudget = 0.00;
        private bool beingHandled = false;
        public Dictionary<string, double> pricePerYard = new Dictionary<string, double>();

        public FormAnalysis(TamsProject theProject)
        {
            InitializeComponent();
            AnalysisRowPanel newPanel = new AnalysisRowPanel(0);
            panelRows.Controls.Add(newPanel);
            Project = theProject;
            roads = Database.GetDataByQuery(Project.conn, "SELECT rsl, width, length, type FROM road GROUP BY TAMSID;");
            //checkBoxes.Add(checkBox0);
            //checkBoxes.Add(checkBox1);
            //checkBoxes.Add(checkBox2);
            //checkBoxes.Add(checkBox3);
            //checkBoxes.Add(checkBox4);
            //checkBoxes.Add(checkBox5);
            //checkBoxes.Add(checkBox6);
            //checkBoxes.Add(checkBox7);
            //checkBoxes.Add(checkBox8);
            //checkBoxes.Add(checkBox9);
            //checkBoxes.Add(checkBox10);
            //checkBoxes.Add(checkBox11);
            //checkBoxes.Add(checkBox12);
            //checkBoxes.Add(checkBox13);
            //checkBoxes.Add(checkBox14);
            //checkBoxes.Add(checkBox15);
            //checkBoxes.Add(checkBox16);
            //checkBoxes.Add(checkBox17);
            //checkBoxes.Add(checkBox18);
            //checkBoxes.Add(checkBox19);
            //checkBoxes.Add(checkBox20);
            //comboBoxFunctionalClassifications.Add(comboBoxType0);
            //comboBoxFunctionalClassifications.Add(comboBoxType1);
            //comboBoxFunctionalClassifications.Add(comboBoxType2);
            //comboBoxFunctionalClassifications.Add(comboBoxType3);
            //comboBoxFunctionalClassifications.Add(comboBoxType4);
            //comboBoxFunctionalClassifications.Add(comboBoxType5);
            //comboBoxFunctionalClassifications.Add(comboBoxType6);
            //comboBoxFunctionalClassifications.Add(comboBoxType7);
            //comboBoxFunctionalClassifications.Add(comboBoxType8);
            //comboBoxFunctionalClassifications.Add(comboBoxType9);
            //comboBoxFunctionalClassifications.Add(comboBoxType10);
            //comboBoxFunctionalClassifications.Add(comboBoxType11);
            //comboBoxFunctionalClassifications.Add(comboBoxType12);
            //comboBoxFunctionalClassifications.Add(comboBoxType13);
            //comboBoxFunctionalClassifications.Add(comboBoxType14);
            //comboBoxFunctionalClassifications.Add(comboBoxType15);
            //comboBoxFunctionalClassifications.Add(comboBoxType16);
            //comboBoxFunctionalClassifications.Add(comboBoxType17);
            //comboBoxFunctionalClassifications.Add(comboBoxType18);
            //comboBoxFunctionalClassifications.Add(comboBoxType19);
            //comboBoxFunctionalClassifications.Add(comboBoxType20);       
            //comboBoxTreatments.Add(comboBoxTreatment0);
            //comboBoxTreatments.Add(comboBoxTreatment1);
            //comboBoxTreatments.Add(comboBoxTreatment2);
            //comboBoxTreatments.Add(comboBoxTreatment3);
            //comboBoxTreatments.Add(comboBoxTreatment4);
            //comboBoxTreatments.Add(comboBoxTreatment5);
            //comboBoxTreatments.Add(comboBoxTreatment6);
            //comboBoxTreatments.Add(comboBoxTreatment7);
            //comboBoxTreatments.Add(comboBoxTreatment8);
            //comboBoxTreatments.Add(comboBoxTreatment9);
            //comboBoxTreatments.Add(comboBoxTreatment10);
            //comboBoxTreatments.Add(comboBoxTreatment11);
            //comboBoxTreatments.Add(comboBoxTreatment12);
            //comboBoxTreatments.Add(comboBoxTreatment13);
            //comboBoxTreatments.Add(comboBoxTreatment14);
            //comboBoxTreatments.Add(comboBoxTreatment15);
            //comboBoxTreatments.Add(comboBoxTreatment16);
            //comboBoxTreatments.Add(comboBoxTreatment17);
            //comboBoxTreatments.Add(comboBoxTreatment18);
            //comboBoxTreatments.Add(comboBoxTreatment19);
            //comboBoxTreatments.Add(comboBoxTreatment20);
            for (int i = 0; i <= 20; i++)
            {
                rslArea.Add(i, 0.0);
            }
            treatments = Database.GetDataByQuery(Project.conn, "SELECT id, name, cost FROM treatments;");
            pricePerYard.Add("", 0.0);
            pricePerYard.Add("Crack Seal", Convert.ToDouble(treatments.Rows[0]["cost"]));
            pricePerYard.Add("Fog Coat", Convert.ToDouble(treatments.Rows[4]["cost"]));
            pricePerYard.Add("High Mineral Asphalt Emulsion", Convert.ToDouble(treatments.Rows[5]["cost"]));
            pricePerYard.Add("Sand Seal", Convert.ToDouble(treatments.Rows[6]["cost"]));
            pricePerYard.Add("Scrub Seal", Convert.ToDouble(treatments.Rows[7]["cost"]));
            pricePerYard.Add("Single Chip Seal", Convert.ToDouble(treatments.Rows[8]["cost"]));
            pricePerYard.Add("Slurry Seal", Convert.ToDouble(treatments.Rows[9]["cost"]));
            pricePerYard.Add("Microsurfacing", Convert.ToDouble(treatments.Rows[10]["cost"]));
            pricePerYard.Add("Plant Mix Seal", Convert.ToDouble(treatments.Rows[11]["cost"]));
            pricePerYard.Add("Cold In-place Recycling (2 in. with chip seal)", Convert.ToDouble(treatments.Rows[12]["cost"]));
            pricePerYard.Add("Thin Hot Mix Overlay (<2 in.)", Convert.ToDouble(treatments.Rows[13]["cost"]));
            pricePerYard.Add("HMA (leveling) & Overlay (<2 in.)", Convert.ToDouble(treatments.Rows[14]["cost"]));
            pricePerYard.Add("Hot Surface Recycling", Convert.ToDouble(treatments.Rows[15]["cost"]));
            pricePerYard.Add("Rotomill & Overlay (<2 in.)", Convert.ToDouble(treatments.Rows[16]["cost"]));
            pricePerYard.Add("Cold In-place Recycling (2/2 in.)", Convert.ToDouble(treatments.Rows[17]["cost"]));
            pricePerYard.Add("Thick Overlay (3 in.)", Convert.ToDouble(treatments.Rows[18]["cost"]));
            pricePerYard.Add("Rotomill & Thick Overlay (3 in.)", Convert.ToDouble(treatments.Rows[19]["cost"]));
            pricePerYard.Add("Base Repair/ Pavement Replacement", Convert.ToDouble(treatments.Rows[20]["cost"]));
            pricePerYard.Add("Full Depth Reclamation & Overlay (3/3 in.)", Convert.ToDouble(treatments.Rows[21]["cost"]));
            pricePerYard.Add("Base/ Pavement Replacement (3/3/6 in.)", Convert.ToDouble(treatments.Rows[22]["cost"]));
            pricePerYard.Add("Cold Recycling & Overlay (3/3 in.)", Convert.ToDouble(treatments.Rows[23]["cost"]));
        }

        //private void checkBox0_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType0.Enabled = checkBox0.Checked;
        //    comboBox0.Enabled = checkBox0.Checked;
        //    comboBoxTreatment0.Enabled = checkBox0.Checked;
        //}

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType1.Enabled = checkBox1.Checked;
        //    comboBox1.Enabled = checkBox1.Checked;
        //    comboBoxTreatment1.Enabled = checkBox1.Checked;
        //}

        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType2.Enabled = checkBox2.Checked;
        //    comboBox2.Enabled = checkBox2.Checked;
        //    comboBoxTreatment2.Enabled = checkBox2.Checked;
        //}

        //private void checkBox3_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType3.Enabled = checkBox3.Checked;
        //    comboBox3.Enabled = checkBox3.Checked;
        //    comboBoxTreatment3.Enabled = checkBox3.Checked;
        //}

        //private void checkBox4_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType4.Enabled = checkBox4.Checked;
        //    comboBox4.Enabled = checkBox4.Checked;
        //    comboBoxTreatment4.Enabled = checkBox4.Checked;
        //}

        //private void checkBox5_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType5.Enabled = checkBox5.Checked;
        //    comboBox5.Enabled = checkBox5.Checked;
        //    comboBoxTreatment5.Enabled = checkBox5.Checked;
        //}

        //private void checkBox6_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType6.Enabled = checkBox6.Checked;
        //    comboBox6.Enabled = checkBox6.Checked;
        //    comboBoxTreatment6.Enabled = checkBox6.Checked;
        //}

        //private void checkBox7_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType7.Enabled = checkBox7.Checked;
        //    comboBox7.Enabled = checkBox7.Checked;
        //    comboBoxTreatment7.Enabled = checkBox7.Checked;
        //}

        //private void checkBox8_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType8.Enabled = checkBox8.Checked;
        //    comboBox8.Enabled = checkBox8.Checked;
        //    comboBoxTreatment8.Enabled = checkBox8.Checked;
        //}

        //private void checkBox9_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType9.Enabled = checkBox9.Checked;
        //    comboBox9.Enabled = checkBox9.Checked;
        //    comboBoxTreatment9.Enabled = checkBox9.Checked;
        //}

        //private void checkBox10_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType10.Enabled = checkBox10.Checked;
        //    comboBox10.Enabled = checkBox10.Checked;
        //    comboBoxTreatment10.Enabled = checkBox10.Checked;
        //}

        //private void checkBox11_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType11.Enabled = checkBox11.Checked;
        //    comboBox11.Enabled = checkBox11.Checked;
        //    comboBoxTreatment11.Enabled = checkBox11.Checked;
        //}

        //private void checkBox12_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType12.Enabled = checkBox12.Checked;
        //    comboBox12.Enabled = checkBox12.Checked;
        //    comboBoxTreatment12.Enabled = checkBox12.Checked;
        //}

        //private void checkBox13_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType13.Enabled = checkBox13.Checked;
        //    comboBox13.Enabled = checkBox13.Checked;
        //    comboBoxTreatment13.Enabled = checkBox13.Checked;
        //}

        //private void checkBox14_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType14.Enabled = checkBox14.Checked;
        //    comboBox14.Enabled = checkBox14.Checked;
        //    comboBoxTreatment14.Enabled = checkBox14.Checked;
        //}

        //private void checkBox15_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType15.Enabled = checkBox15.Checked;
        //    comboBox15.Enabled = checkBox15.Checked;
        //    comboBoxTreatment15.Enabled = checkBox15.Checked;
        //}

        //private void checkBox16_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType16.Enabled = checkBox16.Checked;
        //    comboBox16.Enabled = checkBox16.Checked;
        //    comboBoxTreatment16.Enabled = checkBox16.Checked;
        //}

        //private void checkBox17_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType17.Enabled = checkBox17.Checked;
        //    comboBox17.Enabled = checkBox17.Checked;
        //    comboBoxTreatment17.Enabled = checkBox17.Checked;
        //}

        //private void checkBox18_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType18.Enabled = checkBox18.Checked;
        //    comboBox18.Enabled = checkBox18.Checked;
        //    comboBoxTreatment18.Enabled = checkBox18.Checked;
        //}

        //private void checkBox19_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType19.Enabled = checkBox19.Checked;
        //    comboBox19.Enabled = checkBox19.Checked;
        //    comboBoxTreatment19.Enabled = checkBox19.Checked;
        //}

        //private void checkBox20_CheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxType20.Enabled = checkBox20.Checked;
        //    comboBox20.Enabled = checkBox20.Checked;
        //    comboBoxTreatment20.Enabled = checkBox20.Checked;
        //}

        //************************************************************************************************

        private void reconstructionTreatments(ComboBox comboBoxRSL, ComboBox comboBoxTreatment, string changed)
        {
            if (changed == "RSL")
            {
                //if(comboBoxRSL == comboBox0) comboBoxTreatment.Items.Clear();
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

        //private void comboBox0_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    reconstructionTreatments(comboBox0, comboBoxTreatment0, "RSL");
        //}

        //private void comboBoxTreatment0_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    reconstructionTreatments(comboBox0, comboBoxTreatment0, "Treatment");
        //}

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl1to3Treatments(comboBox1, comboBoxTreatment1, "RSL");
        //    reconstructionTreatments(comboBox1, comboBoxTreatment1, "RSL");
        //}

        //private void comboBoxTreatment1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl1to3Treatments(comboBox1, comboBoxTreatment1, "Treatment");
        //    reconstructionTreatments(comboBox1, comboBoxTreatment1, "Treatment");
        //}

        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl1to3Treatments(comboBox2, comboBoxTreatment2, "RSL");
        //    reconstructionTreatments(comboBox2, comboBoxTreatment2, "RSL");
        //}

        //private void comboBoxTreatment2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl1to3Treatments(comboBox2, comboBoxTreatment2, "Treatment");
        //    reconstructionTreatments(comboBox2, comboBoxTreatment2, "Treatment");
        //}

        //private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl1to3Treatments(comboBox3, comboBoxTreatment3, "RSL");
        //    reconstructionTreatments(comboBox3, comboBoxTreatment3, "RSL");
        //}

        //private void comboBoxTreatment3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl1to3Treatments(comboBox3, comboBoxTreatment3, "Treatment");
        //    reconstructionTreatments(comboBox3, comboBoxTreatment3, "Treatment");
        //}

        //private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl4to6Treatments(comboBox4, comboBoxTreatment4, "RSL");
        //    reconstructionTreatments(comboBox4, comboBoxTreatment4, "RSL");
        //}

        //private void comboBoxTreatment4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl4to6Treatments(comboBox4, comboBoxTreatment4, "Treatment");
        //    reconstructionTreatments(comboBox4, comboBoxTreatment4, "Treatment");
        //}

        //private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl4to6Treatments(comboBox5, comboBoxTreatment5, "RSL");
        //    reconstructionTreatments(comboBox5, comboBoxTreatment5, "RSL");
        //}

        //private void comboBoxTreatment5_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl4to6Treatments(comboBox5, comboBoxTreatment5, "Treatment");
        //    reconstructionTreatments(comboBox5, comboBoxTreatment5, "Treatment");
        //}

        //private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl4to6Treatments(comboBox6, comboBoxTreatment6, "RSL");
        //    reconstructionTreatments(comboBox6, comboBoxTreatment6, "RSL");
        //}

        //private void comboBoxTreatment6_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl4to6Treatments(comboBox6, comboBoxTreatment6, "Treatment");
        //    reconstructionTreatments(comboBox6, comboBoxTreatment6, "Treatment");
        //}

        //private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl7to9Treatments(comboBox7, comboBoxTreatment7, "RSL");
        //    reconstructionTreatments(comboBox7, comboBoxTreatment7, "RSL");
        //}

        //private void comboBoxTreatment7_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl7to9Treatments(comboBox7, comboBoxTreatment7, "Treatment");
        //    reconstructionTreatments(comboBox7, comboBoxTreatment7, "Treatment");
        //}

        //private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl7to9Treatments(comboBox8, comboBoxTreatment8, "RSL");
        //    reconstructionTreatments(comboBox8, comboBoxTreatment8, "RSL");
        //}

        //private void comboBoxTreatment8_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl7to9Treatments(comboBox8, comboBoxTreatment8, "Treatment");
        //    reconstructionTreatments(comboBox8, comboBoxTreatment8, "Treatment");
        //}

        //private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl7to9Treatments(comboBox9, comboBoxTreatment9, "RSL");
        //    reconstructionTreatments(comboBox9, comboBoxTreatment9, "RSL");
        //}

        //private void comboBoxTreatment9_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl7to9Treatments(comboBox9, comboBoxTreatment9, "Treatment");
        //    reconstructionTreatments(comboBox9, comboBoxTreatment9, "Treatment");
        //}

        //private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl10to12Treatments(comboBox10, comboBoxTreatment10, "RSL");
        //    reconstructionTreatments(comboBox10, comboBoxTreatment10, "RSL");
        //}

        //private void comboBoxTreatment10_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl10to12Treatments(comboBox10, comboBoxTreatment10, "Treatment");
        //    reconstructionTreatments(comboBox10, comboBoxTreatment10, "Treatment");
        //}

        //private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl10to12Treatments(comboBox11, comboBoxTreatment11, "RSL");
        //    reconstructionTreatments(comboBox11, comboBoxTreatment11, "RSL");
        //}

        //private void comboBoxTreatment11_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl10to12Treatments(comboBox11, comboBoxTreatment11, "Treatment");
        //    reconstructionTreatments(comboBox11, comboBoxTreatment11, "Treatment");
        //}

        //private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl10to12Treatments(comboBox12, comboBoxTreatment12, "RSL");
        //    reconstructionTreatments(comboBox12, comboBoxTreatment12, "RSL");
        //}

        //private void comboBoxTreatment12_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl10to12Treatments(comboBox12, comboBoxTreatment12, "Treatment");
        //    reconstructionTreatments(comboBox12, comboBoxTreatment12, "Treatment");
        //}

        //private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl13to15Treatments(comboBox13, comboBoxTreatment13, "RSL");
        //    reconstructionTreatments(comboBox13, comboBoxTreatment13, "RSL");
        //}

        //private void comboBoxTreatment13_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl13to15Treatments(comboBox13, comboBoxTreatment13, "Treatment");
        //    reconstructionTreatments(comboBox13, comboBoxTreatment13, "Treatment");
        //}

        //private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl13to15Treatments(comboBox14, comboBoxTreatment14, "RSL");
        //    reconstructionTreatments(comboBox14, comboBoxTreatment14, "RSL");
        //}

        //private void comboBoxTreatment14_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl13to15Treatments(comboBox14, comboBoxTreatment14, "Treatment");
        //    reconstructionTreatments(comboBox14, comboBoxTreatment14, "Treatment");
        //}

        //private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl13to15Treatments(comboBox15, comboBoxTreatment15, "RSL");
        //    reconstructionTreatments(comboBox15, comboBoxTreatment15, "RSL");
        //}

        //private void comboBoxTreatment15_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl13to15Treatments(comboBox15, comboBoxTreatment15, "Treatment");
        //    reconstructionTreatments(comboBox15, comboBoxTreatment15, "Treatment");
        //}

        //private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl16to18Treatments(comboBox16, comboBoxTreatment16, "RSL");
        //    reconstructionTreatments(comboBox16, comboBoxTreatment16, "RSL");
        //}

        //private void comboBoxTreatment16_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl16to18Treatments(comboBox16, comboBoxTreatment16, "Treatment");
        //    reconstructionTreatments(comboBox16, comboBoxTreatment16, "Treatment");
        //}

        //private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl16to18Treatments(comboBox17, comboBoxTreatment17, "RSL");
        //    reconstructionTreatments(comboBox17, comboBoxTreatment17, "RSL");
        //}

        //private void comboBoxTreatment17_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl16to18Treatments(comboBox17, comboBoxTreatment17, "Treatment");
        //    reconstructionTreatments(comboBox17, comboBoxTreatment17, "Treatment");
        //}

        //private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl16to18Treatments(comboBox18, comboBoxTreatment18, "RSL");
        //    reconstructionTreatments(comboBox18, comboBoxTreatment18, "RSL");
        //}

        //private void comboBoxTreatment18_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl16to18Treatments(comboBox18, comboBoxTreatment18, "Treatment");
        //    reconstructionTreatments(comboBox18, comboBoxTreatment18, "Treatment");
        //}

        //private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl19to20Treatments(comboBox19, comboBoxTreatment19, "RSL");
        //    reconstructionTreatments(comboBox19, comboBoxTreatment19, "RSL");
        //}

        //private void comboBoxTreatment19_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl19to20Treatments(comboBox19, comboBoxTreatment19, "Treatment");
        //    reconstructionTreatments(comboBox19, comboBoxTreatment19, "Treatment");
        //}

        //private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl19to20Treatments(comboBox20, comboBoxTreatment20, "RSL");
        //    reconstructionTreatments(comboBox20, comboBoxTreatment20, "RSL");
        //}

        //private void comboBoxTreatment20_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    rsl19to20Treatments(comboBox20, comboBoxTreatment20, "Treatment");
        //    reconstructionTreatments(comboBox20, comboBoxTreatment20, "Treatment");
        //}

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            clearBudgetControlTable();
            costBreakdown.Clear();
            areaBreakdown.Clear();

            double totalArea = 0;
            double totalCost = 0;

            foreach (CheckBox checkBox in checkBoxes)
            {
                if (!checkBox.Checked) continue;

                string sql = "SELECT width, length, rsl FROM road WHERE rsl = " + checkBox.Text;
                if (comboBoxFunctionalClassifications[Util.ToInt(checkBox.Text)].Text != "")
                {
                    sql += " AND type = '" + comboBoxFunctionalClassifications[Util.ToInt(checkBox.Text)].Text + "';";
                }
                DataTable rslAreas = Database.GetDataByQuery(Project.conn, sql);
                foreach (DataRow row in rslAreas.Rows)
                {
                    double area = Util.ToDouble(row["width"].ToString()) * Util.ToDouble(row["length"].ToString());
                    rslArea[Util.ToInt(checkBox.Text)] += area;
                    totalArea += area;
                    totalCost += pricePerYard[comboBoxTreatments[Util.ToInt(checkBox.Text)].Text] * (area / 9);
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
                    tableBudgetControl.Height += (int)(temp.Height - 20);
                    tableBudgetControl.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                    tableBudgetControl.Controls.Add(new TextBox() { Text = i.ToString(), ReadOnly = true }, 0, tableBudgetControl.RowCount++);
                    NumericUpDown budgetUpDown = new NumericUpDown()
                    {
                        Increment = 100,
                        Minimum = 0,
                        Maximum = (decimal)(pricePerYard[comboBoxTreatments[i].Text] * (rslArea[i] / 9)),
                        Value = (decimal)(pricePerYard[comboBoxTreatments[i].Text] * (rslArea[i] / 9)),
                    };
                    NumericUpDown areaUpDown = new NumericUpDown()
                    {
                        Increment = 100,
                        Minimum = 0,
                        Maximum = (decimal)(rslArea[i] / 9),
                        Value = (decimal)(rslArea[i] / 9)
                    };
                    NumericUpDown percentCoveredUpDown = new NumericUpDown()
                    {
                        Increment = 5,
                        Minimum = 0,
                        Maximum = 100,
                        Value = 100
                    };

                    costBreakdown[budgetUpDown] = budgetUpDown.Value;
                    areaBreakdown[areaUpDown] = areaUpDown.Value;
                    double costPerYard = (double)(budgetUpDown.Value / areaUpDown.Value);
                    budgetUpDown.ValueChanged += new EventHandler(delegate (object _sender, EventArgs _e) { BudgetUpDown_ValueChanged(sender, e, costPerYard, budgetUpDown, areaUpDown, percentCoveredUpDown); });
                    areaUpDown.ValueChanged += new EventHandler(delegate (object _sender, EventArgs _e) { AreaUpDown_ValueChanged(sender, e, costPerYard, budgetUpDown, areaUpDown, percentCoveredUpDown); });
                    percentCoveredUpDown.ValueChanged += new EventHandler(delegate (object _sender, EventArgs _e) { PercentCoveredUpDown_ValueChanged(sender, e, costPerYard, budgetUpDown, areaUpDown, percentCoveredUpDown); } );
                    tableBudgetControl.Controls.Add(budgetUpDown, 1, tableBudgetControl.RowCount - 1);
                    tableBudgetControl.Controls.Add(areaUpDown, 2, tableBudgetControl.RowCount - 1);
                    tableBudgetControl.Controls.Add(percentCoveredUpDown, 3, tableBudgetControl.RowCount - 1);
                }
            }
            tableBudgetControl.Visible = true;
            for (int i = 0; i <= 20; i++)
            {
                rslArea[i] = 0;
            }
        }

        private void BudgetUpDown_ValueChanged(object sender, EventArgs e, double costPerYard, NumericUpDown budgetUpDown, NumericUpDown areaUpDown, NumericUpDown percentCoveredUpDown)
        {
            handleNumericUpDownChanges(costPerYard, budgetUpDown, areaUpDown, percentCoveredUpDown, "budget");
        }

        private void AreaUpDown_ValueChanged(object sender, EventArgs e, double costPerYard, NumericUpDown budgetUpDown, NumericUpDown areaUpDown, NumericUpDown percentCoveredUpDown)
        {
            handleNumericUpDownChanges(costPerYard, budgetUpDown, areaUpDown, percentCoveredUpDown, "area");
        }

        private void PercentCoveredUpDown_ValueChanged(object sender, EventArgs e, double costPerYard, NumericUpDown budgetUpDown, NumericUpDown areaUpDown, NumericUpDown percentCoveredUpDown)
        {
            handleNumericUpDownChanges(costPerYard, budgetUpDown, areaUpDown, percentCoveredUpDown, "percent");
        }

        private void handleNumericUpDownChanges(double costPerYard, NumericUpDown budgetUpDown, NumericUpDown areaUpDown, NumericUpDown percentCoveredUpDown, string caller)
        {
            if (beingHandled) return;
            beingHandled = true;

            if (caller == "area")
            {
                decimal newCost = (decimal)((double)areaUpDown.Value * costPerYard);
                decimal newPercentCovered = (decimal)(((double)areaUpDown.Value / (double)areaUpDown.Maximum) * 100);
                budgetUpDown.Value = newCost;
                percentCoveredUpDown.Value = newPercentCovered;
            }

            if (caller == "budget")
            {
                decimal newArea = (decimal)((double)budgetUpDown.Value / costPerYard);
                decimal newPercentCovered = (decimal)(((double)newArea / (double)areaUpDown.Maximum) * 100);
                areaUpDown.Value = newArea;
                percentCoveredUpDown.Value = newPercentCovered;
            }

            if (caller == "percent")
            {
                decimal newArea = (decimal)((double)areaUpDown.Maximum * (((double)percentCoveredUpDown.Value) / 100));
                decimal newCost = (decimal)((double)newArea * costPerYard);
                areaUpDown.Value = newArea;
                budgetUpDown.Value = newCost;
            }

            areaBreakdown[areaUpDown] = areaUpDown.Value;
            decimal totalArea = 0;
            foreach (decimal area in areaBreakdown.Values)
            {
                totalArea += area;
            }
            textBoxTotalArea.Text = String.Format("{0:n0}", (Math.Round(totalArea, 2))) + " yds\u00b2";

            costBreakdown[budgetUpDown] = budgetUpDown.Value;
            decimal totalCost = 0;
            foreach (decimal price in costBreakdown.Values)
            {
                totalCost += price;
            }
            textBoxTotalCost.Text = "$" + String.Format("{0:n0}", totalCost); ;
            if ((double)totalCost > estBudget)
            {
                labelOverBudget.Text = "$" + String.Format("{0:n0}", ((double)totalCost - estBudget)) + " over budget!";
                labelOverBudget.Visible = true;
            }
            else
            {
                labelOverBudget.Visible = false;
            }

            beingHandled = false;
        }

        private void clearBudgetControlTable()
        {
            tableBudgetControl.Visible = false;
            tableBudgetControl.RowCount = 1;
            tableBudgetControl.Controls.Clear();
            tableBudgetControl.RowStyles.Clear();
            tableBudgetControl.ColumnCount = 4;
            tableBudgetControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tableBudgetControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            tableBudgetControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            tableBudgetControl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableBudgetControl.Controls.Add(labelRSLx, 0, 0);
            tableBudgetControl.Controls.Add(labelBudgetUsed, 1, 0);
            tableBudgetControl.Controls.Add(labelAreaCovered, 2, 0);
            tableBudgetControl.Controls.Add(labelPercentConvered, 3, 0);
            tableBudgetControl.Location = new System.Drawing.Point(14, 95);
            tableBudgetControl.Name = "tableBudgetControl";
            tableBudgetControl.RowCount = 1;
            tableBudgetControl.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableBudgetControl.Size = new System.Drawing.Size(300, 15);
            tableBudgetControl.TabIndex = 32;
            tableBudgetControl.AutoScroll = true;
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

        private void buttonTreatmentCosts_Click(object sender, EventArgs e)
        {
            FormTreatmentCosts treatmentCosts = new FormTreatmentCosts(Project, pricePerYard, this);
            treatmentCosts.ShowDialog();
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            AnalysisRowPanel newPanel = new AnalysisRowPanel(28 * numberOfRows);
            panelRows.Controls.Add(newPanel);
            numberOfRows++;
        }
    }
}