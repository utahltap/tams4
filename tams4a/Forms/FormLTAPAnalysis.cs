using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormLTAPAnalysis : Form
    {
        private TamsProject Project;
        private ModuleRoads moduleRoads;
        private int currentPanel = 1;
        private DataTable roads;
        private Dictionary<int, PictureBox> pictureBoxes = new Dictionary<int, PictureBox>();
        private int set = 0;
        private string subPath;
        private Dictionary<PictureBox, bool> selectedPicture = new Dictionary<PictureBox, bool>();
        // dictionaries to hold the rows of the roads table corresponding to the dictionaries for the photos
        private Dictionary<int, DataRow> failedRSLRoads = new Dictionary<int, DataRow>();
        private Dictionary<int, DataRow> poorRSLRoads = new Dictionary<int, DataRow>();
        private Dictionary<int, DataRow> fairRSLRoads = new Dictionary<int, DataRow>();
        private Dictionary<int, DataRow> goodRSLRoads = new Dictionary<int, DataRow>();
        private Dictionary<int, DataRow> veryGoodRSLRoads = new Dictionary<int, DataRow>();
        private Dictionary<int, DataRow> excellentRSLRoads = new Dictionary<int, DataRow>();


        // dictionaries to hold the different classifications of photos
        private Dictionary<int, string> picturesFailedRSL = new Dictionary<int, string>();
        private Dictionary<int, string> picturesPoorRSL = new Dictionary<int, string>();
        private Dictionary<int, string> picturesFairRSL = new Dictionary<int, string>();
        private Dictionary<int, string> picturesGoodRSL = new Dictionary<int, string>();
        private Dictionary<int, string> picturesVeryGoodRSL = new Dictionary<int, string>();
        private Dictionary<int, string> picturesExcellentRSL = new Dictionary<int, string>();

        // -1 means no picture is selected. 
        private int selectedFailedPicture = -1;
        private int selectedPoorPicture = -1;
        private int selectedFairPicture = -1;
        private int selectedGoodPicture = -1;
        private int selectedVeryGoodPicture = -1;
        private int selectedExcellentPicture = -1;
        private int genericSelectedPicture = -1;


        private Dictionary<int, string> picturesSelection = new Dictionary<int, string>();

        public FormLTAPAnalysis(TamsProject theProject, ModuleRoads modRoads)
        {
            Project = theProject;
            moduleRoads = modRoads;
            InitializeComponent();
            roads = Database.GetDataByQuery(Project.conn, moduleRoads.getSelectAllSQL());
            subPath = Database.GetDataByQuery(Project.conn, "SELECT road_photos FROM photo_paths;").Rows[0][0].ToString();
            pictureBoxes[0] = pictureBox1;
            pictureBoxes[1] = pictureBox2;
            pictureBoxes[2] = pictureBox3;
            pictureBoxes[3] = pictureBox4;
            pictureBoxes[4] = pictureBox5;
            pictureBoxes[5] = pictureBox6;

            panel1.BringToFront();

            foreach (PictureBox box in pictureBoxes.Values) {
                selectedPicture[box] = false;
            }

            foreach (DataRow row in roads.Rows)
            {
                if(string.IsNullOrEmpty(row["rsl"].ToString()))
                {
                    continue;
                }

                int rsl = Util.ToInt(row["rsl"].ToString());
                string photo = row["photo"].ToString();
                // Failed roads
                if (rsl == 0 && !string.IsNullOrEmpty(row["photo"].ToString())) 
                {
                    savePhotosToDictionary(row, picturesFailedRSL, failedRSLRoads);
                }
                // Poor roads
                else if (rsl >= 1 && rsl <= 6 && !string.IsNullOrEmpty(row["photo"].ToString()))
                {
                    savePhotosToDictionary(row, picturesPoorRSL, poorRSLRoads);
                }
                // Fair roads
                else if(rsl >= 7 && rsl <= 9 && !string.IsNullOrEmpty(row["photo"].ToString()))
                {
                    savePhotosToDictionary(row, picturesFairRSL, fairRSLRoads);
                }
                // Good roads
                else if(rsl >= 10 && rsl <= 12 && !string.IsNullOrEmpty(row["photo"].ToString()))
                {
                    savePhotosToDictionary(row, picturesGoodRSL, goodRSLRoads);
                }
                // Very Good roads
                else if(rsl >= 13 && rsl <= 18 && !string.IsNullOrEmpty(row["photo"].ToString()))
                {
                    savePhotosToDictionary(row, picturesVeryGoodRSL, veryGoodRSLRoads);
                }
                // Excellent roads
                else if(rsl >= 19 && rsl <= 20 && !string.IsNullOrEmpty(row["photo"].ToString()))
                {
                    savePhotosToDictionary(row, picturesExcellentRSL, excellentRSLRoads);
                }
            }
        }

        private void savePhotosToDictionary(DataRow row, Dictionary<int, string> pictures, Dictionary<int, DataRow> roads)
        {
            if (string.IsNullOrEmpty(row["name"].ToString()) || string.IsNullOrEmpty(row["from_address"].ToString()) || string.IsNullOrEmpty(row["to_address"].ToString()))
            {
                // don't save this road because it has missing information
                return;
            }
            char[] splitListChars = { '/', ' ' };
            string[] listOfPhotos = row["photo"].ToString().Split(splitListChars, StringSplitOptions.RemoveEmptyEntries);
            foreach (string photo in listOfPhotos)
            {
                roads[roads.Count] = row;
                pictures[pictures.Count] = photo;
            }

        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            LTAPAnalysis analysis = new LTAPAnalysis(Project, moduleRoads);
            // update paths***
            object template = "C:\\Users\\A02064884\\Desktop\\Report_Template.docx";
            object file = "C:\\Users\\A02064884\\Desktop\\Test_Report.docx";
            analysis.CreateWordDocument(template, file, this);
            Close();
        }

        public DataRow getSelectedRoadInfo(string pictureType)
        {
            if (pictureType == "FAILED")
            {
                if (selectedFailedPicture == -1)
                {
                    return null;
                }
                return failedRSLRoads[selectedFailedPicture];
            }
            else if (pictureType == "POOR")
            {
                if (selectedPoorPicture == -1)
                {
                    return null;
                }
                return poorRSLRoads[selectedPoorPicture];

            }
            else if (pictureType == "FAIR")
            {
                if (selectedFairPicture == -1)
                {
                    return null;
                }
                return fairRSLRoads[selectedFairPicture];

            }
            else if (pictureType == "GOOD")
            {
                if (selectedGoodPicture == -1)
                {
                    return null;
                }
                return goodRSLRoads[selectedGoodPicture];
            }
            else if (pictureType == "VERY GOOD")
            {
                if (selectedVeryGoodPicture == -1)
                {
                    return null;
                }
                return veryGoodRSLRoads[selectedVeryGoodPicture];
            }
            else if (pictureType == "EXCELLENT")
            {
                if (selectedExcellentPicture == -1)
                {
                    return null;
                }
                return excellentRSLRoads[selectedExcellentPicture];
            }
            else
            {
                Console.WriteLine("Incorrect image type specified");
                return null;
            }
        }

        public string getSelectedPictureByIndex(string pictureType)
        {
            if(pictureType == "FAILED")
            {
                if(selectedFailedPicture == -1)
                {
                    return "No Photo Selected";
                }
                return picturesFailedRSL[selectedFailedPicture];
            }
            else if(pictureType == "POOR")
            {
                if (selectedPoorPicture == -1)
                {
                    return "No Photo Selected";
                }
                return picturesPoorRSL[selectedPoorPicture];

            }
            else if (pictureType == "FAIR")
            {
                if (selectedFairPicture == -1)
                {
                    return "No Photo Selected";
                }
                return picturesFairRSL[selectedFairPicture];

            }
            else if (pictureType == "GOOD")
            {
                if (selectedGoodPicture == -1)
                {
                    return "No Photo Selected";
                }
                return picturesGoodRSL[selectedGoodPicture];
            }
            else if (pictureType == "VERY GOOD")
            {
                if (selectedVeryGoodPicture == -1)
                {
                    return "No Photo Selected";
                }
                return picturesVeryGoodRSL[selectedVeryGoodPicture];
            }
            else if (pictureType == "EXCELLENT")
            {
                if (selectedExcellentPicture == -1)
                {
                    return "No Photo Selected";
                }
                return picturesExcellentRSL[selectedExcellentPicture];
            }
            else
            {
                Console.WriteLine("Incorrect image type specified");
                return "";
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            // reset set when we switch to different types of photos
            buttonPreviousSet.Enabled = false;
            buttonNextSet.Enabled = false;
            clearPictureSelection();
            clearPictures();
            // Failed roads
            if (currentPanel == 1)
            {
                panel2.BringToFront();
                currentPanel = 2;
                buttonPrevious.Visible = true;
                picturesSelection = picturesFailedRSL;
                Console.WriteLine(picturesSelection.Count);
                genericSelectedPicture = selectedFailedPicture;
            }
            // Poor roads
            else if (currentPanel == 2)
            {
                currentPanel = 3;
                labelPictureSelect.Text = "Select an image to use as an example for POOR road condition.";
                picturesSelection = picturesPoorRSL;
                Console.WriteLine(picturesSelection.Count);
                genericSelectedPicture = selectedPoorPicture;
            }
            // Fair roads
            else if (currentPanel == 3)
            {
                currentPanel = 4;
                labelPictureSelect.Text = "Select an image to use as an example for FAIR road condition.";
                picturesSelection = picturesFairRSL;
                Console.WriteLine(picturesSelection.Count);
                genericSelectedPicture = selectedFairPicture;
            }
            // Good roads
            else if (currentPanel == 4)
            {
                currentPanel = 5;
                labelPictureSelect.Text = "Select an image to use as an example for GOOD road condition.";
                picturesSelection = picturesGoodRSL;
                Console.WriteLine(picturesSelection.Count);
                genericSelectedPicture = selectedGoodPicture;
               
            }
            // Very Good roads
            else if (currentPanel == 5)
            {
                currentPanel = 6;
                labelPictureSelect.Text = "Select an image to use as an example for VERY GOOD road condition.";
                picturesSelection = picturesVeryGoodRSL;
                Console.WriteLine(picturesSelection.Count);
                genericSelectedPicture = selectedVeryGoodPicture;
                
            }
            // Excellent roads
            else if (currentPanel == 6)
            {
                currentPanel = 7;
                labelPictureSelect.Text = "Select an image to use as an example for EXCELLENT road condition.";
                picturesSelection = picturesExcellentRSL;
                Console.WriteLine(picturesSelection.Count);
                genericSelectedPicture = selectedExcellentPicture;
            }
            else
            {
                Console.WriteLine("Figure out what happens next");
            }
            set = genericSelectedPicture / 6;
            getPictures(genericSelectedPicture);
            if (picturesSelection.Count / 6 > set) buttonNextSet.Enabled = true;
            if (set > 0) buttonPreviousSet.Enabled = true;
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            buttonPreviousSet.Enabled = false;
            buttonNextSet.Enabled = false;
            set = 0;
            clearPictureSelection();
            clearPictures();
            // goto General info panel
            if (currentPanel == 2)
            {
                panel1.BringToFront();
                currentPanel = 1;
                buttonPrevious.Visible = false;
            }
            // goto Failed roads panel
            else if (currentPanel == 3)
            {
                currentPanel = 2;
                picturesSelection = picturesFailedRSL;
                genericSelectedPicture = selectedFailedPicture;
                labelPictureSelect.Text = "Select an image to use as an example for FAILED road condition.";
            }
            // goto Poor roads panel
            else if (currentPanel == 4)
            {
                currentPanel = 3;
                picturesSelection = picturesPoorRSL;
                genericSelectedPicture = selectedPoorPicture;
                labelPictureSelect.Text = "Select an image to use as an example for POOR road condition.";
            }
            // goto Fair roads panel
            else if (currentPanel == 5)
            {
                currentPanel = 4;
                picturesSelection = picturesFairRSL;
                genericSelectedPicture = selectedFairPicture;
                labelPictureSelect.Text = "Select an image to use as an example for FAIR road condition.";
            }
            // goto Good roads panel
            else if (currentPanel == 6)
            {
                currentPanel = 5;
                picturesSelection = picturesGoodRSL;
                genericSelectedPicture = selectedGoodPicture;
                labelPictureSelect.Text = "Select an image to use as an example for GOOD road condition.";
            }
            // goto Very Good roads panel
            else if (currentPanel == 7)
            {
                currentPanel = 6;
                picturesSelection = picturesVeryGoodRSL;
                genericSelectedPicture = selectedVeryGoodPicture;
                labelPictureSelect.Text = "Select an image to use as an example for VERY GOOD road condition.";
            }
            // figure out what is after the EXCELLENT panel, so we can go back to EXCELLENT panel
            set = genericSelectedPicture / 6;
            getPictures(genericSelectedPicture);
            if (picturesSelection.Count / 6 > set) buttonNextSet.Enabled = true;
            if (set > 0) buttonPreviousSet.Enabled = true;
        }

        private void getPictures(int selectedPicture)
        {

            for (int i = 0; i < 6; ++i)
            {
                int dictionaryIndex = (set * 6) + i;
                if(dictionaryIndex >= picturesSelection.Count)
                {
                    break;
                }
                string imageName = picturesSelection[dictionaryIndex];
                pictureBoxes[i].ImageLocation = Project.projectFolderPath + "\\" + subPath + "\\" + imageName;
                pictureBoxes[i].Enabled = true;

                if(dictionaryIndex == selectedPicture)
                {
                    pictureBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                    pictureBoxes[i].BackColor = Color.LightSkyBlue;
                    this.selectedPicture[pictureBoxes[i]] = true;
                }
            }
        }

        private void buttonNextSet_Click(object sender, EventArgs e)
        {
            ++set;
            int lowerSetBound = set * 6;
            int upperSetBound = (set + 1) * 6;
            Console.WriteLine("Set: " + set);
            clearPictures();
            buttonPreviousSet.Enabled = true;
            if (upperSetBound >= picturesSelection.Count) buttonNextSet.Enabled = false;
            clearPictureSelection();
            getPictures(genericSelectedPicture);

            if(genericSelectedPicture >= lowerSetBound && genericSelectedPicture < upperSetBound)
            {
                int index = genericSelectedPicture - lowerSetBound;
                pictureBoxes[index].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxes[index].BackColor = Color.LightSkyBlue;
                this.selectedPicture[pictureBoxes[index]] = true;
            }
        }

        private void buttonPreviousSet_Click(object sender, EventArgs e)
        {
            --set;
            int lowerSetBound = set * 6;
            int upperSetBound = (set + 1) * 6;
            Console.WriteLine("Set: " + set);

            clearPictures();
            buttonNextSet.Enabled = true;
            if (set == 0) buttonPreviousSet.Enabled = false;
            clearPictureSelection();
            getPictures(genericSelectedPicture);

            if (genericSelectedPicture >= lowerSetBound && genericSelectedPicture < upperSetBound)
            {
                int index = genericSelectedPicture - lowerSetBound;
                pictureBoxes[index].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxes[index].BackColor = Color.LightSkyBlue;
                this.selectedPicture[pictureBoxes[index]] = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            handlePictureClick(pictureBox1, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            handlePictureClick(pictureBox2, 1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            handlePictureClick(pictureBox3, 2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            handlePictureClick(pictureBox4, 3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            handlePictureClick(pictureBox5, 4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            handlePictureClick(pictureBox6, 5);
        }

        private void handlePictureClick(PictureBox box, int pictureBoxIndex)
        {
            if (selectedPicture[box])
            {
                if (currentPanel == 2)
                {
                    selectedFailedPicture = -1;
                }
                else if (currentPanel == 3)
                {
                    selectedPoorPicture = -1;
                }
                else if (currentPanel == 4)
                {
                    selectedFairPicture = -1;
                }
                else if (currentPanel == 5)
                {
                    selectedGoodPicture = -1;
                }
                else if (currentPanel == 6)
                {
                    selectedVeryGoodPicture = -1;
                }
                else if (currentPanel == 7)
                {
                    selectedExcellentPicture = -1;
                }
                clearPictureSelection();
                return;
            }
                     
            if(currentPanel == 2)
            {
                selectedFailedPicture = (set * 6) + pictureBoxIndex;
            }
            else if (currentPanel == 3)
            {
                selectedPoorPicture = (set * 6) + pictureBoxIndex;
            }
            else if (currentPanel == 4)
            {
                selectedFairPicture = (set * 6) + pictureBoxIndex;
            }
            else if (currentPanel == 5)
            {
                selectedGoodPicture = (set * 6) + pictureBoxIndex;
            }
            else if (currentPanel == 6)
            {
                selectedVeryGoodPicture = (set * 6) + pictureBoxIndex;
            }
            else if(currentPanel == 7)
            {
                selectedExcellentPicture = (set * 6) + pictureBoxIndex;
            }
            genericSelectedPicture = (set * 6) + pictureBoxIndex;

            clearPictureSelection();
            box.BorderStyle = BorderStyle.FixedSingle;
            box.BackColor = Color.LightSkyBlue;
            selectedPicture[box] = true;
        }

        private void clearPictures()
        {
            foreach (PictureBox box in pictureBoxes.Values)
            {
                box.Enabled = false;
                box.Image = null;
            }
        }

        private void clearPictureSelection()
        {
            foreach (PictureBox box in pictureBoxes.Values)
            {
                box.BorderStyle = BorderStyle.None;
                selectedPicture[box] = false;
                box.BackColor = SystemColors.Control;
            }
        }


    }
}
