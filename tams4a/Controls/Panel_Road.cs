using System;
using System.Windows.Forms;
using tams4a.Classes;
using System.IO;
using tams4a.Forms;

namespace tams4a.Controls
{
    public partial class Panel_Road : Panel_Module
    {
        private TamsProject Project;
        public string currentFolder;
        //public string[] listOfPhotos;
        public ModuleRoads moduleRoads;

        public Panel_Road(TamsProject theProject, ModuleRoads theModuleRoads)
        {
            InitializeComponent();
            Project = theProject;
            try
            {
                currentFolder = Project.projectFolderPath + Database.GetDataByQuery(Project.conn, "SELECT road_photos FROM photo_paths;").Rows[0][0].ToString();
            }
            catch
            {
                currentFolder = null;
            }

            moduleRoads = theModuleRoads;
            //listOfPhotos = moduleRoads.listOfPhotos;
            

            numericUpDownSpeedLimit.ValueChanged += moduleValueChanged;
            numericUpDownLanes.ValueChanged += moduleValueChanged;
            textBoxFrom.TextChanged += moduleValueChanged;
            textBoxTo.TextChanged += moduleValueChanged;
            textBoxRoadName.TextChanged += moduleValueChanged;
            comboBoxSurface.TextChanged += moduleValueChanged;
            comboBoxType.TextChanged += moduleValueChanged;
            comboBoxTreatment.TextChanged += moduleValueChanged;
            inputRsl.TextChanged += moduleValueChanged;
            textBoxWidth.TextChanged += widthChanged;
            textBoxLength.TextChanged += lengthChanged;

            checkDistressValues();


            AutoScroll = true;
        }

        private void checkDistressValues()
        {
            if (distress1.Value >= 0) comboBoxSurface.Enabled = false;
            if (distress2.Value >= 0) comboBoxSurface.Enabled = false;
            if (distress3.Value >= 0) comboBoxSurface.Enabled = false;
            if (distress4.Value >= 0) comboBoxSurface.Enabled = false;
            if (distress5.Value >= 0) comboBoxSurface.Enabled = false;
            if (distress6.Value >= 0) comboBoxSurface.Enabled = false;
            if (distress7.Value >= 0) comboBoxSurface.Enabled = false;
            if (distress8.Value >= 0) comboBoxSurface.Enabled = false;
            if (distress9.Value >= 0) comboBoxSurface.Enabled = false;
        }

        private void lengthChanged(object sender, EventArgs e)
        {
            updateArea();
            moduleValueChanged(sender, e);
        }


        private void widthChanged(object sender, EventArgs e)
        {
            updateArea();
            moduleValueChanged(sender, e);
        }


        private void comboBoxSurfaceChanged(object sender, EventArgs e)
        {
            moduleValueChanged(sender, e);
        }

        private void comboBoxTreatmentChanged(object sender, EventArgs e)
        {
            moduleValueChanged(sender, e);
        }

        private void comboBoxTypeChanged(object sender, EventArgs e)
        {
            moduleValueChanged(sender, e);
        }
        
        private void updateArea()
        {
            try
            {
                if (textBoxWidth.Text != "" && textBoxLength.Text != "")
                {
                    Decimal width = Convert.ToDecimal(textBoxWidth.Text);
                    Decimal length = Convert.ToDecimal(textBoxLength.Text);
                    Decimal area = width * length;

                    textBoxWidth.Text = (width == 0) ? "" : width.ToString();
                    textBoxLength.Text = (length == 0) ? "" : length.ToString();
                    textBoxArea.Text = (area == 0) ? "" : area.ToString();
                }
            }
            catch
            { // nothing
            }
        }

        private void comboBoxPhotoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxPhotoList.Text))
            {
                string imageLocation = currentFolder + "\\" + comboBoxPhotoList.Text;
                if (File.Exists(imageLocation))
                {
                    pictureBoxPhoto.ImageLocation = imageLocation;
                }
                else
                {
                    Log.Warning("Missing image file: " + imageLocation);
                    pictureBoxPhoto.Image = Properties.Resources.error;
                }
            }
            else
            {
                pictureBoxPhoto.Image = Properties.Resources.nophoto;
            }
        }

        private void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            FormAddPhoto addPhoto = new FormAddPhoto(this, Project, moduleRoads.listOfPhotos);
            addPhoto.Show();
        }
    }
}
