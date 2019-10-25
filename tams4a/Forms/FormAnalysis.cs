using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using tams4a.Classes;
using tams4a.Classes.Roads;

namespace tams4a.Forms
{
    public partial class FormAnalysis : Form
    {
        private DataTable roads;
        private DataTable treatments;
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private List<ComboBox> comboBoxFunctionalClassifications = new List<ComboBox>();
        private List<ComboBox> comboBoxTreatments = new List<ComboBox>();
        private Dictionary<int, string> rowQueries = new Dictionary<int, string>();
        private Dictionary<int, BudgetControlTable> budgetControlTables = new Dictionary<int, BudgetControlTable>();
        private TamsProject Project;
        private int numberOfRows = 1;
        public double estBudget = 0.00;
        public double totalArea = 0.00;
        public double totalCost = 0.00;
        public Dictionary<string, double> pricePerYard = new Dictionary<string, double>();
        private ModuleRoads moduleRoads;
        private RoadReports roadReports;

        internal Dictionary<int, BudgetControlTable> BudgetControlTables { get => budgetControlTables; set => budgetControlTables = value; }

        public FormAnalysis(TamsProject theProject, ModuleRoads modRoads)
        {
            InitializeComponent();
            AnalysisRowPanel newPanel = new AnalysisRowPanel(0, "1");
            panelRows.Controls.Add(newPanel);
            Project = theProject;
            moduleRoads = modRoads;
            roadReports = new RoadReports(Project, moduleRoads);
            roads = Database.GetDataByQuery(Project.conn, "SELECT rsl, width, length, type FROM road GROUP BY TAMSID;");
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

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            totalArea = 0.0;
            totalCost = 0.0;
            int i = 0;
            foreach (AnalysisRowPanel rowPanel in panelRows.Controls)
            {
                if (string.IsNullOrEmpty(rowPanel.getFromRSL().ToString())
                    || string.IsNullOrEmpty(rowPanel.getToRSL().ToString())
                    || string.IsNullOrEmpty(rowPanel.getFunctionalClassification()))
                {
                    rowQueries[i] = "none";
                    continue;
                }
                string subQuery = "WHERE rsl >= " + rowPanel.getFromRSL() + " AND rsl <= " + rowPanel.getToRSL();
                if (!string.IsNullOrEmpty(rowPanel.getFunctionalClassification()))
                {
                    subQuery += " AND type = '" + rowPanel.getFunctionalClassification() + "'";
                }
                subQuery += " GROUP BY TAMSID ORDER BY TAMSID ASC, survey_date DESC";
                string fullQuery = "CREATE VIEW newestRoads AS " + moduleRoads.getSelectAllSQL() + ";"
                    + "CREATE VIEW filteredRoads AS SELECT * FROM newestRoads INNER JOIN ( SELECT * FROM road " + subQuery + ");"
                    + "SELECT TAMSID, survey_date, name, width, length, rsl, type, speed_limit, lanes, surface, from_address, to_address, "
                    + "photo, distress1, distress2, distress3, distress4, distress5, distress6, distress7, distress8, distress9, "
                    + "suggested_treatment, notes FROM filteredRoads " + subQuery + ";"
                    + "DROP VIEW newestRoads;" 
                    + "DROP VIEW filteredRoads;";

                rowQueries[i] = fullQuery;

                DataTable rslAreas = Database.GetDataByQuery(Project.conn, rowQueries[i]);
                rowPanel.initRSLAreas();
                foreach (DataRow row in rslAreas.Rows)
                {
                    double area = Util.ToDouble(row["width"].ToString()) * Util.ToDouble(row["length"].ToString());
                    rowPanel.addRSLArea(Util.ToInt(row["rsl"].ToString()), area);
                    totalArea += area;
                    totalCost += pricePerYard[rowPanel.getTreatment()] * (area / 9);
                }
                i++;
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
            totalArea /= 9;
            textBoxTotalArea.Text = String.Format("{0:n0}", (Math.Round(totalArea, 2))) + " yds\u00b2"; 
            textBoxTotalCost.Text = "$" + String.Format("{0:n0}", roundedCost);

            AnalysisRowPanel currentRow = (AnalysisRowPanel)panelRows.Controls[0];
            Dictionary<int, double> rslArea = currentRow.getRSLAreas();
            comboBoxResultsRow.SelectedIndex = -1;
            comboBoxResultsRow.SelectedIndex = 0;
            buttonFullRowData.Enabled = true;
            updateCharts();
        }

        private void comboBoxResultsRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxResultsRow.SelectedIndex == -1) return;
            if (panelCalculator.Controls.Count == 11) panelCalculator.Controls.RemoveAt(10);
            int selectedRow = comboBoxResultsRow.SelectedIndex;
            AnalysisRowPanel currentRow = (AnalysisRowPanel)panelRows.Controls[selectedRow];
            Dictionary<int, double> rslArea = currentRow.getRSLAreas();
            if (!currentRow.tableCreated || !currentRow.tableValid)
            {
                BudgetControlTables[selectedRow] = new BudgetControlTable(this);
                BudgetControlTables[selectedRow].addRowTable(pricePerYard, rslArea, currentRow);
                currentRow.tableValid = true;
            }
            int rowTotalY = BudgetControlTables[selectedRow].Size.Height + 130;
            if (rowTotalY > 700) rowTotalY = 700;
            panelRowTotal.Location = new Point(3, rowTotalY);
            panelCalculator.Controls.Add(BudgetControlTables[selectedRow]);
            updateCharts(true);
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
        }

