using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormOutput : Form
    {
        private TamsProject Project;
        private ModuleRoads moduleRoads;

        public FormOutput(TamsProject theProject, ModuleRoads roads = null)
        {
            InitializeComponent();
            CenterToScreen();
            Project = theProject;
            moduleRoads = roads;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void csvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.TableToCSV((DataTable)(dataGridViewReport.DataSource), "TAMS");
        }

        private void pngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.TableToPNG(dataGridViewReport);
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable report = new DataTable();

            string thisSql = moduleRoads.getSelectAllSQL();
            DataTable fullDataSet = Database.GetDataByQuery(Project.conn, thisSql);

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

            foreach (DataColumn col in report.Columns)
            {
                try
                {
                    foreach (DataRow row in report.Rows)
                    {
                        string column = "";

                        if (col.ToString() == "ID") column = "TAMSID";
                        else if (col.ToString() == "Name") column = "name";
                        else if (col.ToString() == "Speed Limit") column = "speed_limit";
                        else if (col.ToString() == "Lanes") column = "lanes";
                        else if (col.ToString() == "Width (ft)") column = "width";
                        else if (col.ToString() == "Length (ft)") column = "length";
                        else if (col.ToString() == "From Address") column = "from_address";
                        else if (col.ToString() == "To Address") column = "to_address";
                        else if (col.ToString() == "Surface") column = "surface";
                        else if (col.ToString() == "Treatment") column = "suggested_treatment";
                        else if (col.ToString() == "RSL") column = "rsl";
                        else if (col.ToString() == "Functional Classification") column = "type";
                        else if (col.ToString() == "Notes") column = "notes";
                        else if (col.ToString() == "Survey Date") column = "survey_date";
                        else if (col.ToString() == "Fat/Spa/Pot") column = "distress1";
                        else if (col.ToString() == "Edg/Joi/Rut") column = "distress2";
                        else if (col.ToString() == "Lon/Cor/X-S") column = "distress3";
                        else if (col.ToString() == "Pat/Bro/Dra") column = "distress4";
                        else if (col.ToString() == "Pot/Fau/Dus") column = "distress5";
                        else if (col.ToString() == "Dra/Lon/Agg") column = "distress6";
                        else if (col.ToString() == "Tra/Tra/Cor") column = "distress7";
                        else if (col.ToString() == "Block/Crack") column = "distress8";
                        else if (col.ToString() == "Rutti/Patch") column = "distress9";
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

                        string sql = "UPDATE road SET " + column + " = \"" + newValue + "\" WHERE TAMSID = " + currentID;

                        if (column != "") Database.ExecuteNonQuery(Project.conn, sql);
                    }
                }
                catch
                {
                    Cursor.Current = Cursors.Arrow;
                    MessageBox.Show("Make sure the column names match each of the column names found in the 'general report.'", "Error: Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Cursor.Current = Cursors.Arrow;
            MessageBox.Show("Changes Saved");
            return;
        }

        private void LoadingMessage()
        {
            Application.Run(new FormLoading("Saving Changes..."));
        }
    }
}
