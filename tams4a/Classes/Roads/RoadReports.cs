using DotSpatial.Symbology;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using tams4a.Forms;

namespace tams4a.Classes.Roads
{
    public class RoadReports
    {
        private TamsProject Project;
        private ModuleRoads moduleRoads;
        private DataTable reportTable;
        private string ModuleName = "road";

        public RoadReports(TamsProject theProject, ModuleRoads roads)
        {
            Project = theProject;
            moduleRoads = roads;
        }

        public void generalReport(object sender, EventArgs e)
        {
            DataTable general = new DataTable();
            general.Columns.Add("ID");
            general.Columns.Add("Name");
            general.Columns.Add("Width (ft)");
            general.Columns.Add("Length (ft)");
            general.Columns.Add("From Address");
            general.Columns.Add("To Address");
            general.Columns.Add("Surface");
            general.Columns.Add("Governing Distress");
            general.Columns.Add("Treatment");
            general.Columns.Add("Cost");
            general.Columns.Add("Area");
            general.Columns.Add("RSL");
            general.Columns.Add("Functional Classification");
            general.Columns.Add("Notes");
            general.Columns.Add("Survey Date");
            general.Columns.Add("Fat/Spa/Pot");
            general.Columns.Add("Edg/Joi/Rut");
            general.Columns.Add("Lon/Cor/X-S");
            general.Columns.Add("Pat/Bro/Dra");
            general.Columns.Add("Pot/Fau/Dus");
            general.Columns.Add("Dra/Lon/Agg");
            general.Columns.Add("Tra/Tra/Cor");
            general.Columns.Add("Block/Crack");
            general.Columns.Add("Rutti/Patch");

            string thisSql = moduleRoads.getSelectAllSQL();
            try
            {
                DataTable resultsTable = Database.GetDataByQuery(Project.conn, thisSql);

                foreach (DataRow row in resultsTable.Rows)
                {

                    DataRow nr = general.NewRow();
                    nr["ID"] = row["TAMSID"];
                    nr["Name"] = row["name"];
                    nr["Width (ft)"] = row["width"];
                    nr["Length (ft)"] = row["length"];
                    nr["From Address"] = row["from_address"];
                    nr["To Address"] = row["to_address"];
                    nr["Surface"] = row["surface"];
                    nr["RSL"] = row["rsl"];
                    nr["Functional Classification"] = row["type"];
                    nr["Notes"] = truncateNote(row);
                    nr["Survey Date"] = row["survey_date"];
                    nr["Fat/Spa/Pot"] = row["distress1"];
                    nr["Edg/Joi/Rut"] = row["distress2"];
                    nr["Lon/Cor/X-S"] = row["distress3"];
                    nr["Pat/Bro/Dra"] = row["distress4"];
                    nr["Pot/Fau/Dus"] = row["distress5"];
                    nr["Dra/Lon/Agg"] = row["distress6"];
                    nr["Tra/Tra/Cor"] = row["distress7"];
                    nr["Block/Crack"] = row["distress8"];
                    nr["Rutti/Patch"] = row["distress9"];

                    int[] dvs = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        dvs[i] = Util.ToInt(row["distress" + (i + 1).ToString()].ToString());
                    }
                    nr["Governing Distress"] = moduleRoads.getGoverningDistress(dvs, row["surface"].ToString());
                    if (!row["suggested_treatment"].ToString().Contains("null") && !string.IsNullOrWhiteSpace(row["suggested_treatment"].ToString()))
                    {
                        nr["Treatment"] = row["suggested_treatment"];
                    }
                    nr["Area"] = Util.ToDouble(row["width"].ToString()) * Util.ToDouble(row["length"].ToString());
                    general.Rows.Add(nr);
                }

                general.DefaultView.Sort = "Name asc, Treatment asc, From Address asc";
                general = general.DefaultView.ToTable();
                FormOutput report = new FormOutput(Project);
                report.dataGridViewReport.DataSource = general;
                report.Text = "Treatment Report";
                report.Show();
            }
            catch (Exception err)
            {
                Log.Error("Could not get database values for " + ModuleName + " module.\n" + err.ToString());
                MessageBox.Show("An error has occured while trying to consolidate data.");
            }
        }