        private void textBoxBudget_EnterPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                panelCalculator.Focus();
                buttonCalculate_Click(sender, e);
            }
        }

        private void buttonTreatmentCosts_Click(object sender, EventArgs e)
        {
            FormTreatmentCosts treatmentCosts = new FormTreatmentCosts(Project, pricePerYard, this);
            treatmentCosts.ShowDialog();
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            AnalysisRowPanel newPanel = new AnalysisRowPanel(28 * numberOfRows, (numberOfRows + 1).ToString());
            panelRows.Controls.Add(newPanel);
            numberOfRows++;
            comboBoxResultsRow.Items.AddRange(new object[] { numberOfRows.ToString() });
            rowQueries[numberOfRows - 1] = "";
            buttonRemoveRow.Enabled = true;
            if (numberOfRows == 23) buttonAddRow.Enabled = false;
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            numberOfRows--;
            panelRows.Controls.RemoveAt(numberOfRows);
            buttonAddRow.Enabled = true;
            comboBoxResultsRow.Items.RemoveAt(numberOfRows);
            if (numberOfRows == 1) buttonRemoveRow.Enabled = false;
        }

        private void buttonFullRowData_Click(object sender, EventArgs e)
        {
            if (rowQueries[comboBoxResultsRow.SelectedIndex] == "none") return;
            DataTable results = Database.GetDataByQuery(Project.conn, rowQueries[comboBoxResultsRow.SelectedIndex]);
            if (results.Rows.Count == 0)
            {
                MessageBox.Show("No roads matching the given description were found.");
                return;
            }
            DataTable outputTable = roadReports.addColumns("");

            FormOutput report = new FormOutput(Project, moduleRoads);
            foreach (DataRow row in results.Rows)
            {
                DataRow nr = outputTable.NewRow();
                string note = row["notes"].ToString().Split(new[] { '\r', '\n' }).FirstOrDefault(); //retrive most recent note

                int oldNoteLength = note.Length;
                int maxLength = 17;
                if (!string.IsNullOrEmpty(note))
                {
                    note = note.Substring(0, Math.Min(oldNoteLength, maxLength));
                    if (note.Length == maxLength) note += "...";
                }
                roadReports.addRows(nr, row, "");
                outputTable.Rows.Add(nr);
            }
            report.dataGridViewReport.DataSource = outputTable;
            report.Text = "Full Report of Selected Row";
            report.Show();
        }

        private void updateCharts(bool justProjection = false)
        {
            if (rowQueries[comboBoxResultsRow.SelectedIndex] == "none") return;

            string thisSql = moduleRoads.getSelectAllSQL();
            string[] categories = { "0", "1-3", "4-6", "7-9", "10-12", "13-15", "16-18", "19-20" };
            int[] caps = { 0, 3, 6, 9, 12, 15, 18, 20 };

            DataTable currentRoadTable = Database.GetDataByQuery(Project.conn, thisSql);

            Dictionary<string, double> currentRslArea = new Dictionary<string, double>();
            double totalAreaChart = 0.0;
            for (int i = 0; i < categories.Length; i++)
            {
                currentRslArea.Add(categories[i], 0.0);
            }

            foreach (DataRow row in currentRoadTable.Rows)
            {
                int rsl = Util.ToInt(row["rsl"].ToString());
                if (rsl == -1) continue;

                for (int i = 0; i < categories.Length; i++)
                {
                    if (rsl <= caps[i])
                    {
                        totalAreaChart += Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                        currentRslArea[categories[i]] += Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                        break;
                    }
                }
            }

            string[] domain = new string[categories.Length];
            double[] range = new double[categories.Length];
            for (int i = 0; i < categories.Length; i++)
            {
                domain[i] = categories[i];
                range[i] = Math.Round(currentRslArea[categories[i]] / totalAreaChart, 3) * 100;
            }


            updateProjectionChart(currentRoadTable, totalAreaChart);
            if (justProjection) return;

            Color[] colors = { Color.DarkRed, Color.Red, Color.Orange, Color.Yellow, Color.LimeGreen, Color.Green, Color.DeepSkyBlue, Color.Blue };

            //
            // chartCurrent
            //
            if (chartCurrent.Titles.Count == 0)
            {
                Title title = chartCurrent.Titles.Add("Current RSL Distribution");
                title.Font = new Font("Arial", 14, FontStyle.Bold);
            }
            chartCurrent.Invalidate();
            chartCurrent.Series.Clear();
            chartCurrent.Legends.Clear();
            chartCurrent.ChartAreas.Clear();
            chartCurrent.Series.Add("Series");
            chartCurrent.Series["Series"].IsValueShownAsLabel = true;
            chartCurrent.Series["Series"].Label = "#PERCENT{P1}";
            chartCurrent.ChartAreas.Add("Area");
            chartCurrent.ChartAreas["Area"].AxisX.Interval = 1;
            chartCurrent.ChartAreas["Area"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartCurrent.ChartAreas["Area"].AxisY.MajorGrid.LineColor = Color.LightGray;
            chartCurrent.ChartAreas["Area"].AxisY.Title = "Percent of Road Network";
            for (int i = 0; i < domain.Length; i++)
            {
                chartCurrent.Series["Series"].SetDefault(true);
                chartCurrent.Series["Series"].Enabled = true;
                chartCurrent.Series["Series"].Points.AddXY(domain[i], range[i]);
                chartCurrent.Series["Series"].ChartType = SeriesChartType.Column;
                chartCurrent.Series["Series"].ChartArea = "Area";
                chartCurrent.Series["Series"].Points[i].Color = colors[i % colors.Length];
            }
            chartCurrent.Show();
        }

        private void updateProjectionChart(DataTable currentRoadTable, double totalAreaChart)
        {
            string[] categories = { "0", "1-3", "4-6", "7-9", "10-12", "13-15", "16-18", "19-20" };
            int[] caps = { 0, 3, 6, 9, 12, 15, 18, 20 };

            DataTable projectedTreatmentsTable = Database.GetDataByQuery(Project.conn, rowQueries[comboBoxResultsRow.SelectedIndex]);

            Dictionary<string, double> projectedRslArea = new Dictionary<string, double>();
            for (int i = 0; i < categories.Length; i++)
            {
                projectedRslArea.Add(categories[i], 0.0);
            }


            AnalysisRowPanel rowPanel = (AnalysisRowPanel)panelRows.Controls[comboBoxResultsRow.SelectedIndex];

            int fromRSL = rowPanel.getFromRSL();
            int toRSL = rowPanel.getToRSL();
            string type = rowPanel.getFunctionalClassification();
            string treatment = rowPanel.getTreatment();

            Console.WriteLine("fromRSL: " + fromRSL);
            Console.WriteLine("toRSL: " + toRSL);
            Console.WriteLine("type: " + type);
            Console.WriteLine("treatment: " + treatment);


            foreach (DataRow row in currentRoadTable.Rows)
            {
                int rsl = Util.ToInt(row["rsl"].ToString());
                if (rsl == -1) continue;
                if (rsl >= fromRSL && rsl <= toRSL && row["type"].ToString() == type) rsl += adjustRSL(rsl, treatment);
                if (rsl > 20) rsl = 20;

                for (int i = 0; i < categories.Length; i++)
                {
                    if (rsl <= caps[i])
                    {
                        projectedRslArea[categories[i]] += Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                        break;
                    }
                }
            }

            string[] newDomain = new string[categories.Length];
            double[] newRange = new double[categories.Length];
            for (int i = 0; i < categories.Length; i++)
            {
                newDomain[i] = categories[i];
                newRange[i] = Math.Round(projectedRslArea[categories[i]] / totalAreaChart, 3) * 100;
            }


            Color[] colors = { Color.DarkRed, Color.Red, Color.Orange, Color.Yellow, Color.LimeGreen, Color.Green, Color.DeepSkyBlue, Color.Blue };

            //
            // chartProjection
            //
            if (chartProjection.Titles.Count == 0)
            {
                Title title = chartProjection.Titles.Add("Projected RSL Distribution");
                title.Font = new Font("Arial", 14, FontStyle.Bold);
            }
            chartProjection.Invalidate();
            chartProjection.Series.Clear();
            chartProjection.Legends.Clear();
            chartProjection.ChartAreas.Clear();
            chartProjection.Series.Add("Series");
            chartProjection.Series["Series"].IsValueShownAsLabel = true;
            chartProjection.Series["Series"].Label = "#PERCENT{P1}";
            chartProjection.ChartAreas.Add("Area");
            chartProjection.ChartAreas["Area"].AxisX.Interval = 1;
            chartProjection.ChartAreas["Area"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartProjection.ChartAreas["Area"].AxisY.MajorGrid.LineColor = Color.LightGray;
            chartProjection.ChartAreas["Area"].AxisY.Title = "Percent of Road Network";
            for (int i = 0; i < newDomain.Length; i++)
            {
                chartProjection.Series["Series"].SetDefault(true);
                chartProjection.Series["Series"].Enabled = true;
                chartProjection.Series["Series"].Points.AddXY(newDomain[i], newRange[i]);
                chartProjection.Series["Series"].ChartType = SeriesChartType.Column;
                chartProjection.Series["Series"].ChartArea = "Area";
                chartProjection.Series["Series"].Points[i].Color = colors[i % colors.Length];
            }
            chartProjection.Show();

        }

        private int adjustRSL(int currentRSL, string treatment)
        {
            if (treatment == "Cold In-place Recycling (2/2 in.)") return 15;
            if (treatment == "Thick Overlay (3 in.)") return 12;
            if (treatment == "Rotomill & Thick Overlay (3 in.)") return 12;
            if (treatment == "Base Repair/ Pavement Replacement") return 16;
            if (treatment == "Cold Recycling & Overlay (3/3 in.)") return 14;
            if (treatment == "Full Depth Reclamation & Overlay (3/3 in.)") return 20;
            if (treatment == "Base/ Pavement Replacement (3/3/6 in.)") return 20;

            if (currentRSL >= 1 && currentRSL <= 3)
            {
                if (treatment == "Scrub Seal") return 1;
                if (treatment == "Single Chip Seal") return 1;
                if (treatment == "Slurry Seal") return 1;
                if (treatment == "Microsurfacing") return 2;
                if (treatment == "Plant Mix Seal") return 3;
                if (treatment == "Cold In-place Recycling (2 in. with chip seal)") return 3;
                if (treatment == "Thin Hot Mix Overlay (<2 in.)") return 4;
                if (treatment == "HMA (leveling) & Overlay (<2 in.)") return 4;
                if (treatment == "Hot Surface Recycling") return 3;
                if (treatment == "Rotomill & Overlay (<2 in.)") return 4;
            }

            if (currentRSL >= 4 && currentRSL <= 6)
            {
                if (treatment == "Scrub Seal") return 3;
                if (treatment == "Single Chip Seal") return 3;
                if (treatment == "Slurry Seal") return 3;
                if (treatment == "Microsurfacing") return 3;
                if (treatment == "Plant Mix Seal") return 4;
                if (treatment == "Cold In-place Recycling (2 in. with chip seal)") return 4;
                if (treatment == "Thin Hot Mix Overlay (<2 in.)") return 6;
                if (treatment == "HMA (leveling) & Overlay (<2 in.)") return 6;
                if (treatment == "Hot Surface Recycling") return 5;
                if (treatment == "Rotomill & Overlay (<2 in.)") return 7;
            }

            if (currentRSL >= 7 && currentRSL <= 9)
            {
                if (treatment == "Fog Coat") return 1;
                if (treatment == "High Mineral Asphalt Emulsion") return 1;
                if (treatment == "Sand Seal") return 1;
                if (treatment == "Scrub Seal") return 5;
                if (treatment == "Single Chip Seal") return 5;
                if (treatment == "Slurry Seal") return 5;
                if (treatment == "Microsurfacing") return 5;
                if (treatment == "Plant Mix Seal") return 5;
                if (treatment == "Cold In-place Recycling (2 in. with chip seal)") return 5;
                if (treatment == "Thin Hot Mix Overlay (<2 in.)") return 7;
                if (treatment == "HMA (leveling) & Overlay (<2 in.)") return 8;
                if (treatment == "Hot Surface Recycling") return 7;
                if (treatment == "Rotomill & Overlay (<2 in.)") return 8;
            }

            if (currentRSL >= 10 && currentRSL <= 12)
            {
                if (treatment == "Crack Seal") return 1;
                if (treatment == "Fog Coat") return 1;
                if (treatment == "High Mineral Asphalt Emulsion") return 2;
                if (treatment == "Sand Seal") return 2;
                if (treatment == "Scrub Seal") return 5;
                if (treatment == "Single Chip Seal") return 5;
                if (treatment == "Slurry Seal") return 5;
                if (treatment == "Microsurfacing") return 7;
                if (treatment == "Plant Mix Seal") return 7;
                if (treatment == "Cold In-place Recycling (2 in. with chip seal)") return 6;
                if (treatment == "Thin Hot Mix Overlay (<2 in.)") return 7;
                if (treatment == "HMA (leveling) & Overlay (<2 in.)") return 8;
                if (treatment == "Hot Surface Recycling") return 8;
                if (treatment == "Rotomill & Overlay (<2 in.)") return 8;
            }

            if (currentRSL >= 13 && currentRSL <= 15)
            {
                if (treatment == "Crack Seal") return 2;
                if (treatment == "Fog Coat") return 2;
                if (treatment == "High Mineral Asphalt Emulsion") return 3;
                if (treatment == "Sand Seal") return 2;
                if (treatment == "Scrub Seal") return 5;
                if (treatment == "Single Chip Seal") return 5;
                if (treatment == "Slurry Seal") return 5;
                if (treatment == "Microsurfacing") return 7;
                if (treatment == "Plant Mix Seal") return 7;
                if (treatment == "Cold In-place Recycling (2 in. with chip seal)") return 7;
                if (treatment == "Thin Hot Mix Overlay (<2 in.)") return 7;
                if (treatment == "HMA (leveling) & Overlay (<2 in.)") return 8;
                if (treatment == "Hot Surface Recycling") return 8;
                if (treatment == "Rotomill & Overlay (<2 in.)") return 8;
            }

            if (currentRSL >= 16 && currentRSL <= 18)
            {
                if (treatment == "Crack Seal") return 3;
                if (treatment == "Fog Coat") return 2;
                if (treatment == "High Mineral Asphalt Emulsion") return 5;
                if (treatment == "Sand Seal") return 2;
                if (treatment == "Scrub Seal") return 5;
                if (treatment == "Single Chip Seal") return 5;
                if (treatment == "Slurry Seal") return 5;
                if (treatment == "Microsurfacing") return 7; 
                if (treatment == "Plant Mix Seal") return 7;
                if (treatment == "Cold In-place Recycling (2 in. with chip seal)") return 7;
                if (treatment == "Thin Hot Mix Overlay (<2 in.)") return 7;
                if (treatment == "HMA (leveling) & Overlay (<2 in.)") return 8;
                if (treatment == "Hot Surface Recycling") return 8;
                if (treatment == "Rotomill & Overlay (<2 in.)") return 8;
            }

            if (currentRSL >= 19 && currentRSL <= 20)
            {
                if (treatment == "Crack Seal") return 2;
                if (treatment == "Fog Coat") return 2;
                if (treatment == "High Mineral Asphalt Emulsion") return 5;
                if (treatment == "Sand Seal") return 2;
                if (treatment == "Scrub Seal") return 5;
                if (treatment == "Single Chip Seal") return 5;
                if (treatment == "Slurry Seal") return 5;
                if (treatment == "Microsurfacing") return 7;
                if (treatment == "Plant Mix Seal") return 7;
                if (treatment == "Cold In-place Recycling (2 in. with chip seal)") return 7;
                if (treatment == "Thin Hot Mix Overlay (<2 in.)") return 7;
                if (treatment == "HMA (leveling) & Overlay (<2 in.)") return 8;
                if (treatment == "Hot Surface Recycling") return 8;
                if (treatment == "Rotomill & Overlay (<2 in.)") return 8;
            }

            return 0;
        }
    }
}