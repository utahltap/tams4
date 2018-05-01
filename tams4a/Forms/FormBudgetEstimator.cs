using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormBudgetEstimator : Form
    {
        private FormCategories categories;
        private FormFutureTreatment futurePlans;
        private int[] categoryRSL;
        private decimal[] categoryPercents;
        private Label[] groups;
        private NumericUpDown[] percentages;
        private DataTable treatment, roadTable, byBudgetResults, byTargetResults;
        private Dictionary<string, List<NumericUpDown>> treatmentControls;
        private Dictionary<string, List<TreatmentFastReference>> treatmentData;
        private List<roadData> roads;
        private decimal totalArea = 0;
        private Dictionary<int, Dictionary<string, List<decimal>>> yearlyTreatment;

        public FormBudgetEstimator()
        {
            InitializeComponent();
            new ToolTip().SetToolTip(labelMaxBudget, "Must be a number representing the maximum acceptable budget in a single year.");
            categories = new FormCategories();
            futurePlans = new FormFutureTreatment();
            categoryRSL = categories.getRSLcategories();
            setPercentageDisplay();
        }
        
        private void finishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Called when the categories menu button is click. Allows the user to set the number of rsl categories for the simulation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            categories.ShowDialog();
            categoryRSL = categories.getRSLcategories();
            setPercentageDisplay();
        }

        /// <summary>
        /// Sets up the controls for the Budget by Target tab page
        /// </summary>
        private void setPercentageDisplay()
        {
            groupBoxTargets.Controls.Clear();
            groups = new Label[categoryRSL.Length];
            string[] rslLabels = getRSLlabels(categoryRSL);
            percentages = new NumericUpDown[categoryRSL.Length];
            for (int i = categoryRSL.Length - 1; i >= 0; i--)
            {
                int x = 28;
                int y = 45 + 24 * (categoryRSL.Length - 1 - i);
                groups[i] = new Label();
                groups[i].Location = new Point(x, y);
                groups[i].Size = new Size(70, 15);
                groups[i].Text = rslLabels[i];
                groupBoxTargets.Controls.Add(groups[i]);

                percentages[i] = new NumericUpDown();
                percentages[i].Minimum = 0;
                percentages[i].Maximum = 100;
                percentages[i].Value = 0;
                percentages[i].Location = new Point(x + 70, y);
                percentages[i].Size = new Size(48, 15);
                percentages[i].Increment = 1;
                if (i == categoryRSL.Length - 1)
                {
                    percentages[i].Value = 100;
                    percentages[i].Minimum = -99;
                    percentages[i].Enabled = false;
                }
                else
                {
                    percentages[i].Value = 0;
                    percentages[i].ValueChanged += setBalance;
                }
                groupBoxTargets.Controls.Add(percentages[i]);
            }
        }

        /// <summary>
        /// The top percentage is automatically set for whatever remains of the the percentage rsls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setBalance(Object sender, EventArgs e)
        {
            decimal totals = 0;
            for (int i = 0; i < percentages.Length -1; i++)
            {
                totals += percentages[i].Value;
            }
            percentages[percentages.Length - 1].Value = 100 - totals;
        }

        /// <summary>
        /// Assigns the data from the roads and treatments for use in the simulations
        /// </summary>
        /// <param name="r"></param>
        /// <param name="t"></param>
        public bool setData(DataTable r, DataTable t)
        {
            treatment = t;
            roadTable = r;
            initTreatmentControls();
            futurePlans.initTreatmentControls(t);
            roads = setRoadData();
            try
            {
                categoryPercents = setPercentages(roads);
            }
            catch (Exception e)
            {
                Log.Error("Total Area is Zero" + e.ToString());
                MessageBox.Show("The total area of surveyed roads is 0 (Zero). Make sure that roads have been surveyed and both a length and width have been applied.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Creates a list of mutable road objects for simulation from the stored datatable
        /// </summary>
        /// <returns></returns>
        private List<roadData> setRoadData()
        {
            List<roadData> rd = new List<roadData>();
            totalArea = 0;
            foreach (DataRow row in roadTable.Rows)
            {
                if (String.IsNullOrEmpty(row["rsl"].ToString()) || Util.ToInt(row["rsl"].ToString()) < 0)
                {
                    continue;
                }
                int rsl = Util.ToInt(row["rsl"].ToString());
                decimal area = (decimal)Util.ToDouble(row["length"].ToString()) * (decimal)Util.ToDouble(row["width"].ToString());
                string rt = row["suggested_treatment"].ToString();
                totalArea += area;
                rd.Add(new roadData(area, rsl, rt));
            }
            return rd;
        }

        /// <summary>
        /// Creats a list of the actual percentages for each RSL category based on the input list road objects and the current category settings.
        /// </summary>
        /// <param name="rd"></param>
        /// <returns></returns>
        private decimal[] setPercentages(List<roadData> rd)
        {
            decimal[] cp = new decimal[categoryRSL.Length];
            for (int i = 0; i < rd.Count; i++)
            {
                for (int j = 0; j < categoryRSL.Length; j++)
                {
                    if (rd[i].RSL <= categoryRSL[j])
                    {
                        cp[j] += rd[i].area;
                        break;
                    }
                }
            }
            for (int i = 0; i < cp.Length; i++)
            {
                cp[i] = cp[i] / totalArea;
            }
            return cp;
        }

        /// <summary>
        /// Creates the controls on the RSL by Budget based on the stored datatable for road treatments.
        /// </summary>
        private void initTreatmentControls()
        {
            Dictionary<string, Panel> tg = new Dictionary<string, Panel>()
            {
                { "routine", panelRoutine},
                { "preventative", panelPreventative},
                { "rehabilitation", panelRehabilitation },
                { "reconstruction", panelReconstruction }
            };
            treatmentControls = new Dictionary<string, List<NumericUpDown>>()
            {
                { "routine", new List<NumericUpDown>()},
                { "preventative", new List<NumericUpDown>()},
                { "rehabilitation", new List<NumericUpDown>()},
                { "reconstruction", new List<NumericUpDown>()}
            };
            treatmentData = new Dictionary<string, List<TreatmentFastReference>>()
            {
                { "routine", new List<TreatmentFastReference>()},
                { "preventative", new List<TreatmentFastReference>()},
                { "rehabilitation", new List<TreatmentFastReference>()},
                { "reconstruction", new List<TreatmentFastReference>()}
            };
            yearlyTreatment = new Dictionary<int, Dictionary<string, List<decimal>>>();
            Dictionary<string, List<decimal>> currentYear = new Dictionary<string, List<decimal>>()
            {
                { "routine", new List<decimal>() },
                { "preventative", new List<decimal>() },
                { "rehabilitation", new List<decimal>() },
                { "reconstruction", new List<decimal>() },
            };
            
            Dictionary<string, int> tx = new Dictionary<string, int>()
            {
                { "routine", 16},
                { "preventative", 16},
                { "rehabilitation", 16 },
                { "reconstruction", 16 }
            };
            Dictionary<string, int> ty = new Dictionary<string, int>()
            {
                { "routine", 16},
                { "preventative", 16},
                { "rehabilitation", 16},
                { "reconstruction", 16}
            };
            foreach (DataRow row in treatment.Rows)
            {
                Label l = new Label();
                l.Text = row["name"].ToString();
                new ToolTip().SetToolTip(l, l.Text);
                string cat = row["category"].ToString();
                if (cat == "patch")
                {
                    continue;
                }
                l.Location = new Point(tx[cat], ty[cat]);
                l.Size = new Size(150, 15);
                tg[cat].Controls.Add(l);

                NumericUpDown nu = new NumericUpDown();
                nu.Maximum = 100;
                nu.Increment = 1;
                nu.Location = new Point(tx[cat] + 150, ty[cat]);
                nu.Size = new Size(60, 15);
                tg[cat].Controls.Add(nu);
                treatmentControls[cat].Add(nu);
                treatmentData[cat].Add(new TreatmentFastReference(Util.ToDouble(row["cost"].ToString()), cat, Util.ToInt(row["min_rsl"].ToString()), Util.ToInt(row["max_rsl"].ToString()), Util.ToInt(row["average_boost"].ToString())));
                currentYear[cat].Add(0);
                nu.ValueChanged += computeTotalTreatedArea;
                ty[cat] += 24;
            }
            yearlyTreatment.Add(DateTime.Now.Year, currentYear);
        }

        /// <summary>
        /// Called when compute RSL is click, runs a simulation of road maintenance upto 10 years into the future.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonComputeRSL_Click(object sender, EventArgs e)
        {
            dataGridViewRSL.DataSource = null;
            if (numericUpDownTotals.Value > 100)
            {
                var dialogrslt = MessageBox.Show("The total treated area adds up to more than 100 percent, and the resulting simulation may not make sense. Are you sure you wish to continue?", "Continue Cancel", MessageBoxButtons.OKCancel);
                if (dialogrslt == DialogResult.Cancel)
                {
                    return;
                }
            }
            byBudgetResults = new DataTable();
            byBudgetResults.Columns.Add("Year");
            string[] rslLabels = getRSLlabels(categoryRSL);
            for (int i = 0; i < rslLabels.Length; i++)
            {
                byBudgetResults.Columns.Add(rslLabels[i]);
            }
            byBudgetResults.Columns.Add("Cost");
            List<roadData> rd = new List<roadData>();
            for (int i = 0; i < roads.Count; i++)
            {
                rd.Add(new roadData(roads[i].area, roads[i].RSL, roads[i].recommendedTreatment));
            }
            setPlan();
            for (int i = 0; i <= numericUpDownYear1.Value; i++)
            {
                decimal[] cp = setPercentages(rd);
                DataRow nr = byBudgetResults.NewRow();
                double cost = 0;
                nr["Year"] = DateTime.Now.Year + i;
                for (int j = 0; j < rslLabels.Length; j++)
                {
                    nr[rslLabels[j]] = Math.Round(cp[j] * 100);
                }
                Dictionary<string, decimal[]> atp = new Dictionary<string, decimal[]>()
                {
                    { "routine", new decimal[treatmentControls["routine"].Count]},
                    { "preventative", new decimal[treatmentControls["preventative"].Count]},
                    { "rehabilitation", new decimal[treatmentControls["rehabilitation"].Count]},
                    { "reconstruction", new decimal[treatmentControls["reconstruction"].Count]}
                };
                string[] cat = { "routine", "preventative", "rehabilitation", "reconstruction"};
                for (int j = 0; j < rd.Count; j++)
                {
                    rd[j].RSL--;
                    if (rd[j].RSL < 0)
                    {
                        rd[j].RSL = 0;
                    }
                    for (int k = 0; k < cat.Length; k++)
                    {
                        double c;
                        bool treated = examineCategory(cat[k], rd[j], atp, DateTime.Now.Year + i, out c);
                        if (treated)
                        {
                            cost += c;
                            break;
                        }
                    }
                    if (rd[j].RSL > 20)
                    {
                        rd[j].RSL = 20;
                    }
                }
                if (cost > 1000000)
                {
                    nr["Cost"] = Math.Round(cost / 1000000, 2).ToString() + " M";
                }
                else
                {
                    nr["Cost"] = ((int)(cost / 1000)).ToString() + " k";
                }
                byBudgetResults.Rows.Add(nr);
            }
            chartBudgetRSL.Invalidate();
            chartBudgetRSL.Series.Clear();
            chartBudgetRSL.Legends.Clear();
            chartBudgetRSL.Legends.Add(new Legend("Legend"));
            for (int i = 0; i < rslLabels.Length; i++)
            {
                chartBudgetRSL.Series.Add(rslLabels[i]);
                chartBudgetRSL.Series[rslLabels[i]].Points.DataBind(new DataView(byBudgetResults), "Year", rslLabels[i], "");
                chartBudgetRSL.Series[rslLabels[i]].ChartType = SeriesChartType.StackedArea100;
                chartBudgetRSL.Series[rslLabels[i]].Legend = "Legend";
                chartBudgetRSL.Series[rslLabels[i]].Color = Color.FromArgb(140, 255 * (rslLabels.Length - i)/rslLabels.Length, 255 * i/rslLabels.Length, 0);
            }
            chartBudgetRSL.Show();
            dataGridViewRSL.DataSource = byBudgetResults;
            for (int i = 0; i < dataGridViewRSL.Columns.Count; i++)
            {
                dataGridViewRSL.Columns[i].Width = 1012/dataGridViewRSL.Columns.Count;
            }
            setYearlyDistributionGraph();
        }

        /// <summary>
        /// private helper function to improve readability of buttonComputeRSL_Click
        /// </summary>
        /// <param name="cat"></param>
        /// <param name="rd"></param>
        /// <param name="atp"></param>
        /// <param name='c'></param>
        /// <returns></returns>
        private bool examineCategory(string cat, roadData rd, Dictionary<string, decimal[]> atp, int yr, out double c)
        {
            for (int i = 0; i < treatmentData[cat].Count; i++)
            {
                if (rd.RSL <= treatmentData[cat][i].max_rsl && rd.RSL >= treatmentData[cat][i].min_rsl && atp[cat][i] < yearlyTreatment[yr][cat][i])
                {
                    rd.RSL += treatmentData[cat][i].average_boost;
                    atp[cat][i] += (rd.area / totalArea) * 100;
                    c = treatmentData[cat][i].cost * (double)rd.area/9; //Note: road dimensions are in feet, the treat costs are per square yard.
                    return true;
                }
            }
            c = 0;
            return false;
        }

        /// <summary>
        /// returns an array of the rsl labels based on the values stored in provided array.
        /// </summary>
        /// <param name="rsls"></param>
        /// <returns></returns>
        private string[] getRSLlabels(int[] rsls)
        {
            string[] rslLabels = new string[categoryRSL.Length];
            for (int i = 0; i < rsls.Length; i++)
            {
                if (i == 0)
                {
                    if (rsls[i] == 0)
                    {
                        rslLabels[i] = "0";
                    }
                    else
                    {
                        rslLabels[i] = "0-" + rsls[0].ToString();
                    }
                    continue;
                }
                else
                {
                    if (rsls[i] - categoryRSL[i - 1] == 1)
                    {
                        rslLabels[i] = rsls[i].ToString();
                    }
                    else
                    {
                        rslLabels[i] = (rsls[i - 1] + 1).ToString() + "-" + rsls[i].ToString();
                    }
                }
            }
            return rslLabels;
        }

        /// <summary>
        /// Computes the total treated area whenever a treatment control is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void computeTotalTreatedArea(Object sender, EventArgs e)
        {
            decimal totals = 0;
            foreach (string key in treatmentControls.Keys)
            {
                for (int i = 0; i < treatmentControls[key].Count; i++)
                {
                    totals += treatmentControls[key][i].Value;
                    yearlyTreatment[DateTime.Now.Year][key][i] = treatmentControls[key][i].Value;
                }
            }
            numericUpDownTotals.Value = totals;
        }

        /// <summary>
        /// Helper object with mutable state for the simulation
        /// </summary>
        private class roadData
        {
            public decimal area;
            public int RSL;
            public string recommendedTreatment;

            public roadData(decimal a, int rsl, string rt)
            {
                area = a;
                RSL = rsl;
                recommendedTreatment = rt;
            }
        }

        private void buttonFuture_Click(object sender, EventArgs e)
        {
            futurePlans.ShowDialog();
            checkBoxVaried.Checked = true;
            
        }

        /// <summary>
        /// Sets the plan according to the plan settings in future plans.
        /// </summary>
        private void setPlan()
        {
            int yr = -1;
            Dictionary<int, Dictionary<string, List<decimal>>> tp = futurePlans.getYearlyTreatments();
            bool[] cyrs = futurePlans.changedYears();
            for (int i = 0; i < cyrs.Length; i++)
            {
                if (cyrs[i])
                {
                    yr = i;
                }
                if (yr == -1 || !checkBoxVaried.Checked)
                {
                    yearlyTreatment[DateTime.Now.Year + i] = yearlyTreatment[DateTime.Now.Year];
                }
                else
                {
                    yearlyTreatment[DateTime.Now.Year + i] = tp[DateTime.Now.Year + yr];
                }
            }
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControlRSL.SelectedTab == tabPageRSL && byBudgetResults != null)
            {
                if (Util.TableToCSV(byBudgetResults, "Expected RSL over time based on treatment plan," + Environment.NewLine))
                {
                    MessageBox.Show("Table exported successfully!");
                }
                else
                {
                    MessageBox.Show("Could not export Data Table!");
                }
            }
            else if (tabControlRSL.SelectedTab == tabPageBudget && byTargetResults != null)
            {
                if (Util.TableToCSV(byTargetResults, "Expected RSL over time based on target and budget," + Environment.NewLine))
                {
                    MessageBox.Show("Table exported successfully!");
                }
                else
                {
                    MessageBox.Show("Could not export Data Table!");
                }
            }
            else
            {
                MessageBox.Show("There is no Data to Export, please run an analysis too.");
            }
        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControlRSL.SelectedTab == tabPageRSL && byBudgetResults != null)
            {
                if (tabControlBudgetData.SelectedTab != tabPageYearlyDist)
                {
                    Title title = chartBudgetRSL.Titles.Add("Expected RSL by Category " + DateTime.Now.Year.ToString() + "-" + (DateTime.Now.Year + numericUpDownYear1.Value).ToString());
                    chartBudgetRSL.Dock = DockStyle.None;
                    chartBudgetRSL.Size = new Size(1000, 600);
                    title.Font = new Font("Arial", 16, FontStyle.Bold);
                    ChartToPNG(chartBudgetRSL);
                    chartBudgetRSL.Titles.Clear();
                    chartBudgetRSL.Dock = DockStyle.Fill;
                }
                else
                {
                    Title title = chartYearlyDistribution.Titles.Add("RSL Distribution " + numericUpDownDisplayYear.Value.ToString());
                    chartYearlyDistribution.Dock = DockStyle.None;
                    chartYearlyDistribution.Size = new Size(500, 600);
                    title.Font = new Font("Arial", 14, FontStyle.Bold);
                    ChartToPNG(chartYearlyDistribution);
                    chartYearlyDistribution.Dock = DockStyle.Fill;
                    chartYearlyDistribution.Titles.Clear();
                }
            }
            else if (tabControlRSL.SelectedTab == tabPageBudget && byTargetResults != null)
            {
                Title title = chartBudget.Titles.Add("Expected Cost based on Target RSL");
                title.Font = new Font("Arial", 14, FontStyle.Bold);
                ChartToPNG(chartBudget);
                chartBudget.Titles.Clear();
            }
            else
            {
                MessageBox.Show("There is no Data to Export, please run an analysis too.");
            }
        }

        /// <summary>
        /// Resets the values in the treatment controls to zero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResetRSL_Click(object sender, EventArgs e)
        {
            string[] cat = { "routine", "preventative", "rehabilitation", "reconstruction" };
            for (int i = 0; i < cat.Length; i++)
            {
                for (int j = 0; j < treatmentControls[cat[i]].Count; j++)
                {
                    treatmentControls[cat[i]][j].Value = 0; 
                }
            }
        }

        private void numericUpDownYear1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownDisplayYear.Maximum = DateTime.Now.Year + numericUpDownYear1.Value;
        }

        private void numericUpDownDisplayYear_ValueChanged(object sender, EventArgs e)
        {
            setYearlyDistributionGraph();
        }

        private void setYearlyDistributionGraph()
        {
            if (byBudgetResults != null)
            {
                string[] rslLabels = getRSLlabels(categoryRSL);
                int[] rslPercents = new int[rslLabels.Length];
                DataRow sourceRow = byBudgetResults.Select("Year = " + numericUpDownDisplayYear.Value.ToString())[0];
                for (int i = 0; i < rslLabels.Length; i++)
                {
                    rslPercents[i] = Util.ToInt(sourceRow[rslLabels[i]].ToString());
                }
                chartYearlyDistribution.Invalidate();
                chartYearlyDistribution.Series.Clear();
                chartYearlyDistribution.Legends.Clear();
                chartYearlyDistribution.ChartAreas.Clear();
                chartYearlyDistribution.Series.Add("Series");
                chartYearlyDistribution.ChartAreas.Add("Area");
                for (int i = 0; i < rslLabels.Length; i++)
                {
                    chartYearlyDistribution.Series["Series"].SetDefault(true);
                    chartYearlyDistribution.Series["Series"].Enabled = true;
                    chartYearlyDistribution.Series["Series"].Points.AddXY(rslLabels[i], rslPercents[i]);
                    chartYearlyDistribution.Series["Series"].ChartType = SeriesChartType.Column;
                    chartYearlyDistribution.Series["Series"].ChartArea = "Area";
                    chartYearlyDistribution.Series["Series"].Points[i].Color = Color.FromArgb(190, 255 * (rslLabels.Length - i) / rslLabels.Length, 255 * i / rslLabels.Length, 0);
                }
                chartYearlyDistribution.Show();
            }
        }

        private void buttonGraph_Click(object sender, EventArgs e)
        {
            string[] cat = { "routine", "preventative", "rehabilitation", "reconstruction" };
            string[] rslLabels = getRSLlabels(categoryRSL);
            double maxBudget = Util.ToDouble(textBoxMaxBudget.Text);
            Dictionary<string, double> avgCost = new Dictionary<string, double>();
            Dictionary<string, double> avgBoost = new Dictionary<string, double>();
            byTargetResults = new DataTable();
            byTargetResults.Columns.Add("Year");
            for (int i = 0; i < rslLabels.Length; i++)
            {
                byTargetResults.Columns.Add(rslLabels[i]);
            }
            byTargetResults.Columns.Add("Cost");
            List<roadData> rd = new List<roadData>();
            for (int i = 0; i < roads.Count; i++)
            {
                rd.Add(new roadData(roads[i].area, roads[i].RSL, roads[i].recommendedTreatment));
            }
            List<int> years = new List<int>();
            List<double> yearlyCost = new List<double>();
            for (int i = 0; i < cat.Length; i++)
            {
                avgCost[cat[i]] = 0;
                avgBoost[cat[i]] = 0;
                for (int j = 0; j < treatmentData[cat[i]].Count; j++)
                {
                    avgCost[cat[i]] += treatmentData[cat[i]][j].cost;
                    avgBoost[cat[i]] += treatmentData[cat[i]][j].average_boost;
                }
                avgCost[cat[i]] /= treatmentData[cat[i]].Count;
                avgBoost[cat[i]] /= treatmentData[cat[i]].Count;
            }
            for (int i = 0; i <= numericUpDownYear2.Value; i++)
            {
                DataRow row = byTargetResults.NewRow();
                years.Add(DateTime.Now.Year + i);
                row["Year"] = years[i];
                double cost = 0;
                decimal[] actauls = setPercentages(rd);
                decimal[] change = new decimal[rslLabels.Length];
                for (int j = 0; j < rslLabels.Length; j++)
                {
                    change[j] = 0;
                }
                for (int j = 0; j < rd.Count; j++)
                {
                    if (maxBudget > 0 && cost > maxBudget)
                    {
                        break;
                    }
                    int oldRSL = rd[j].RSL;
                    int oldCat = 0;
                    for (int k = 0; k < categoryRSL.Length; k++)
                    {
                        if (oldRSL <= categoryRSL[k])
                        {
                            oldCat = k;
                            break;
                        }
                    }
                    rd[j].RSL--;
                    if (actauls[oldCat] * 100 + change[oldCat] < percentages[oldCat].Value || oldCat == categoryRSL.Length - 1)
                    {
                        continue;
                    }
                    if (rd[j].RSL < 0)
                    {
                        rd[j].RSL = 0;
                    }
                    if (rd[j].RSL > 15 && (maxBudget <= 0 || cost < maxBudget/2))
                    {
                        cost += (double)rd[j].area * avgCost[cat[0]]/9;
                        rd[j].RSL += (int)Math.Ceiling(avgBoost[cat[0]]);
                    }
                    else if (rd[j].RSL > 9)
                    {
                        cost += (double)rd[j].area * avgCost[cat[1]]/9;
                        rd[j].RSL += 4;
                    }
                    else if (rd[j].RSL > 3)
                    {
                        cost += (double)rd[j].area * avgCost[cat[2]]/9;
                        rd[j].RSL += 8;
                    }
                    else if (maxBudget <= 0 || cost < maxBudget / 2)
                    {
                        cost += (double)rd[j].area * avgCost[cat[3]]/9;
                        rd[j].RSL += 18;
                    }
                    change[oldCat] -= rd[j].area / totalArea * 100;
                    int newRSL = rd[j].RSL;
                    int newCat = 0;
                    for (int k = 0; k < categoryRSL.Length; k++)
                    {
                        if (newRSL <= categoryRSL[k])
                        {
                            newCat = k;
                            break;
                        }
                    }
                    change[newCat] += rd[j].area / totalArea * 100;
                }
                yearlyCost.Add(cost);
                for (int j = 0; j < rslLabels.Length; j++)
                {
                    row[rslLabels[j]] = Math.Round(actauls[j] * 100);
                }
                if (yearlyCost[i] > 1000000)
                {
                    row["Cost"] = Math.Round(yearlyCost[i]/1000000, 2).ToString() + " M";
                }
                else
                {
                    row["Cost"] = Math.Round(yearlyCost[i]/1000).ToString() + " k";
                }
                byTargetResults.Rows.Add(row);
            }
            decimal[] endActauls = setPercentages(rd);
            for (int i = 0; i < percentages.Length - 2; i++)
            {
                if (endActauls[i] * 100 > percentages[i].Value)
                {
                    textBoxTargetsMet.Text = "NO";
                    textBoxTargetsMet.BackColor = Color.Pink;
                    break;
                }
                textBoxTargetsMet.Text = "YES";
                textBoxTargetsMet.BackColor = Color.LightSeaGreen;
            }
            decimal runningAVG = 0;
            for (int i = 0; i < rd.Count; i++)
            {
                runningAVG = runningAVG * i/ (i+1) + (decimal)rd[i].RSL / (i + 1);
            }
            textBoxAverageRSL.Text = Math.Round(runningAVG, MidpointRounding.AwayFromZero).ToString();
            chartBudget.Invalidate();
            chartBudget.Series.Clear();
            chartBudget.Legends.Clear();
            chartBudget.ChartAreas.Clear();
            chartBudget.Series.Add("Series");
            chartBudget.ChartAreas.Add("Area");
            chartBudget.ChartAreas["Area"].AxisY.LabelStyle.Format = "{0:0,}K";
            chartBudget.Series["Series"].Points.DataBindXY(years, yearlyCost);
            chartBudget.Series["Series"].ChartType = SeriesChartType.Line;
            chartBudget.Series["Series"].BorderWidth = 5;
            chartBudget.Series["Series"].ChartArea = "Area";
            chartBudget.Show();
        }

        /// <summary>
        /// Immutabe data structure that contains data for the various road treatments
        /// </summary>
        private struct TreatmentFastReference
        {
            public double cost;
            public string name;
            public int min_rsl;
            public int max_rsl;
            public int average_boost;
            public TreatmentFastReference(double c, string n, int mn, int mx, int ab)
            {
                cost = c;
                name = n;
                min_rsl = mn;
                max_rsl = mx;
                average_boost = ab;
            }
        }

        private void ChartToPNG(Chart chart)
        {
            String filename;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Portable Network Graphic (*.png)|*.png";
            try
            {
                saveDialog.InitialDirectory = Properties.Settings.Default.lastFolder;
            }
            catch
            {
                saveDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            }
             if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            filename = saveDialog.FileName;
            try
            {
                chart.SaveImage(filename, ChartImageFormat.Png);
            }
            catch (Exception e)
            {
                Log.Error("Could not save image file: " + e.ToString());
                MessageBox.Show("An error occoured while trying to export chart.");
            }

        }
        
    }
}
