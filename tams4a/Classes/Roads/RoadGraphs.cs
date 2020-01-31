using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using tams4a.Forms;

namespace tams4a.Classes.Roads
{
    public class RoadGraphs
    {
        private TamsProject Project;
        private ModuleRoads moduleRoads;
        private string[] distressAsphalt;
        private string[] distressGravel;
        private string[] distressConcrete;
        private LTAPAnalysis analysis;
        private Color[] colorPalette = { Color.FromArgb(88, 192, 235), Color.FromArgb(253, 231, 76), Color.FromArgb(155, 197, 61), Color.FromArgb(229, 89, 52), Color.FromArgb(250, 121, 33), Color.FromArgb(175, 110, 242) };

    public RoadGraphs(TamsProject theProject, ModuleRoads roads, string[] asphalt, string[] gravel, string[] concrete, LTAPAnalysis ltapAnalysis = null)
        {
            Project = theProject;
            moduleRoads = roads;
            distressAsphalt = asphalt;
            distressGravel = gravel;
            distressConcrete = concrete;
            analysis = ltapAnalysis;
        }

        public void graphRoadType(object sender, EventArgs e)
        {
            string[] roadTypes = { "asphalt", "concrete", "gravel" };
            Color[] c = { Color.Black, Color.LightGray, Color.FromArgb(150, 75, 0) };
            makeTypeGraph(roadTypes, "surface", "Road Surface Distribution", c, sender.ToString() == "Generate Graphs");
        }

        public void graphRoadCategory(object sender, EventArgs e)
        {
            string[] roadTypes = { "Major Arterial", "Minor Arterial", "Major Collector", "Minor Collector", "Residential", "Other" };
            makeTypeGraph(roadTypes, "type", "Distribution of Functional Classification", colorPalette, sender.ToString() == "Generate Graphs");
        }

