namespace tams4a.Forms
{
    partial class FormPicture
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonPreviousPhoto = new System.Windows.Forms.Button();
            this.buttonNextPhoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(737, 542);
            this.buttonOK.MaximumSize = new System.Drawing.Size(101, 33);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(101, 33);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(854, 513);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // buttonPreviousPhoto
            // 
            this.buttonPreviousPhoto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPreviousPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPreviousPhoto.Location = new System.Drawing.Point(336, 533);
            this.buttonPreviousPhoto.Name = "buttonPreviousPhoto";
            this.buttonPreviousPhoto.Size = new System.Drawing.Size(75, 51);
            this.buttonPreviousPhoto.TabIndex = 2;
            this.buttonPreviousPhoto.Text = "<";
            this.buttonPreviousPhoto.UseVisualStyleBackColor = true;
            this.buttonPreviousPhoto.Click += new System.EventHandler(this.buttonPreviousPhoto_Click);
            // 
            // buttonNextPhoto
            // 
            this.buttonNextPhoto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonNextPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNextPhoto.Location = new System.Drawing.Point(417, 533);
            this.buttonNextPhoto.Name = "buttonNextPhoto";
            this.buttonNextPhoto.Size = new System.Drawing.Size(75, 51);
            this.buttonNextPhoto.TabIndex = 3;
            this.buttonNextPhoto.Tag = "";
            this.buttonNextPhoto.Text = ">";
            this.buttonNextPhoto.UseVisualStyleBackColor = true;
            this.buttonNextPhoto.Click += new System.EventHandler(this.buttonNextPhoto_Click);
            // 
            // FormPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 597);
            this.Controls.Add(this.buttonNextPhoto);
            this.Controls.Add(this.buttonPreviousPhoto);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.pictureBox);
            this.MinimumSize = new System.Drawing.Size(866, 636);
            this.Name = "FormPicture";
            this.Text = "Picture";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonPreviousPhoto;
        private System.Windows.Forms.Button buttonNextPhoto;
    }
}