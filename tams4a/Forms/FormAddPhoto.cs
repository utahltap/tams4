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
        private string[] listOfPhotos;
        private TamsProject Project;

        //new ToolTip().SetToolTip(buttonNextPhoto, "Get Next Photo");
        //new ToolTip().SetToolTip(buttonSuggest, "Get TAMS Suggestion");

        public FormAddPhoto(Panel_Road existingPanel, TamsProject theProject, string[] theListOfPhotos)
        {
            panelRoad = existingPanel;
            Project = theProject;
            InitializeComponent();
            listOfPhotos = theListOfPhotos;

            int rowIndex = 0;
            foreach (string photo in listOfPhotos)
            {
                Console.WriteLine(photo);
                Label newLabel = new Label();
                newLabel.Size = new System.Drawing.Size(100, 15);
                newLabel.Text = photo;
                newLabel.Location = new System.Drawing.Point(5, ((rowIndex * 20) + 5));
                panelSegmentPhotosList.Controls.Add(newLabel);
                rowIndex++;
            }

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
            }
        }

        private void buttonBrowseDirectory_Click(object sender, EventArgs e)
        {
            //// User select file
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = panelRoad.currentFolder;
            openDialog.Filter = "JPG Files|*.JPG|PNG Files|*.PNG";
            openDialog.Multiselect = false;

            //String prettyType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(type);
            //if (prettyType != "") { prettyType += " "; } // add space to make it look right

            openDialog.Title = "Open Image";
            DialogResult openDialogResult = openDialog.ShowDialog();
            if (openDialogResult != DialogResult.OK) { return; }

            string[] pathToImage = openDialog.FileName.Split('\\');
            textBoxPhotoFile.Text = pathToImage[pathToImage.Length - 1];
                    
            //// now try to open the file
            //try
            //{
            //    openFile(openDialog.FileName, type);
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("An error occured while trying to open the shape file. Please ensure the file is of the correct type for the module used.");
            //    Log.Error("Could not open shape file. " + Environment.NewLine + e.ToString());
            //    close();
            //    return false;
            //}
        }

    }
}
