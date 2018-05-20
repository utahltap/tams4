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
            this.toolStripDropDownAddObject = new System.Windows.Forms.ToolStripDropDownButton();
            this.enterCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clickMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.labelPhoto = new System.Windows.Forms.Label();
            this.buttonNextPhoto = new System.Windows.Forms.Button();
            this.textBoxPhotoFile = new System.Windows.Forms.TextBox();
            this.comboBoxIcon = new System.Windows.Forms.ComboBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelIcon = new System.Windows.Forms.Label();
            this.comboBoxObject = new System.Windows.Forms.ComboBox();
            this.labelObject = new System.Windows.Forms.Label();
            this.labelSurveyDate = new System.Windows.Forms.Label();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.toolStrip1.SuspendLayout();
            this.groupBoxType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripDropDownAddObject,
            this.toolStripButtonRemove});
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
            // toolStripDropDownAddObject
            // 
            this.toolStripDropDownAddObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownAddObject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterCoordinatesToolStripMenuItem,
            this.clickMapToolStripMenuItem});
            this.toolStripDropDownAddObject.Image = global::tams4a.Properties.Resources.baseadd;
            this.toolStripDropDownAddObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownAddObject.Name = "toolStripDropDownAddObject";
            this.toolStripDropDownAddObject.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownAddObject.Text = "Add Object";
            this.toolStripDropDownAddObject.ToolTipText = "Add Landmark";
            // 
            // enterCoordinatesToolStripMenuItem
            // 
            this.enterCoordinatesToolStripMenuItem.Name = "enterCoordinatesToolStripMenuItem";
            this.enterCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.enterCoordinatesToolStripMenuItem.Text = "Enter Coordinates";
            // 
            // clickMapToolStripMenuItem
            // 
            this.clickMapToolStripMenuItem.Name = "clickMapToolStripMenuItem";
            this.clickMapToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clickMapToolStripMenuItem.Text = "Click Map";
            // 
            // toolStripButtonRemove
            // 
            this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemove.Image = global::tams4a.Properties.Resources.baseremove;
            this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemove.Name = "toolStripButtonRemove";
            this.toolStripButtonRemove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRemove.Text = "Remove Other";
            this.toolStripButtonRemove.ToolTipText = "Remove Landmark";
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.textBoxAddress);
            this.groupBoxType.Controls.Add(this.label1);
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
            this.groupBoxType.Size = new System.Drawing.Size(224, 232);
            this.groupBoxType.TabIndex = 1;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "Type";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(89, 85);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(112, 20);
            this.textBoxAddress.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Address";
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPhoto.InitialImage = global::tams4a.Properties.Resources.nophoto;
            this.pictureBoxPhoto.Location = new System.Drawing.Point(111, 156);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(90, 64);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 23;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // labelPhoto
            // 
            this.labelPhoto.AutoSize = true;
            this.labelPhoto.Location = new System.Drawing.Point(14, 132);
            this.labelPhoto.Name = "labelPhoto";
            this.labelPhoto.Size = new System.Drawing.Size(54, 13);
            this.labelPhoto.TabIndex = 22;
            this.labelPhoto.Text = "Photo File";
            // 
            // buttonNextPhoto
            // 
            this.buttonNextPhoto.Location = new System.Drawing.Point(89, 131);
            this.buttonNextPhoto.Name = "buttonNextPhoto";
            this.buttonNextPhoto.Size = new System.Drawing.Size(20, 20);
            this.buttonNextPhoto.TabIndex = 21;
            this.buttonNextPhoto.Text = ">";
            this.buttonNextPhoto.UseVisualStyleBackColor = true;
            // 
            // textBoxPhotoFile
            // 
            this.textBoxPhotoFile.Location = new System.Drawing.Point(111, 131);
            this.textBoxPhotoFile.Name = "textBoxPhotoFile";
            this.textBoxPhotoFile.Size = new System.Drawing.Size(90, 20);
            this.textBoxPhotoFile.TabIndex = 20;
            this.textBoxPhotoFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxIcon
            // 
            this.comboBoxIcon.FormattingEnabled = true;
            this.comboBoxIcon.Location = new System.Drawing.Point(89, 61);
            this.comboBoxIcon.Name = "comboBoxIcon";
            this.comboBoxIcon.Size = new System.Drawing.Size(112, 21);
            this.comboBoxIcon.TabIndex = 6;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(89, 108);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(112, 20);
            this.textBoxDescription.TabIndex = 5;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(11, 110);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Description";
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
            this.comboBoxObject.Items.AddRange(new object[] {
            "Sidewalk",
            "ADA Ramp",
            "Severe Road Distress",
            "Accident Hotspot",
            "Other"});
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
            this.groupBoxProperties.Location = new System.Drawing.Point(0, 263);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(224, 406);
            this.groupBoxProperties.TabIndex = 2;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Properties";
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
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.GroupBox groupBoxProperties;
        private System.Windows.Forms.Label labelObject;
        private System.Windows.Forms.Label labelSurveyDate;
        private System.Windows.Forms.Label labelIcon;
        private System.Windows.Forms.Label labelDescription;
        public System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.Label labelPhoto;
        public System.Windows.Forms.Button buttonNextPhoto;
        public System.Windows.Forms.TextBox textBoxPhotoFile;
        public System.Windows.Forms.ComboBox comboBoxObject;
        public System.Windows.Forms.ComboBox comboBoxIcon;
        public System.Windows.Forms.TextBox textBoxDescription;
        public System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownAddObject;
        private System.Windows.Forms.ToolStripMenuItem enterCoordinatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clickMapToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton toolStripButtonRemove;
    }
}
