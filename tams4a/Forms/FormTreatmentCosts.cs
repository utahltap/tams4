using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormTreatmentCosts : Form
    {
        private DataTable treatments;
        private TamsProject Project;
        private Dictionary<string, double> updatedPricePerYard;
        private FormAnalysis analysis;

        public FormTreatmentCosts(TamsProject theProject, Dictionary<string, double> pricePerYard, FormAnalysis formAnalysis)
        {
            InitializeComponent();
            Project = theProject;
            updatedPricePerYard = pricePerYard;
            analysis = formAnalysis;
            treatments = Database.GetDataByQuery(Project.conn, "SELECT id, name, cost FROM treatments;");
            numericUpDown1.Value = Convert.ToDecimal(treatments.Rows[0]["cost"]);
            numericUpDown2.Value = Convert.ToDecimal(treatments.Rows[1]["cost"]);
            numericUpDown3.Value = Convert.ToDecimal(treatments.Rows[2]["cost"]);
            numericUpDown4.Value = Convert.ToDecimal(treatments.Rows[3]["cost"]);
            numericUpDown5.Value = Convert.ToDecimal(treatments.Rows[4]["cost"]);
            numericUpDown6.Value = Convert.ToDecimal(treatments.Rows[5]["cost"]);
            numericUpDown7.Value = Convert.ToDecimal(treatments.Rows[6]["cost"]);
            numericUpDown8.Value = Convert.ToDecimal(treatments.Rows[7]["cost"]);
            numericUpDown9.Value = Convert.ToDecimal(treatments.Rows[8]["cost"]);
            numericUpDown10.Value = Convert.ToDecimal(treatments.Rows[9]["cost"]);
            numericUpDown11.Value = Convert.ToDecimal(treatments.Rows[10]["cost"]);
            numericUpDown12.Value = Convert.ToDecimal(treatments.Rows[11]["cost"]);
            numericUpDown13.Value = Convert.ToDecimal(treatments.Rows[12]["cost"]);
            numericUpDown14.Value = Convert.ToDecimal(treatments.Rows[13]["cost"]);
            numericUpDown15.Value = Convert.ToDecimal(treatments.Rows[14]["cost"]);
            numericUpDown16.Value = Convert.ToDecimal(treatments.Rows[15]["cost"]);
            numericUpDown17.Value = Convert.ToDecimal(treatments.Rows[16]["cost"]);
            numericUpDown18.Value = Convert.ToDecimal(treatments.Rows[17]["cost"]);
            numericUpDown19.Value = Convert.ToDecimal(treatments.Rows[18]["cost"]);
            numericUpDown20.Value = Convert.ToDecimal(treatments.Rows[19]["cost"]);
            numericUpDown21.Value = Convert.ToDecimal(treatments.Rows[23]["cost"]);
            numericUpDown22.Value = Convert.ToDecimal(treatments.Rows[20]["cost"]);
            numericUpDown23.Value = Convert.ToDecimal(treatments.Rows[21]["cost"]);
            numericUpDown24.Value = Convert.ToDecimal(treatments.Rows[22]["cost"]);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            updatedPricePerYard["Crack Seal"] = Convert.ToDouble(numericUpDown1.Value);
            updatedPricePerYard["Fog Coat"] = Convert.ToDouble(numericUpDown5.Value);
            updatedPricePerYard["High Mineral Asphalt Emulsion"] = Convert.ToDouble(numericUpDown6.Value);
            updatedPricePerYard["Sand Seal"] = Convert.ToDouble(numericUpDown7.Value);
            updatedPricePerYard["Scrub Seal"] = Convert.ToDouble(numericUpDown8.Value);
            updatedPricePerYard["Single Chip Seal"] = Convert.ToDouble(numericUpDown9.Value);
            updatedPricePerYard["Slurry Seal"] = Convert.ToDouble(numericUpDown10.Value);
            updatedPricePerYard["Microsurfacing"] = Convert.ToDouble(numericUpDown11.Value);
            updatedPricePerYard["Plant Mix Seal"] = Convert.ToDouble(numericUpDown12.Value);
            updatedPricePerYard["Cold In-place Recycling (2 in. with chip seal)"] = Convert.ToDouble(numericUpDown13.Value);
            updatedPricePerYard["Thin Hot Mix Overlay (<2 in.)"] = Convert.ToDouble(numericUpDown14.Value);
            updatedPricePerYard["HMA (leveling) & Overlay (<2 in.)"] = Convert.ToDouble(numericUpDown15.Value);
            updatedPricePerYard["Hot Surface Recycling"] = Convert.ToDouble(numericUpDown16.Value);
            updatedPricePerYard["Rotomill & Overlay (<2 in.)"] = Convert.ToDouble(numericUpDown17.Value);
            updatedPricePerYard["Cold In-place Recycling (2/2 in.)"] = Convert.ToDouble(numericUpDown18.Value);
            updatedPricePerYard["Thick Overlay (3 in.)"] = Convert.ToDouble(numericUpDown19.Value);
            updatedPricePerYard["Rotomill & Thick Overlay (3 in.)"] = Convert.ToDouble(numericUpDown20.Value);
            updatedPricePerYard["Cold Recycling & Overlay (3/3 in.)"] = Convert.ToDouble(numericUpDown21.Value);
            updatedPricePerYard["Base Repair/ Pavement Replacement"] = Convert.ToDouble(numericUpDown22.Value);
            updatedPricePerYard["Full Depth Reclamation & Overlay (3/3 in.)"] = Convert.ToDouble(numericUpDown23.Value);
            updatedPricePerYard["Base/ Pavement Replacement (3/3/6 in.)"] = Convert.ToDouble(numericUpDown24.Value);

            analysis.pricePerYard = updatedPricePerYard;

            String sql = "UPDATE treatments SET cost = " + numericUpDown1.Value + " WHERE id = 0;\n"
                + "UPDATE treatments SET cost = " + numericUpDown1.Value + " WHERE id = 1;\n"
                + "UPDATE treatments SET cost = " + numericUpDown2.Value + " WHERE id = 2;\n"
                + "UPDATE treatments SET cost = " + numericUpDown3.Value + " WHERE id = 3;\n"
                + "UPDATE treatments SET cost = " + numericUpDown4.Value + " WHERE id = 4;\n"
                + "UPDATE treatments SET cost = " + numericUpDown5.Value + " WHERE id = 5;\n"
                + "UPDATE treatments SET cost = " + numericUpDown6.Value + " WHERE id = 6;\n"
                + "UPDATE treatments SET cost = " + numericUpDown7.Value + " WHERE id = 7;\n"
                + "UPDATE treatments SET cost = " + numericUpDown8.Value + " WHERE id = 8;\n"
                + "UPDATE treatments SET cost = " + numericUpDown9.Value + " WHERE id = 9;\n"
                + "UPDATE treatments SET cost = " + numericUpDown10.Value + " WHERE id = 10;\n"
                + "UPDATE treatments SET cost = " + numericUpDown11.Value + " WHERE id = 11;\n"
                + "UPDATE treatments SET cost = " + numericUpDown12.Value + " WHERE id = 12;\n"
                + "UPDATE treatments SET cost = " + numericUpDown13.Value + " WHERE id = 13;\n"
                + "UPDATE treatments SET cost = " + numericUpDown14.Value + " WHERE id = 14;\n"
                + "UPDATE treatments SET cost = " + numericUpDown15.Value + " WHERE id = 15;\n"
                + "UPDATE treatments SET cost = " + numericUpDown16.Value + " WHERE id = 16;\n"
                + "UPDATE treatments SET cost = " + numericUpDown17.Value + " WHERE id = 17;\n"
                + "UPDATE treatments SET cost = " + numericUpDown18.Value + " WHERE id = 18;\n"
                + "UPDATE treatments SET cost = " + numericUpDown19.Value + " WHERE id = 19;\n"
                + "UPDATE treatments SET cost = " + numericUpDown20.Value + " WHERE id = 20;\n"
                + "UPDATE treatments SET cost = " + numericUpDown21.Value + " WHERE id = 24;\n"
                + "UPDATE treatments SET cost = " + numericUpDown22.Value + " WHERE id = 21;\n"
                + "UPDATE treatments SET cost = " + numericUpDown23.Value + " WHERE id = 22;\n"
                + "UPDATE treatments SET cost = " + numericUpDown24.Value + " WHERE id = 23;";
            try
            {
                Database.ExecuteNonQuery(Project.conn, sql);
            }
            catch
            {
                MessageBox.Show("Failed to update changes to treatment costs", "Error: Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Arrow;
            Close();
            return;
        }
    }
}
