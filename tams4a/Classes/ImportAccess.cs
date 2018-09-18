using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Globalization;
using System.Data;

namespace tams4a.Classes
{
    static class ImportAccess
    {
        public static void importAccessDBRoads(SQLiteConnection conn, string type="")
        {
            try
            {
                MessageBox.Show("This tool will import road data generated from older versions of tams. Supported Databases versions are 2.2.6 and 3.0.0.2, We can attempt to import other versions, but there is no gaurantee of success.");

                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Filter = "MicroSoft Access DataBase|*.mdb";
                openDialog.Multiselect = false;

                string prettyType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(type);
                if (prettyType != "") { prettyType += " "; } 

                openDialog.Title = "Open " + prettyType + "mdb File";
                DialogResult openDialogResult = openDialog.ShowDialog();

                Cursor.Current = Cursors.WaitCursor;

                OleDbConnection access = new OleDbConnection();
                access.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +openDialog.FileName+";" +
                                "Jet OLEDB:Database Password=crazyltap1";
                access.Open();
                OleDbCommand command = new OleDbCommand("SELECT tblLocation.*, tblPavePicts.Name FROM tblLocation LEFT JOIN tblPavePicts ON tblLocation.Seg_ID = tblPavePicts.Seg_ID;");
                command.Connection = access;

                DataTable dt = new DataTable();
                bool v2_2_6 = true;
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                try
                {
                    adapter.Fill(dt);
                }
                catch (OleDbException oe)
                {
                    v2_2_6 = false;
                }
                
                if (v2_2_6)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        Dictionary<string, string> values = new Dictionary<string, string>();
                        values["TAMSID"] = r["Seg_ID"].ToString();
                        values["survey_date"] = DateTime.ParseExact(r["Date_Of_Last_Survey"].ToString().Split(' ')[0], "m/d/yyyy", CultureInfo.CurrentUICulture, DateTimeStyles.None).ToString("yyyy-mm-dd");
                        values["surface"] = r["Surface_Type"].ToString();
                        values["type"] = r["Functional_Class"].ToString();
                        values["from_address"] = r["From_Address"].ToString();
                        values["to_address"] = r["To_Address"].ToString();
                        values["speed_limit"] = r["Speed_Limit"].ToString().Split(' ')[0];
                        values["lanes"] = r["Number_Of_Lanes"].ToString();
                        values["width"] = r["Seg_Width"].ToString();
                        values["length"] = r["Seg_Length"].ToString();
                        values["name"] = r["Road_Name"].ToString();
                        values["rsl"] = r["RSL"].ToString();
                        values["photo"] = r["Name"].ToString();

                        if (values["surface"].ToLower().Contains("asphalt"))
                        {
                            values["surface"] = "asphalt";
                            values["distress1"] = r["Fat_Spall_XSec"].ToString();
                            values["distress2"] = r["Edge_Broke_Pot"].ToString();
                            values["distress3"] = r["Lon_Joint_Drain"].ToString();
                            values["distress4"] = r["Pot_Fault_LAggr"].ToString();
                            values["distress5"] = "0";
                            values["distress6"] = r["Drain_Patch"].ToString();
                            values["distress7"] = r["Tran_Corner_Rutt"].ToString();
                            values["distress8"] = r["Block_Crack"].ToString();
                            values["distress9"] = r["Rutt_Lon_Dust"].ToString();
                        }
                        else if (values["surface"].ToLower().Contains("gravel") || values["surface"].ToLower().Contains("unpaved"))
                        {
                            values["surface"] = "gravel";
                            values["distress1"] = r["Edge_Broke_Pot"].ToString();
                            values["distress2"] = r["Tran_Corner_Rutt"].ToString();
                            values["distress3"] = r["Fat_Spall_XSec"].ToString();
                            values["distress4"] = r["Lon_Joint_Drain"].ToString();
                            values["distress5"] = r["Rutt_Lon_Dust"].ToString();
                            values["distress6"] = r["Pot_Fault_LAggr"].ToString();
                            values["distress7"] = r["Rough_Tran_Corr"].ToString();
                        }
                        else if (values["surface"].ToLower().Contains("concrete"))
                        {
                            values["surface"] = "concrete";
                            values["distress1"] = r["Fat_Spall_XSec"].ToString();
                            values["distress2"] = r["Lon_Joint_Drain"].ToString();
                            values["distress3"] = r["Tran_Corner_Rutt"].ToString();
                            values["distress4"] = r["Edge_Broke_Pot"].ToString(); ;
                            values["distress5"] = r["Pot_Fault_LAggr"].ToString();
                            values["distress6"] = r["Rutt_Lon_Dust"].ToString();
                            values["distress7"] = r["Rough_Tran_Corr"].ToString();
                            values["distress8"] = r["Block_Crack"].ToString();
                            values["distress9"] = r["Drain_Patch"].ToString();
                        }

                        Database.InsertRow(conn, values, "road");
                    }
                }
                else
                {
                    command = new OleDbCommand(@"SELECT Inventory.*, InventoryHistory.DistressValues, InventoryHistory.RSL
                                FROM Inventory INNER JOIN InventoryHistory ON Inventory.SegmentID = InventoryHistory.SegmentID;", access);
                    adapter.SelectCommand = command;
                    adapter.Fill(dt);
                    

                    foreach (DataRow r in dt.Rows)
                    {
                        Dictionary<string, string> values = new Dictionary<string, string>();
                        values["TAMSID"] = r["SegmentID"].ToString();
                        values["survey_date"] = DateTime.ParseExact(r["InputDate"].ToString().Split(' ')[0], "m/d/yyyy", CultureInfo.CurrentUICulture, DateTimeStyles.None).ToString("yyyy-mm-dd");
                        values["name"] = r["RoadName"].ToString();
                        values["lanes"] = r["TravelLanes"].ToString();
                        values["width"] = r["RoadWidth"].ToString();
                        values["length"] = r["SegmentLength"].ToString();
                        values["from_address"] = r["FromAddress"].ToString();
                        values["to_address"] = r["ToAddress"].ToString();
                        values["rsl"] = r["RSL"].ToString();
                        int sl;
                        int.TryParse(r["SpeedLimit_ID"].ToString(), out sl); sl = sl * 5;
                        values["speed_limit"] = sl.ToString();
                        int fc;
                        int.TryParse(r["FunctionalClass_ID"].ToString(), out fc);
                        if (fc == 1)
                        {
                            values["type"] = "residential";
                        }
                        else if (fc == 2)
                        {
                            values["type"] = "minor collector";
                        }
                        else if (fc == 3)
                        {
                            values["type"] = "minor arterial";
                        }
                        else if (fc == 4)
                        {
                            values["type"] = "major collector";
                        }
                        else if (fc == 5)
                        {
                            values["type"] = "major arterial";
                        }
                        else if (fc == 6) {
                            values["type"] = "other";
                        }
                        int st;
                        int.TryParse(r["SurfaceType_ID"].ToString(), out st);
                        if (st == 1)
                        {
                            values["surface"] = "asphalt";
                            string[] dvs = r["DistressValues"].ToString().Split('#');
                            for (int i = 0; i < dvs.Length; i++)
                            {
                                values["distress" + (i+1).ToString()] = dvs[i];
                                if (i >= 8)
                                {
                                    break;
                                }
                            }
                        }
                        else if (st == 4)
                        {
                            values["surface"] = "gravel";
                            string[] dvs = r["DistressValues"].ToString().Split('#');
                            for (int i = 0; i < dvs.Length; i++)
                            {
                                values["distress" + (i+1).ToString()] = dvs[i];
                                if (i >= 8)
                                {
                                    break;
                                }
                            }
                        }
                        else if (st == 6)
                        {
                            values["surface"] = "concrete";
                            string[] dvs = r["DistressValues"].ToString().Split('#');
                            for (int i = 0; i < dvs.Length; i++)
                            {
                                values["distress" + (i + 1).ToString()] = dvs[i];
                                if (i >= 8)
                                {
                                    break;
                                }
                            }
                        }
                        Database.InsertRow(conn, values, "road");
                    }
                }

                access.Close();

            } catch (Exception e)
            {
                Log.Error("Could not import TAMS data\n" + e.ToString());
                Cursor.Current = Cursors.Arrow;
                MessageBox.Show("Could not import the data from the provided file.");
            }
            Cursor.Current = Cursors.Arrow;
        }
    }
}
