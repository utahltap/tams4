using DotSpatial.Symbology;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using tams4a.Forms;
using tams4a.Classes.Roads;
using tams4a.Classes.Signs;

namespace tams4a.Classes
{
    class CustomReport
    {
        private TamsProject Project;
        private ModuleRoads moduleRoads;
        private RoadReports roadReports;
        private ModuleSigns moduleSigns;
        private SignReports signReports;
        private GenericModule moduleOther;
        private MainWindow window;

        public CustomReport(TamsProject theProject, ModuleRoads roads, ModuleSigns signs, GenericModule other, MainWindow mainWindow)
        {
            Project = theProject;
            moduleRoads = roads;
            roadReports = new RoadReports(Project, roads);
            moduleSigns = signs;
            signReports = new SignReports(Project, signs);
            moduleOther = other;
            window = mainWindow;
        }

        public void newCustomReport()
        {
            int selectTab = 0;
            if (window.tabControlControls.SelectedIndex == 0) selectTab = 0;
            if (window.tabControlControls.SelectedIndex == 1) selectTab = 1;
            if (window.tabControlControls.SelectedIndex == 2) selectTab = 3;
            FormQueryBuilder tableFilters = new FormQueryBuilder(Project, selectTab);

            if (tableFilters.ShowDialog() == DialogResult.OK)
            {
                if (tableFilters.tabControlCustom.SelectedTab.Text == "Road")
                {
                    customRoadReport(tableFilters);
                }
                if (tableFilters.tabControlCustom.SelectedTab.Text == "Sign")
                {
                    customSignReport(tableFilters);
                }
                if (tableFilters.tabControlCustom.SelectedTab.Text == "Support")
                {
                    customSupportReport(tableFilters);
                }
            }
            tableFilters.Close();
        }


        private void customRoadReport(FormQueryBuilder tableFilters)
        {     
            bool selectResults = false;
            string surfaceType = tableFilters.getSurface();
            string query = tableFilters.getQuery();
            if (tableFilters.checkBoxSelectResults.Checked && query != "SELECT * FROM road") selectResults = true;
            query += " GROUP BY TAMSID ORDER BY TAMSID ASC, survey_date DESC;";
            DataTable results = Database.GetDataByQuery(Project.conn, query);
            if (results.Rows.Count == 0)
            {
                MessageBox.Show("No roads matching the given description were found.");
                return;
            }
            DataTable outputTable = roadReports.addColumns(surfaceType);

            FormOutput report = new FormOutput(Project, moduleRoads);
            foreach (DataRow row in results.Rows)
            {
                if (selectResults)
                {
                    FeatureLayer selectionLayer = (FeatureLayer)moduleRoads.Layer;
                    String tamsidcolumn = Project.settings.GetValue("road_f_TAMSID");
                    selectionLayer.SelectByAttribute(tamsidcolumn + " = " + row["TAMSID"], ModifySelectionMode.Append);
                }

                DataRow nr = outputTable.NewRow();
                string note = row["notes"].ToString().Split(new[] { '\r', '\n' }).FirstOrDefault(); //retrive most recent note

                int oldNoteLength = note.Length;
                int maxLength = 17;
                if (!string.IsNullOrEmpty(note))
                {
                    note = note.Substring(0, Math.Min(oldNoteLength, maxLength));
                    if (note.Length == maxLength) note += "...";
                }
                roadReports.addRows(nr, row, surfaceType);
                outputTable.Rows.Add(nr);
            }
            report.dataGridViewReport.DataSource = outputTable;
            report.Text = "Treatment Report";
            report.Show();
            if (selectResults) moduleRoads.selectionChanged();
        }

        private void customSignReport(FormQueryBuilder tableFilters)
        {
            bool selectResults = false;
            string query = tableFilters.getQuery();
            if (tableFilters.checkBoxSelectResults.Checked && query != "SELECT * FROM sign") selectResults = true;
            query += " GROUP BY TAMSID ORDER BY TAMSID ASC, support_id ASC;";
            DataTable results = Database.GetDataByQuery(Project.conn, query);
            if (results.Rows.Count == 0)
            {
                MessageBox.Show("No signs matching the given description were found.");
                return;
            }
            DataTable outputTable = signReports.addSignColumns();

            Console.WriteLine(query);

            FormOutput report = new FormOutput(Project, null, "Sign Inventory");
            foreach (DataRow row in results.Rows)
            {
                if (selectResults)
                {
                    FeatureLayer selectionLayer = (FeatureLayer)moduleSigns.Layer;
                    String tamsidcolumn = Project.settings.GetValue("sign_f_TAMSID");
                    selectionLayer.SelectByAttribute(tamsidcolumn + " = " + row["support_id"], ModifySelectionMode.Append);
                }

                DataRow nr = outputTable.NewRow();
                string note = row["notes"].ToString().Split(new[] { '\r', '\n' }).FirstOrDefault(); //retrive most recent note

                int oldNoteLength = note.Length;
                int maxLength = 17;
                if (!string.IsNullOrEmpty(note))
                {
                    note = note.Substring(0, Math.Min(oldNoteLength, maxLength));
                    if (note.Length == maxLength) note += "...";
                }
                signReports.addSignRows(nr, row);
                outputTable.Rows.Add(nr);
            }
            report.dataGridViewReport.DataSource = outputTable;
            report.Text = "Custom Sign Report";
            report.Show();
            if (selectResults) moduleSigns.selectionChanged();
        }

        private void customSupportReport(FormQueryBuilder tableFilters)
        {
            bool selectResults = false;
            string query = tableFilters.getQuery();
            if (tableFilters.checkBoxSelectResults.Checked && query != "SELECT * FROM sign_support") selectResults = true;
            query += " GROUP BY support_id ORDER BY support_id ASC;";
            DataTable results = Database.GetDataByQuery(Project.conn, query);
            if (results.Rows.Count == 0)
            {
                MessageBox.Show("No sign supports matching the given description were found.");
                return;
            }
            DataTable outputTable = signReports.addSupportColumns();

            Console.WriteLine(query);

            FormOutput report = new FormOutput(Project, null, "Support Inventory");
            foreach (DataRow row in results.Rows)
            {
                if (selectResults)
                {
                    FeatureLayer selectionLayer = (FeatureLayer)moduleSigns.Layer;
                    String tamsidcolumn = Project.settings.GetValue("sign_f_TAMSID");
                    selectionLayer.SelectByAttribute(tamsidcolumn + " = " + row["support_id"], ModifySelectionMode.Append);
                }

                DataRow nr = outputTable.NewRow();
                string note = row["notes"].ToString().Split(new[] { '\r', '\n' }).FirstOrDefault(); //retrive most recent note

                int oldNoteLength = note.Length;
                int maxLength = 17;
                if (!string.IsNullOrEmpty(note))
                {
                    note = note.Substring(0, Math.Min(oldNoteLength, maxLength));
                    if (note.Length == maxLength) note += "...";
                }
                signReports.addSupportRows(nr, row);
                outputTable.Rows.Add(nr);
            }
            report.dataGridViewReport.DataSource = outputTable;
            report.Text = "Custom Support Report";
            report.Show();
            if (selectResults) moduleSigns.selectionChanged();
        }

    }
}