        public void potholeReport(object sender, EventArgs e)
        {
            string[] pd = { "less than 1\"", "less than 2\"", "more than 2\"" };
            string[] pq = { "less than 2", "less than 5", "more than 5" };
            DataTable potholes = new DataTable("Potholes");
            potholes.Columns.Add("ID");
            potholes.Columns.Add("Name");
            potholes.Columns.Add("From Address");
            potholes.Columns.Add("To Address");
            potholes.Columns.Add("Depth");
            potholes.Columns.Add("Quantity");
            potholes.Columns.Add("Suggested Treatment");
            string thisSql = moduleRoads.getSelectAllSQL();
            try
            {
                DataTable resultsTable = Database.GetDataByQuery(Project.conn, thisSql);
                if (resultsTable.Rows.Count == 0)
                {
                    MessageBox.Show("No list could be generated because no roads with potholes where found.");
                    return;
                }
                foreach (DataRow row in resultsTable.Rows)
                {
                    if (Util.ToInt(row["distress5"].ToString()) <= 0)
                    {
                        continue;
                    }
                    DataRow nr = potholes.NewRow();
                    nr["ID"] = row["TAMSID"];
                    nr["Name"] = row["name"];
                    nr["From Address"] = row["from_address"];
                    nr["To Address"] = row["to_address"];
                    nr["Depth"] = (Util.ToInt(row["distress5"].ToString()) > 0 ? pd[(Util.ToInt(row["distress5"].ToString()) - 1) / 3] : "None");
                    nr["Quantity"] = (Util.ToInt(row["distress5"].ToString()) > 0 ? pq[(Util.ToInt(row["distress5"].ToString()) - 1) % 3] : "None");
                    nr["Suggested Treatment"] = row["suggested_treatment"].ToString();
                    potholes.Rows.InsertAt(nr, potholes.Rows.Count);
                }
                potholes.DefaultView.Sort = "Name asc, From Address asc";
                FormOutput report = new FormOutput(Project);
                report.dataGridViewReport.DataSource = potholes.DefaultView.ToTable();
                report.Text = "Potholes Report";
                report.Show();
            }
            catch (Exception err)
            {
                Log.Error("Could not get database values for " + ModuleName + " module.\n" + err.ToString());
                MessageBox.Show("An error has occured while trying to consolidate data.");
            }
        }

