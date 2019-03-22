using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using tams4a.Forms;

namespace tams4a.Classes.Other
{
    class OtherReports
    {
        private TamsProject Project;
        private GenericModule moduleOther;

        public OtherReports(TamsProject theProject, GenericModule other = null)
        {
            Project = theProject;
            moduleOther = other;
        }

        private void createReport(string query, Dictionary<string, string> mapping, string sortKey = "ID", string name = "")
        {
            DataTable outputTable = new DataTable();
            foreach (string key in mapping.Keys)
            {
                outputTable.Columns.Add(key);
            }
            try
            {
                DataTable results = Database.GetDataByQuery(Project.conn, query);
                if (results.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no " + name + " were found.");
                    return;
                }
                foreach (DataRow row in results.Rows)
                {
                    DataRow nr = outputTable.NewRow();
                    foreach (string key in mapping.Keys)
                    {
                        nr[key] = row[mapping[key]];
                    }
                    outputTable.Rows.Add(nr);
                }
                outputTable.DefaultView.Sort = sortKey + " asc";
                FormOutput report = new FormOutput(Project, null, name);
                report.dataGridViewReport.DataSource = outputTable.DefaultView.ToTable();
                report.Text = name + " Report";
                report.Show();
            }
            catch (Exception e)
            {
                Log.Error("Could not get data from database " + Environment.NewLine + e.ToString());
            }
        }

        public void SidewalkReport(object sender, EventArgs e)
        {
            string query = "SELECT * FROM miscellaneous WHERE type='Sidewalk'";
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "TAMSID" },
                { "Address", "address" },
                { "Description", "description" },
                { "Faults", "property1" },
                { "Breaks", "property2" },
                { "Notes", "notes" }
            };
            createReport(query, map, "ID", "Sidewalks");
        }

        public void RampReport(object sender, EventArgs e)
        {
            string query = "SELECT * FROM miscellaneous WHERE type='ADA Ramp'";
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "TAMSID" },
                { "Address", "address" },
                { "Description", "description" },
                { "Condition", "property1" },
                { "Compliant", "property2" },
                { "Notes", "notes" }
            };
            createReport(query, map, "ID", "ADA Ramps");
        }

        public void RoadReport(object sender, EventArgs e)
        {
            string query = "SELECT * FROM miscellaneous WHERE type='Severe Road Distress'";
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "TAMSID" },
                { "Address", "address" },
                { "Description", "description" },
                { "Distress", "property1" },
                { "Recommendation", "property2" },
                { "Notes", "notes" }
            };
            createReport(query, map, "ID", "Extreme Distresses");
        }

        public void DrainageReport(object sender, EventArgs e)
        {
            string query = "SELECT * FROM miscellaneous WHERE type='Drainage'";
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "TAMSID" },
                { "Address", "address" },
                { "Description", "description" },
                { "Cause", "property1" },
                { "Comment", "property2" },
                { "Notes", "notes" }
            };
            createReport(query, map, "ID", "Drainage Problems");
        }

        public void AccidentReport(object sender, EventArgs e)
        {
            string query = "SELECT * FROM miscellaneous WHERE type='Accident'";
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "TAMSID" },
                { "Address", "address" },
                { "Description", "description" },
                { "Date", "property1" },
                { "Type", "property2" },
                { "Severity", "property3" },
                { "Notes", "notes" }
            };
            createReport(query, map, "ID", "Accident");
        }

        public void OtherReport(object sender, EventArgs e)
        {
            string query = "SELECT * FROM miscellaneous WHERE type='Other'";
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "TAMSID" },
                { "Address", "address" },
                { "Description", "description" },
                { "Property 1", "property1" },
                { "Property 2", "property2" },
                { "Notes", "notes" }
            };
            createReport(query, map, "ID", "Objects");
        }

        public void RoadsWithSidewalks(object sender, EventArgs e)
        {
            string query = "SELECT * FROM road_sidewalks";
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "road_ID" },
                { "Sidewalks", "installed" },
                { "Comments", "comments" }
            };
            createReport(query, map, "ID", "Sidewalks");
        }

    }
}
