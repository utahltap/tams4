using Microsoft.Office.Interop.Word;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using tams4a.Classes.Roads;
using tams4a.Forms;

namespace tams4a.Classes
{
    public class LTAPAnalysis
    {
        private TamsProject Project;
        private ModuleRoads moduleRoads;
        private const int NUM_RSL_CATEGORIES = 8;
        private double percentConcrete = 0;
        private double averageRSL = 0;
        private double majorAsphaltDistressPercent = 0;
        private double[] rslRange = new double[NUM_RSL_CATEGORIES];
        private string numberOfAsphaltDistressesPresent = "";
        private string numberOfConcreteDistressesPresent = "";
        private string majorAsphaltDistress = "";
        private string majorConcreteDistress = "";
        private const int FEET_TO_MILES = 5820;
        private const string MAJOR_ASPHALT_DISTRESS = "<major_asphalt_distress> is the main governing distress in the majority of the streets and affects <per_major_asphalt_distress> percent (<%_major_asphalt_distress>%) of the network surface area. ";


        public LTAPAnalysis(TamsProject theProject, ModuleRoads modRoads)
        {
            Project = theProject;
            moduleRoads = modRoads;
        }

        public void CreateWordDocument(object filename, object saveAs, FormLTAPAnalysis reportForm) {
            Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
            object missing = Missing.Value;
            Document document = null;

            if (File.Exists((string)filename))
            {
                object readOnly = false;
                object isVisible = false;
                winword.Visible = false;

                

                FileStream documentToOpen = null;

                try
                {
                    documentToOpen = File.Open(filename.ToString(), FileMode.Open, FileAccess.Read, FileShare.None);
                    documentToOpen.Close();
                    documentToOpen.Dispose();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex);
                    //Process[] allProcesses = Process.GetProcessesByName("WINWORD");
                    //foreach (Process process in allProcesses)
                    //{
                    //    process.Close();
                    //    process.Dispose();
                    //}
                }


                document = winword.Documents.Open(ref filename, ref missing,
                    ref readOnly, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing);

                document.Activate();

                RoadGraphs graphs = new RoadGraphs(Project, moduleRoads, moduleRoads.distressAsphalt, moduleRoads.distressGravel, moduleRoads.distressConcrete, this);
                object linkToFile = true;
                object saveWithDocument = false;
                object graphTrigger = "Generate Graphs";
                string subPath = Database.GetDataByQuery(Project.conn, "SELECT road_photos FROM photo_paths;").Rows[0][0].ToString();
                string path = Project.projectFolderPath + "\\" + subPath + "\\";

                foreach (InlineShape image in document.InlineShapes)
                {
                    object range = image.Range;
                    Console.WriteLine(image.Title);

                    if (image.Title == "Figure 2. Distribution of Street Network by Functional Classification")
                    {
                        graphs.graphRoadCategory(graphTrigger, null);

                        string imageLocation = Properties.Settings.Default.projectFolder + @"\Reports\FunctionalClassificationGraph.png";
                        image.Select();
                        winword.Selection.Delete();
                        winword.ActiveDocument.InlineShapes.AddPicture(imageLocation, linkToFile, saveWithDocument, range);
                    }
                    else if (image.Title == "Figure 3. Percentages of Asphalt and Concrete Streets by Surface Area")
                    {
                        graphs.graphRoadType(graphTrigger, null);

                        string imageLocation = Properties.Settings.Default.projectFolder + @"\Reports\SurfaceTypeGraph.png";
                        image.Select();
                        winword.Selection.Delete();
                        winword.ActiveDocument.InlineShapes.AddPicture(imageLocation, linkToFile, saveWithDocument, range);
                    }
                    else if (image.Title == "Figure 5. Major Distress Distribution for Asphalt Roads")
                    {
                        graphs.graphGoverningDistress("Asphalt", null);

                        string imageLocation = Properties.Settings.Default.projectFolder + @"\Reports\AsphaltDistressGraph.png";
                        image.Select();
                        winword.Selection.Delete();
                        winword.ActiveDocument.InlineShapes.AddPicture(imageLocation, linkToFile, saveWithDocument, range);
                    }
                    else if (image.Title == "Figure 6. Major Distress Distribution for Concrete Roads")
                    {
                        graphs.graphGoverningDistress("Concrete", null);

                        string imageLocation = Properties.Settings.Default.projectFolder + @"\Reports\ConcreteDistressGraph.png";
                        image.Select();
                        winword.Selection.Delete();
                        winword.ActiveDocument.InlineShapes.AddPicture(imageLocation, linkToFile, saveWithDocument, range);
                    }
                    else if (image.Title == "Figure 7. Current RSL Distribution for Asphalt and Concrete Street Network")
                    {
                        graphs.graphRSL("Asphalt,Concrete,", null);

                        string imageLocation = Properties.Settings.Default.projectFolder + @"\Reports\AsphaltConcreteRSLGraph.png";
                        image.Select();
                        winword.Selection.Delete();
                        winword.ActiveDocument.InlineShapes.AddPicture(imageLocation, linkToFile, saveWithDocument, range);
                    }
                    else if (image.Title == "Photo 1. Failed Condition")
                    {
                        string selectedImage = reportForm.getSelectedPictureByIndex("FAILED");
                        if (selectedImage == "No Photo Selected")
                        {
                            continue;
                        }
                        string imageLocation = path + selectedImage;
                        image.Select();
                        winword.Selection.Delete();
                        winword.ActiveDocument.InlineShapes.AddPicture(imageLocation, linkToFile, saveWithDocument, range);

                    }
                    else if (image.Title == "Photo 2. Poor Condition")
                    {
                        string selectedImage = reportForm.getSelectedPictureByIndex("POOR");
                        if (selectedImage == "No Photo Selected")
                        {
                            continue;
                        }
                        string imageLocation = path + selectedImage;
                        image.Select();
                        winword.Selection.Delete();
                        winword.ActiveDocument.InlineShapes.AddPicture(imageLocation, linkToFile, saveWithDocument, range);
                    }
                    else if (image.Title == "Photo 3. Fair Condition")
                    {
                        string selectedImage = reportForm.getSelectedPictureByIndex("FAIR");
                        if (selectedImage == "No Photo Selected")
                        {
                            continue;
                        }
                        string imageLocation = path + selectedImage;
                        image.Select();
                        winword.Selection.Delete();
                        winword.ActiveDocument.InlineShapes.AddPicture(imageLocation, linkToFile, saveWithDocument, range);
                    }
                    else if (image.Title == "Photo 4. Good Condition")
                    {
                        string selectedImage = reportForm.getSelectedPictureByIndex("GOOD");
                        if (selectedImage == "No Photo Selected")
                        {
                            continue;
                        }
                        string imageLocation = path + selectedImage;
                        image.Select();
                        winword.Selection.Delete();
                        winword.ActiveDocument.InlineShapes.AddPicture(imageLocation, linkToFile, saveWithDocument, range);
                    }
                    else if (image.Title == "Photo 5. Very Good Condition")
                    {
                        string selectedImage = reportForm.getSelectedPictureByIndex("VERY GOOD");
                        if (selectedImage == "No Photo Selected")
                        {
                            continue;
                        }
                        string imageLocation = path + selectedImage;
                        image.Select();
                        winword.Selection.Delete();
                        winword.ActiveDocument.InlineShapes.AddPicture(imageLocation, linkToFile, saveWithDocument, range);
                    }
                    else if (image.Title == "Photo 6. Excellent Condition")
                    {
                        string selectedImage = reportForm.getSelectedPictureByIndex("EXCELLENT");
                        if (selectedImage == "No Photo Selected")
                        {
                            continue;
                        }
                        string imageLocation = path + selectedImage;
                        image.Select();
                        winword.Selection.Delete();
                        winword.ActiveDocument.InlineShapes.AddPicture(imageLocation, linkToFile, saveWithDocument, range);
                    }

                }

                System.Data.DataTable roads = Database.GetDataByQuery(Project.conn, moduleRoads.getSelectAllSQL());

                double feetOfRoad = 0;
                double feetOfAsphaltRoad = 0;
                foreach (System.Data.DataRow row in roads.Rows)
                {
                    double segmentLength = Util.ToInt(row["length"].ToString());
                    feetOfRoad += segmentLength;
                    if (row["surface"].ToString() == "asphalt")
                    {
                        feetOfAsphaltRoad += segmentLength;
                    }
                }
                int milesOfRoad = (int)Math.Round(feetOfRoad / FEET_TO_MILES);
                double onePercentAsphalt = Math.Round((feetOfAsphaltRoad / 100) / FEET_TO_MILES, 1);

                FindAndReplace(winword, "<organization>", reportForm.textBoxOrganization.Text); // Not working because it is in the header
                FindAndReplace(winword, "<city>", reportForm.textBoxCityName.Text);
                FindAndReplace(winword, "<miles>", milesOfRoad);
                FindAndReplace(winword, "<one_percent_asphalt>", onePercentAsphalt);
                FindAndReplace(winword, "<contact_date>", reportForm.dateTimePickerContactDate.Text);
                FindAndReplace(winword, "<proposal_date>", reportForm.dateTimePickerProposalDate.Text);
                FindAndReplace(winword, "<city_dep>", reportForm.textBoxCityDepartment.Text);
                FindAndReplace(winword, "<survey_month>", reportForm.textBoxSurveyMonth.Text);
                FindAndReplace(winword, "<survey_year>", reportForm.numericUpDownSurveyYear.Value);
                FindAndReplace(winword, "<percent_concrete>", percentConcrete);
                FindAndReplace(winword, "<number_of_asphalt_distresses>", numberOfAsphaltDistressesPresent);
                FindAndReplace(winword, "<number_of_concrete_distresses>", numberOfConcreteDistressesPresent);
                FindAndReplace(winword, "<major_concrete_distress>", majorConcreteDistress);
                FindAndReplace(winword, "<average_rsl>", averageRSL.ToString("N2"));

                setMajorAsphaltDistressSentence(winword);

                FindAndReplace(winword, "<%_rsl_0>", rslRange[0].ToString("N2"));
                FindAndReplace(winword, "<%_rsl_1-3>", rslRange[1].ToString("N2"));
                FindAndReplace(winword, "<%_rsl_4-6>", rslRange[2].ToString("N2"));
                FindAndReplace(winword, "<%_rsl_7-9>", rslRange[3].ToString("N2"));
                FindAndReplace(winword, "<%_rsl_10-12>", rslRange[4].ToString("N2"));
                FindAndReplace(winword, "<%_rsl_13-15>", rslRange[5].ToString("N2"));
                FindAndReplace(winword, "<%_rsl_16-18>", rslRange[6].ToString("N2"));
                FindAndReplace(winword, "<%_rsl_19-20>", rslRange[7].ToString("N2"));
                FindAndReplace(winword, "<%_rsl_poor>", (rslRange[1] + rslRange[2]).ToString("N2"));
                FindAndReplace(winword, "<%_rsl_very_good>", (rslRange[5] + rslRange[6]).ToString("N2"));

                FindAndReplace(winword, "<per_rsl_0>", capitalizeFirstLetter(numToString((int)Math.Round(rslRange[0], MidpointRounding.AwayFromZero))));
                FindAndReplace(winword, "<per_rsl_poor>", capitalizeFirstLetter(numToString((int)Math.Round(rslRange[1] + rslRange[2], MidpointRounding.AwayFromZero))));
                FindAndReplace(winword, "<per_rsl_7-9>", capitalizeFirstLetter(numToString((int)Math.Round(rslRange[3], MidpointRounding.AwayFromZero))));
                FindAndReplace(winword, "<per_rsl_10-12>", capitalizeFirstLetter(numToString((int)Math.Round(rslRange[4], MidpointRounding.AwayFromZero))));
                FindAndReplace(winword, "<per_rsl_very_good>", numToString((int)Math.Round(rslRange[5] + rslRange[6], MidpointRounding.AwayFromZero)));
                FindAndReplace(winword, "<per_rsl_19-20>", numToString((int)Math.Round(rslRange[7], MidpointRounding.AwayFromZero)));

                FindAndReplace(winword, "<failed_road_address>", roadAddressToString(reportForm.getSelectedRoadInfo("FAILED")));
                FindAndReplace(winword, "<poor_road_address>", roadAddressToString(reportForm.getSelectedRoadInfo("POOR")));
                FindAndReplace(winword, "<fair_road_address>", roadAddressToString(reportForm.getSelectedRoadInfo("FAIR")));
                FindAndReplace(winword, "<good_road_address>", roadAddressToString(reportForm.getSelectedRoadInfo("GOOD")));
                FindAndReplace(winword, "<very_good_road_address>", roadAddressToString(reportForm.getSelectedRoadInfo("VERY GOOD")));
                FindAndReplace(winword, "<excellent_road_address>", roadAddressToString(reportForm.getSelectedRoadInfo("EXCELLENT")));

                FindAndReplace(winword, "<poor_road_rsl>", roadRSLToString(reportForm.getSelectedRoadInfo("POOR")));
                FindAndReplace(winword, "<fair_road_rsl>", roadRSLToString(reportForm.getSelectedRoadInfo("FAIR")));
                FindAndReplace(winword, "<good_road_rsl>", roadRSLToString(reportForm.getSelectedRoadInfo("GOOD")));
                FindAndReplace(winword, "<very_good_road_rsl>", roadRSLToString(reportForm.getSelectedRoadInfo("VERY GOOD")));
                FindAndReplace(winword, "<excellent_road_rsl>", roadRSLToString(reportForm.getSelectedRoadInfo("EXCELLENT")));





                int surveyYear = (int)reportForm.numericUpDownSurveyYear.Value;
                FindAndReplace(winword, "<5yr>", surveyYear + 5);
                FindAndReplace(winword, "<10yr>", surveyYear + 10);

                System.Data.DataTable allRoads = Database.GetDataByQuery(Project.conn, moduleRoads.getSelectAllSQL());

                int rslSum = 0;
                int fiveYrSum = 0;
                int tenYrSum = 0;
                int asphaltCount = 0;

                double rsl3Percent = 0;
                double totalArea = 0;
                double rsl3Area = 0;
                foreach (DataRow row in allRoads.Rows)
                {
                    // get area for rsl 3 for finding rsl3Percent
                    totalArea += Util.ToDouble(row["width"].ToString()) * Util.ToDouble(row["length"].ToString());
                    if(row["rsl"].ToString() == "3")
                    {
                        rsl3Area += Util.ToDouble(row["width"].ToString()) * Util.ToDouble(row["length"].ToString());
                    }

                    if (row["surface"].ToString() == "asphalt" && !string.IsNullOrEmpty(row["rsl"].ToString()))
                    {
                        int rsl = Util.ToInt(row["rsl"].ToString());
                        rslSum += rsl;

                        rsl -= 5;
                        if (rsl < 0) rsl = 0;
                        fiveYrSum += rsl;

                        rsl -= 5;
                        if (rsl < 0) rsl = 0;
                        tenYrSum += rsl;

                        asphaltCount++;
                    }
                }

                rsl3Percent = Math.Round( (rsl3Area / totalArea) * 100, 2);

                double avgAsphaltRSL = Math.Round((double)rslSum / asphaltCount, 1);
                double fiveYrEst = Math.Round((double)fiveYrSum / asphaltCount, 1);
                double tenYrEst = Math.Round((double)tenYrSum / asphaltCount, 1);

                FindAndReplace(winword, "<current_rsl>", avgAsphaltRSL);
                FindAndReplace(winword, "<5yr_est>", fiveYrEst);
                FindAndReplace(winword, "<10yr_est>", tenYrEst);

                FindAndReplace(winword, "<%_rsl_3>", rsl3Percent.ToString("N2"));
                // <5yr_trt>
                // <current_est_concrete>
            }
            else
            {
                MessageBox.Show("File not found!");
            }

