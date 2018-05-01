using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO: Change this to an instantiated class.  Make it a member of the tamsproject class.
namespace tams4a.Classes
{
    public static class Database
    {
        // is database connected?
        public static Boolean IsOpen(SQLiteConnection conn)
        {
            if (    (conn != null) &&
                    (conn.State == ConnectionState.Open)
                )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Database schema needs to be tightly controlled, not all features would necisarily be used, modules should still be modular.
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static Boolean UpdateDatabase(SQLiteConnection conn)
        {
            int dbVersion;
            try
            {
                var dt = GetDataByQuery(conn, "SELECT version FROM db_version");
                dbVersion = int.Parse(dt.Rows[0]["version"].ToString());
            }
            catch (Exception e)
            {
                string cmdString = @"CREATE TABLE db_version (version INTEGER PRIMARY KEY NOT NULL, warning TEXT NOT NULL);
                                        INSERT INTO db_version (version, warning) VALUES (0, 'DO_NOT_MODIFY');";
                SQLiteCommand cmd = new SQLiteCommand(cmdString, conn);
                cmd.ExecuteNonQuery();
                dbVersion = 0;
            }
            #region db_update_1_immute
            if (dbVersion == 0)
            {
                try
                {
                    Dictionary<string, string> ct  = new Dictionary<string, string>()
                    {
                        #region fields
                        { "id", "INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE" },
                        { "TAMSID", "INTEGER NOT NULL" },
                        { "survey_date", "TEXT" },
                        { "name", "TEXT" },
                        { "speed_limit", "INTEGER" },
                        { "lanes", "INTEGER" },
                        { "width", "NUMERIC" },
                        { "length", "NUMERIC" },
                        { "type", "TEXT" },
                        { "surface", "TEXT" },
                        { "from_address", "TEXT" },
                        { "to_address", "TEXT" },
                        { "photo", "TEXT" },
                        { "distress1", "INTEGER" },
                        { "distress2", "INTEGER" },
                        { "distress3", "INTEGER" },
                        { "distress4", "INTEGER" },
                        { "distress5", "INTEGER" },
                        { "distress6", "INTEGER" },
                        { "distress7", "INTEGER" },
                        { "distress8", "INTEGER" },
                        { "distress9", "INTEGER" },
                        { "rsl", "INTEGER" },
                        { "suggested_treatment", "TEXT" },
                        { "notes", "TEXT" }
                        #endregion fields
                    };
                    string cmdString = @"CREATE TABLE road (";
                    foreach (string key in ct.Keys)
                    {
                        cmdString = cmdString + key + " " + ct[key] + ", ";
                    }
                    cmdString = cmdString.Substring(0, cmdString.Length - 2) + ");";
                    SQLiteCommand cmd = new SQLiteCommand(cmdString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Dictionary<string, string> ct = new Dictionary<string, string>()
                    {
                        #region fields
                        { "id", "INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE" },
                        { "TAMSID", "INTEGER NOT NULL" },
                        { "survey_date", "TEXT" },
                        { "name", "TEXT" },
                        { "speed_limit", "INTEGER" },
                        { "lanes", "INTEGER" },
                        { "width", "NUMERIC" },
                        { "length", "NUMERIC" },
                        { "type", "TEXT" },
                        { "surface", "TEXT" },
                        { "from_address", "TEXT" },
                        { "to_address", "TEXT" },
                        { "photo", "TEXT" },
                        { "distress1", "INTEGER" },
                        { "distress2", "INTEGER" },
                        { "distress3", "INTEGER" },
                        { "distress4", "INTEGER" },
                        { "distress5", "INTEGER" },
                        { "distress6", "INTEGER" },
                        { "distress7", "INTEGER" },
                        { "distress8", "INTEGER" },
                        { "distress9", "INTEGER" },
                        { "rsl", "INTEGER" },
                        { "suggested_treatment", "TEXT" },
                        { "notes", "TEXT" }
                        #endregion fields
                    };
                    string cmdString = @"BEGIN TRANSACTION; 
                                ALTER TABLE road RENAME TO temp;
                                CREATE TABLE road (";
                    foreach (string key in ct.Keys)
                    {
                        cmdString = cmdString + key + " " + ct[key] + ", ";
                    }
                    cmdString = cmdString.Substring(0, cmdString.Length - 2) + @");
                                INSERT INTO road
                                SELECT
                                    id, TAMSID, survey_date, name, speed_limit, lanes, width, length, type, surface, NULL, NULL, photo, distress1, distress2, distress3, distress4, distress5, distress6, distress7, distress8, distress9, rsl, NULL, notes
                                FROM
                                    temp;
                                DROP TABLE temp;
                                COMMIT;";
                    SQLiteCommand cmd = new SQLiteCommand(cmdString, conn);
                    cmd.ExecuteNonQuery();
                }
                try
                {
                    string cmdString = @"CREATE TABLE treatments (
                                id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
                                name TEXT,
                                category TEXT,
                                road_applied TEXT,
                                cost NUMERIC
                            );
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Crack Seal', 'routine', 'asphalt', 0.45);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Cold Patch', 'routine', 'asphalt', 0.45);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Digout and Hot Patch', 'routine', 'asphalt', 0.68);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('High Performance Cold Patch', 'routine', 'asphalt', 0.9);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Fog Coat', 'routine', 'asphalt', 0.68);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('High Mineral Asphalt Emulsion', 'preventative', 'asphalt', 1.8);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Sand Seal', 'preventative', 'asphalt', 0.98);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Scrub Seal', 'preventative', 'asphalt', 1.5);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Single Chip Seal', 'preventative', 'asphalt', 1.95);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Slurry Seal', 'preventative', 'asphalt', 2.63);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Microsurfacing', 'preventative', 'asphalt', 3.6);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Plant Seal Mix', 'rehabilitation', 'asphalt', 8.4);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Cold In-Place Recycling (2 in. with Chip Seal)', 'rehabilitation', 'asphalt', 7.5);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Thin Hot Overlay <2 in.', 'rehabilitation', 'asphalt', 10.13);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('HMA (leveling) and Thin Overlay', 'rehabilitation', 'asphalt', 11.25);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Hot Surface Recycling', 'rehabilitation', 'asphalt', 7.5);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Rotomill and Thin Overlay', 'rehabilitation', 'asphalt', 12.6);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Cold In Place Recycling (2 in. with Thin Overlay)', 'reconstruction', 'asphalt', 15.45);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Thick Overlay (3 in.)', 'reconstruction', 'asphalt', 15.0);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Rotomill and Thick Overlay', 'reconstruction', 'asphalt', 16.5);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Base Repair and Pavement Replacement', 'reconstruction', 'asphalt', 16.73);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Full Depth Reclamation and Overlay', 'reconstruction', 'asphalt', 19.88);
                            INSERT INTO treatments (name, category, road_applied, cost) VALUES ('Base and Pavement Replacement', 'reconstruction', 'asphalt', 28.5);";

                    SQLiteCommand cmd = new SQLiteCommand(cmdString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Error("Failed to update database, check database schema: " + e.ToString());
                    MessageBox.Show("The database could not be updated to the latest version of TAMS please contact the Utah LTAP Center for help.");
                    return false;
                }
                #region newrows1
                InsertRow(conn, new Dictionary<string, string>(){
                        { "name", "concrete" },
                        { "max_rsl", "20"}
                    }, "road_surfaces");
                InsertRow(conn, new Dictionary<string, string>()
                {
                    { "surface_id", "3" },
                    { "name", "Spalling" },
                    { "dbkey", "distress1" },
                    { "description", "Damage at seams that cause concrete to flake off." },
                    { "max_distress", "9" },
                    { "imageName",  "NULL"},
                    { "rsl1", "15" },
                    { "rsl2", "12" },
                    { "rsl3", "10" },
                    { "rsl4", "12" },
                    { "rsl5", "10" },
                    { "rsl6", "8" },
                    { "rsl7", "12" },
                    { "rsl8", "6" },
                    { "rsl9", "0" }
                }, "road_distresses");
                InsertRow(conn, new Dictionary<string, string>()
                {
                    { "surface_id", "3" },
                    { "name", "Joint Seal" },
                    { "dbkey", "distress2" },
                    { "description", "Corrosion of joint seal material." },
                    { "max_distress", "9" },
                    { "imageName",  "NULL"},
                    { "rsl1", "16" },
                    { "rsl2", "14" },
                    { "rsl3", "12" },
                    { "rsl4", "14" },
                    { "rsl5", "10" },
                    { "rsl6", "8" },
                    { "rsl7", "12" },
                    { "rsl8", "8" },
                    { "rsl9", "6" }
                }, "road_distresses");
                InsertRow(conn, new Dictionary<string, string>()
                {
                    { "surface_id", "3" },
                    { "name", "Corners" },
                    { "dbkey", "distress3" },
                    { "description", "Breaks near the corner of block." },
                    { "max_distress", "9" },
                    { "imageName",  "NULL"},
                    { "rsl1", "15" },
                    { "rsl2", "14" },
                    { "rsl3", "12" },
                    { "rsl4", "12" },
                    { "rsl5", "10" },
                    { "rsl6", "6" },
                    { "rsl7", "8" },
                    { "rsl8", "4" },
                    { "rsl9", "0" }
                }, "road_distresses");
                InsertRow(conn, new Dictionary<string, string>()
                {
                    { "surface_id", "3" },
                    { "name", "Broken" },
                    { "dbkey", "distress4" },
                    { "description", "Slabs that have split entirely." },
                    { "max_distress", "9" },
                    { "imageName",  "NULL"},
                    { "rsl1", "15" },
                    { "rsl2", "14" },
                    { "rsl3", "12" },
                    { "rsl4", "12" },
                    { "rsl5", "10" },
                    { "rsl6", "8" },
                    { "rsl7", "10" },
                    { "rsl8", "6" },
                    { "rsl9", "0" }
                }, "road_distresses");
                InsertRow(conn, new Dictionary<string, string>()
                {
                    { "surface_id", "3" },
                    { "name", "Faulting" },
                    { "dbkey", "distress5" },
                    { "description", "Vertical gap between slabs of concrete." },
                    { "max_distress", "9" },
                    { "imageName",  "NULL"},
                    { "rsl1", "15" },
                    { "rsl2", "12" },
                    { "rsl3", "10" },
                    { "rsl4", "12" },
                    { "rsl5", "8" },
                    { "rsl6", "6" },
                    { "rsl7", "10" },
                    { "rsl8", "4" },
                    { "rsl9", "0" }
                }, "road_distresses");
                InsertRow(conn, new Dictionary<string, string>()
                {
                    { "surface_id", "3" },
                    { "name", "Longitudinal" },
                    { "dbkey", "distress6" },
                    { "description", "Large cracks running parallel to traffic." },
                    { "max_distress", "9" },
                    { "imageName",  "NULL"},
                    { "rsl1", "18" },
                    { "rsl2", "15" },
                    { "rsl3", "12" },
                    { "rsl4", "15" },
                    { "rsl5", "10" },
                    { "rsl6", "6" },
                    { "rsl7", "10" },
                    { "rsl8", "4" },
                    { "rsl9", "0" }
                }, "road_distresses");
                InsertRow(conn, new Dictionary<string, string>()
                {
                    { "surface_id", "3" },
                    { "name", "Transverse" },
                    { "dbkey", "distress7" },
                    { "description", "Large cracks perpendicular to traffic." },
                    { "max_distress", "9" },
                    { "imageName",  "NULL"},
                    { "rsl1", "18" },
                    { "rsl2", "15" },
                    { "rsl3", "12" },
                    { "rsl4", "15" },
                    { "rsl5", "10" },
                    { "rsl6", "6" },
                    { "rsl7", "10" },
                    { "rsl8", "6" },
                    { "rsl9", "2" }
                }, "road_distresses");
                InsertRow(conn, new Dictionary<string, string>()
                {
                    { "surface_id", "3" },
                    { "name", "Cracking" },
                    { "dbkey", "distress8" },
                    { "description", "Small interconnected cracks in concrete." },
                    { "max_distress", "9" },
                    { "imageName",  "NULL"},
                    { "rsl1", "18" },
                    { "rsl2", "15" },
                    { "rsl3", "12" },
                    { "rsl4", "15" },
                    { "rsl5", "10" },
                    { "rsl6", "6" },
                    { "rsl7", "10" },
                    { "rsl8", "4" },
                    { "rsl9", "0" }
                }, "road_distresses");
                InsertRow(conn, new Dictionary<string, string>()
                {
                    { "surface_id", "3" },
                    { "name", "Patches" },
                    { "dbkey", "distress9" },
                    { "description", "Deteriation of patches made to concrete." },
                    { "max_distress", "9" },
                    { "imageName",  "NULL"},
                    { "rsl1", "16" },
                    { "rsl2", "14" },
                    { "rsl3", "12" },
                    { "rsl4", "12" },
                    { "rsl5", "10" },
                    { "rsl6", "8" },
                    { "rsl7", "10" },
                    { "rsl8", "6" },
                    { "rsl9", "0" }
                }, "road_distresses");
                #endregion newrows1
                Dictionary<string, string> updateDb = new Dictionary<string, string>();
                UpdateRow(conn, new Dictionary<string, string>() { { "rsl6", "8" } }, "road_distresses", "name", "'Block'");
                dbVersion = 1;
                updateDb["version"] = "1";
                Database.UpdateRow(conn, updateDb, "db_version", "warning", "'DO_NOT_MODIFY'");
            }
            #endregion db_update_1_immute
            #region db_update_2_immute
            if (dbVersion == 1)
            {
                try
                {
                    string cmdString = @"REPLACE INTO treatments (name, category, road_applied, cost) VALUES ('Cold Recyling and Thick Overlay', 'reconstruction', 'asphalt', 16.73);
REPLACE INTO road_distresses (id, surface_id, name, dbkey, description, max_distress, imageName, rsl1, rsl2, rsl3, rsl4, rsl5, rsl6, rsl7, rsl8, rsl9, notes) VALUES (5, 1, 'Potholes', 'distress5', 'Potholes are holes of various sizes in pavement surface.', 9, 'potholes', 16, 10, 4, 12, 7, 2, 10, 4, 0, NULL);

ALTER TABLE treatments ADD COLUMN min_rsl INTEGER;
ALTER TABLE treatments ADD COLUMN max_rsl INTEGER;
ALTER TABLE treatments ADD COLUMN average_boost INTEGER;

UPDATE road_distresses SET imageName = 'conlong' WHERE (name = 'Longitudinal' AND surface_id = 3);
UPDATE road_distresses SET imageName = 'contrans' WHERE (name = 'Transverse' AND surface_id = 3);
UPDATE road_distresses SET imageName = 'mapcrack' WHERE (name = 'Cracking' AND surface_id = 3);
UPDATE road_distresses SET imageName = 'corner' WHERE (name = 'Corners' AND surface_id = 3);
UPDATE road_distresses SET imageName = 'spalling' WHERE (name = 'Spalling' AND surface_id = 3);

UPDATE treatments SET min_rsl = 13, max_rsl = 19, average_boost = 2 WHERE name = 'Crack Seal';
UPDATE treatments SET min_rsl = 10, max_rsl = 18, average_boost = 1 WHERE name = 'Digout and Hot Patch';
UPDATE treatments SET min_rsl = 10, max_rsl = 18, average_boost = 0 WHERE name = 'Cold Patch';
UPDATE treatments SET min_rsl = 10, max_rsl = 18, average_boost = 0 WHERE name = 'High Performance Cold Patch';
UPDATE treatments SET min_rsl = 12, max_rsl = 19, average_boost = 2 WHERE name = 'Fog Coat';
UPDATE treatments SET min_rsl = 10, max_rsl = 17, average_boost = 3 WHERE name = 'High Mineral Asphalt Emulsion';
UPDATE treatments SET min_rsl = 10, max_rsl = 17, average_boost = 2 WHERE name = 'Sand Seal';
UPDATE treatments SET min_rsl = 6, max_rsl = 16, average_boost = 4 WHERE name = 'Single Chip Seal';
UPDATE treatments SET min_rsl = 6, max_rsl = 16, average_boost = 4 WHERE name = 'Slurry Seal';
UPDATE treatments SET min_rsl = 8, max_rsl = 16, average_boost = 3 WHERE name = 'Scrub Seal';
UPDATE treatments SET min_rsl = 6, max_rsl = 15, average_boost = 5 WHERE name = 'Microsurfacing';
UPDATE treatments SET min_rsl = 5, max_rsl = 14, average_boost = 5 WHERE name = 'Plant Seal Mix';
UPDATE treatments SET min_rsl = 5, max_rsl = 14, average_boost = 6 WHERE name = 'Cold In-Place Recycling (2 in. with Chip Seal)';
UPDATE treatments SET min_rsl = 4, max_rsl = 13, average_boost = 7 WHERE name = 'Thin Hot Overlay <2 in.';
UPDATE treatments SET min_rsl = 4, max_rsl = 13, average_boost = 8 WHERE name = 'HMA (leveling) and Thin Overlay';
UPDATE treatments SET min_rsl = 4, max_rsl = 12, average_boost = 8 WHERE name = 'Hot Surface Recycling';
UPDATE treatments SET min_rsl = 4, max_rsl = 12, average_boost = 8 WHERE name = 'Rotomill and Thin Overlay';
UPDATE treatments SET min_rsl = 2, max_rsl = 6, average_boost = 15 WHERE name = 'Cold In Place Recycling (2 in. with Thin Overlay)';
UPDATE treatments SET min_rsl = 2, max_rsl = 8, average_boost = 12 WHERE name = 'Thick Overlay (3 in.)';
UPDATE treatments SET min_rsl = 2, max_rsl = 8, average_boost = 12 WHERE name = 'Rotomill and Thick Overlay';
UPDATE treatments SET min_rsl = 0, max_rsl = 4, average_boost = 16 WHERE name = 'Base Repair and Pavement Replacement';
UPDATE treatments SET min_rsl = 1, max_rsl = 6, average_boost = 14 WHERE name = 'Cold Recyling and Thick Overlay';
UPDATE treatments SET min_rsl = 0, max_rsl = 1, average_boost = 20 WHERE name = 'Full Depth Reclamation and Overlay';
UPDATE treatments SET min_rsl = 0, max_rsl = 0, average_boost = 20 WHERE name = 'Base and Pavement Replacement';";
                    SQLiteCommand cmd = new SQLiteCommand(cmdString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Error("Failed to update database, check database schema: " + e.ToString());
                    MessageBox.Show("The database could not be updated to the latest version of TAMS please contact the Utah LTAP Center for help.");
                    return false;
                }
                Dictionary<string, string> updateDb = new Dictionary<string, string>();
                updateDb["version"] = "2";
                dbVersion = 2;
                Database.UpdateRow(conn, updateDb, "db_version", "warning", "'DO_NOT_MODIFY'");
            }
            #endregion db_update_2_immute
            #region db_update_3_immute
            if (dbVersion == 2)
            {
                try
                {
                    string cmdString = @"UPDATE treatments SET category = 'patch' WHERE name = 'Digout and Hot Patch';
UPDATE treatments SET category = 'patch' WHERE name = 'Cold Patch';
UPDATE treatments SET category = 'patch' WHERE name = 'High Performance Cold Patch';
UPDATE treatments SET average_boost = 5 where name = 'Single Chip Seal';
UPDATE treatments SET average_boost = 4 where name = 'Scrub Seal';
UPDATE road_distresses set rsl1 = 16, rsl2 = 16, rsl3 = 16, rsl4 = 16, rsl5 = 16, rsl6 = 16, rsl7 = 16, rsl8 = 16, rsl9 = 16 WHERE name = 'Potholes';
UPDATE road_distresses set rsl6 = 8 WHERE name = 'Block';
CREATE TABLE sign(ID INTEGER PRIMARY KEY AUTOINCREMENT, TAMSID INTEGER, sheeting TEXT, backing TEXT, width NUMERIC, height NUMERIC, mount_height NUMERIC, type TEXT, sign_text TEXT, photo TEXT, obstructions TEXT, reflectivity TEXT, condition TEXT, install_date TEXT, survey_date TEXT, direction TEXT, support_id INTEGER);
CREATE TABLE sign_support(ID INTEGER PRIMARY KEY AUTOINCREMENT, support_id INTEGER, material TEXT, condition TEXT, address TEXT, road_offset NUMERIC, height NUMERIC, survey_date TEXT);";
                    SQLiteCommand cmd = new SQLiteCommand(cmdString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Error("Failed to update database, check database schema: " + e.ToString());
                    MessageBox.Show("The database could not be updated to the latest version of TAMS please contact the Utah LTAP Center for help.");
                    return false;
                }
                Dictionary<string, string> updateDb = new Dictionary<string, string>();
                updateDb["version"] = "3";
                dbVersion = 3;
                Database.UpdateRow(conn, updateDb, "db_version", "warning", "'DO_NOT_MODIFY'");
            }
            #endregion db_update_3_immute
            #region db_update_4_immute
            if (dbVersion == 3)
            {
                try
                {
                    string cmdString = @"CREATE TABLE support_materials (id INTEGER PRIMARY KEY AUTOINCREMENT, material);
INSERT INTO support_materials (material) VALUES ('wood');
INSERT INTO support_materials (material) VALUES ('U-Channel post');
INSERT INTO support_materials (material) VALUES ('square steel tube');
INSERT INTO support_materials (material) VALUES ('I-Beam');
CREATE TABLE sign_backing (id INTEGER PRIMARY KEY AUTOINCREMENT, material TEXT, life INTEGER);
INSERT INTO sign_backing (material, life) VALUES ('aluminum', 15);
INSERT INTO sign_backing (material, life) VALUES ('wood', 6);
INSERT INTO sign_backing (material, life) VALUES ('plastic', 8);
INSERT INTO sign_backing (material, life) VALUES ('composite', 15);
CREATE TABLE sign_sheeting (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, type TEXT, life INTEGER);
INSERT INTO sign_sheeting (name, type, life) VALUES ('eng. grade', 'I', 7);
INSERT INTO sign_sheeting (name, type, life) VALUES ('super eng. grade', 'II', 10);
INSERT INTO sign_sheeting (name, type, life) VALUES ('high int.', 'III', 10);
INSERT INTO sign_sheeting (name, type, life) VALUES ('', 'IV', 10);
INSERT INTO sign_sheeting (name, type, life) VALUES ('', 'V', 5);
INSERT INTO sign_sheeting (name, type, life) VALUES ('', 'VI', 2);
INSERT INTO sign_sheeting (name, type, life) VALUES ('', 'VII', 10);
INSERT INTO sign_sheeting (name, type, life) VALUES ('', 'VIII', 10);
INSERT INTO sign_sheeting (name, type, life) VALUES ('', 'IX', 10);
INSERT INTO sign_sheeting (name, type, life) VALUES ('', 'X', 10);
INSERT INTO sign_sheeting (name, type, life) VALUES ('', 'XI', 12);";
                    SQLiteCommand cmd = new SQLiteCommand(cmdString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Error("Failed to update database, check database schema: " + e.ToString());
                    MessageBox.Show("The database could not be updated to the latest version of TAMS please contact the Utah LTAP Center for help.");
                    return false;
                }
                Dictionary<string, string> updateDb = new Dictionary<string, string>();
                updateDb["version"] = "4";
                dbVersion = 4;
                Database.UpdateRow(conn, updateDb, "db_version", "warning", "'DO_NOT_MODIFY'");
            }
            #endregion db_update_4_immute
            #region db_update_5_immute
            if (dbVersion == 4)
            {
                try
                {
                    string cmdString = @"DROP TABLE sign;
DROP TABLE sign_support;
CREATE TABLE sign (TAMSID INTEGER PRIMARY KEY, sheeting TEXT, backing TEXT, width NUMERIC, height NUMERIC, mount_height NUMERIC, mutcd_code TEXT, description TEXT, sign_text TEXT, photo TEXT, obstructions TEXT, reflectivity NUMERIC, condition TEXT, install_date TEXT, survey_date TEXT, direction TEXT, support_id INTEGER, category TEXT, lighted TEXT, notes TEXT);
CREATE TABLE sign_support (support_id INTEGER PRIMARY KEY, material TEXT, condition TEXT, address TEXT, road_offset NUMERIC, height NUMERIC, survey_date TEXT, category TEXT);
CREATE TABLE mutcd_lookup (mutcd_code TEXT PRIMARY KEY, description TEXT, sign_text TEXT, category TEXT);";
                    DataTable mutcdDat = Util.CSVtoDataTable(Properties.Resources.mutcd_remastered);
                    SQLiteCommand cmd = new SQLiteCommand(cmdString, conn);
                    cmd.ExecuteNonQuery();
                    var liteAdapter = new SQLiteDataAdapter("SELECT * FROM mutcd_lookup", conn);
                    var cmdBUilder = new SQLiteCommandBuilder(liteAdapter);
                    liteAdapter.Update(mutcdDat);
                }
                catch (Exception e)
                {
                    Log.Error("Failed to update database, check database schema: " + e.ToString());
                    MessageBox.Show("The database could not be updated to the latest version of TAMS please contact the Utah LTAP Center for help.");
                    return false;
                }
                Dictionary<string, string> updateDb = new Dictionary<string, string>();
                updateDb["version"] = "5";
                dbVersion = 5;
                Database.UpdateRow(conn, updateDb, "db_version", "warning", "'DO_NOT_MODIFY'");
            }
            #endregion db_update_5_immute
            #region db_update_6_immute
            if (dbVersion == 5)
            {
                try
                {
                    string cmdString = @"UPDATE road_distresses SET imageName='jointseal' WHERE name='Joint Seal';
UPDATE road_distresses SET imageName = 'broke' WHERE name = 'Broken';
UPDATE road_distresses SET imageName = 'fault' WHERE name = 'Faulting';
ALTER TABLE sign_support ADD notes TEXT;
ALTER TABLE sign ADD barcode TEXT;
ALTER TABLE sign ADD favorite TEXT;
UPDATE mutcd_lookup SET category = 'regulatory_rw' WHERE category = 'reguatory_rw';
UPDATE mutcd_lookup SET category = 'regulatory_bw' WHERE category = 'reguatory_bw';
REPLACE INTO mutcd_lookup(mutcd_code, description, sign_text, category) VALUES('R10-3c', 'crossing info text', '[[instructions]]', 'regulatory_pedestrian');";
                    SQLiteCommand cmd = new SQLiteCommand(cmdString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Error("Failed to update database, check database schema: " + e.ToString());
                    MessageBox.Show("The database could not be updated to the latest version of TAMS please contact the Utah LTAP Center for help.");
                    return false;
                }
                Dictionary<string, string> updateDb = new Dictionary<string, string>();
                updateDb["version"] = "6";
                dbVersion = 6;
                Database.UpdateRow(conn, updateDb, "db_version", "warning", "'DO_NOT_MODIFY'");
            }
            #endregion db_update_6_immute
            return true;
        }

        // attempts to connect to the database file
        public static SQLiteConnection Connect(string filename)
        {
            SQLiteConnection conn;

            SQLiteConnectionStringBuilder connStringBuilder = new SQLiteConnectionStringBuilder();
            connStringBuilder.DataSource = filename;
            connStringBuilder.Pooling = true;

            // connect
            string connString = connStringBuilder.ConnectionString;

            try
            {
                // 2nd parameter sets the connection string parser.  This version lets us use UNC paths
                // Default will not open network files.
                conn = new SQLiteConnection(connString, true);
                conn.Open();

            }
            catch (Exception e)
            {
                Log.Error("Could not connect to database " + filename + "\n\n" + e.ToString());
                throw new Exception("Could not open connection.");
            }

            if (conn.State == ConnectionState.Open)
            {
                return conn;
            }
            // unknown error
            throw new Exception("Could not open connection.");
        }

        /// <summary>
        /// Issues the replace command to the database
        /// </summary>
        /// <param name="conn">The database connection</param>
        /// <param name="keyVals">the key value pairs</param>
        /// <param name="table">the table to insert or replace into</param>
        /// <returns></returns>
        public static Boolean ReplaceRow(SQLiteConnection conn, Dictionary<string, string> keyVals, string table)
        {
            if (!IsOpen(conn)) { throw new Exception("Database not connected"); }

            Tuple<string, string> columnParams = CreateKeyParamStrings(keyVals.Keys.ToArray());
            string sql = "REPLACE INTO " + table + " (" + columnParams.Item1 + ") VALUES (" + columnParams.Item2 + ")";
            
            if (!ExecuteNonQuery(conn, sql, keyVals))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Issues the update command to the database
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="keyVals"></param>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Boolean UpdateRow(SQLiteConnection conn, Dictionary<string, string> keyVals, string table, string column, string key)
        {
            if (!IsOpen(conn)) { throw new Exception("Database not connected"); }

            string sql = "UPDATE " + table + " SET ";
            foreach (string k in keyVals.Keys)
            {
                sql = sql + k + "=" + keyVals[k] + ", ";
            }
            sql = sql.Substring(0, sql.Length - 2) + " WHERE " + column + "=" + key + ";";
            
            if (!ExecuteNonQuery(conn, sql))
            {
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// Executes the DELETE sql command given the parameters.
        /// </summary>
        /// <param name="conn">The SQLite connection</param>
        /// <param name="table">the table containing the row to be deleted</param>
        /// <param name="column">the name of the column to validate</param>
        /// <param name="key">the value the column to check for</param>
        /// <returns></returns>
        public static bool DeleteRow(SQLiteConnection conn, string table, string column, string key)
        {
            string sql = "DELETE FROM " + table + " WHERE " + column + "=" + key;
            if (!ExecuteNonQuery(conn, sql))
            {
                return false;
            }
            return true;
        }

        // issues REPLACE command for table with keyVals<column, value>
        public static Boolean InsertRow(SQLiteConnection conn, Dictionary<string, string> keyVals, string table)
        {
            if (!IsOpen(conn)) { throw new Exception("Database not connected"); }

            Tuple<string, string> columnParams = CreateKeyParamStrings(keyVals.Keys.ToArray());
            string sql = "INSERT INTO " + table + " (" + columnParams.Item1 + ") VALUES (" + columnParams.Item2 + ")";

            if (!ExecuteNonQuery(conn, sql, keyVals))
            {
                return false;
            }
            return true;
        }

        // helpver function for InsertRow & ReplaceRow & ???
        // returns an SQL pair of strings representing columns and parameter-placeholders
        // 1 => "[column1],[column2],[column3]"
        // 2 => "@column1, @column2, @column3
        private static Tuple<string, string> CreateKeyParamStrings(string[] keys)
        {
            string keyslist = "";
            string paramlist = "";

            foreach (string keyname in keys)
            {
                // need comma separator except for first one/
                if (keyslist != "")
                {
                    keyslist += ",";
                    paramlist += ",";
                }
                keyslist += "[" + keyname + "]";
                paramlist += "@" + keyname;
            }

            Tuple<string, string> returnValue = new Tuple<string, string>(keyslist, paramlist);
            return returnValue;
        }

        // returns false if problem
        public static Boolean ExecuteNonQuery(SQLiteConnection conn, string sql, Dictionary<string, string> keyVals = null)
        {
            if (!IsOpen(conn)) { throw new Exception("Database not connected"); }

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                if (keyVals != null && keyVals.Count > 0)  // not really necessary since foreach will handle it?
                {
                    string placeholder;
                    foreach (KeyValuePair<string, string> pair in keyVals)
                    {
                        placeholder = "@" + pair.Key;
                        cmd.Parameters.AddWithValue(placeholder, pair.Value);
                    }
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Log.Error("Database error in ExecuteNonQuery.\n" + e.ToString() + "\n\n" + sql);
                return false;
            }

            return true;
        }

        // attempts a db query with parameterized values
        // within query, parameters should be formatted: @paramname
        public static DataTable GetDataByQuery(SQLiteConnection conn, string query, Dictionary<string, string> values = null)
        {
            if (!IsOpen(conn)) { throw new Exception("Database not connected"); }

            if (values == null)
            {
                values = new Dictionary<string, string>();
            }

            DataTable returnTable = new DataTable();
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                foreach (KeyValuePair<string, string> pair in values)
                {
                    cmd.Parameters.AddWithValue("@" + pair.Key, pair.Value);
                }
                SQLiteDataReader reader = cmd.ExecuteReader();
                returnTable.Load(reader);
            }
            catch (Exception e)
            {
                throw new Exception("Could not get data. ", e);
            }
            return returnTable;
        }

        /// <summary>
        /// Gets the the value for the specified key in the speficied table for the specified column.
        /// </summary>
        /// <param name="conn">The database connection</param>
        /// <param name="table">the specified table</param>
        /// <param name="valueColumn">The specified value</param>
        /// <param name="keyColumn">The specified collumn</param>
        /// <param name="key">the specfied key</param>
        /// <returns></returns>
        public static string GetValueByKey(SQLiteConnection conn, string table, string valueColumn, string keyColumn, string key)
        {
            if (!IsOpen(conn)) { throw new Exception("Database not connected"); }

            try
            {
                string sql = "SELECT [" + valueColumn + "] FROM [" + table + "] WHERE [" + keyColumn + "] = @" + key;
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@" + keyColumn, key);
                return (string)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception("Could not get data. ", e);
            }
        }
        
        /// <summary>
        /// Attempts to get data from the datatable given specific key.
        /// </summary>
        /// <param name="conn">The database connection</param>
        /// <param name="table">the table to search</param>
        /// <param name="keyColumn">the collumn to check</param>
        /// <param name="key">the key to search for</param>
        /// <returns></returns>
        public static DataTable GetDataByKey(SQLiteConnection conn, string table, string keyColumn, string key)
        {
            if (!IsOpen(conn)) { throw new Exception("Database not connected"); }
            DataTable returnTable = new DataTable();

            try
            {
                string sql = "SELECT * FROM [" + table + "] WHERE [" + keyColumn + "] = @" + keyColumn;
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@" + keyColumn, key);
                SQLiteDataReader reader = cmd.ExecuteReader();
                returnTable.Load(reader);
            }
            catch (Exception e)
            {
                throw new Exception("Could not get data. ", e);
            }
            return returnTable;
        }

        /// <summary>
        /// Use only when closing a project.
        /// </summary>
        /// <param name="conn"></param>
        public static void Close(SQLiteConnection conn)
        {
            if (!IsOpen(conn))
            {
                return;
            }
            conn.Close();
        }


        // Checks table for columns<name, type>
        // adds table and/or columns if needed.
        public static void VerifyFields(SQLiteConnection conn, string table, Dictionary<string, string> columns)
        {
            string sql = "PRAGMA table_info([" + table + "])";
            DataTable resultsTable = GetDataByQuery(conn, sql, new Dictionary<string, string>());

            if (resultsTable.Rows.Count <= 0)
            {
                // need to create table
                sql = "CREATE TABLE [" + table + "](";
                Boolean needComma = false;
                foreach (KeyValuePair<string, string> pair in columns)
                {
                    if (needComma)
                    {
                        sql += ", ";
                    } else
                    {
                        needComma = true;
                    }

                    sql += "[" + pair.Key + "] " + pair.Value;
                }
                sql += ");";

                if (!ExecuteNonQuery(conn, sql))
                {
                    Log.Error("Could not verify fields in table " + table + "\n" + columns.ToString());
                    throw new Exception("Could not verify fields in table " + table);
                }
            }
            else
            {
                // foreach, etc etc
                // add in missing fields if needed
                // can I safely alter fields?
                foreach (KeyValuePair<string, string> pair in columns)
                {
                    //if (resultsTable.
                }
            }
        }
    }
}
