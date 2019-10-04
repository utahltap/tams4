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
        private string[] fileEntries;
        private int lastUsedPhotoIndex;

        public Panel_Sign(TamsProject theProject)
        {
            InitializeComponent();
            Project = theProject;
            fileEntries = Directory.GetFiles(Project.projectFolderPath + @"\Photos\");
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
                string imageLocation = Project.projectFolderPath + @"\Photos\" + textBoxPhotoPost.Text;
                if (File.Exists(imageLocation))
                {
                    pictureBoxPost.ImageLocation = imageLocation;
                }
                else
                {
                    Log.Warning("Missing image file: " + imageLocation);
                    pictureBoxPost.Image = Properties.Resources.error;
                }
            }
            else
            {
                pictureBoxPost.Image = Properties.Resources.nophoto;
            }
        }

        private void textBoxPhotoFile_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPhotoSign.Text))
            {
                string imageLocation = Project.projectFolderPath + @"\Photos\" + textBoxPhotoSign.Text;
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

        private void buttonNextPhotoPost_Click(object sender, EventArgs e)
        {
            updatePhotoPreview(textBoxPhotoPost, 1);
        }

        private void buttonPreviousPhotoPost_Click(object sender, EventArgs e)
        {
            updatePhotoPreview(textBoxPhotoPost, -1);
        }

        private void buttonNextPhotoSign_Click(object sender, EventArgs e)
        {
            updatePhotoPreview(textBoxPhotoSign, 1);
        }

        private void buttonPreviousPhotoSign_Click(object sender, EventArgs e)
        {
            updatePhotoPreview(textBoxPhotoSign, -1);
        }

        private void updatePhotoPreview(TextBox file, int direction)
        {
            String[] splitFile;
            if (!String.IsNullOrWhiteSpace(file.Text))
            {
                for (int i = 0; i < fileEntries.Length; i++)
                {
                    splitFile = fileEntries[i].Split('\\');
                    if (file.Text == splitFile[splitFile.Length - 1])
                    {
                        if (direction == 1 && i == fileEntries.Length - 1) i = 0;
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

    }
}
