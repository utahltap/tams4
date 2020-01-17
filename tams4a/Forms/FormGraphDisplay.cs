using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace tams4a.Forms
{
    public partial class FormGraphDisplay : Form
    {
        private DataTable displayedTable;
        private Color[] colorPalette = { Color.FromArgb(88, 192, 235), Color.FromArgb(253, 231, 76), Color.FromArgb(155, 197, 61), Color.FromArgb(229, 89, 52), Color.FromArgb(250, 121, 33), Color.FromArgb(175, 110, 242) };

        public FormGraphDisplay(DataTable dt, string[] domain, double[] range, string t = "Distribution Graph", Color[] c = null)
        {
            InitializeComponent();
            CenterToScreen();
            displayedTable = dt;
            dataGridView.DataSource = displayedTable;
            if (c != null) {
                colorPalette = c;
            }
            Title title = chart.Titles.Add(t);
            title.Font = new Font("Arial", 20, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(60, 60, 60);
            chart.Invalidate();
            chart.Series.Clear();
            chart.Legends.Clear();
            chart.ChartAreas.Clear();
            chart.Series.Add("Series");
            chart.Series["Series"].IsValueShownAsLabel = true;
            chart.Series["Series"].Label = "#PERCENT{P1}";
            chart.ChartAreas.Add("Area");
            chart.ChartAreas["Area"].AxisY.Interval = 10;
            chart.ChartAreas["Area"].AxisX.Interval = 1;
            chart.ChartAreas["Area"].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas["Area"].AxisY.MajorGrid.LineWidth = 2;
            chart.ChartAreas["Area"].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas["Area"].AxisY.Title = "Percent of Road Network";
            chart.ChartAreas["Area"].AxisY.TitleFont = new Font("Arial", 14);
            chart.ChartAreas["Area"].AxisY.LabelAutoFitMinFontSize = 12;
            chart.ChartAreas["Area"].AxisY.LabelAutoFitMaxFontSize = 12;
            chart.ChartAreas["Area"].AxisX.LabelAutoFitMaxFontSize = 14;
            chart.ChartAreas["Area"].AxisY.LineWidth = 0;
            chart.ChartAreas["Area"].AxisX.LineWidth = 0;
            TickMark tickMark = new TickMark();
            tickMark.LineWidth = 0;
            chart.ChartAreas["Area"].AxisY.MajorTickMark = tickMark;
            chart.ChartAreas["Area"].AxisX.MajorTickMark = tickMark;
            for (int i = 0; i < domain.Length; i++)
            {
                chart.Series["Series"]["PixelPointWidth"] = "5";
                chart.Series["Series"].SetDefault(true);
                chart.Series["Series"].Enabled = true;
                chart.Series["Series"].Points.AddXY(domain[i], range[i]);
                chart.Series["Series"].ChartType = SeriesChartType.Column;
                chart.Series["Series"].ChartArea = "Area";
                chart.Series["Series"].Points[i].Color = colorPalette[i % colorPalette.Length];
                chart.Series["Series"].Font = new Font("Arial", 12);
            }
            chart.Show();
        }

        public FormGraphDisplay(DataTable dt, double[] domain, double[] range, Color[] c = null)
        {
            InitializeComponent();
            CenterToScreen();
            displayedTable = dt;
            dataGridView.DataSource = displayedTable;
            if (c != null)
            {
                colorPalette = c;
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
                chart.Series["Series"].Points[i].Color = colorPalette[i % colorPalette.Length];
            }
            chart.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Classes.Util.ChartToPNG(chart);
        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Classes.Util.TableToCSV(displayedTable);
        }

        private void pNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Classes.Util.TableToPNG(dataGridView);
        }
    }
}