        private void makeTypeGraph(string[] roadTypes, string column, string title, Color[] c = null, bool suppressDisplay = false)
        {
            string thisSql = moduleRoads.getSelectAllSQL();
            try
            {
                DataTable roadTable = Database.GetDataByQuery(Project.conn, thisSql);
                if (roadTable.Rows.Count == 0)
                {
                    MessageBox.Show("No graph could be generated because no roads have a road type set.", "No Roads", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Dictionary<string, double> roadArea = new Dictionary<string, double>();
                for (int i = 0; i < roadTypes.Length; i++)
                {
                    roadArea.Add(roadTypes[i], 0.0);
                }
                double totalArea = 0.0;
                foreach (DataRow row in roadTable.Rows)
                {
                    for (int i = 0; i < roadTypes.Length; i++)
                    {
                        if (row[column].ToString().Contains(roadTypes[i]))
                        {
                            totalArea += Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                            roadArea[roadTypes[i]] += Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                        }
                    }
                }
                DataTable results = new DataTable();
                results.Columns.Add("Distribution");
                for (int i = 0; i < roadTypes.Length; i++)
                {
                    results.Columns.Add(Util.UppercaseFirst(roadTypes[i]));
                }
                DataRow totalsRow = results.NewRow();
                DataRow percentageRow = results.NewRow();
                totalsRow["Distribution"] = "Area (sqr. ft.)";
                percentageRow["Distribution"] = "Percentage";


                int count = 0;
                for (int i = 0; i < roadTypes.Length; i++)
                {
                    if (roadArea[roadTypes[i]] > 0) count++;
                }

                string[] domain = new string[count];
                double[] range = new double[count];

                int index = 0;
                for (int i = 0; i < roadTypes.Length; i++)
                {
                    double percentageCovered = Math.Round(roadArea[roadTypes[i]] / totalArea, 3) * 100;
                    if (percentageCovered == 0) continue;
                    percentageRow[Util.UppercaseFirst(roadTypes[i])] = percentageCovered;
                    totalsRow[Util.UppercaseFirst(roadTypes[i])] = roadArea[roadTypes[i]];
                    domain[index] = Util.UppercaseFirst(roadTypes[i]);
                    range[index] = percentageCovered;
                    index++;
                }
                results.Rows.Add(totalsRow);
                results.Rows.Add(percentageRow);

                FormGraphDisplay graph = new FormGraphDisplay(results, domain, range, title, c);
                if (suppressDisplay)
                {
                    string graphName = "";
                    if (column == "surface")
                    {
                        graphName = "SurfaceTypeGraph";
                        analysis.setPercentConcrete(Util.ToDouble(percentageRow[2].ToString()));
                    }
                    else if (column == "type") graphName = "FunctionalClassificationGraph";
                    Util.AutoChartToPNG(graph.chart, graphName);
                }
                else
                {
                    graph.Show();
                }
            }
            catch (Exception err)
            {
                Log.Error("Problem getting data from database " + err.ToString());
            }
        }

        public void graphGoverningDistress(object sender, EventArgs e)
        {
            ChooseRoadForm roadChooser = null;
            bool bypassForm = false;
            if (sender.ToString() == "Generate Graphs")
            {
                bypassForm = true;
            }
            else
            {
                roadChooser = new ChooseRoadForm("What Road Type?", "Select a Road Surface Type");
            }
            string thisSql = moduleRoads.getSelectAllSQL();
            if (bypassForm || roadChooser.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string roadType;
                    if (bypassForm) roadType = "Asphalt";
                    else roadType = roadChooser.chooseRoad();
                    DataTable roadTable = Database.GetDataByQuery(Project.conn, thisSql);
                    var roads = roadTable.Select("surface = '" + roadType + "'");

                    if (roads.Length == 0)
                    {
                        MessageBox.Show("No graph could be generated because there are no roads of type " + roadType + ".", "No Roads", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Dictionary<string, string[]> distressGroup = new Dictionary<string, string[]>()
                    {
                        {"Asphalt", distressAsphalt },
                        {"Gravel", distressGravel },
                        {"Concrete", distressConcrete }
                    };
                    Dictionary<string, double> distressedArea = new Dictionary<string, double>();
                    double totalArea = 0.0;
                    double noDistress = 0.0;
                    for (int i = 0; i < distressGroup[roadType].Length; i++)
                    {
                        distressedArea.Add(distressGroup[roadType][i], 0.0);
                    }
                    foreach (DataRow row in roads)
                    {
                        double area = Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                        totalArea += area;
                        int[] dvs = new int[9];
                        for (int i = 0; i < 9; i++)
                        {
                            dvs[i] = Util.ToInt(row["distress" + (i + 1).ToString()].ToString());
                        }
                        Dictionary<int, string> governingDistress = moduleRoads.getGoverningDistress(dvs, row["surface"].ToString());
                        if (governingDistress.Count == 0)
                        {
                            noDistress += area;
                        }
                        else
                        {
                            foreach (string distress in governingDistress.Values)
                            {
                                distressedArea[distress] += area;
                            }
                        }
                    }
                    DataTable results = new DataTable();
                    results.Columns.Add("Distribution");
                    for (int i = 0; i < distressGroup[roadType].Length; i++)
                    {
                        results.Columns.Add(distressGroup[roadType][i]);
                    }
                    results.Columns.Add("No Distress");
                    DataRow totalsRow = results.NewRow();
                    DataRow percentageRow = results.NewRow();
                    totalsRow["Distribution"] = "Area (sqr. ft.)";
                    percentageRow["Distribution"] = "Percentage";

                    int count = 1;
                    for (int i = 0; i < distressGroup[roadType].Length; i++)
                    {
                        if (distressedArea[distressGroup[roadType][i]] > 0) count++;
                    }

                    string[] domain = new string[count];
                    double[] range = new double[count];

                    double maxDistress = 0;
                    string majorDistress = "";
                    int patchPotholeIndex = -1;
                    int index = 0;
                    for (int i = 0; i < distressGroup[roadType].Length; i++)
                    {
                        double percentageCovered = Math.Round(distressedArea[distressGroup[roadType][i]] / totalArea, 3) * 100;
                        if (percentageCovered == 0) continue;
                        if (percentageCovered > maxDistress)
                        {
                            maxDistress = percentageCovered;
                            majorDistress = distressGroup[roadType][i];
                        }
                        totalsRow[distressGroup[roadType][i]] = distressedArea[distressGroup[roadType][i]];
                        percentageRow[distressGroup[roadType][i]] = percentageCovered;
                        if (distressGroup[roadType][i] == "Patch")
                        {
                            patchPotholeIndex = index;
                        }
                        if (distressGroup[roadType][i] == "Pothole")
                        {
                            if (patchPotholeIndex == -1)
                            {
                                patchPotholeIndex = index;
                                domain[patchPotholeIndex] = distressGroup[roadType][i];
                                index++;
                            }
                            else domain[patchPotholeIndex] = "Patch/Pothole";
                            range[patchPotholeIndex] += percentageCovered;
                        }
                        else
                        {
                            domain[index] = distressGroup[roadType][i];
                            range[index] = percentageCovered;
                            index++;
                        }
                    }
                    double percentNoDistress = Math.Round(noDistress / totalArea, 3) * 100;
                    totalsRow["No Distress"] = noDistress;
                    percentageRow["No Distress"] = percentNoDistress;
                    results.Rows.Add(totalsRow);
                    results.Rows.Add(percentageRow);
                    domain[count - 1] = "No Distress";
                    range[count - 1] = percentNoDistress;
                    string yLabel = "Percent of " + roadType + " Road Network";
                    FormGraphDisplay graph = new FormGraphDisplay(results, domain, range, Util.UppercaseFirst(roadType) + " Road Major Distresses", colorPalette, yLabel);
                    if (bypassForm)
                    {
                        analysis.setNumberOfAsphaltDistressesPresent(index - 1);
                        analysis.setMajorAsphaltDistress(majorDistress);
                        Util.AutoChartToPNG(graph.chart, "AsphaltDistressGraph");
                    }
                    else
                    {
                        graph.Show();
                    }
                }
                catch (Exception err)
                {
                    Log.Error("Problem getting data from database " + err.ToString());
                }
            }
        }

        public void graphRSL(object sender, EventArgs e)
        {
            ChooseRoadForm roadChooser = new ChooseRoadForm("What Road Type?", "Select a road surface type.");
            string thisSql = moduleRoads.getSelectAllSQL();
            if (roadChooser.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string roadType = roadChooser.chooseRoad();
                    string[] categories = { "0", "1-3", "4-6", "7-9", "10-12", "13-15", "16-18", "19-20" };
                    int[] caps = { 0, 3, 6, 9, 12, 15, 18, 20 };
                    DataTable roadTable = Database.GetDataByQuery(Project.conn, thisSql);
                    var roads = roadTable.Select("surface = '" + roadType + "'");
                    if (roadType == "All") roads = roadTable.Select();
                    if (roads.Length == 0)
                    {
                        MessageBox.Show("No graph could be generated because there are no roads of type " + roadType + ".", "No Roads", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    Dictionary<string, double> rslArea = new Dictionary<string, double>();
                    double totalArea = 0.0;
                    for (int i = 0; i < categories.Length; i++)
                    {
                        rslArea.Add(categories[i], 0.0);
                    }

                    foreach (DataRow row in roads)
                    {
                        int rsl = Util.ToInt(row["rsl"].ToString());
                        if (rsl == -1)
                        {
                            continue;
                        }
                        for (int i = 0; i < categories.Length; i++)
                        {
                            if (rsl <= caps[i])
                            {
                                totalArea += Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                                rslArea[categories[i]] += Util.ToDouble(row["length"].ToString()) * Util.ToDouble(row["width"].ToString());
                                break;
                            }
                        }
                    }
                    DataTable results = new DataTable();
                    results.Columns.Add("Distribution");
                    for (int i = 0; i < categories.Length; i++)
                    {
                        results.Columns.Add(categories[i]);
                    }
                    DataRow totalsRow = results.NewRow();
                    DataRow percentageRow = results.NewRow();
                    totalsRow["Distribution"] = "Area (sqr. ft.)";
                    percentageRow["Distribution"] = "Percentage";
                    string[] domain = new string[categories.Length];
                    double[] range = new double[categories.Length];
                    for (int i = 0; i < categories.Length; i++)
                    {
                        totalsRow[categories[i]] = rslArea[categories[i]];
                        percentageRow[categories[i]] = Math.Round(rslArea[categories[i]] / totalArea, 3) * 100;
                        domain[i] = categories[i];
                        range[i] = Math.Round(rslArea[categories[i]] / totalArea, 3) * 100;
                    }
                    results.Rows.Add(totalsRow);
                    results.Rows.Add(percentageRow);
                    Color[] color = { Color.DarkRed, Color.Red, Color.Orange, Color.Yellow, Color.LimeGreen, Color.Green, Color.DeepSkyBlue, Color.Blue };
                    FormGraphDisplay graph = new FormGraphDisplay(results, domain, range, "Road RSL Distribution", color);
                    graph.Show();
                }
                catch (Exception err)
                {
                    Log.Error("Problem getting data from database " + err.ToString());
                }
            }
        }
    }
}