        public void customReport(object sender, EventArgs e)
        {
            FormQueryBuilder tableFilters = new FormQueryBuilder("road");
            if (tableFilters.ShowDialog() == DialogResult.OK)
            {
                string surfaceType = tableFilters.getSurface();
                string query = tableFilters.getQuery() + " GROUP BY TAMSID ORDER BY TAMSID ASC, survey_date DESC;";
                DataTable results = Database.GetDataByQuery(Project.conn, query);
                if (results.Rows.Count == 0)
                {
                    MessageBox.Show("No roads matching the given description were found.");
                    return;
                }
                DataTable outputTable = new DataTable();
                outputTable.Columns.Add("ID");
                outputTable.Columns.Add("Name");
                outputTable.Columns.Add("Speed Limit");
                outputTable.Columns.Add("Lanes");
                outputTable.Columns.Add("Width (ft)");
                outputTable.Columns.Add("Length (ft)");
                outputTable.Columns.Add("From Address");
                outputTable.Columns.Add("To Address");
                outputTable.Columns.Add("Surface");
                outputTable.Columns.Add("Governing Distress");
                outputTable.Columns.Add("Treatment");
                outputTable.Columns.Add("Cost");
                outputTable.Columns.Add("Area");
                outputTable.Columns.Add("RSL");
                outputTable.Columns.Add("Functional Classification");
                outputTable.Columns.Add("Notes");
                outputTable.Columns.Add("Survey Date");
                if (surfaceType == "")
                {
                    outputTable.Columns.Add("Fat/Spa/Pot");
                    outputTable.Columns.Add("Edg/Joi/Rut");
                    outputTable.Columns.Add("Lon/Cor/X-S");
                    outputTable.Columns.Add("Pat/Bro/Dra");
                    outputTable.Columns.Add("Pot/Fau/Dus");
                    outputTable.Columns.Add("Dra/Lon/Agg");
                    outputTable.Columns.Add("Tra/Tra/Cor");
                    outputTable.Columns.Add("Block/Crack");
                    outputTable.Columns.Add("Rutti/Patch");
                }
                if (surfaceType == "Asphalt")
                {
                    outputTable.Columns.Add("Fatigue");
                    outputTable.Columns.Add("Edge");
                    outputTable.Columns.Add("Longitudinal");
                    outputTable.Columns.Add("Patches");
                    outputTable.Columns.Add("Potholes");
                    outputTable.Columns.Add("Drainage");
                    outputTable.Columns.Add("Transverse");
                    outputTable.Columns.Add("Block");
                    outputTable.Columns.Add("Rutting");
                }
                if (surfaceType == "Concrete")
                {
                    outputTable.Columns.Add("Spalling");
                    outputTable.Columns.Add("Joint Seal");
                    outputTable.Columns.Add("Corners");
                    outputTable.Columns.Add("Broken");
                    outputTable.Columns.Add("Faulting");
                    outputTable.Columns.Add("Longitudinal");
                    outputTable.Columns.Add("Transverse");
                    outputTable.Columns.Add("Cracking");
                    outputTable.Columns.Add("Patches");
                }

                if (surfaceType == "Gravel")
                {
                    outputTable.Columns.Add("Potholes");
                    outputTable.Columns.Add("Rutting");
                    outputTable.Columns.Add("X-Section");
                    outputTable.Columns.Add("Drainage");
                    outputTable.Columns.Add("Dust");
                    outputTable.Columns.Add("Aggregate");
                    outputTable.Columns.Add("Corrugate");
                }

                FormOutput report = new FormOutput(Project);
                foreach (DataRow row in results.Rows)
                {
                    DataRow nr = outputTable.NewRow();
                    string note = row["notes"].ToString().Split(new[] { '\r', '\n' }).FirstOrDefault(); //retrive most recent note

                    int oldNoteLength = note.Length;
                    int maxLength = 17;
                    if (!string.IsNullOrEmpty(note))
                    {
                        note = note.Substring(0, Math.Min(oldNoteLength, maxLength));
                        if (note.Length == maxLength) note += "...";
                    }
                    double area = Util.ToDouble(row["width"].ToString()) * Util.ToDouble(row["length"].ToString());

                    nr["ID"] = row["TAMSID"];
                    nr["Name"] = row["name"];
                    nr["Speed Limit"] = row["speed_limit"];
                    nr["Lanes"] = row["lanes"];
                    nr["Width (ft)"] = row["width"];
                    nr["Length (ft)"] = row["length"];
                    nr["From Address"] = row["from_address"];
                    nr["To Address"] = row["to_address"];
                    nr["Surface"] = row["surface"];
                    nr["Area"] = area;
                    nr["RSL"] = row["rsl"];
                    nr["Functional Classification"] = row["type"];
                    nr["Notes"] = note;
                    nr["Survey Date"] = row["survey_date"];
                    if (surfaceType == "")
                    {
                        nr["Fat/Spa/Pot"] = row["distress1"];
                        nr["Edg/Joi/Rut"] = row["distress2"];
                        nr["Lon/Cor/X-S"] = row["distress3"];
                        nr["Pat/Bro/Dra"] = row["distress4"];
                        nr["Pot/Fau/Dus"] = row["distress5"];
                        nr["Dra/Lon/Agg"] = row["distress6"];
                        nr["Tra/Tra/Cor"] = row["distress7"];
                        nr["Block/Crack"] = row["distress8"];
                        nr["Rutti/Patch"] = row["distress9"];
                    }
                    if (surfaceType == "Asphalt")
                    {
                        nr["Fatigue"] = row["distress1"];
                        nr["Edge"] = row["distress2"];
                        nr["Longitudinal"] = row["distress3"];
                        nr["Patches"] = row["distress4"];
                        nr["Potholes"] = row["distress5"];
                        nr["Drainage"] = row["distress6"];
                        nr["Transverse"] = row["distress7"];
                        nr["Block"] = row["distress8"];
                        nr["Rutting"] = row["distress9"];
                    }
                    if (surfaceType == "Concrete")
                    {
                        nr["Spalling"] = row["distress1"];
                        nr["Joint Seal"] = row["distress2"];
                        nr["Corners"] = row["distress3"];
                        nr["Broken"] = row["distress4"];
                        nr["Faulting"] = row["distress5"];
                        nr["Longitudinal"] = row["distress6"];
                        nr["Transverse"] = row["distress7"];
                        nr["Cracking"] = row["distress8"];
                        nr["Patches"] = row["distress9"];
                    }

                    if (surfaceType == "Gravel")
                    {
                        nr["Potholes"] = row["distress1"];
                        nr["Rutting"] = row["distress2"];
                        nr["X-Section"] = row["distress3"];
                        nr["Drainage"] = row["distress4"];
                        nr["Dust"] = row["distress5"];
                        nr["Aggregate"] = row["distress6"];
                        nr["Corrugate"] = row["distress7"];
                    }

                    int[] dvs = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        dvs[i] = Util.ToInt(row["distress" + (i + 1).ToString()].ToString());
                    }
                    nr["Governing Distress"] = moduleRoads.getGoverningDistress(dvs, row["surface"].ToString());
                    nr["Cost"] = 0;
                    if (!row["suggested_treatment"].ToString().Contains("null") && !string.IsNullOrWhiteSpace(row["suggested_treatment"].ToString()))
                    {
                        nr["Treatment"] = row["suggested_treatment"];
                        string treatment = row["suggested_treatment"].ToString();

                        double treatmentCost = 0.0;
                        if (treatment == "Routine") treatmentCost = 0.56;
                        if (treatment == "Patching") treatmentCost = 0.67;
                        if (treatment == "Preventative") treatmentCost = 2.08;
                        if (treatment == "Preventative with Patching") treatmentCost = 2.75;
                        if (treatment == "Rehabilitation") treatmentCost = 9.57;
                        if (treatment == "Reconstruction") treatmentCost = 18.4;
                        try
                        {
                            if (treatmentCost == 0.0 && treatment != "Nothing")
                            {
                                DataTable tc = Database.GetDataByQuery(Project.conn, "SELECT cost FROM treatments " + "WHERE name LIKE '" + treatment + "';");
                                treatmentCost = Util.ToDouble(tc.Rows[0]["cost"].ToString());
                            }
                        }
                        catch (Exception err)
                        {
                            Log.Error("Problem getting data from database " + err.ToString());
                        }


                        double estCost = area * treatmentCost / 9;
                        if (estCost > 1000000)
                        {
                            nr["Cost"] = Math.Round(estCost / 1000000, 2).ToString() + "M";
                        }
                        else if (estCost > 1000)
                        {
                            nr["Cost"] = Math.Round(estCost / 1000).ToString() + "k";
                        }
                        else
                        {
                            nr["Cost"] = Math.Round(estCost).ToString();
                        }
                    }
                    outputTable.Rows.Add(nr);
                }
                report.dataGridViewReport.DataSource = outputTable;
                report.Text = "Treatment Report";
                report.Show();
            }
            tableFilters.Close();
        }

        public void reportSelected(object sender, EventArgs e)
        {
            DataTable general = new DataTable();
            general.Columns.Add("ID");
            general.Columns.Add("Name");
            general.Columns.Add("Speed Limit");
            general.Columns.Add("Lanes");
            general.Columns.Add("Width (ft)");
            general.Columns.Add("Length (ft)");
            general.Columns.Add("From Address");
            general.Columns.Add("To Address");
            general.Columns.Add("Surface");
            general.Columns.Add("Governing Distress");
            general.Columns.Add("Treatment");
            general.Columns.Add("Cost");
            general.Columns.Add("Area");
            general.Columns.Add("RSL");
            general.Columns.Add("Functional Classification");
            general.Columns.Add("Notes");
            general.Columns.Add("Survey Date");
            general.Columns.Add("Fat/Spa/Pot");
            general.Columns.Add("Edg/Joi/Rut");
            general.Columns.Add("Lon/Cor/X-S");
            general.Columns.Add("Pat/Bro/Dra");
            general.Columns.Add("Pot/Fau/Dus");
            general.Columns.Add("Dra/Lon/Agg");
            general.Columns.Add("Tra/Tra/Cor");
            general.Columns.Add("Block/Crack");
            general.Columns.Add("Rutti/Patch");
            FeatureLayer selectionLayer = (FeatureLayer)moduleRoads.Layer;
            ISelection shpSelection = selectionLayer.Selection;
            DataTable selectionTable = shpSelection.ToFeatureSet().DataTable;
            string thisSql = moduleRoads.SelectionSql.Replace("[[IDLIST]]", moduleRoads.extractTAMSIDs(selectionTable));
            try
            {
                DataTable selectedResultsTable = Database.GetDataByQuery(Project.conn, thisSql);
                double totalCost = 0;

                foreach (DataRow row in selectedResultsTable.Rows)
                {
                    double area = Util.ToDouble(row["width"].ToString()) * Util.ToDouble(row["length"].ToString());

                    DataRow nr = general.NewRow();
                    nr["ID"] = row["TAMSID"];
                    nr["Name"] = row["name"];
                    nr["Width (ft)"] = row["width"];
                    nr["Length (ft)"] = row["length"];
                    nr["From Address"] = row["from_address"];
                    nr["To Address"] = row["to_address"];
                    nr["Surface"] = row["surface"];
                    nr["RSL"] = row["rsl"];
                    nr["Functional Classification"] = row["type"];
                    nr["Notes"] = truncateNote(row);
                    nr["Survey Date"] = row["survey_date"];
                    nr["Fat/Spa/Pot"] = row["distress1"];
                    nr["Edg/Joi/Rut"] = row["distress2"];
                    nr["Lon/Cor/X-S"] = row["distress3"];
                    nr["Pat/Bro/Dra"] = row["distress4"];
                    nr["Pot/Fau/Dus"] = row["distress5"];
                    nr["Dra/Lon/Agg"] = row["distress6"];
                    nr["Tra/Tra/Cor"] = row["distress7"];
                    nr["Block/Crack"] = row["distress8"];
                    nr["Rutti/Patch"] = row["distress9"];
                    int[] dvs = new int[9];
                    for (int i = 0; i < 9; i++)
                    {
                        dvs[i] = Util.ToInt(row["distress" + (i + 1).ToString()].ToString());
                    }
                    nr["Governing Distress"] = moduleRoads.getGoverningDistress(dvs, row["surface"].ToString());
                    nr["Cost"] = 0;
                    if (!row["suggested_treatment"].ToString().Contains("null") && !string.IsNullOrWhiteSpace(row["suggested_treatment"].ToString()))
                    {
                        nr["Treatment"] = row["suggested_treatment"];
                        string treatment = row["suggested_treatment"].ToString();

                        double treatmentCost = 0.0;
                        if (treatment == "Routine") treatmentCost = 0.56;
                        if (treatment == "Patching") treatmentCost = 0.67;
                        if (treatment == "Preventative") treatmentCost = 2.08;
                        if (treatment == "Preventative with Patching") treatmentCost = 2.75;
                        if (treatment == "Rehabilitation") treatmentCost = 9.57;
                        if (treatment == "Reconstruction") treatmentCost = 18.4;
                        try
                        {
                            if (treatmentCost == 0.0 && treatment != "Nothing")
                            {
                                DataTable tc = Database.GetDataByQuery(Project.conn, "SELECT cost FROM treatments " + "WHERE name LIKE '" + treatment + "';");
                                treatmentCost = Util.ToDouble(tc.Rows[0]["cost"].ToString());
                            }
                        }
                        catch (Exception err)
                        {
                            Log.Error("Problem getting data from database " + err.ToString());
                        }


                        double estCost = area * treatmentCost / 9;
                        totalCost += estCost;
                        if (estCost > 1000000)
                        {
                            nr["Cost"] = Math.Round(estCost / 1000000, 2).ToString() + "M";
                        }
                        else if (estCost > 1000)
                        {
                            nr["Cost"] = Math.Round(estCost / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            nr["Cost"] = Math.Round(estCost).ToString();
                        }
                    }
                    nr["Area"] = area;
                    general.Rows.Add(nr);
                }
                general.DefaultView.Sort = "Name asc, Treatment asc, From Address asc";
                general = general.DefaultView.ToTable();
                DataRow totals = general.NewRow();
                totals["Surface"] = "Total";
                totals["Governing Distress"] = "Estimated";
                totals["Treatment"] = "Cost";
                if (totalCost > 1000000)
                {
                    totals["Cost"] = Math.Round(totalCost / 1000000, 2).ToString() + "M";
                }
                else if (totalCost > 1000)
                {
                    totals["Cost"] = Math.Round(totalCost / 1000).ToString() + "k";
                }
                else
                {
                    totals["Cost"] = Math.Round(totalCost).ToString();
                }
                general.Rows.Add(totals);
                reportTable = general.DefaultView.ToTable();
                FormOutput report = new FormOutput(Project);
                report.dataGridViewReport.DataSource = reportTable;
                report.Text = "Treatment Report";
                report.Show();
                report.FormClosing += updateChanges;
            }
            catch (Exception err)
            {
                Log.Error("Could not get database values for " + ModuleName + " module.\n" + err.ToString());
                MessageBox.Show("An error has occured while trying to consolidate data.");
            }
        }

        public void showHistory(object sender, EventArgs e)
        {
            FeatureLayer selectionLayer = (FeatureLayer)moduleRoads.Layer;
            ISelection shpSelection = selectionLayer.Selection;
            DataTable selectionTable = shpSelection.ToFeatureSet().DataTable;
            string histring = @"SELECT * FROM road WHERE TAMSID IN (" + moduleRoads.extractTAMSIDs(selectionTable) + ") ORDER BY TAMSID ASC, survey_date DESC;";
            try
            {
                DataTable history = Database.GetDataByQuery(Project.conn, histring);

                history.Columns["id"].ColumnName = "ID";
                history.Columns["survey_date"].ColumnName = "Survey Date";
                history.Columns["name"].ColumnName = "Name";
                history.Columns["speed_limit"].ColumnName = "Speed Limit";
                history.Columns["lanes"].ColumnName = "Lanes";
                history.Columns["width"].ColumnName = "Width";
                history.Columns["length"].ColumnName = "Length";
                history.Columns["surface"].ColumnName = "Surface";
                history.Columns["type"].ColumnName = "Functional Classification";
                history.Columns["from_address"].ColumnName = "From Address";
                history.Columns["to_address"].ColumnName = "To Address";
                history.Columns["photo"].ColumnName = "Photo";
                history.Columns["rsl"].ColumnName = "RSL";
                history.Columns["suggested_treatment"].ColumnName = "Suggested Treatment";
                history.Columns["notes"].ColumnName = "Notes";

                int surface_id = 0;
                string surface_type = history.Rows[0]["surface"].ToString();
                if (surface_type == "asphalt") surface_id = 1;
                if (surface_type == "gravel")
                {
                    surface_id = 2;
                    history.Columns.Remove("distress8");
                    history.Columns.Remove("distress9");
                }
                if (surface_type == "concrete") surface_id = 3;

                DataTable distresses = Database.GetDataByQuery(Project.conn, "SELECT name, dbkey FROM road_distresses WHERE surface_id = " + surface_id.ToString());
                for (int i = 0; i < distresses.Rows.Count; i++)
                {
                    string distressNumber = distresses.Rows[i]["dbkey"].ToString();
                    history.Columns[distressNumber].ColumnName = distresses.Rows[i]["name"].ToString();
                }

                reportTable = history.DefaultView.ToTable();
                FormOutput histForm = new FormOutput(Project);
                histForm.Text = "Road History";
                histForm.dataGridViewReport.DataSource = history;
                histForm.Show();
            }
            catch (Exception err)
            {
                Log.Error("Malformed request " + err.ToString());
                MessageBox.Show("An error occured when attempting to show history. Roads Database may be corrupted.");
            }
        }

        private void updateChanges(object sender, EventArgs e)
        {
            FeatureLayer selectionLayer = (FeatureLayer)moduleRoads.Layer;
            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");
            string tamsidsCSV = string.Join(",", moduleRoads.tamsids.ToArray());

            foreach (DataRow row in selectionLayer.DataSet.DataTable.Select(tamsidcolumn + " IN (" + tamsidsCSV + ")"))
            {
                foreach (DataRow r in reportTable.Rows)
                {
                    int x, y;
                    Int32.TryParse(r["ID"].ToString(), out x);
                    Int32.TryParse(row["TAMS_ID"].ToString(), out y);
                    if (x == y)
                    {
                        row["TAMSROADRSL"] = r["RSL"];
                        row["TAMSTREATMENT"] = r["Treatment"];
                    }
                }
            }

            selectionLayer.ClearSelection();
            moduleRoads.symbols.setSymbolizer();
            Project.map.Invalidate();
            Project.map.Refresh();
            Project.map.ResetBuffer();
            Project.map.Update();
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
    }
}
