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
        private int count0RSL = 0;
        private string subPath;
        private Dictionary<PictureBox, bool> selectedPicture = new Dictionary<PictureBox, bool>();
        private Dictionary<int, string> pictures0RSL = new Dictionary<int, string>();

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

            int index0 = 0;
            foreach (DataRow row in roads.Rows)
            {
                if (row["rsl"].ToString() != "0" && !string.IsNullOrEmpty(row["photo"].ToString()))
                {
                    pictures0RSL[index0++] = row["photo"].ToString();   
                    ++count0RSL;
                }
            }
            if (count0RSL <= 6) buttonNextSet.Enabled = false;
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
            if (currentPanel == 1)
            {
                panel2.BringToFront();
                currentPanel = 2;
                buttonPrevious.Visible = true;
                getPictures();
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (currentPanel == 2)
            {
                panel1.BringToFront();
                currentPanel = 1;
                buttonPrevious.Visible = false;
            }
        }

        private void getPictures()
        {
            int pictureNum = 0;
            int setCount = set;
            foreach (string path in pictures0RSL.Values)
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


            //foreach (DataRow row in roads.Rows)
            //{
            //    if (row["rsl"].ToString() != "0" && !string.IsNullOrEmpty(row["photo"].ToString()))
            //    {
            //        pictureBoxes[pictureNum].ImageLocation = Project.projectFolderPath + "\\" + subPath + "\\" + row["photo"].ToString();
            //    }
            //}
        }

        private void buttonNextSet_Click(object sender, EventArgs e)
        {
            ++set;
            buttonPreviousSet.Enabled = true;
            if ((set * 6) >= count0RSL) buttonNextSet.Enabled = false;
            getPictures();
            clearPictureSelection();
        }

        private void buttonPreviousSet_Click(object sender, EventArgs e)
        {
            --set;
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
