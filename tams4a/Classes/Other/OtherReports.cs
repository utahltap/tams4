using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                        if (key == "Notes")
                            nr[key] = truncateNote(row[mapping[key]]);
                        else
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

        private string truncateNote(Object row)
        {
            string note = row.ToString().Split(new[] { '\r', '\n' }).FirstOrDefault(); //retrive most recent note

            int oldNoteLength = note.Length;
            int maxLength = 17;
            if (!string.IsNullOrEmpty(note))
            {
                note = note.Substring(0, Math.Min(oldNoteLength, maxLength));

            }
            if (note.Length == maxLength) note += "...";
            return note;
        }

        public void SidewalkReport(object sender, EventArgs e, string query = "SELECT * FROM miscellaneous WHERE type='Sidewalk'")
        {
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "TAMSID" },
                { "Address", "address" },
                { "Description", "description" },
                { "Faults", "property1" },
                { "Breaks", "property2" },
                { "Recommendation", "property3" },
                { "Surface", "property4" },
                { "Notes", "notes" }
            };
            createReport(query, map, "ID", "Sidewalks");
        }

        public void RampReport(object sender, EventArgs e, string query = "SELECT * FROM miscellaneous WHERE type='ADA Ramp'")
        {
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "TAMSID" },
                { "Address", "address" },
                { "Description", "description" },
                { "Condition", "property1" },
                { "Compliant", "property2" },
                { "Has Tiles", "property3" },
                { "Notes", "notes" }
            };
            createReport(query, map, "ID", "ADA Ramps");
        }

        public void RoadReport(object sender, EventArgs e, string query = "SELECT * FROM miscellaneous WHERE type='Severe Road Distress'")
        {
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "TAMSID" },
                { "Address", "address" },
                { "Description", "description" },
                { "Distress", "property1" },
                { "Recommendation", "property2" },
                { "Notes", "notes" }
            };
            createReport(query, map, "ID", "Severe Road Distresses");
        }

        public void DrainageReport(object sender, EventArgs e, string query = "SELECT * FROM miscellaneous WHERE type='Drainage'")
        {
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "TAMSID" },
                { "Address", "address" },
                { "Description", "description" },
                { "Type", "property1" },
                { "Recommendation", "property2" },
                { "Notes", "notes" }
            };
            createReport(query, map, "ID", "Drainage Problems");
        }

        public void AccidentReport(object sender, EventArgs e, string query = "SELECT * FROM miscellaneous WHERE type='Accident'")
        {
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

        public void OtherReport(object sender, EventArgs e, string query = "SELECT * FROM miscellaneous WHERE type='Other'")
        {
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

        public void RoadsWithSidewalks(object sender, EventArgs e, string query = "With uniqueRoad AS (SELECT * FROM road_sidewalks INNER JOIN road ON road_sidewalks.road_ID = road.TAMSID) SELECT DISTINCT road_ID, installed, comments, name, from_address, to_address FROM uniqueRoad;")
        {
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "road_ID" },
                { "Sidewalks", "installed" },
                { "Comments", "comments" },
                { "Name", "name" },
                { "From Address", "from_address" },
                { "To Address", "to_address" }
            };
            createReport(query, map, "ID", "Roads with Sidewalks");
        }

        public void MiscReport(object sender, EventArgs e, string query = "SELECT * FROM miscellaneous;")
        {
            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { "ID", "TAMSID" },
                { "Landmark Type", "type" },
                { "Address", "address" },
                { "Description", "description" },
                { "Property 1", "property1" },
                { "Property 2", "property2" },
                { "Property 3", "property3" },
                { "Notes", "notes" }
            };
            createReport(query, map, "ID", "Roads with Sidewalks");
        }

    }
}
