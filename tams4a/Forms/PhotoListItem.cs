using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tams4a.Forms
{
    public class PhotoListItem : Panel
    {
        public Label labelPicture = new Label();
        private Button buttonRemovePicture = new Button();
        private string photoName;
        private FormAddPhoto addPhoto;
        private string currentFolder; 

        public PhotoListItem(FormAddPhoto theAddPhoto, string thePhotoName, int location, string theCurrentFolder)
        {
            photoName = thePhotoName;
            addPhoto = theAddPhoto;
            currentFolder = theCurrentFolder;

            new ToolTip().SetToolTip(buttonRemovePicture, "Remove Photo");

            labelPicture.AutoSize = true;
            labelPicture.Location = new System.Drawing.Point(3, 8);
            labelPicture.Name = "labelPicture";
            labelPicture.Size = new System.Drawing.Size(80, 13);
            labelPicture.TabIndex = 0;
            labelPicture.Text = photoName;
            labelPicture.Click += new System.EventHandler(panel_Click);
            this.Click += new System.EventHandler(panel_Click);
            // 
            // buttonRemovePicture
            // 
            buttonRemovePicture.Image = Properties.Resources.baseremove;
            buttonRemovePicture.Location = new System.Drawing.Point(131, 3);
            buttonRemovePicture.Name = "buttonRemovePicture";
            buttonRemovePicture.Size = new System.Drawing.Size(32, 23);
            buttonRemovePicture.TabIndex = 2;
            buttonRemovePicture.UseVisualStyleBackColor = true;
            buttonRemovePicture.Click += new System.EventHandler(buttonRemovePicture_Click);


            Controls.Add(labelPicture);
            Controls.Add(buttonRemovePicture);

            Location = new System.Drawing.Point(0, location);
            Size = new System.Drawing.Size(166, 29);

        }

        private void panel_Click(object sender, EventArgs e)
        {
            addPhoto.togglePhotoListSelection(this);
            addPhoto.pictureBoxPhoto.ImageLocation = currentFolder + "\\" + photoName;
        }

        private void buttonRemovePicture_Click(object sender, EventArgs e)
        {
            addPhoto.removePhotoFromList(photoName);   
        }
    }
}
