using DotSpatial.Controls;
using DotSpatial.Symbology;
using System.Data;
using System.Drawing;

namespace tams4a.Classes.Roads
{
    public class RoadSymbols
    {
        private TamsProject Project;
        private ModuleRoads moduleRoads;
        private string ModuleName = "road";

        public RoadSymbols(TamsProject theProject, ModuleRoads roads)
        {
            Project = theProject;
            moduleRoads = roads;
        }

        /// <summary>
        /// Sets the data properties used to color surveyed roads on the map. Roads are colored based RSL or Treatment
        /// </summary>
        public void applyColorizedProperties()
        {
            FeatureLayer selectionLayer = (FeatureLayer)moduleRoads.Layer;
            moduleRoads.UnsavedChanges = false;
            selectionLayer.SelectAll();
            ISelection shpSelection = selectionLayer.Selection;
            DataTable selectionTable = shpSelection.ToFeatureSet().DataTable;
            string tamsidcolumn = Project.settings.GetValue(ModuleName + "_f_TAMSID");
            selectionTable.DefaultView.Sort = tamsidcolumn + " asc";
            selectionTable = selectionTable.DefaultView.ToTable();
            string[] symbols = { "TAMSROADRSL", "TAMSTREATMENT" };
            moduleRoads.PrepareDatatable(selectionTable, symbols);
            string roadSQL = moduleRoads.SelectionSql.Replace("[[IDLIST]]", moduleRoads.extractTAMSIDs(selectionTable));
            DataTable tamsTable = Database.GetDataByQuery(Project.conn, roadSQL);
            tamsTable.DefaultView.Sort = "TAMSID asc";
            tamsTable = tamsTable.DefaultView.ToTable();
            for (int i = 0; i < selectionTable.Rows.Count; i++)
            {
                selectionTable.Rows[i]["TAMSROADRSL"] = i >= tamsTable.Rows.Count ? -1 : string.IsNullOrWhiteSpace(tamsTable.Rows[i]["rsl"].ToString()) ? -1 : Util.ToInt(tamsTable.Rows[i]["rsl"].ToString());
                selectionTable.Rows[i]["TAMSTREATMENT"] = i >= tamsTable.Rows.Count ? -1 : tamsTable.Rows[i]["suggested_treatment"];
            }
            selectionLayer.DataSet.DataTable = selectionTable;
        }

