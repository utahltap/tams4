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
        private int set = 1;
        private string subPath;
        private int countFailedRSL = 0;
        private int countPoorRSL = 0;
        private Dictionary<PictureBox, bool> selectedPicture = new Dictionary<PictureBox, bool>();
        private Dictionary<int, string> picturesFailedRSL = new Dictionary<int, string>();
        private Dictionary<int, string> picturesPoorRSL = new Dictionary<int, string>();
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

            foreach (PictureBox box in pictureBoxes.Values) {
                selectedPicture[box] = false;
            }

            int indexFailed = 0;
            int indexPoor = 0;
            foreach (DataRow row in roads.Rows)
            {
                int rsl = Util.ToInt(row["rsl"].ToString());
                if (rsl == 0 && !string.IsNullOrEmpty(row["photo"].ToString()))
                {
                    picturesFailedRSL[indexFailed++] = row["photo"].ToString();   
                    ++countFailedRSL;
                }
                if (rsl >= 1 && rsl <= 20 && !string.IsNullOrEmpty(row["photo"].ToString()))
                {
                    picturesPoorRSL[indexPoor++] = row["photo"].ToString();
                    ++countPoorRSL;
                }
            }
           
        }

        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            LTAPAnalysis analysis = new LTAPAnalysis(Project, moduleRoads);
            object template = "C:\\Users\\A02064884\\Desktop\\Report_Template.docx";
            object file = "C:\\Users\\A02064884\\Desktop\\Test_Report.docx";
            analysis.CreateWordDocument(template, file, this);
            Close();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            set = 1;
            clearPictures();
            if (currentPanel == 1)
            {
                panel2.BringToFront();
                currentPanel = 2;
                buttonPrevious.Visible = true;
                picturesSelection = picturesFailedRSL;
                Console.WriteLine(picturesSelection.Count);
                getPictures();
                if (countFailedRSL > 6) buttonNextSet.Enabled = true;
                return;
            }

            if (currentPanel == 2)
            {
                currentPanel = 3;
                labelPictureSelect.Text = "Select an image to use as an example for POOR road condition.";
                picturesSelection = picturesPoorRSL;
                Console.WriteLine(picturesSelection.Count);
                getPictures();
                if (countPoorRSL > 6) buttonNextSet.Enabled = true;
                return;
            }


        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            set = 1;
            clearPictures();
            if (currentPanel == 2)
            {
                panel1.BringToFront();
                currentPanel = 1;
                buttonPrevious.Visible = false;
                if (countFailedRSL <= 6) buttonNextSet.Enabled = false;
            }
            if (currentPanel == 3)
            {
                currentPanel = 2;
                labelPictureSelect.Text = "Select an image to use as an example for FAILED road condition.";
                if (countPoorRSL <= 6) buttonNextSet.Enabled = false;
            }
        }

        private void getPictures()
        {
            int pictureNum = 0;
            int setCount = set;

            foreach (string path in picturesSelection.Values)
            {
                if (pictureNum == 6)
                {
                    if (setCount == 1) return;
                    else
                    {
                        pictureNum = 0;
                        --setCount;
                    }
                }
                pictureBoxes[pictureNum].ImageLocation = Project.projectFolderPath + "\\" + subPath + "\\" + path;
                ++pictureNum;
            }
        }

        private void buttonNextSet_Click(object sender, EventArgs e)
        {
            ++set;
            clearPictures();
            buttonPreviousSet.Enabled = true;

            // TODO:
            // ************************************************************
            // * Change countFailedRSL to current picture selection count *
            // ************************************************************

            if ((set * 6) >= countFailedRSL) buttonNextSet.Enabled = false;
            getPictures();
            clearPictureSelection();
        }

        private void buttonPreviousSet_Click(object sender, EventArgs e)
        {
            --set;
            clearPictures();
            buttonNextSet.Enabled = true;
            if (set == 1) buttonPreviousSet.Enabled = false;
            getPictures();
            clearPictureSelection();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            handlePictureClick(pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            handlePictureClick(pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            handlePictureClick(pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            handlePictureClick(pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            handlePictureClick(pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            handlePictureClick(pictureBox6);
        }

        private void handlePictureClick(PictureBox box)
        {
            if (selectedPicture[box])
            {
                clearPictureSelection();
                return;
            }
            clearPictureSelection();
            box.BorderStyle = BorderStyle.FixedSingle;
            box.BackColor = Color.LightSkyBlue;
            selectedPicture[box] = true;
        }

        private void clearPictures()
        {
            foreach (PictureBox box in pictureBoxes.Values)
            {
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
