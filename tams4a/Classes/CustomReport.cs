using DotSpatial.Symbology;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using tams4a.Forms;
using tams4a.Classes.Roads;
using tams4a.Classes.Signs;
using tams4a.Classes.Other;

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
        private OtherReports otherReports;
        private MainWindow window;

        public CustomReport(TamsProject theProject, ModuleRoads roads, ModuleSigns signs, GenericModule other, MainWindow mainWindow)
        {
            Project = theProject;
            moduleRoads = roads;
            roadReports = new RoadReports(Project, roads);
            moduleSigns = signs;
            signReports = new SignReports(Project, signs);
            moduleOther = other;
            otherReports = new OtherReports(Project, other);
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
                if (tableFilters.tabControlCustom.SelectedTab.Text == "Other")
                {
                    customOtherReport(tableFilters);
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
            FeatureLayer selectionLayer = (FeatureLayer)moduleRoads.Layer;
            selectionLayer.ClearSelection();
            foreach (DataRow row in results.Rows)
            {
                if (selectResults)
                {
                    String tamsidcolumn = Project.settings.GetValue("road_f_TAMSID");
                    selectionLayer.SelectByAttribute(tamsidcolumn + " = " + row["TAMSID"], ModifySelectionMode.Append);
                    Console.WriteLine(selectionLayer.Selection.Count);
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
            FeatureLayer selectionLayer = (FeatureLayer)moduleSigns.Layer;
            selectionLayer.ClearSelection();
            foreach (DataRow row in results.Rows)
            {
                if (selectResults)
                {
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
            FeatureLayer selectionLayer = (FeatureLayer)moduleSigns.Layer;
            selectionLayer.ClearSelection();
            foreach (DataRow row in results.Rows)
            {
                if (selectResults)
                {
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

        private void customOtherReport(FormQueryBuilder tableFilters)
        {
            bool selectResults = false;
            string query = tableFilters.getQuery();
            if (tableFilters.checkBoxSelectResults.Checked && query != "SELECT * FROM miscellaneous") selectResults = true;

            string type = tableFilters.getType();
            DataTable results = Database.GetDataByQuery(Project.conn, query);

            if (type == "Roads with Sidewalks")
            {
                query += " GROUP BY road_ID ORDER BY road_ID ASC;";
                DataTable r = Database.GetDataByQuery(Project.conn, query);
                if (r.Rows.Count == 0)
                {
                    MessageBox.Show("No landmarks matching the given description were found.");
                    return;
                }
                otherReports.RoadsWithSidewalks(null, null, query);
            }
            else
            {
                query += " GROUP BY TAMSID ORDER BY TAMSID ASC;";
                results = Database.GetDataByQuery(Project.conn, query);
                if (results.Rows.Count == 0)
                {
                    MessageBox.Show("No landmarks matching the given description were found.");
                    return;
                }

                if (type == "Sidewalk") otherReports.SidewalkReport(null, null, query);
                else if (type == "ADA Ramp") otherReports.RampReport(null, null, query);
                else if (type == "Severe Road Distress") otherReports.RoadReport(null, null, query);
                else if (type == "Drainage") otherReports.DrainageReport(null, null, query);
                else if (type == "Accident") otherReports.AccidentReport(null, null, query);
                else if (type == "Other") otherReports.OtherReport(null, null, query);
                else otherReports.MiscReport(null, null, query);
            }

            if (selectResults)
            {
                foreach (DataRow row in results.Rows)
                {
                    if (selectResults)
                    {
                        FeatureLayer selectionLayer;
                        String tamsidcolumn;
                        if (type == "Roads with Sidewalks")
                        {
                            selectionLayer = (FeatureLayer)moduleRoads.Layer;
                            selectionLayer.ClearSelection();
                            tamsidcolumn = Project.settings.GetValue("road_f_TAMSID");
                            selectionLayer.SelectByAttribute(tamsidcolumn + " = " + row["road_ID"], ModifySelectionMode.Append);
                            moduleRoads.selectionChanged();
                            return;
                        }
                        selectionLayer = (FeatureLayer)moduleOther.Layer;
                        selectionLayer.ClearSelection();
                        tamsidcolumn = Project.settings.GetValue("miscellaneous_f_TAMSID");
                        selectionLayer.SelectByAttribute(tamsidcolumn + " = " + row["TAMSID"], ModifySelectionMode.Append);
                    }
                }
                moduleOther.selectionChanged();
            }
            return;
        }
    }
}
