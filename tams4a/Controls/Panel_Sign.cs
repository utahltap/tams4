using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using tams4a.Classes;

namespace tams4a.Controls
{
    public partial class Panel_Sign : Panel_Module
    {
        private TamsProject Project;
        private string[] fileEntriesSupport;
        private string[] fileEntriesSign;
        private bool validSupportFolder = false;
        private bool validSignFolder = false;
        private int lastUsedSupportPhotoIndex;
        private int lastUsedSignPhotoIndex;
        private string currentSupportFolder;
        private string currentSignFolder;

        public Panel_Sign(TamsProject theProject)
        {
            InitializeComponent();
            Project = theProject;

            string supportPhotos = Database.GetDataByQuery(Project.conn, "SELECT support_photos FROM photo_paths;").Rows[0][0].ToString();
            currentSupportFolder = Project.projectFolderPath + supportPhotos;

            if (string.IsNullOrEmpty(supportPhotos))
            {
                validSupportFolder = false;
            }
            else
            {
                try
                {
                    fileEntriesSupport = Directory.GetFiles(currentSupportFolder);
                    validSupportFolder = true;
                }
                catch
                {
                    validSupportFolder = false;
                }
            }

            string signPhotos = Database.GetDataByQuery(Project.conn, "SELECT sign_photos FROM photo_paths;").Rows[0][0].ToString();
            currentSignFolder = Project.projectFolderPath + signPhotos;

            if (string.IsNullOrEmpty(signPhotos))
            {
                validSignFolder = false;
            }
            else
            {
                try
                {
                    fileEntriesSign = Directory.GetFiles(currentSignFolder);
                    validSignFolder = true;
                }
                catch
                {
                    validSignFolder = false;
                }
            }

            textBoxAddress.TextChanged += moduleValueChanged;
            comboBoxMaterial.SelectionChangeCommitted += moduleValueChanged;
            comboBoxCondition.SelectionChangeCommitted += moduleValueChanged;
            comboBoxObstruction.SelectedValueChanged += moduleValueChanged;
            numericUpDownOffset.ValueChanged += moduleValueChanged;
            comboBoxSupportRecommendation.SelectedValueChanged += moduleValueChanged;
            textBoxType.TextChanged += moduleValueChanged;
            textBoxDescription.TextChanged += moduleValueChanged;
            comboBoxSheeting.SelectedValueChanged += moduleValueChanged;
            comboBoxBacking.SelectedValueChanged += moduleValueChanged;
            numericUpDownHeightSign.ValueChanged += moduleValueChanged;
            numericUpDownWidth.ValueChanged += moduleValueChanged;
            numericUpDownMountHeight.ValueChanged += moduleValueChanged;
            textBoxInstall.TextChanged += moduleValueChanged;
            textBoxText.TextChanged += moduleValueChanged;
            comboBoxReflectivity.SelectionChangeCommitted += moduleValueChanged;
            comboBoxConditionSign.SelectedValueChanged += moduleValueChanged;
            comboBoxDirection.SelectedValueChanged += moduleValueChanged;
            textBoxPhotoPost.TextChanged += moduleValueChanged;
            textBoxPhotoSign.TextChanged += moduleValueChanged;

            new ToolTip().SetToolTip(buttonAdd, "Add New Sign to Post");
            new ToolTip().SetToolTip(buttonRemove, "Remove Sign from Post");
            new ToolTip().SetToolTip(buttonInstallDate, "Set Install Date of Sign");
            new ToolTip().SetToolTip(buttonFavorite, "Add Sign to Favorites");
            new ToolTip().SetToolTip(buttonSignNote, "Add Note to Sign");
            new ToolTip().SetToolTip(buttonNextPhotoSign, "Get Next Photo");

            AutoScroll = true;
        }



        private void buttonSheetingInfo_Click(object sender, EventArgs e)
        {
            String openPDFFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SheetingGuide.pdf";
            File.WriteAllBytes(openPDFFile, Properties.Resources.SheetingGuide);      
            Process.Start(openPDFFile);
        }

