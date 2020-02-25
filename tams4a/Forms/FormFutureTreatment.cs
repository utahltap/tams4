using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tams4a.Forms
{
    public partial class FormFutureTreatment : Form
    {
        private Dictionary<int, Dictionary<string, List<decimal>>> yearlyTreatment;
        private Dictionary<int, decimal> totals;
        private Dictionary<string, List<NumericUpDown>> treatmentControls;
        private string[] categories = { "routine", "preventative", "rehabilitation", "reconstruction"};
        private bool[] yearIsDiff;
        private bool captureEvent;

        public FormFutureTreatment()
        {
            InitializeComponent();
            CenterToScreen();
            totals = new Dictionary<int, decimal>();
            yearIsDiff = new bool[11];
            for (int i = 0; i <= 10; ++i)
            {
                comboBoxYear.Items.Add(DateTime.Now.Year + i);
                totals.Add(DateTime.Now.Year + i, 0);
                yearIsDiff[i] = false;
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            Hide();
        }

        public void initTreatmentControls(DataTable treatments)
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
            yearlyTreatment = new Dictionary<int, Dictionary<string, List<decimal>>>();
            for (int i = 0; i <= 10; ++i)
            {
                yearlyTreatment.Add(DateTime.Now.Year + i, new Dictionary<string, List<decimal>>()
                {
                    {"routine", new List<decimal>() },
                    {"preventative", new List<decimal>() },
                    {"rehabilitation", new List<decimal>() },
                    {"reconstruction", new List<decimal>() }
                });
            }
            Dictionary<string, int> tx = new Dictionary<string, int>()
            {
                { "routine", 24},
                { "preventative", 24},
                { "rehabilitation", 24 },
                { "reconstruction", 24 }
            };
            Dictionary<string, int> ty = new Dictionary<string, int>()
            {
                { "routine", 16},
                { "preventative", 16},
                { "rehabilitation", 16},
                { "reconstruction", 16}
            };
            foreach (DataRow row in treatments.Rows)
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
                l.Size = new Size(150, 12);
                tg[cat].Controls.Add(l);

                NumericUpDown nu = new NumericUpDown();
                nu.Maximum = 100;
                nu.Increment = 1;
                nu.Location = new Point(tx[cat] + 150, ty[cat]);
                nu.Size = new Size(60, 12);
                tg[cat].Controls.Add(nu);
                treatmentControls[cat].Add(nu);
                for (int i = 0; i <= 10; ++i)
                {
                    yearlyTreatment[DateTime.Now.Year + i][cat].Add(0);
                }
                nu.ValueChanged += setYearlyData;
                ty[cat] += 24;
            }
            comboBoxYear.Text = (DateTime.Now.Year + 1).ToString();
        }

        private void setYearlyData(object sender, EventArgs e)
        {
            if (captureEvent)
            {
                return;
            }
            decimal total = 0;
            int yr = Classes.Util.ToInt(comboBoxYear.Text);
            for (int i = 0; i < categories.Length; ++i)
            {
                for (int j = 0; j < treatmentControls[categories[i]].Count; j++)
                {
                    yearlyTreatment[yr][categories[i]][j] = treatmentControls[categories[i]][j].Value;
                    total += treatmentControls[categories[i]][j].Value;
                }
            }
            totals[yr] = total;
            numericUpDownTotals.Value = total;
        }

        public Dictionary<int, Dictionary<string, List<decimal>>> getYearlyTreatments()
        {
            return yearlyTreatment;
        }

        public bool[] changedYears()
        {
            return yearIsDiff;
        }

        private void comboBoxYear_selectionChange(object sender, EventArgs e)
        {
            captureEvent = true;
            int yr = Classes.Util.ToInt(comboBoxYear.Text);
            for (int i = 0; i < categories.Length; ++i)
            {
                for (int j = 0; j < yearlyTreatment[yr][categories[i]].Count; j++)
                {
                    treatmentControls[categories[i]][j].Value = yearlyTreatment[yr][categories[i]][j];
                }
            }
            checkBoxYear.Checked = yearIsDiff[yr - DateTime.Now.Year];
            numericUpDownTotals.Value = totals[yr];
            captureEvent = false;
        }

        private void checkBoxYear_Changed(object sender, EventArgs e)
        {
            yearIsDiff[Classes.Util.ToInt(comboBoxYear.Text) - DateTime.Now.Year] = checkBoxYear.Checked;
        }

        public void resetAll()
        {
            yearIsDiff = new bool[11];
            for (int i = 0; i <= 10; ++i)
            {
                comboBoxYear.Items.Add(DateTime.Now.Year + i);
                totals.Add(DateTime.Now.Year + i, 0);
                yearIsDiff[i] = false;
            }
            foreach (string key in treatmentControls.Keys)
            {
                for (int i = 0; i < treatmentControls[key].Count; ++i)
                {
                    treatmentControls[key][i].Value = 0;
                }
            }
            foreach (int year in yearlyTreatment.Keys)
            {
                foreach (string cat in yearlyTreatment[year].Keys)
                {
                    for (int i = 0; i < yearlyTreatment[year][cat].Count; ++i)
                    {
                        yearlyTreatment[year][cat][i] = 0;
                    }
                }
            }
        }

        private void resetYear()
        {
            yearIsDiff[Classes.Util.ToInt(comboBoxYear.Text) - DateTime.Now.Year] = false;
            foreach (string key in treatmentControls.Keys)
            {
                for (int i = 0; i < treatmentControls[key].Count; ++i)
                {
                    treatmentControls[key][i].Value = 0;
                }
            }
        }

        private void buttonResetAll_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void buttonResetYear_Click(object sender, EventArgs e)
        {
            resetYear();
        }
    }
}
