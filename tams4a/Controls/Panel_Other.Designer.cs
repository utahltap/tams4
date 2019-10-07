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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_Other));
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.buttonChangeDirectory = new System.Windows.Forms.Button();
            this.buttonPreviousPhoto = new System.Windows.Forms.Button();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.labelPhoto = new System.Windows.Forms.Label();
            this.buttonNextPhoto = new System.Windows.Forms.Button();
            this.textBoxPhotoFile = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.comboBoxObject = new System.Windows.Forms.ComboBox();
            this.labelObject = new System.Windows.Forms.Label();
            this.labelSurveyDate = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonDate = new System.Windows.Forms.ToolStripDropDownButton();
            this.setTodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setOtherDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownAddObject = new System.Windows.Forms.ToolStripDropDownButton();
            this.clickMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterCoordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripMoveLandmark = new System.Windows.Forms.ToolStripButton();
            this.groupBoxType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxProperties.Location = new System.Drawing.Point(0, 248);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(220, 492);
            this.groupBoxProperties.TabIndex = 2;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Properties";
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.buttonChangeDirectory);
            this.groupBoxType.Controls.Add(this.buttonPreviousPhoto);
            this.groupBoxType.Controls.Add(this.textBoxAddress);
            this.groupBoxType.Controls.Add(this.label1);
            this.groupBoxType.Controls.Add(this.pictureBoxPhoto);
            this.groupBoxType.Controls.Add(this.labelPhoto);
            this.groupBoxType.Controls.Add(this.buttonNextPhoto);
            this.groupBoxType.Controls.Add(this.textBoxPhotoFile);
            this.groupBoxType.Controls.Add(this.textBoxDescription);
            this.groupBoxType.Controls.Add(this.labelDescription);
            this.groupBoxType.Controls.Add(this.comboBoxObject);
            this.groupBoxType.Controls.Add(this.labelObject);
            this.groupBoxType.Controls.Add(this.labelSurveyDate);
            this.groupBoxType.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxType.Location = new System.Drawing.Point(0, 25);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(220, 223);
            this.groupBoxType.TabIndex = 1;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "Type";
            // 
            // buttonChangeDirectory
            // 
            this.buttonChangeDirectory.Image = ((System.Drawing.Image)(resources.GetObject("buttonChangeDirectory.Image")));
            this.buttonChangeDirectory.Location = new System.Drawing.Point(14, 132);
            this.buttonChangeDirectory.Name = "buttonChangeDirectory";
            this.buttonChangeDirectory.Size = new System.Drawing.Size(20, 20);
            this.buttonChangeDirectory.TabIndex = 27;
            this.toolTip.SetToolTip(this.buttonChangeDirectory, "Change directory of photos");
            this.buttonChangeDirectory.UseVisualStyleBackColor = true;
            this.buttonChangeDirectory.Click += new System.EventHandler(this.buttonChangeDirectory_Click);
            // 
            // buttonPreviousPhoto
            // 
            this.buttonPreviousPhoto.Location = new System.Drawing.Point(36, 132);
            this.buttonPreviousPhoto.Name = "buttonPreviousPhoto";
            this.buttonPreviousPhoto.Size = new System.Drawing.Size(20, 20);
            this.buttonPreviousPhoto.TabIndex = 26;
            this.buttonPreviousPhoto.Text = "<";
            this.toolTip.SetToolTip(this.buttonPreviousPhoto, "Get Previous Photo");
            this.buttonPreviousPhoto.UseVisualStyleBackColor = true;
            this.buttonPreviousPhoto.Click += new System.EventHandler(this.buttonPreviousPhoto_Click);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(89, 61);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(112, 20);
            this.textBoxAddress.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Address";
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPhoto.InitialImage = global::tams4a.Properties.Resources.nophoto;
            this.pictureBoxPhoto.Location = new System.Drawing.Point(89, 132);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(112, 78);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 23;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // labelPhoto
            // 
            this.labelPhoto.AutoSize = true;
            this.labelPhoto.Location = new System.Drawing.Point(11, 108);
            this.labelPhoto.Name = "labelPhoto";
            this.labelPhoto.Size = new System.Drawing.Size(54, 13);
            this.labelPhoto.TabIndex = 22;
            this.labelPhoto.Text = "Photo File";
            // 
            // buttonNextPhoto
            // 
            this.buttonNextPhoto.Location = new System.Drawing.Point(58, 132);
            this.buttonNextPhoto.Name = "buttonNextPhoto";
            this.buttonNextPhoto.Size = new System.Drawing.Size(20, 20);
            this.buttonNextPhoto.TabIndex = 5;
            this.buttonNextPhoto.Text = ">";
            this.toolTip.SetToolTip(this.buttonNextPhoto, "Get Next Photo");
            this.buttonNextPhoto.UseVisualStyleBackColor = true;
            // 
            // textBoxPhotoFile
            // 
            this.textBoxPhotoFile.Location = new System.Drawing.Point(89, 107);
            this.textBoxPhotoFile.Name = "textBoxPhotoFile";
            this.textBoxPhotoFile.Size = new System.Drawing.Size(112, 20);
            this.textBoxPhotoFile.TabIndex = 6;
            this.textBoxPhotoFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxPhotoFile.TextChanged += new System.EventHandler(this.textBoxPhotoFile_TextChanged);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(89, 84);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(112, 20);
            this.textBoxDescription.TabIndex = 4;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(11, 86);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 25;
            this.labelDescription.Text = "Description";
            // 
            // comboBoxObject
            // 
            this.comboBoxObject.FormattingEnabled = true;
            this.comboBoxObject.Items.AddRange(new object[] {
            "Sidewalk",
            "ADA Ramp",
            "Severe Road Distress",
            "Accident",
            "Drainage",
            "Other"});
            this.comboBoxObject.Location = new System.Drawing.Point(89, 36);
            this.comboBoxObject.Name = "comboBoxObject";
            this.comboBoxObject.Size = new System.Drawing.Size(112, 21);
            this.comboBoxObject.TabIndex = 2;
            this.comboBoxObject.SelectedIndexChanged += new System.EventHandler(this.comboBoxObject_SelectedIndexChanged);
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
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSave,
            this.toolStripButtonCancel,
            this.toolStripDropDownButtonDate,
            this.toolStripSeparator1,
            this.toolStripDropDownAddObject,
            this.toolStripButtonRemove,
            this.toolStripMoveLandmark});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(220, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
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
            // toolStripButtonCancel
            // 
            this.toolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCancel.Image = global::tams4a.Properties.Resources.cancel;
            this.toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCancel.Text = "Cancel";
            this.toolStripButtonCancel.ToolTipText = "Cancel Changes";
            // 
            // toolStripDropDownButtonDate
            // 
            this.toolStripDropDownButtonDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonDate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setTodayToolStripMenuItem,
            this.setOtherDateToolStripMenuItem});
            this.toolStripDropDownButtonDate.Image = global::tams4a.Properties.Resources.calendar;
            this.toolStripDropDownButtonDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonDate.Name = "toolStripDropDownButtonDate";
            this.toolStripDropDownButtonDate.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonDate.Text = "Select Date";
            this.toolStripDropDownButtonDate.ToolTipText = "Select Date";
            // 
            // setTodayToolStripMenuItem
            // 
            this.setTodayToolStripMenuItem.Name = "setTodayToolStripMenuItem";
            this.setTodayToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.setTodayToolStripMenuItem.Text = "Set Today";
            // 
            // setOtherDateToolStripMenuItem
            // 
            this.setOtherDateToolStripMenuItem.Name = "setOtherDateToolStripMenuItem";
            this.setOtherDateToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.setOtherDateToolStripMenuItem.Text = "Set Other Date";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownAddObject
            // 
            this.toolStripDropDownAddObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownAddObject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clickMapToolStripMenuItem,
            this.enterCoordinatesToolStripMenuItem});
            this.toolStripDropDownAddObject.Image = global::tams4a.Properties.Resources.baseadd;
            this.toolStripDropDownAddObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownAddObject.Name = "toolStripDropDownAddObject";
            this.toolStripDropDownAddObject.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownAddObject.Text = "Add Object";
            this.toolStripDropDownAddObject.ToolTipText = "Add Landmark";
            // 
            // clickMapToolStripMenuItem
            // 
            this.clickMapToolStripMenuItem.Name = "clickMapToolStripMenuItem";
            this.clickMapToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.clickMapToolStripMenuItem.Text = "Click Map";
            // 
            // enterCoordinatesToolStripMenuItem
            // 
            this.enterCoordinatesToolStripMenuItem.Name = "enterCoordinatesToolStripMenuItem";
            this.enterCoordinatesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.enterCoordinatesToolStripMenuItem.Text = "Enter Coordinates";
            // 
            // toolStripButtonRemove
            // 
            this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemove.Enabled = false;
            this.toolStripButtonRemove.Image = global::tams4a.Properties.Resources.baseremove;
            this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemove.Name = "toolStripButtonRemove";
            this.toolStripButtonRemove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRemove.Text = "Remove Other";
            this.toolStripButtonRemove.ToolTipText = "Remove Landmark";
            // 
            // toolStripMoveLandmark
            // 
            this.toolStripMoveLandmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMoveLandmark.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMoveLandmark.Image")));
            this.toolStripMoveLandmark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMoveLandmark.Name = "toolStripMoveLandmark";
            this.toolStripMoveLandmark.Size = new System.Drawing.Size(23, 22);
            this.toolStripMoveLandmark.Text = "toolStripMoveLandmark";
            this.toolStripMoveLandmark.ToolTipText = "Move Landmark";
            // 
            // Panel_Other
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxProperties);
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.toolStrip);
            this.Name = "Panel_Other";
            this.Size = new System.Drawing.Size(220, 740);
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelObject;
        private System.Windows.Forms.Label labelSurveyDate;
        private System.Windows.Forms.Label labelDescription;
        public System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.Label labelPhoto;
        public System.Windows.Forms.Button buttonNextPhoto;
        public System.Windows.Forms.TextBox textBoxPhotoFile;
        public System.Windows.Forms.ComboBox comboBoxObject;
        public System.Windows.Forms.TextBox textBoxDescription;
        public System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolStripButton toolStripButtonSave;
        public System.Windows.Forms.ToolStripButton toolStripButtonRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton toolStripButtonCancel;
        public System.Windows.Forms.ToolStripMenuItem enterCoordinatesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clickMapToolStripMenuItem;
        public System.Windows.Forms.GroupBox groupBoxType;
        public System.Windows.Forms.GroupBox groupBoxProperties;
        public System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonDate;
        public System.Windows.Forms.ToolStripMenuItem setTodayToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem setOtherDateToolStripMenuItem;
        public System.Windows.Forms.ToolStripDropDownButton toolStripDropDownAddObject;
        public System.Windows.Forms.ToolStripButton toolStripMoveLandmark;
        public System.Windows.Forms.Button buttonPreviousPhoto;
        public System.Windows.Forms.Button buttonChangeDirectory;
    }
}