        private void textBoxPhotoPost_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPhotoPost.Text))
            {
                string imageLocation = currentSupportFolder + "\\" + textBoxPhotoPost.Text;
                if (File.Exists(imageLocation))
                {
                    pictureBoxPhotoPost.ImageLocation = imageLocation;
                }
                else
                {
                    Log.Warning("Missing image file: " + imageLocation);
                    pictureBoxPhotoPost.Image = Properties.Resources.error;
                }
            }
            else
            {
                pictureBoxPhotoPost.Image = Properties.Resources.nophoto;
            }
        }

        private void textBoxPhotoFile_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPhotoSign.Text))
            {
                string imageLocation = currentSignFolder + "\\" + textBoxPhotoSign.Text;
                if (File.Exists(imageLocation))
                {
                    pictureBoxPhotoSign.ImageLocation = imageLocation;
                }
                else
                {
                    Log.Warning("Missing image file: " + imageLocation);
                    pictureBoxPhotoSign.Image = Properties.Resources.error;
                }
            }
            else
            {
                pictureBoxPhotoSign.Image = Properties.Resources.nophoto;
            }
        }

        private bool supportFolderIsNotValid(object sender, EventArgs e)
        {
            if (!validSupportFolder)
            {
                MessageBox.Show("No folder for photos is specified.\n Please select the folder containing your photos.", "Please Select Folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonChangeSupportDirectory_Click(sender, e);
                try
                {
                    fileEntriesSupport = Directory.GetFiles(currentSupportFolder);
                    validSupportFolder = true;
                }
                catch
                {
                    return true;
                }
            }
            return false;
        }

        private bool signFolderIsNotValid(object sender, EventArgs e)
        {
            if (!validSignFolder)
            {
                MessageBox.Show("No folder for photos is specified.\n Please select the folder containing your photos.");
                buttonChangeSignDirectory_Click(sender, e);
                try
                {
                    fileEntriesSign = Directory.GetFiles(currentSignFolder);
                    validSignFolder = true;
                }
                catch
                {
                    return true;
                }
            }
            return false;
        }

        private void buttonNextPhotoPost_Click(object sender, EventArgs e)
        {
            if (supportFolderIsNotValid(sender, e)) return;
            updatePhotoPreview(textBoxPhotoPost, 1, fileEntriesSupport, lastUsedSupportPhotoIndex);
        }

        private void buttonPreviousPhotoPost_Click(object sender, EventArgs e)
        {
            if (supportFolderIsNotValid(sender, e)) return;
            updatePhotoPreview(textBoxPhotoPost, -1, fileEntriesSupport, lastUsedSupportPhotoIndex);
        }

        private void buttonNextPhotoSign_Click(object sender, EventArgs e)
        {
            if (signFolderIsNotValid(sender, e)) return;
            updatePhotoPreview(textBoxPhotoSign, 1, fileEntriesSign, lastUsedSignPhotoIndex);
        }

        private void buttonPreviousPhotoSign_Click(object sender, EventArgs e)
        {
            if (signFolderIsNotValid(sender, e)) return;
            updatePhotoPreview(textBoxPhotoSign, -1, fileEntriesSign, lastUsedSignPhotoIndex);
        }

        private void updatePhotoPreview(TextBox file, int direction, string[] fileEntries, int lastUsedPhotoIndex)
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

        private void buttonChangeSupportDirectory_Click(object sender, EventArgs e)
        {
            RootFolderBrowserDialog selectFolder = new RootFolderBrowserDialog();
            selectFolder.RootPath = Project.projectFolderPath;

            if (!string.IsNullOrEmpty(currentSupportFolder))
            {
                try
                {
                    selectFolder.SelectedPath = currentSupportFolder;
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
                Database.ExecuteNonQuery(Project.conn, "UPDATE photo_paths SET support_photos = '" + relativePath + "';");
                currentSupportFolder = selectedFolder;
                fileEntriesSupport = Directory.GetFiles(currentSupportFolder);
                lastUsedSupportPhotoIndex = 0;
            }
        }

        private void buttonChangeSignDirectory_Click(object sender, EventArgs e)
        {
            RootFolderBrowserDialog selectFolder = new RootFolderBrowserDialog();
            selectFolder.RootPath = Project.projectFolderPath;

            if (!string.IsNullOrEmpty(currentSignFolder))
            {
                try
                {
                    selectFolder.SelectedPath = currentSignFolder;
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
                Database.ExecuteNonQuery(Project.conn, "UPDATE photo_paths SET sign_photos = '" + relativePath + "';");
                currentSignFolder = selectedFolder;
                fileEntriesSign = Directory.GetFiles(currentSignFolder);
                lastUsedSignPhotoIndex = 0;
            }
        }
    }
}