        public void setSymbolizer()
        {
            double baseWidth = 20.0;
            double baseOutlineWidth = 10.0;
            double adjWidth = baseWidth;
            double adjOutlineWidth = baseOutlineWidth;

            LineScheme rdScheme = new LineScheme();

            LineSymbolizer catSelSym = new LineSymbolizer();
            catSelSym.ScaleMode = ScaleMode.Geographic;
            catSelSym.SetWidth(adjWidth);
            catSelSym.SetOutline(Color.Blue, adjOutlineWidth);
            catSelSym.SetFillColor(Color.White);

            LineSymbolizer symDef = new LineSymbolizer();
            symDef.ScaleMode = ScaleMode.Geographic;
            symDef.SetWidth(adjWidth);
            symDef.SetOutline(Color.Black, adjOutlineWidth);
            symDef.SetFillColor(Color.Gray);

            LineCategory catDef = new LineCategory();
            catDef.LegendText = "No RSL Info";

            catDef.SelectionSymbolizer = catSelSym;
            catDef.Symbolizer = symDef;
            rdScheme.AddCategory(catDef);

            int[] rslfloor = { 0, 1, 4, 7, 10, 13, 16, 19 };
            int[] rslceil = { 0, 3, 6, 9, 12, 15, 18, 20 };

            int[] r = new int[30];
            int[] g = new int[30];
            int[] b = new int[30];
            r[0] = 139; r[1] = 255; r[2] = 255; r[3] = 255; r[4] = 50; r[5] = 0; r[6] = 0; r[7] = 0;
            g[0] = 0; g[1] = 0; g[2] = 165; g[3] = 255; g[4] = 205; g[5] = 128; g[6] = 191; g[7] = 0;
            b[0] = 0; b[1] = 0; b[2] = 0; b[3] = 0; b[4] = 50; b[5] = 0; b[6] = 255; b[7] = 255;

            if (Project.settings.GetValue("road_colors").Contains("t"))
            {
                if (moduleRoads.roadColors == "RSL")
                {
                    int j = 0;
                    for (int i = 0; i < 21; i++)
                    {
                        while (i > rslceil[j])
                        {
                            j++;
                        }
                        // create a category
                        LineCategory colorCat = new LineCategory();
                        colorCat.FilterExpression = "[TAMSROADRSL] = '" + i.ToString() + "'";

                        LineSymbolizer colorSym = new LineSymbolizer();
                        colorSym.ScaleMode = ScaleMode.Geographic;
                        colorSym.SetWidth(adjWidth);
                        colorSym.SetOutline(Color.DarkGray, adjOutlineWidth);
                        colorSym.SetFillColor(Color.FromArgb(r[j], g[j], b[j]));

                        colorCat.Symbolizer = colorSym;

                        // assign (default) selection symbolizer
                        colorCat.SelectionSymbolizer = catSelSym;

                        // done
                        rdScheme.AddCategory(colorCat);
                    }
                }

                if (moduleRoads.roadColors == "Treatment")
                {
                    DataTable nameToTreatment = Database.GetDataByQuery(Project.conn, "SELECT name, category FROM treatments;");
                    string[] treatments = new string[30];
                    int j = 0;
                    foreach (DataRow row in nameToTreatment.Rows)
                    {
                        treatments[j] = row["name"].ToString();
                        if (row["category"].ToString() == "routine") r[j] = 0; g[j] = 0; b[j] = 255;
                        if (row["category"].ToString() == "patch") r[j] = 50; g[j] = 205; b[j] = 50;
                        if (row["category"].ToString() == "preventative") r[j] = 255; g[j] = 255; b[j] = 0;
                        if (row["category"].ToString() == "rehabilitation") r[j] = 255; g[j] = 0; b[j] = 0;
                        if (row["category"].ToString() == "reconstruction") r[j] = 139; g[j] = 0; b[j] = 0;
                        j++;
                    }
                    treatments[24] = "Routine"; r[24] = 0; g[24] = 0; b[24] = 255;
                    treatments[25] = "Patching"; r[25] = 50; g[25] = 205; b[25] = 50;
                    treatments[26] = "Preventative"; r[26] = 255; g[26] = 255; b[26] = 0;
                    treatments[27] = "Preventative with Patching"; r[27] = 255; g[27] = 165; b[27] = 0;
                    treatments[28] = "Rehabilitation"; r[28] = 255; g[28] = 0; b[28] = 0;
                    treatments[29] = "Reconstruction"; r[29] = 139; g[29] = 0; b[29] = 0;

                    for (int i = 0; i < treatments.Length; i++)
                    {
                        LineCategory colorCat = new LineCategory();
                        colorCat.FilterExpression = "[TAMSTREATMENT] = '" + treatments[i] + "'";

                        LineSymbolizer colorSym = new LineSymbolizer();
                        colorSym.ScaleMode = ScaleMode.Geographic;
                        colorSym.SetWidth(adjWidth);
                        colorSym.SetOutline(Color.DarkGray, adjOutlineWidth);
                        colorSym.SetFillColor(Color.FromArgb(r[i], g[i], b[i]));

                        colorCat.Symbolizer = colorSym;

                        // assign (default) selection symbolizer
                        colorCat.SelectionSymbolizer = catSelSym;

                        // done
                        rdScheme.AddCategory(colorCat);
                    }
                }
            }
            ((MapLineLayer)moduleRoads.Layer).ShowLabels = false;

            FeatureLayer roadFeatures = moduleRoads.Layer as FeatureLayer;

            if (!string.IsNullOrEmpty(Project.settings.GetValue("road_labels")))
            {
                string streetnames = "[" + Project.settings.GetValue(ModuleName + "_f_streetname") + "]";
                //string streetIDs = "[" + Project.settings.GetValue(ModuleName + "_f_TAMSID") + "]";
                roadFeatures.AddLabels(streetnames,
                        new Font("Tahoma", (float)8.0), moduleRoads.labelColor);
                //string sql = "UPDATE road SET name = " + streetnames + " WHERE road_f_tamsid = " + streetIDs + "; ";
                //Database.ExecuteNonQuery(Project.conn, sql);
                roadFeatures.ShowLabels = Project.settings.GetValue("road_labels").Contains("true");
            }

            ((MapLineLayer)moduleRoads.Layer).Symbology = rdScheme;
            ((MapLineLayer)moduleRoads.Layer).ApplyScheme(rdScheme);
        }
    }
}
