using System;
using System.Windows.Forms;
using tams4a.Classes;
using System.IO;

namespace tams4a.Controls
{
    public partial class Panel_Road : Panel_Module
    {
        private TamsProject Project;
        private string[] fileEntries;
        private bool validFolder = false;
        private int lastUsedPhotoIndex;
        private string currentFolder;

        public Panel_Road(TamsProject theProject)
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
            try
            {
                fileEntries = Directory.GetFiles(currentFolder);
                validFolder = true;
            }
            catch
            {
                validFolder = false;
            }

            numericUpDownSpeedLimit.ValueChanged += moduleValueChanged;
            numericUpDownLanes.ValueChanged += moduleValueChanged;
            textBoxFrom.TextChanged += moduleValueChanged;
            textBoxTo.TextChanged += moduleValueChanged;
            textBoxRoadName.TextChanged += moduleValueChanged;
            comboBoxSurface.TextChanged += moduleValueChanged;
            comboBoxType.TextChanged += moduleValueChanged;
            comboBoxTreatment.TextChanged += moduleValueChanged;
            textBoxPhotoFile.TextChanged += moduleValueChanged;
            inputRsl.TextChanged += moduleValueChanged;
            textBoxWidth.TextChanged += widthChanged;
            textBoxLength.TextChanged += lengthChanged;
            buttonNextPhoto.Click += buttonNextPhoto_Click;

            checkDistressValues();

            new ToolTip().SetToolTip(buttonNextPhoto, "Get Next Photo");
            new ToolTip().SetToolTip(buttonSuggest, "Get TAMS Suggestion");

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


        private bool folderIsNotValid(object sender, EventArgs e)
        {
            if (!validFolder)
            {
                MessageBox.Show("No folder for photos is specified.\n Please select the folder containing your photos.", "Please Select Folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonChangeDirectory_Click(sender, e);
                try
                {
                    fileEntries = Directory.GetFiles(currentFolder);
                    validFolder = true;
                }
                catch
                {
                    return true;
                }
            }
            return false;
        }

        private void buttonNextPhoto_Click(object sender, EventArgs e)
        {
            if (folderIsNotValid(sender, e)) return;
            updatePhotoPreview(textBoxPhotoFile, 1);
        }

        private void buttonPreviousPhoto_Click(object sender, EventArgs e)
        {
            if (folderIsNotValid(sender, e)) return;
            updatePhotoPreview(textBoxPhotoFile, -1);
        }

        private void updatePhotoPreview(TextBox file, int direction)
        {
            try
            {
                String[] splitFile;
                if (!String.IsNullOrWhiteSpace(file.Text))
                {
                    for (int i = 0; i < fileEntries.Length; i++)
                    {
                        splitFile = fileEntries[i].Split('\\');
                        if (file.Text == splitFile[splitFile.Length - 1])
                        {
                            if (direction == 1 && i == fileEntries.Length - 1) i = -1;
                            if (direction == -1 && i == 0) i = fileEntries.Length;
                            splitFile = fileEntries[i + direction].Split('\\');
                            file.Text = splitFile[splitFile.Length - 1];
                            lastUsedPhotoIndex = i + direction;
                            return;
                        }
                    }
                }
                int newPhotoIndex = 0;
                if (direction == 1 && lastUsedPhotoIndex + 1 < fileEntries.Length - 1) newPhotoIndex = lastUsedPhotoIndex + direction;
                if (direction == -1 && lastUsedPhotoIndex - 1 >= 0) newPhotoIndex = lastUsedPhotoIndex + direction;
                splitFile = fileEntries[newPhotoIndex].Split('\\');
                file.Text = splitFile[splitFile.Length - 1];
            }
            catch
            {
                //No photos found in directory
            }
        }

        private void textBoxPhotoFile_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPhotoFile.Text))
            {
                string imageLocation = currentFolder + "\\" + textBoxPhotoFile.Text;
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

        private void buttonChangeDirectory_Click(object sender, EventArgs e)
        {
            RootFolderBrowserDialog selectFolder = new RootFolderBrowserDialog();
            selectFolder.RootPath = Project.projectFolderPath;

            if (!string.IsNullOrEmpty(currentFolder))
            {
                try
                {
                    selectFolder.SelectedPath = currentFolder;
                }
                catch
                {
                    selectFolder.SelectedPath = Properties.Settings.Default.lastFolder;
                }
            }
            else
            {
                selectFolder.SelectedPath = Properties.Settings.Default.lastFolder;
            }

            if (selectFolder.ShowDialog() == DialogResult.OK)
            {
                string selectedFolder = selectFolder.SelectedPath;
                string relativePath = selectedFolder.Remove(0, Project.projectFolderPath.Length);
                Database.ExecuteNonQuery(Project.conn, "UPDATE photo_paths SET road_photos = '" + relativePath + "';");
                currentFolder = selectedFolder;
                fileEntries = Directory.GetFiles(currentFolder);
            }
        }
    }
}
