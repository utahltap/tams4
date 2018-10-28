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

namespace tams4a.Forms
{
    public partial class FormGraphDisplay : Form
    {
        private DataTable displayedTable;

        public FormGraphDisplay(DataTable dt, string[] domain, double[] range, string t = "Distribution Graph", Color[] c = null)
        {
            InitializeComponent();
            CenterToScreen();
            displayedTable = dt;
            dataGridView.DataSource = displayedTable;
            Color[] colours = { Color.Green, Color.Turquoise, Color.LightBlue, Color.Blue, Color.Purple, Color.Pink, Color.Red, Color.Orange, Color.Yellow, Color.Brown };
            if (c != null) {
                colours = c;
            }
            Title title = chart.Titles.Add(t);
            title.Font = new Font("Arial", 16, FontStyle.Bold);
            chart.Invalidate();
            chart.Series.Clear();
            chart.Legends.Clear();
            chart.ChartAreas.Clear();
            chart.Series.Add("Series");
            chart.Series["Series"].IsValueShownAsLabel = true;
            chart.Series["Series"].Label = "#PERCENT{P1}";
            chart.ChartAreas.Add("Area");
            chart.ChartAreas["Area"].AxisX.Interval = 1;
            chart.ChartAreas["Area"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas["Area"].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas["Area"].AxisY.Title = "Percent of Road Network";
            for (int i = 0; i < domain.Length; i++)
            {
                chart.Series["Series"].SetDefault(true);
                chart.Series["Series"].Enabled = true;
                chart.Series["Series"].Points.AddXY(domain[i], range[i]);
                chart.Series["Series"].ChartType = SeriesChartType.Column;
                chart.Series["Series"].ChartArea = "Area";
                chart.Series["Series"].Points[i].Color = colours[i % colours.Length];
            }
            chart.Show();
        }

        public FormGraphDisplay(DataTable dt, double[] domain, double[] range, Color[] c = null)
        {
            InitializeComponent();
            CenterToScreen();
            displayedTable = dt;
            dataGridView.DataSource = displayedTable;
            Color[] colours = { Color.Green, Color.Turquoise, Color.LightBlue, Color.Blue, Color.Purple, Color.Pink, Color.Red, Color.Orange, Color.Yellow, Color.Brown };
            if (c != null)
            {
                colours = c;
            }
            chart.Invalidate();
            chart.Series.Clear();
            chart.Legends.Clear();
            chart.ChartAreas.Clear();
            chart.Series.Add("Series");
            chart.ChartAreas.Add("Area");
            for (int i = 0; i < domain.Length; i++)
            {
                chart.Series["Series"].SetDefault(true);
                chart.Series["Series"].Enabled = true;
                chart.Series["Series"].Points.AddXY(domain[i], range[i]);
                chart.Series["Series"].ChartType = SeriesChartType.Column;
                chart.Series["Series"].ChartArea = "Area";
                chart.Series["Series"].Points[i].Color = colours[i % colours.Length];
            }
            chart.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Classes.Util.ChartToPNG(chart);
        }

        private void exportTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Classes.Util.TableToCSV(displayedTable);
        }
    }
}
