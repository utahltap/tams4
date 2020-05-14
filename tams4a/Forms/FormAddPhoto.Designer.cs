namespace tams4a.Forms
{
    partial class FormAddPhoto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonChangeDirectory = new System.Windows.Forms.Button();
            this.buttonPreviousPhoto = new System.Windows.Forms.Button();
            this.buttonNextPhoto = new System.Windows.Forms.Button();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.textBoxPhotoFile = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.panelSegmentPhotosList = new System.Windows.Forms.Panel();
            this.buttonBrowseFile = new System.Windows.Forms.Button();
            this.buttonAddPhoto = new System.Windows.Forms.Button();
            this.labelCurrentDirectory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonChangeDirectory
            // 
            this.buttonChangeDirectory.Image = global::tams4a.Properties.Resources.foldericon;
            this.buttonChangeDirectory.Location = new System.Drawing.Point(181, 264);
            this.buttonChangeDirectory.Name = "buttonChangeDirectory";
            this.buttonChangeDirectory.Size = new System.Drawing.Size(27, 23);
            this.buttonChangeDirectory.TabIndex = 0;
            this.buttonChangeDirectory.UseVisualStyleBackColor = true;
            this.buttonChangeDirectory.Click += new System.EventHandler(this.buttonChangeDirectory_Click);
            // 
            // buttonPreviousPhoto
            // 
            this.buttonPreviousPhoto.Location = new System.Drawing.Point(214, 264);
            this.buttonPreviousPhoto.Name = "buttonPreviousPhoto";
            this.buttonPreviousPhoto.Size = new System.Drawing.Size(27, 23);
            this.buttonPreviousPhoto.TabIndex = 1;
            this.buttonPreviousPhoto.Text = "<";
            this.buttonPreviousPhoto.UseVisualStyleBackColor = true;
            this.buttonPreviousPhoto.Click += new System.EventHandler(this.buttonPreviousPhoto_Click);
            // 
            // buttonNextPhoto
            // 
            this.buttonNextPhoto.Location = new System.Drawing.Point(247, 264);
            this.buttonNextPhoto.Name = "buttonNextPhoto";
            this.buttonNextPhoto.Size = new System.Drawing.Size(27, 23);
            this.buttonNextPhoto.TabIndex = 2;
            this.buttonNextPhoto.Text = ">";
            this.buttonNextPhoto.UseVisualStyleBackColor = true;
            this.buttonNextPhoto.Click += new System.EventHandler(this.buttonNextPhoto_Click);
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.Location = new System.Drawing.Point(174, 12);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(325, 226);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 3;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // textBoxPhotoFile
            // 
            this.textBoxPhotoFile.Location = new System.Drawing.Point(280, 266);
            this.textBoxPhotoFile.Name = "textBoxPhotoFile";
            this.textBoxPhotoFile.Size = new System.Drawing.Size(100, 20);
            this.textBoxPhotoFile.TabIndex = 4;
            this.textBoxPhotoFile.TextChanged += new System.EventHandler(this.textBoxPhotoFile_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(180, 293);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(74, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(425, 292);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(74, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // panelSegmentPhotosList
            // 
            this.panelSegmentPhotosList.BackColor = System.Drawing.Color.White;
            this.panelSegmentPhotosList.Location = new System.Drawing.Point(2, 1);
            this.panelSegmentPhotosList.Name = "panelSegmentPhotosList";
            this.panelSegmentPhotosList.Size = new System.Drawing.Size(166, 323);
            this.panelSegmentPhotosList.TabIndex = 7;
            // 
            // buttonBrowseFile
            // 
            this.buttonBrowseFile.Location = new System.Drawing.Point(425, 263);
            this.buttonBrowseFile.Name = "buttonBrowseFile";
            this.buttonBrowseFile.Size = new System.Drawing.Size(74, 23);
            this.buttonBrowseFile.TabIndex = 8;
            this.buttonBrowseFile.Text = "Browse";
            this.buttonBrowseFile.UseVisualStyleBackColor = true;
            this.buttonBrowseFile.Click += new System.EventHandler(this.buttonBrowseDirectory_Click);
            // 
            // buttonAddPhoto
            // 
            this.buttonAddPhoto.Image = global::tams4a.Properties.Resources.baseadd;
            this.buttonAddPhoto.Location = new System.Drawing.Point(386, 264);
            this.buttonAddPhoto.Name = "buttonAddPhoto";
            this.buttonAddPhoto.Size = new System.Drawing.Size(31, 23);
            this.buttonAddPhoto.TabIndex = 9;
            this.buttonAddPhoto.UseVisualStyleBackColor = true;
            this.buttonAddPhoto.Click += new System.EventHandler(this.buttonAddPhoto_Click);
            // 
            // labelCurrentDirectory
            // 
            this.labelCurrentDirectory.AutoSize = true;
            this.labelCurrentDirectory.Location = new System.Drawing.Point(177, 245);
            this.labelCurrentDirectory.Name = "labelCurrentDirectory";
            this.labelCurrentDirectory.Size = new System.Drawing.Size(35, 13);
            this.labelCurrentDirectory.TabIndex = 10;
            this.labelCurrentDirectory.Text = "label1";
            // 
            // FormAddPhoto
            // 
            this.ClientSize = new System.Drawing.Size(514, 326);
            this.Controls.Add(this.labelCurrentDirectory);
            this.Controls.Add(this.buttonAddPhoto);
            this.Controls.Add(this.buttonBrowseFile);
            this.Controls.Add(this.panelSegmentPhotosList);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxPhotoFile);
            this.Controls.Add(this.pictureBoxPhoto);
            this.Controls.Add(this.buttonNextPhoto);
            this.Controls.Add(this.buttonPreviousPhoto);
            this.Controls.Add(this.buttonChangeDirectory);
            this.Name = "FormAddPhoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Segment Photos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button buttonChangeDirectory;
        private System.Windows.Forms.Button buttonPreviousPhoto;
        private System.Windows.Forms.Button buttonNextPhoto;
        public System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.TextBox textBoxPhotoFile;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Panel panelSegmentPhotosList;
        private System.Windows.Forms.Button buttonBrowseFile;
        private System.Windows.Forms.Button buttonAddPhoto;
        private System.Windows.Forms.Label labelCurrentDirectory;
    }
}