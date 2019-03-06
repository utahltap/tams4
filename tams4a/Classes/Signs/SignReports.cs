using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using tams4a.Forms;

namespace tams4a.Classes.Signs
{
    class SignReports
    {
        private TamsProject Project;
        private ModuleSigns moduleSigns;

        public SignReports(TamsProject theProject, ModuleSigns signs = null)
        {
            Project = theProject;
            moduleSigns = signs;
        }

        public void signInventory(object sender, EventArgs e)
        {
            DataTable data = addSignColumns();   
            try
            {
                DataTable signsTable = Database.GetDataByQuery(Project.conn, "SELECT * FROM sign;");
                if (signsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no signs where found.");
                    return;
                }
                foreach (DataRow row in signsTable.Rows)
                {
                    DataRow nr = data.NewRow();
                    addSignRows(nr, row);
                    data.Rows.Add(nr);
                }
                showReport(data, "Sign Inventory");
            }
            catch (Exception err)
            {
                errMsg(err);
            }
        }

        public void signRecommendations(object sender, EventArgs e)
        {
            int Integer = 0;
            Type typeInt = Integer.GetType();
            DataTable data = new DataTable();
            data.Columns.Add("ID", typeInt);
            data.Columns.Add("Support ID", typeInt);
            data.Columns.Add("Address");
            data.Columns.Add("Recommendation");
            data.Columns.Add("Notes");
            data.Columns.Add("Survey Date");
            try
            {
                DataTable signsTable = Database.GetDataByQuery(Project.conn, "SELECT * FROM sign WHERE recommendation != '';");
                DataTable signAddress = Database.GetDataByQuery(Project.conn, "SELECT address, support_id FROM sign_support;");
                if (signsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no signs where found.");
                    return;
                }
                foreach (DataRow row in signsTable.Rows)
                {
                    string address = "";
                    foreach (DataRow r in signAddress.Rows)
                    {
                        if (r["support_id"].ToString() == row["support_id"].ToString())
                            {
                                address = r["address"].ToString();
                                break;
                            }
                    }

                    DataRow nr = data.NewRow();
                    nr["ID"] = row["TAMSID"];
                    nr["Support ID"] = row["support_id"];
                    nr["Address"] = address;
                    nr["Recommendation"] = row["recommendation"];
                    nr["Notes"] = truncateNote(row);
                    nr["Survey Date"] = row["survey_date"];

                    data.Rows.Add(nr);
                }
                showReport(data, "Sign Recommendations");
            }
            catch (Exception err)
            {
                errMsg(err);
            }
        }

        public void supportInventory(object sender, EventArgs e)
        {
            DataTable data = addSupportColumns();
            try
            {
                DataTable signsTable = Database.GetDataByQuery(Project.conn, "SELECT * FROM sign_support;");
                if (signsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no signs where found.");
                    return;
                }
                foreach (DataRow row in signsTable.Rows)
                {
                    DataRow nr = data.NewRow();
                    addSupportRows(nr, row);
                    data.Rows.Add(nr);
                }
                showReport(data, "Support Inventory");
            }
            catch (Exception err)
            {
                errMsg(err);
            }
        }

        public void supportRecommendations(object sender, EventArgs e)
        {
            int Integer = 0;
            Type typeInt = Integer.GetType();
            DataTable data = new DataTable();
            data.Columns.Add("Support ID", typeInt);
            data.Columns.Add("Address");
            data.Columns.Add("Recommendation");
            data.Columns.Add("Notes");
            data.Columns.Add("Survey Date");
            try
            {
                DataTable signsTable = Database.GetDataByQuery(Project.conn, "SELECT * FROM sign_support WHERE recommendation != '';");
                if (signsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no signs where found.");
                    return;
                }
                foreach (DataRow row in signsTable.Rows)
                {
                    DataRow nr = data.NewRow();
                    nr["Support ID"] = row["support_id"];
                    nr["Address"] = row["address"];
                    nr["Recommendation"] = row["recommendation"];
                    nr["Notes"] = truncateNote(row);
                    nr["Survey Date"] = row["survey_date"];
                    data.Rows.Add(nr);
                }
                showReport(data, "Support Recommendations");
            }
            catch (Exception err)
            {
                errMsg(err);
            }
        }