            //Save the document  
            document.SaveAs2(ref saveAs, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing);

            document.Close();
            winword.Quit();
            MessageBox.Show("File Created!");
        }

        private void FindAndReplace(Microsoft.Office.Interop.Word.Application winword, object toFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object matchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            winword.Selection.Find.Execute(ref toFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref matchAllForms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }

        private void setMajorAsphaltDistressSentence(Microsoft.Office.Interop.Word.Application winword)
        {

            foreach (string distress in moduleRoads.distressAsphalt)
            {
                if (majorAsphaltDistress == distress)
                {
                    FindAndReplace(winword, "<" + distress.ToLower() + "_is_major>", MAJOR_ASPHALT_DISTRESS);

                    string dist = distress;
                    if (dist == "Transverse" || dist == "Longitudinal" ||  dist == "Blocking" || dist == "Edge" || dist == "Fatigue")
                        dist += " cracking";
                    FindAndReplace(winword, "<major_asphalt_distress>", dist);
                }
                else
                    FindAndReplace(winword, "<" + distress.ToLower() + "_is_major>", "");
            }
            FindAndReplace(winword, "<%_major_asphalt_distress>", majorAsphaltDistressPercent.ToString("#.##"));
            FindAndReplace(winword, "<per_major_asphalt_distress>", numToString((int)Math.Round(majorAsphaltDistressPercent, MidpointRounding.AwayFromZero)));
        }

        private string roadAddressToString(DataRow row)
        {
            if(row == null || row["name"] == null || row["name"] == "")
            {
                return "***Missing Data***";
            }
            return row["name"].ToString() + " from " + row["from_address"].ToString() + " to " + row["to_address"].ToString();
        }

        private string roadRSLToString(DataRow row)
        {
            if(row == null || row["rsl"] == null)
            {
                return "***Missing rsl data***";
            }
            return row["rsl"].ToString();
        }

        internal void setPercentConcrete(double value)
        {
            percentConcrete = value;
        }

        internal void setNumberOfAsphaltDistressesPresent(int value)
        {
            numberOfAsphaltDistressesPresent = numToString(value);
        }

        internal void setMajorAsphaltDistress(string value)
        {
            majorAsphaltDistress = value;
        }

        internal void setNumberOfConcreteDistressesPresent(int value)
        {
            numberOfConcreteDistressesPresent = numToString(value);
        }

        internal void setMajorConcreteDistress(string value)
        {
            majorConcreteDistress = value;
        }

        internal void setAverageRSL(double value)
        {
            averageRSL = value;
        }

        internal void setRSLRange(double[] value)
        {
            rslRange = value;
        }

        internal void setMajorAsphaltDistressPercent(double value)
        {
            majorAsphaltDistressPercent = value;
        }

        private string numToString(int num)
        {
            if (num == 0) return "zero";
            if (num == 1) return "one";
            if (num == 2) return "two";
            if (num == 3) return "three";
            if (num == 4) return "four";
            if (num == 5) return "five";
            if (num == 6) return "six";
            if (num == 7) return "seven";
            if (num == 8) return "eight";
            if (num == 9) return "nine";
            if (num == 10) return "ten";
            if (num == 11) return "eleven";
            if (num == 12) return "twelve";
            if (num == 13) return "thirteen";
            if (num == 14) return "fourteen";
            if (num == 15) return "fifteen";
            if (num == 16) return "sixteen";
            if (num == 17) return "seventeen";
            if (num == 18) return "eighteen";
            if (num == 19) return "nineteen";

            string number = num.ToString();

            if (number.Length == 2)
            {
                string numName = "";
                if (number[0] == '2') numName += "twenty";
                else if (number[0] == '3') numName += "thirty";
                else if (number[0] == '4') numName += "fourty";
                else if (number[0] == '5') numName += "fifty";
                else if (number[0] == '6') numName += "sixty";
                else if (number[0] == '7') numName += "seventy";
                else if (number[0] == '8') numName += "eighty";
                else if (number[0] == '9') numName += "ninety";

                if (number[1] == 0) return numName;
                else return numName + "-" + numToString(Util.ToInt(number[1].ToString())); 
            }
            if (num == 100) return "one-hundred";

            return "NAN";
        }

        private string capitalizeFirstLetter(string str)
        {
            if (str.Length == 0) return "NAN";
            else if (str.Length == 1) return str.ToUpper();
            return char.ToUpper(str[0]) + str.Substring(1);
        }


    }
}
