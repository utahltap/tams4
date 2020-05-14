using System;
using System.IO;
using System.Windows.Forms;
using tams4a.Classes;
using tams4a.Controls;

namespace tams4a.Forms
{
    public partial class FormAddPhoto : Form
    {
        private Panel_Road panelRoad;
        private int lastUsedPhotoIndex;
        private bool validFolder = false;
        private string[] fileEntries;
        public string[] listOfPhotos;
        private TamsProject Project;
        private ModuleRoads moduleRoads;
        
        //new ToolTip().SetToolTip(buttonNextPhoto, "Get Next Photo");

        public FormAddPhoto(Panel_Road existingPanel, TamsProject theProject, ModuleRoads theModuleRoads)
        {
            moduleRoads = theModuleRoads;
            panelRoad = existingPanel;
            Project = theProject;
            InitializeComponent();
            listOfPhotos = moduleRoads.listOfPhotos;

            //roadControls.toolTip.SetToolTip(roadControls.pictureBoxPhoto, "");
            new ToolTip().SetToolTip(buttonAddPhoto, "Add Photo");
            new ToolTip().SetToolTip(buttonNextPhoto, "Next Photo");
            new ToolTip().SetToolTip(buttonPreviousPhoto, "Previous Photo");
            new ToolTip().SetToolTip(buttonChangeDirectory, "Change Directory");
            new ToolTip().SetToolTip(buttonBrowseFile, "Browse Directory");

            string relativePath = panelRoad.currentFolder.Remove(0, Project.projectFolderPath.Length);

            labelCurrentDirectory.Text = Project.projectFolderPath[0] + ":\\...\\Databases" + relativePath;


            populatePhotoList();

            try
            {
                fileEntries = Directory.GetFiles(panelRoad.currentFolder);
                validFolder = true;
            }
            catch
            {
                validFolder = false;
            }
        }

        private void textBoxPhotoFile_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPhotoFile.Text))
            {
                string imageLocation = panelRoad.currentFolder + "\\" + textBoxPhotoFile.Text;
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

        private bool folderIsNotValid(object sender, EventArgs e)
        {
            if (!validFolder)
            {
                MessageBox.Show("No folder for photos is specified.\n Please select the folder containing your photos.", "Please Select Folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonChangeDirectory_Click(sender, e);
                try
                {
                    fileEntries = Directory.GetFiles(panelRoad.currentFolder);
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
                MessageBox.Show("No photos found in the directory. Add photos to this directory, or switch directories.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void buttonChangeDirectory_Click(object sender, EventArgs e)
        {
            RootFolderBrowserDialog selectFolder = new RootFolderBrowserDialog();
            selectFolder.RootPath = Project.projectFolderPath;

            if (!string.IsNullOrEmpty(panelRoad.currentFolder))
            {
                try
                {
                    selectFolder.SelectedPath = panelRoad.currentFolder;
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
                panelRoad.currentFolder = selectedFolder;
                fileEntries = Directory.GetFiles(panelRoad.currentFolder);
                labelCurrentDirectory.Text = "C:\\...\\Databases" + relativePath;
            }
        }

        private void buttonBrowseDirectory_Click(object sender, EventArgs e)
        {
            // User select file
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = panelRoad.currentFolder;
            openDialog.Filter = "JPG Files|*.JPG|PNG Files|*.PNG";
            openDialog.Multiselect = false;

            openDialog.Title = "Open Image";
            DialogResult openDialogResult = openDialog.ShowDialog();
            if (openDialogResult != DialogResult.OK) { return; }

            string[] pathToImage = openDialog.FileName.Split('\\');
            textBoxPhotoFile.Text = pathToImage[pathToImage.Length - 1];
                    
        }

        private void populatePhotoList()
        {
            panelSegmentPhotosList.Controls.Clear();
            int rowIndex = 0;
            foreach (string photo in listOfPhotos)
            {
                PhotoListItem newItem = new PhotoListItem(this, photo, (rowIndex * 30) + 3, panelRoad.currentFolder);
                panelSegmentPhotosList.Controls.Add(newItem);
                rowIndex++;
            }
        }

        public void togglePhotoListSelection(PhotoListItem clickedItem)
        {
            foreach(PhotoListItem listItem in panelSegmentPhotosList.Controls)
            {
                listItem.BorderStyle = BorderStyle.None;
            }
            clickedItem.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhotoFile.Text = clickedItem.labelPicture.Text;

        }

        private void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            string photoName = textBoxPhotoFile.Text;
            if(string.IsNullOrEmpty(photoName))
            {
                MessageBox.Show("No photo selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] tempPhotoList = new string[listOfPhotos.Length + 1];
            int i = 0;

            foreach (string photo in listOfPhotos)
            {
                if(photoName == photo)
                {
                    MessageBox.Show("The Photo is already included for this road segment.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                tempPhotoList[i] = photo;
                i++;
            }
            tempPhotoList[i] = photoName;

            listOfPhotos = tempPhotoList;
            populatePhotoList();
        }
    

        public void removePhotoFromList(string photoName)
        {
            string[] tempPhotoList = new string[listOfPhotos.Length - 1];
            int i = 0;

            foreach (string photo in listOfPhotos)
            {
                // don't include the photo to remove
                if (photoName == photo)
                {
                    continue;
                }
                tempPhotoList[i] = photo;
                i++;
            }
            listOfPhotos = tempPhotoList;
            populatePhotoList();
        }

        

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // Check if the list of photos has changed
            if(moduleRoads.listOfPhotos == listOfPhotos)
            {
                Close();
                return;
            }

            // create a comma separated string from list of photos
            string photoListString = "";
            int i = 0;
            foreach (string photo in listOfPhotos)
            {
                photoListString += photo;
                if (i != listOfPhotos.Length - 1)
                {
                    photoListString += "/ ";
                }
                i++;
            }
            moduleRoads.setListOfPhotos(listOfPhotos, photoListString);

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
