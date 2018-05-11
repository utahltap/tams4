namespace tams4a.Controls
{
    partial class Panel_Other
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.labelIcon = new System.Windows.Forms.Label();
            this.comboBoxObject = new System.Windows.Forms.ComboBox();
            this.labelObject = new System.Windows.Forms.Label();
            this.labelSurveyDate = new System.Windows.Forms.Label();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxIcon = new System.Windows.Forms.ComboBox();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.labelPhoto = new System.Windows.Forms.Label();
            this.buttonNextPhoto = new System.Windows.Forms.Button();
            this.textBoxPhotoFile = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.groupBoxType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(224, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::tams4a.Properties.Resources.save;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.ToolTipText = "Save Data Entry";
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.pictureBoxPhoto);
            this.groupBoxType.Controls.Add(this.labelPhoto);
            this.groupBoxType.Controls.Add(this.buttonNextPhoto);
            this.groupBoxType.Controls.Add(this.textBoxPhotoFile);
            this.groupBoxType.Controls.Add(this.comboBoxIcon);
            this.groupBoxType.Controls.Add(this.textBoxDescription);
            this.groupBoxType.Controls.Add(this.labelDescription);
            this.groupBoxType.Controls.Add(this.labelIcon);
            this.groupBoxType.Controls.Add(this.comboBoxObject);
            this.groupBoxType.Controls.Add(this.labelObject);
            this.groupBoxType.Controls.Add(this.labelSurveyDate);
            this.groupBoxType.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxType.Location = new System.Drawing.Point(0, 25);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(224, 208);
            this.groupBoxType.TabIndex = 1;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "Type";
            // 
            // labelIcon
            // 
            this.labelIcon.AutoSize = true;
            this.labelIcon.Location = new System.Drawing.Point(11, 64);
            this.labelIcon.Name = "labelIcon";
            this.labelIcon.Size = new System.Drawing.Size(28, 13);
            this.labelIcon.TabIndex = 3;
            this.labelIcon.Text = "Icon";
            // 
            // comboBoxObject
            // 
            this.comboBoxObject.FormattingEnabled = true;
            this.comboBoxObject.Location = new System.Drawing.Point(89, 36);
            this.comboBoxObject.Name = "comboBoxObject";
            this.comboBoxObject.Size = new System.Drawing.Size(112, 21);
            this.comboBoxObject.TabIndex = 2;
            // 
            // labelObject
            // 
            this.labelObject.AutoSize = true;
            this.labelObject.Location = new System.Drawing.Point(11, 39);
            this.labelObject.Name = "labelObject";
            this.labelObject.Size = new System.Drawing.Size(38, 13);
            this.labelObject.TabIndex = 1;
            this.labelObject.Text = "Object";
            // 
            // labelSurveyDate
            // 
            this.labelSurveyDate.AutoSize = true;
            this.labelSurveyDate.Location = new System.Drawing.Point(11, 18);
            this.labelSurveyDate.Name = "labelSurveyDate";
            this.labelSurveyDate.Size = new System.Drawing.Size(62, 13);
            this.labelSurveyDate.TabIndex = 0;
            this.labelSurveyDate.Text = "survey date";
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxProperties.Location = new System.Drawing.Point(0, 239);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(224, 430);
            this.groupBoxProperties.TabIndex = 2;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Properties";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(11, 87);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Description";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(89, 85);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(112, 20);
            this.textBoxDescription.TabIndex = 5;
            // 
            // comboBoxIcon
            // 
            this.comboBoxIcon.FormattingEnabled = true;
            this.comboBoxIcon.Location = new System.Drawing.Point(89, 61);
            this.comboBoxIcon.Name = "comboBoxIcon";
            this.comboBoxIcon.Size = new System.Drawing.Size(112, 21);
            this.comboBoxIcon.TabIndex = 6;
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPhoto.InitialImage = global::tams4a.Properties.Resources.nophoto;
            this.pictureBoxPhoto.Location = new System.Drawing.Point(111, 133);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(90, 64);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 23;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // labelPhoto
            // 
            this.labelPhoto.AutoSize = true;
            this.labelPhoto.Location = new System.Drawing.Point(14, 109);
            this.labelPhoto.Name = "labelPhoto";
            this.labelPhoto.Size = new System.Drawing.Size(54, 13);
            this.labelPhoto.TabIndex = 22;
            this.labelPhoto.Text = "Photo File";
            // 
            // buttonNextPhoto
            // 
            this.buttonNextPhoto.Location = new System.Drawing.Point(89, 108);
            this.buttonNextPhoto.Name = "buttonNextPhoto";
            this.buttonNextPhoto.Size = new System.Drawing.Size(20, 20);
            this.buttonNextPhoto.TabIndex = 21;
            this.buttonNextPhoto.Text = ">";
            this.buttonNextPhoto.UseVisualStyleBackColor = true;
            // 
            // textBoxPhotoFile
            // 
            this.textBoxPhotoFile.Location = new System.Drawing.Point(111, 108);
            this.textBoxPhotoFile.Name = "textBoxPhotoFile";
            this.textBoxPhotoFile.Size = new System.Drawing.Size(90, 20);
            this.textBoxPhotoFile.TabIndex = 20;
            this.textBoxPhotoFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Panel_Other
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxProperties);
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Panel_Other";
            this.Size = new System.Drawing.Size(224, 669);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.GroupBox groupBoxProperties;
        private System.Windows.Forms.ComboBox comboBoxObject;
        private System.Windows.Forms.Label labelObject;
        private System.Windows.Forms.Label labelSurveyDate;
        private System.Windows.Forms.Label labelIcon;
        private System.Windows.Forms.ComboBox comboBoxIcon;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        public System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.Label labelPhoto;
        public System.Windows.Forms.Button buttonNextPhoto;
        public System.Windows.Forms.TextBox textBoxPhotoFile;
    }
}
