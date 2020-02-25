using Microsoft.Office.Interop.Word;
using System;
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
        private double percentConcrete = 0;
        private string numberOfAsphaltDistressesPresent = "";
        private string numberOfConcreteDistressesPresent = "";
        private string majorAsphaltDistress = "";
        private string majorConcreteDistress = "";
        private const int FEET_TO_MILES = 5820;

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

                document = winword.Documents.Open(ref filename, ref missing,
                    ref readOnly, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing);

                document.Activate();

                RoadGraphs graphs = new RoadGraphs(Project, moduleRoads, moduleRoads.distressAsphalt, moduleRoads.distressGravel, moduleRoads.distressConcrete, this);
                object linkToFile = true;
                object saveWithDocument = false;
                object graphTrigger = "Generate Graphs";

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
                int milesOfRoad = (int)Math.Round(feetOfRoad/FEET_TO_MILES);
                double onePercentAsphalt = Math.Round((feetOfAsphaltRoad / 100) / FEET_TO_MILES, 1);

                //find and replace
                FindAndReplace(winword, "<organization>", reportForm.textBoxOrganization.Text); // Not working...
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
                FindAndReplace(winword, "<major_asphalt_distress>", majorAsphaltDistress);
                FindAndReplace(winword, "<number_of_concrete_distresses>", numberOfConcreteDistressesPresent);
                FindAndReplace(winword, "<major_concrete_distress>", majorConcreteDistress);


                int surveyYear = (int)reportForm.numericUpDownSurveyYear.Value;
                FindAndReplace(winword, "<5yr>", surveyYear + 5);
                FindAndReplace(winword, "<10yr>", surveyYear + 10);

                System.Data.DataTable allRoads = Database.GetDataByQuery(Project.conn, moduleRoads.getSelectAllSQL());

                int rslSum = 0;
                int fiveYrSum = 0;
                int tenYrSum = 0;
                int asphaltCount = 0;
                foreach (System.Data.DataRow row in allRoads.Rows)
                {
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

                double avgAsphaltRSL = Math.Round((double)rslSum / asphaltCount, 1);
                double fiveYrEst = Math.Round((double)fiveYrSum / asphaltCount, 1);
                double tenYrEst = Math.Round((double)tenYrSum / asphaltCount, 1);

                FindAndReplace(winword, "<current_rsl>", avgAsphaltRSL);
                FindAndReplace(winword, "<5yr_est>", fiveYrEst);
                FindAndReplace(winword, "<10yr_est>", tenYrEst);

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
            return "NAN";
        }
    }
}
