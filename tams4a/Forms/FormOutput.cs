using DotSpatial.Symbology;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormOutput : Form
    {
        private TamsProject Project;

        public FormOutput(TamsProject theProject)
        {
            InitializeComponent();
            CenterToScreen();
            Project = theProject;
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
            Thread thread = new Thread(new ThreadStart(LoadingMessage));
            thread.Start();
            Cursor.Current = Cursors.WaitCursor;
            DataTable report = new DataTable();

            foreach(DataGridViewColumn col in dataGridViewReport.Columns)
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
                        if (col.ToString() == "Name") column = "name";
                        if (col.ToString() == "Speed Limit") column = "speed_limit";
                        if (col.ToString() == "Lanes") column = "lanes";
                        if (col.ToString() == "Width (ft)") column = "width";
                        if (col.ToString() == "Length (ft)") column = "length";
                        if (col.ToString() == "From Address") column = "from_address";
                        if (col.ToString() == "To Address") column = "to_address";
                        if (col.ToString() == "Surface") column = "surface";
                        if (col.ToString() == "Treatment") column = "suggested_treatment";
                        if (col.ToString() == "RSL") column = "rsl";
                        if (col.ToString() == "Functional Classification") column = "type";
                        if (col.ToString() == "Notes") column = "notes";
                        if (col.ToString() == "Survey Date") column = "survey_date";
                        if (col.ToString() == "Fat/Spa/Pot") column = "distress1";
                        if (col.ToString() == "Edg/Joi/Rut") column = "distress2";
                        if (col.ToString() == "Lon/Cor/X-S") column = "distress3";
                        if (col.ToString() == "Pat/Bro/Dra") column = "distress4";
                        if (col.ToString() == "Pot/Fau/Dus") column = "distress5";
                        if (col.ToString() == "Dra/Lon/Agg") column = "distress6";
                        if (col.ToString() == "Tra/Tra/Cor") column = "distress7";
                        if (col.ToString() == "Block/Crack") column = "distress8";
                        if (col.ToString() == "Rutti/Patch") column = "distress9";


                        string newValue = row[col].ToString();
                        if (String.IsNullOrEmpty(newValue)) newValue = null;

                        string sql = "UPDATE road SET " + column + " = \"" + newValue + "\" WHERE TAMSID = " + row["ID"].ToString();

                        if (column != "")
                            Database.ExecuteNonQuery(Project.conn, sql);
                    }
                }
                catch
                {
                    thread.Abort();
                    Cursor.Current = Cursors.Arrow;
                    MessageBox.Show("Make sure the column names match each of the column names found in the 'general report.'", "Error: Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            thread.Abort();
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