        private void showReport(DataTable data, string name)
        {
            data.DefaultView.Sort = "Support ID asc";
            FormOutput report = new FormOutput(Project, null, name);
            report.dataGridViewReport.DataSource = data.DefaultView.ToTable();
            report.Text = name;
            report.Show();
        }

        private void errMsg(Exception err)
        {
            MessageBox.Show("An error occured while trying to generate the report.");
            Log.Error("Report failed to generate." + Environment.NewLine + err.ToString());
        }

        private string truncateNote(DataRow row)
        {
            string note = row["notes"].ToString().Split(new[] { '\r', '\n' }).FirstOrDefault(); //retrive most recent note

            int oldNoteLength = note.Length;
            int maxLength = 17;
            if (!string.IsNullOrEmpty(note))
            {
                note = note.Substring(0, Math.Min(oldNoteLength, maxLength));

            }
            if (note.Length == maxLength) note += "...";
            return note;
        }

        public DataTable addSignColumns()
        {
            int Integer = 0;
            Type typeInt = Integer.GetType();
            DataTable data = new DataTable();
            data.Columns.Add("ID", typeInt);
            data.Columns.Add("Support ID", typeInt);
            data.Columns.Add("Description");
            data.Columns.Add("Sign Text");
            data.Columns.Add("Condition");
            data.Columns.Add("Recommendation");
            data.Columns.Add("Reflectivity");
            data.Columns.Add("Sheeting");
            data.Columns.Add("Backing");
            data.Columns.Add("Height (in)", typeInt);
            data.Columns.Add("Width (in)", typeInt);
            data.Columns.Add("Mount Height (ft)", typeInt);
            data.Columns.Add("Direction");
            data.Columns.Add("Category");
            data.Columns.Add("Notes");
            data.Columns.Add("Favorite");
            data.Columns.Add("MUTCD Code");
            data.Columns.Add("Install Date");
            data.Columns.Add("Survey Date");
            return data;
        }

        public void addSignRows(DataRow nr, DataRow row)
        {
            nr["ID"] = row["TAMSID"];
            nr["Support ID"] = row["support_id"];
            nr["Description"] = row["description"];
            nr["Sign Text"] = row["sign_text"];
            nr["Condition"] = row["condition"];
            nr["Recommendation"] = row["recommendation"];
            nr["Reflectivity"] = row["reflectivity"];
            nr["Sheeting"] = row["sheeting"];
            nr["Backing"] = row["backing"];
            nr["Height (in)"] = row["height"];
            nr["Width (in)"] = row["width"];
            nr["Mount Height (ft)"] = row["mount_height"];
            nr["Direction"] = row["direction"];
            nr["Category"] = row["category"];
            nr["Notes"] = truncateNote(row);
            nr["Favorite"] = row["favorite"];
            nr["MUTCD Code"] = row["mutcd_code"];
            nr["Install Date"] = row["install_date"];
            nr["Survey Date"] = row["survey_date"];
        }

        public DataTable addSupportColumns()
        {
            int Integer = 0;
            Type typeInt = Integer.GetType();
            DataTable data = new DataTable();
            data.Columns.Add("Support ID", typeInt);
            data.Columns.Add("Address");
            data.Columns.Add("Material");
            data.Columns.Add("Condition");
            data.Columns.Add("Obstructions");
            data.Columns.Add("Recommendation");
            data.Columns.Add("Road Offset (ft)", typeInt);
            data.Columns.Add("Height (ft)", typeInt);
            data.Columns.Add("Category");
            data.Columns.Add("Notes");
            data.Columns.Add("Survey Date");
            return data;
        }

        public void addSupportRows(DataRow nr, DataRow row)
        {
            nr["Support ID"] = row["support_id"];
            nr["Address"] = row["address"];
            nr["Material"] = row["material"];
            nr["Condition"] = row["condition"];
            nr["Obstructions"] = row["obstructions"];
            nr["Recommendation"] = row["recommendation"];
            nr["Road Offset (ft)"] = row["road_offset"];
            nr["Height (ft)"] = row["height"];
            nr["Category"] = row["category"];
            nr["Notes"] = truncateNote(row);
            nr["Survey Date"] = row["survey_date"];
        }
    }
}
