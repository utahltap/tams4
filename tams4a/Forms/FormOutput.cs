using System;
using System.Data;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormOutput : Form
    {
        private TamsProject Project;
        private ModuleRoads moduleRoads;
        private string reportType;

        public FormOutput(TamsProject theProject, ModuleRoads roads = null, string name = null)
        {
            InitializeComponent();
            CenterToScreen();
            Project = theProject;
            moduleRoads = roads;
            reportType = name;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void csvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.TableToCSV((DataTable)(dataGridViewReport.DataSource));
        }

        private void pngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.TableToPNG(dataGridViewReport);
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable report = new DataTable();

            foreach (DataGridViewColumn col in dataGridViewReport.Columns)
            {
                report.Columns.Add(col.Name);
            }
            foreach(DataGridViewRow row in dataGridViewReport.Rows)
            {
                DataRow dataRow = report.NewRow();
                foreach(DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }
                report.Rows.Add(dataRow);
            }

            if (String.IsNullOrEmpty(reportType) || reportType == "Road") roadReport(report);
            else if (reportType == "Sign Inventory") signInventoryReport(report);
            else if (reportType == "Sign Recommendations") signRecommendationsReport(report);
            else if (reportType == "Support Inventory") supportInventoryReport(report);
            else if (reportType == "Support Recommendations") supportRecommendationsReport(report);
            else otherReport(report);

            Cursor.Current = Cursors.Arrow;
            MessageBox.Show("Changes Saved");
            return;
        }

        private void roadReport(DataTable report)
        {
            string thisSql = moduleRoads.getSelectAllSQL();
            DataTable fullDataSet = Database.GetDataByQuery(Project.conn, thisSql);

            string sql = "";
            foreach (DataColumn col in report.Columns)
            {
                foreach (DataRow row in report.Rows)
                {
                    string column = "";
                    string thisCol = col.ToString();

                    if (thisCol == "ID") column = "TAMSID";
                    else if (thisCol == "Name") column = "name";
                    else if (thisCol == "Speed Limit") column = "speed_limit";
                    else if (thisCol == "Lanes") column = "lanes";
                    else if (thisCol == "Width (ft)") column = "width";
                    else if (thisCol == "Length (ft)") column = "length";
                    else if (thisCol == "From Address") column = "from_address";
                    else if (thisCol == "To Address") column = "to_address";
                    else if (thisCol == "Surface") column = "surface";
                    else if (thisCol == "Treatment") column = "suggested_treatment";
                    else if (thisCol == "RSL") column = "rsl";
                    else if (thisCol == "Functional Classification") column = "type";
                    else if (thisCol == "Survey Date") column = "survey_date";
                    else if (thisCol == "Photo") column = "photo";
                    else if (thisCol == "Fat/Spa/Pot") column = "distress1";
                    else if (thisCol == "Edg/Joi/Rut") column = "distress2";
                    else if (thisCol == "Lon/Cor/X-S") column = "distress3";
                    else if (thisCol == "Pat/Bro/Dra") column = "distress4";
                    else if (thisCol == "Pot/Fau/Dus") column = "distress5";
                    else if (thisCol == "Dra/Lon/Agg") column = "distress6";
                    else if (thisCol == "Tra/Tra/Cor") column = "distress7";
                    else if (thisCol == "Block/Crack") column = "distress8";
                    else if (thisCol == "Rutti/Patch") column = "distress9";
                    else continue;

                    string currentID = row["ID"].ToString();
                    if (String.IsNullOrEmpty(currentID)) currentID = null;
                    if (currentID == null) continue;

                    string newValue = row[col].ToString();
                    if (String.IsNullOrEmpty(newValue)) newValue = null;

                    bool valuePresent = false;

                    string searchDataSet = "TAMSID = null";
                    if (!(currentID == null)) searchDataSet = "TAMSID = " + row["ID"].ToString();
                    DataRow[] existingRow = fullDataSet.Select(searchDataSet);
                    foreach (DataRow dr in existingRow)
                    {
                        string oldValue = dr[column].ToString();
                        if (String.IsNullOrEmpty(oldValue)) oldValue = null;
                        if (oldValue == newValue)
                        {
                            valuePresent = true;
                            continue;
                        }
                    }
                    if (valuePresent) continue;
                    sql += "UPDATE road SET " + column + " = \"" + newValue + "\" WHERE TAMSID = " + currentID + ";";
                }
            }
            try
            {
                Database.ExecuteNonQuery(Project.conn, sql);
            }
            catch
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Make sure the column names match each of the column names found in the 'general report.'", "Error: Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void signInventoryReport(DataTable report)
        {
            DataTable fullDataSet = Database.GetDataByQuery(Project.conn, "SELECT * FROM sign;");

            string sql = "";
            foreach (DataColumn col in report.Columns)
            {
                foreach (DataRow row in report.Rows)
                {
                    string column = "";
                    string thisCol = col.ToString();

                    if (thisCol == "ID") column = "TAMSID";
                    else if (thisCol == "Support ID") column = "support_id";
                    else if (thisCol == "Description") column = "description";
                    else if (thisCol == "Sign Text") column = "sign_text";
                    else if (thisCol == "Obstructions") column = "obstructions";
                    else if (thisCol == "Condition") column = "condition";
                    else if (thisCol == "Recommendation") column = "recommendation";
                    else if (thisCol == "Reflectivity") column = "reflectivity";
                    else if (thisCol == "Sheeting") column = "sheeting";
                    else if (thisCol == "Backing") column = "backing";
                    else if (thisCol == "Height (in)") column = "height";
                    else if (thisCol == "Width (in)") column = "width";
                    else if (thisCol == "Mount Height (ft)") column = "mount_height";
                    else if (thisCol == "Direction") column = "direction";
                    else if (thisCol == "Category") column = "category";
                    else if (thisCol == "Favorite") column = "favorite";
                    else if (thisCol == "MUTCD Code") column = "mutcd_code";
                    else if (thisCol == "Install Date") column = "install_date";
                    else if (thisCol == "Survey Date") column = "survey_date";
                    else if (thisCol == "Photo") column = "photo";
                    else continue;

                    string currentID = row["ID"].ToString();
                    if (String.IsNullOrEmpty(currentID)) currentID = null;
                    if (currentID == null) continue;

                    string newValue = row[col].ToString();
                    if (String.IsNullOrEmpty(newValue)) newValue = null;

                    bool valuePresent = false;

                    string searchDataSet = "TAMSID = null";
                    if (!(currentID == null)) searchDataSet = "TAMSID = " + row["ID"].ToString();
                    DataRow[] existingRow = fullDataSet.Select(searchDataSet);
                    foreach (DataRow dr in existingRow)
                    {
                        string oldValue = dr[column].ToString();
                        if (String.IsNullOrEmpty(oldValue)) oldValue = null;
                        if (oldValue == newValue)
                        {
                            valuePresent = true;
                            continue;
                        }
                    }
                    if (valuePresent) continue;
                    sql += "UPDATE sign SET " + column + " = \"" + newValue + "\" WHERE TAMSID = " + currentID + ";";
                }
            }
            try
            {
                Database.ExecuteNonQuery(Project.conn, sql);
            }
            catch
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Make sure the column names match each of the column names found in the 'Sign Inventory' report.", "Error: Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void signRecommendationsReport(DataTable report)
        {
            DataTable fullDataSet = Database.GetDataByQuery(Project.conn, "SELECT s.TAMSID, s.support_id, s.recommendation, s.notes, s.survey_date, ss.address, s.photo FROM sign s " +
                "JOIN sign_support ss ON s.support_id = ss.support_id;");

            string sql = "";
            foreach (DataColumn col in report.Columns)
            {
                foreach (DataRow row in report.Rows)
                {
                    string column = "";
                    string thisCol = col.ToString();

                    if (thisCol == "ID") column = "TAMSID";
                    else if (thisCol == "Support ID") column = "support_id";
                    else if (thisCol == "Address")
                    {
                        if (String.IsNullOrEmpty(row["Support ID"].ToString())) continue;
                        column = "address";
                        sql += "UPDATE sign_support SET " + column + " = \"" + row[col].ToString() + "\" WHERE support_id = " + row["Support ID"].ToString() + ";";
                        continue;
                    }
                    else if (thisCol == "Recommendation") column = "recommendation";
                    else if (thisCol == "Survey Date") column = "survey_date";
                    else if (thisCol == "Photo") column = "photo";
                    else continue;

                    string currentID = row["ID"].ToString();
                    if (String.IsNullOrEmpty(currentID)) currentID = null;
                    if (currentID == null) continue;

                    string newValue = row[col].ToString();
                    if (String.IsNullOrEmpty(newValue)) newValue = null;

                    bool valuePresent = false;

                    string searchDataSet = "TAMSID = null";
                    if (!(currentID == null)) searchDataSet = "TAMSID = " + row["ID"].ToString();
                    DataRow[] existingRow = fullDataSet.Select(searchDataSet);
                    foreach (DataRow dr in existingRow)
                    {
                        string oldValue = dr[column].ToString();
                        if (String.IsNullOrEmpty(oldValue)) oldValue = null;
                        if (oldValue == newValue)
                        {
                            valuePresent = true;
                            continue;
                        }
                    }
                    if (valuePresent) continue;
                    sql += "UPDATE sign SET " + column + " = \"" + newValue + "\" WHERE TAMSID = " + currentID + ";";
                }
            }
            try
            {
                Database.ExecuteNonQuery(Project.conn, sql);
            }
            catch
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Make sure the column names match each of the column names found in the 'Sign Inventory' report.", "Error: Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void supportInventoryReport(DataTable report)
        {
            DataTable fullDataSet = Database.GetDataByQuery(Project.conn, "SELECT * FROM sign_support;");

            string sql = "";
            foreach (DataColumn col in report.Columns)
            {
                foreach (DataRow row in report.Rows)
                {
                    string column = "";
                    string thisCol = col.ToString();

                    if (thisCol == "Support ID") column = "support_id";
                    else if (thisCol == "Address") column = "address";
                    else if (thisCol == "Material") column = "material";
                    else if (thisCol == "Condition") column = "condition";
                    else if (thisCol == "Obstructions") column = "obstructions";
                    else if (thisCol == "Recommendation") column = "recommendation";
                    else if (thisCol == "Road Offset (ft)") column = "road_offset";
                    else if (thisCol == "Height (ft)") column = "height";
                    else if (thisCol == "Category") column = "category";
                    else if (thisCol == "Survey Date") column = "survey_date";
                    else if (thisCol == "Photo") column = "photo";
                    else continue;

                    string currentID = row["Support ID"].ToString();
                    if (String.IsNullOrEmpty(currentID)) currentID = null;
                    if (currentID == null) continue;

                    string newValue = row[col].ToString();
                    if (String.IsNullOrEmpty(newValue)) newValue = null;

                    bool valuePresent = false;

                    string searchDataSet = "support_id = null";
                    if (!(currentID == null)) searchDataSet = "support_id = " + row["Support ID"].ToString();
                    DataRow[] existingRow = fullDataSet.Select(searchDataSet);
                    foreach (DataRow dr in existingRow)
                    {
                        string oldValue = dr[column].ToString();
                        if (String.IsNullOrEmpty(oldValue)) oldValue = null;
                        if (oldValue == newValue)
                        {
                            valuePresent = true;
                            continue;
                        }
                    }
                    if (valuePresent) continue;
                    sql += "UPDATE sign_support SET " + column + " = \"" + newValue + "\" WHERE support_id = " + currentID + ";";
                }
            }
            try
            {
                Database.ExecuteNonQuery(Project.conn, sql);
            }
            catch
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Make sure the column names match each of the column names found in the 'Sign Inventory' report.", "Error: Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void supportRecommendationsReport(DataTable report)
        {
            DataTable fullDataSet = Database.GetDataByQuery(Project.conn, "SELECT support_id, address, recommendation, notes, survey_date FROM sign_support;");

            string sql = "";
            foreach (DataColumn col in report.Columns)
            {
                foreach (DataRow row in report.Rows)
                {
                    string column = "";
                    string thisCol = col.ToString();

                    if (thisCol == "Support ID") column = "support_id";
                    else if (thisCol == "Address") column = "address";
                    else if (thisCol == "Recommendation") column = "recommendation";
                    else if (thisCol == "Survey Date") column = "survey_date";
                    else continue;

                    string currentID = row["Support ID"].ToString();
                    if (String.IsNullOrEmpty(currentID)) currentID = null;
                    if (currentID == null) continue;

                    string newValue = row[col].ToString();
                    if (String.IsNullOrEmpty(newValue)) newValue = null;

                    bool valuePresent = false;

                    string searchDataSet = "support_id = null";
                    if (!(currentID == null)) searchDataSet = "support_id = " + row["Support ID"].ToString();
                    DataRow[] existingRow = fullDataSet.Select(searchDataSet);
                    foreach (DataRow dr in existingRow)
                    {
                        string oldValue = dr[column].ToString();
                        if (String.IsNullOrEmpty(oldValue)) oldValue = null;
                        if (oldValue == newValue)
                        {
                            valuePresent = true;
                            continue;
                        }
                    }
                    if (valuePresent) continue;
                    sql += "UPDATE sign_support SET " + column + " = \"" + newValue + "\" WHERE support_id = " + currentID + ";";
                }
            }
            try
            {
                Database.ExecuteNonQuery(Project.conn, sql);
            }
            catch
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Make sure the column names match each of the column names found in the 'Sign Inventory' report.", "Error: Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void otherReport(DataTable report)
        {
            DataTable fullDataSet = Database.GetDataByQuery(Project.conn, "SELECT * FROM miscellaneous;");

            string sql = "";
            foreach (DataColumn col in report.Columns)
            {
                foreach (DataRow row in report.Rows)
                {
                    string column = "";
                    string thisCol = col.ToString();
                    string table = "miscellaneous";
                    string idName = "TAMSID";
    
                    if (thisCol == "ID")
                    {
                        column = "TAMSID";
                        if (reportType == "Roads with Sidewalks")
                        {
                            table = "road_sidewalks";
                            column = "road_ID";
                            idName = "road_ID";
                        }
                    }
                    else if (thisCol == "Address") column = "address";
                    else if (thisCol == "Description") column = "description";
                    else if (thisCol == "Photo") column = "photo";
                    else
                    {
                        switch (reportType)
                        {
                            case "Sidewalks":
                                if (thisCol == "Faults") column = "property1";
                                else if (thisCol == "Breaks") column = "property2";
                                else if (thisCol == "Recommendation") column = "property3";
                                else continue;
                                break;

                            case "Roads with Sidewalks":
                                table = "road_sidewalks";
                                idName = "road_ID";
                                if (thisCol == "Sidewalks") column = "installed";
                                else if (thisCol == "Comments") column = "comments";
                                else continue;
                                break;

                            case "Severe Road Distresses":
                                if (thisCol == "Distress") column = "property1";
                                else if (thisCol == "Recommendation") column = "property2";
                                else continue;
                                break;

                            case "ADA Ramps":
                                if (thisCol == "Condition") column = "property1";
                                else if (thisCol == "Compliant") column = "property2";
                                else if (thisCol == "Has Tiles") column = "property3";
                                else continue;
                                break;

                            case "Drainage Problems":
                                if (thisCol == "Type") column = "property1";
                                else if (thisCol == "Recommendation") column = "property2";
                                else continue;
                                break;

                            case "Accident":
                                if (thisCol == "Date") column = "property1";
                                else if (thisCol == "Type") column = "property2";
                                else if (thisCol == "Severity") column = "property3";
                                else continue;
                                break;

                            case "Objects":
                                if (thisCol == "Property 1") column = "property1";
                                else if (thisCol == "Property 2") column = "property2";
                                else continue;
                                break;

                            default:
                                continue;
                        }
                    }

                    string currentID = row["ID"].ToString();
                    if (String.IsNullOrEmpty(currentID)) currentID = null;
                    if (currentID == null) continue;

                    string newValue = row[col].ToString();
                    if (String.IsNullOrEmpty(newValue)) newValue = null;

                    bool valuePresent = false;

                    string searchDataSet = "TAMSID = null";
                    if (!(currentID == null)) searchDataSet = "TAMSID = " + row["ID"].ToString();
                    DataRow[] existingRow = fullDataSet.Select(searchDataSet);
                    foreach (DataRow dr in existingRow)
                    {
                        string oldValue = dr[column].ToString();
                        if (String.IsNullOrEmpty(oldValue)) oldValue = null;
                        if (oldValue == newValue)
                        {
                            valuePresent = true;
                            continue;
                        }
                    }
                    if (valuePresent) continue;
                    sql += "UPDATE " + table + " SET " + column + " = \"" + newValue + "\" WHERE " + idName + " = " + currentID + ";";
                }
            }
            try
            {
                Console.WriteLine(sql);
                Database.ExecuteNonQuery(Project.conn, sql);
            }
            catch
            {
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Make sure the column names match each of the column names found in the 'Sign Inventory' report.", "Error: Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (reportType == "Sidwalks")...
        }

    }
}
