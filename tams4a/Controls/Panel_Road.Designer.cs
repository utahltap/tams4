

namespace tams4a.Controls
{
    partial class Panel_Road
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
            this.groupBoxDistress = new System.Windows.Forms.GroupBox();
            this.buttonSuggest = new System.Windows.Forms.Button();
            this.inputRsl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSuggestedTreatment = new System.Windows.Forms.Label();
            this.comboBoxTreatment = new System.Windows.Forms.ComboBox();
            this.distress9 = new tams4a.Controls.DistressEntry();
            this.distress8 = new tams4a.Controls.DistressEntry();
            this.distress7 = new tams4a.Controls.DistressEntry();
            this.distress6 = new tams4a.Controls.DistressEntry();
            this.distress5 = new tams4a.Controls.DistressEntry();
            this.distress4 = new tams4a.Controls.DistressEntry();
            this.distress3 = new tams4a.Controls.DistressEntry();
            this.distress2 = new tams4a.Controls.DistressEntry();
            this.distress1 = new tams4a.Controls.DistressEntry();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.buttonAddPhoto = new System.Windows.Forms.Button();
            this.comboBoxPhotoList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMPH = new System.Windows.Forms.Label();
            this.numericUpDownLanes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSpeedLimit = new System.Windows.Forms.NumericUpDown();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxRoadName = new System.Windows.Forms.TextBox();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.labelPhoto = new System.Windows.Forms.Label();
            this.labelSurface = new System.Windows.Forms.Label();
            this.comboBoxSurface = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.labelLength = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.textBoxArea = new System.Windows.Forms.TextBox();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.labelLanes = new System.Windows.Forms.Label();
            this.labelSpeedLimit = new System.Windows.Forms.Label();
            this.labelSurveyDate = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonSave = new System.Windows.Forms.ToolStripButton();
            this.buttonReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonSetDate = new System.Windows.Forms.ToolStripDropDownButton();
            this.setTodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setOtherDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonHistory = new System.Windows.Forms.ToolStripButton();
            this.btnNotes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAnalysis = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSidewalk = new System.Windows.Forms.ToolStripButton();
            this.groupBoxDistress.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLanes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeedLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDistress
            // 
            this.groupBoxDistress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDistress.Controls.Add(this.buttonSuggest);
            this.groupBoxDistress.Controls.Add(this.inputRsl);
            this.groupBoxDistress.Controls.Add(this.label4);
            this.groupBoxDistress.Controls.Add(this.labelSuggestedTreatment);
            this.groupBoxDistress.Controls.Add(this.comboBoxTreatment);
            this.groupBoxDistress.Controls.Add(this.distress9);
            this.groupBoxDistress.Controls.Add(this.distress8);
            this.groupBoxDistress.Controls.Add(this.distress7);
            this.groupBoxDistress.Controls.Add(this.distress6);
            this.groupBoxDistress.Controls.Add(this.distress5);
            this.groupBoxDistress.Controls.Add(this.distress4);
            this.groupBoxDistress.Controls.Add(this.distress3);
            this.groupBoxDistress.Controls.Add(this.distress2);
            this.groupBoxDistress.Controls.Add(this.distress1);
            this.groupBoxDistress.Location = new System.Drawing.Point(0, 476);
            this.groupBoxDistress.MinimumSize = new System.Drawing.Size(0, 100);
            this.groupBoxDistress.Name = "groupBoxDistress";
            this.groupBoxDistress.Size = new System.Drawing.Size(220, 308);
            this.groupBoxDistress.TabIndex = 33;
            this.groupBoxDistress.TabStop = false;
            this.groupBoxDistress.Text = "Distresses";
            // 
            // buttonSuggest
            // 
            this.buttonSuggest.Image = global::tams4a.Properties.Resources.suggest;
            this.buttonSuggest.Location = new System.Drawing.Point(79, 245);
            this.buttonSuggest.Name = "buttonSuggest";
            this.buttonSuggest.Size = new System.Drawing.Size(24, 23);
            this.buttonSuggest.TabIndex = 34;
            this.buttonSuggest.UseVisualStyleBackColor = true;
            // 
            // inputRsl
            // 
            this.inputRsl.Location = new System.Drawing.Point(105, 246);
            this.inputRsl.Name = "inputRsl";
            this.inputRsl.Size = new System.Drawing.Size(90, 20);
            this.inputRsl.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "RSL";
            // 
            // labelSuggestedTreatment
            // 
            this.labelSuggestedTreatment.AutoSize = true;
            this.labelSuggestedTreatment.Location = new System.Drawing.Point(8, 278);
            this.labelSuggestedTreatment.Name = "labelSuggestedTreatment";
            this.labelSuggestedTreatment.Size = new System.Drawing.Size(55, 13);
            this.labelSuggestedTreatment.TabIndex = 37;
            this.labelSuggestedTreatment.Text = "Treatment";
            // 
            // comboBoxTreatment
            // 
            this.comboBoxTreatment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTreatment.DropDownWidth = 250;
            this.comboBoxTreatment.FormattingEnabled = true;
            this.comboBoxTreatment.Items.AddRange(new object[] {
            "",
            "Nothing",
            "Routine",
            "Patching",
            "Preventative",
            "Preventative with Patching",
            "Rehabilitation",
            "Reconstruction"});
            this.comboBoxTreatment.Location = new System.Drawing.Point(83, 272);
            this.comboBoxTreatment.Name = "comboBoxTreatment";
            this.comboBoxTreatment.Size = new System.Drawing.Size(112, 21);
            this.comboBoxTreatment.TabIndex = 36;
            this.comboBoxTreatment.SelectedIndexChanged += new System.EventHandler(this.comboBoxTreatmentChanged);
            // 
            // distress9
            // 
            this.distress9.BackColor = System.Drawing.Color.Transparent;
            this.distress9.DataId = 0;
            this.distress9.Description = "";
            this.distress9.IllustrationName = null;
            this.distress9.Label = "Distress Type";
            this.distress9.Location = new System.Drawing.Point(5, 217);
            this.distress9.Margin = new System.Windows.Forms.Padding(1);
            this.distress9.MaxDistress = 0;
            this.distress9.Name = "distress9";
            this.distress9.Size = new System.Drawing.Size(190, 20);
            this.distress9.TabIndex = 8;
            this.distress9.Value = -1;
            this.distress9.Visible = false;
            // 
            // distress8
            // 
            this.distress8.BackColor = System.Drawing.Color.Transparent;
            this.distress8.DataId = 0;
            this.distress8.Description = "";
            this.distress8.IllustrationName = null;
            this.distress8.Label = "Distress Type";
            this.distress8.Location = new System.Drawing.Point(5, 195);
            this.distress8.Margin = new System.Windows.Forms.Padding(1);
            this.distress8.MaxDistress = 0;
            this.distress8.Name = "distress8";
            this.distress8.Size = new System.Drawing.Size(190, 20);
            this.distress8.TabIndex = 7;
            this.distress8.Value = -1;
            this.distress8.Visible = false;
            // 
            // distress7
            // 
            this.distress7.BackColor = System.Drawing.Color.Transparent;
            this.distress7.DataId = 0;
            this.distress7.Description = "";
            this.distress7.IllustrationName = null;
            this.distress7.Label = "Distress Type";
            this.distress7.Location = new System.Drawing.Point(5, 173);
            this.distress7.Margin = new System.Windows.Forms.Padding(1);
            this.distress7.MaxDistress = 0;
            this.distress7.Name = "distress7";
            this.distress7.Size = new System.Drawing.Size(190, 20);
            this.distress7.TabIndex = 6;
            this.distress7.Value = -1;
            this.distress7.Visible = false;
            // 
            // distress6
            // 
            this.distress6.BackColor = System.Drawing.Color.Transparent;
            this.distress6.DataId = 0;
            this.distress6.Description = "";
            this.distress6.IllustrationName = null;
            this.distress6.Label = "Distress Type";
            this.distress6.Location = new System.Drawing.Point(5, 151);
            this.distress6.Margin = new System.Windows.Forms.Padding(1);
            this.distress6.MaxDistress = 0;
            this.distress6.Name = "distress6";
            this.distress6.Size = new System.Drawing.Size(190, 20);
            this.distress6.TabIndex = 5;
            this.distress6.Value = -1;
            this.distress6.Visible = false;
            // 
            // distress5
            // 
            this.distress5.BackColor = System.Drawing.Color.Transparent;
            this.distress5.DataId = 0;
            this.distress5.Description = "";
            this.distress5.IllustrationName = null;
            this.distress5.Label = "Distress Type";
            this.distress5.Location = new System.Drawing.Point(5, 129);
            this.distress5.Margin = new System.Windows.Forms.Padding(1);
            this.distress5.MaxDistress = 0;
            this.distress5.Name = "distress5";
            this.distress5.Size = new System.Drawing.Size(190, 20);
            this.distress5.TabIndex = 4;
            this.distress5.Value = -1;
            this.distress5.Visible = false;
            // 
            // distress4
            // 
            this.distress4.BackColor = System.Drawing.Color.Transparent;
            this.distress4.DataId = 0;
            this.distress4.Description = "";
            this.distress4.IllustrationName = null;
            this.distress4.Label = "Distress Type";
            this.distress4.Location = new System.Drawing.Point(5, 107);
            this.distress4.Margin = new System.Windows.Forms.Padding(1);
            this.distress4.MaxDistress = 0;
            this.distress4.Name = "distress4";
            this.distress4.Size = new System.Drawing.Size(190, 20);
            this.distress4.TabIndex = 3;
            this.distress4.Value = -1;
            this.distress4.Visible = false;
            // 
            // distress3
            // 
            this.distress3.BackColor = System.Drawing.Color.Transparent;
            this.distress3.DataId = 0;
            this.distress3.Description = "";
            this.distress3.IllustrationName = null;
            this.distress3.Label = "Distress Type";
            this.distress3.Location = new System.Drawing.Point(5, 85);
            this.distress3.Margin = new System.Windows.Forms.Padding(1);
            this.distress3.MaxDistress = 0;
            this.distress3.Name = "distress3";
            this.distress3.Size = new System.Drawing.Size(190, 20);
            this.distress3.TabIndex = 2;
            this.distress3.Value = -1;
            this.distress3.Visible = false;
            // 
            // distress2
            // 
            this.distress2.BackColor = System.Drawing.Color.Transparent;
            this.distress2.DataId = 0;
            this.distress2.Description = "";
            this.distress2.IllustrationName = null;
            this.distress2.Label = "Distress Type";
            this.distress2.Location = new System.Drawing.Point(5, 63);
            this.distress2.Margin = new System.Windows.Forms.Padding(1);
            this.distress2.MaxDistress = 0;
            this.distress2.Name = "distress2";
            this.distress2.Size = new System.Drawing.Size(190, 20);
            this.distress2.TabIndex = 1;
            this.distress2.Value = -1;
            this.distress2.Visible = false;
            // 
            // distress1
            // 
            this.distress1.BackColor = System.Drawing.Color.Transparent;
            this.distress1.DataId = 0;
            this.distress1.Description = "";
            this.distress1.IllustrationName = null;
            this.distress1.Label = "Distress Type";
            this.distress1.Location = new System.Drawing.Point(5, 41);
            this.distress1.Margin = new System.Windows.Forms.Padding(1);
            this.distress1.MaxDistress = 0;
            this.distress1.Name = "distress1";
            this.distress1.Size = new System.Drawing.Size(190, 20);
            this.distress1.TabIndex = 0;
            this.distress1.Value = -1;
            this.distress1.Visible = false;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.buttonAddPhoto);
            this.groupBoxInfo.Controls.Add(this.comboBoxPhotoList);
            this.groupBoxInfo.Controls.Add(this.label3);
            this.groupBoxInfo.Controls.Add(this.label2);
            this.groupBoxInfo.Controls.Add(this.label1);
            this.groupBoxInfo.Controls.Add(this.labelMPH);
            this.groupBoxInfo.Controls.Add(this.numericUpDownLanes);
            this.groupBoxInfo.Controls.Add(this.numericUpDownSpeedLimit);
            this.groupBoxInfo.Controls.Add(this.labelTo);
            this.groupBoxInfo.Controls.Add(this.labelFrom);
            this.groupBoxInfo.Controls.Add(this.textBoxTo);
            this.groupBoxInfo.Controls.Add(this.textBoxFrom);
            this.groupBoxInfo.Controls.Add(this.textBoxRoadName);
            this.groupBoxInfo.Controls.Add(this.pictureBoxPhoto);
            this.groupBoxInfo.Controls.Add(this.labelPhoto);
            this.groupBoxInfo.Controls.Add(this.labelSurface);
            this.groupBoxInfo.Controls.Add(this.comboBoxSurface);
            this.groupBoxInfo.Controls.Add(this.comboBoxType);
            this.groupBoxInfo.Controls.Add(this.labelType);
            this.groupBoxInfo.Controls.Add(this.labelArea);
            this.groupBoxInfo.Controls.Add(this.labelLength);
            this.groupBoxInfo.Controls.Add(this.labelWidth);
            this.groupBoxInfo.Controls.Add(this.textBoxArea);
            this.groupBoxInfo.Controls.Add(this.textBoxLength);
            this.groupBoxInfo.Controls.Add(this.textBoxWidth);
            this.groupBoxInfo.Controls.Add(this.labelLanes);
            this.groupBoxInfo.Controls.Add(this.labelSpeedLimit);
            this.groupBoxInfo.Controls.Add(this.labelSurveyDate);
            this.groupBoxInfo.Controls.Add(this.labelName);
            this.groupBoxInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxInfo.Location = new System.Drawing.Point(0, 25);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(220, 445);
            this.groupBoxInfo.TabIndex = 5;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Road";
            // 
            // buttonAddPhoto
            // 
            this.buttonAddPhoto.Location = new System.Drawing.Point(83, 413);
            this.buttonAddPhoto.Name = "buttonAddPhoto";
            this.buttonAddPhoto.Size = new System.Drawing.Size(112, 23);
            this.buttonAddPhoto.TabIndex = 36;
            this.buttonAddPhoto.Text = "Edit Images";
            this.buttonAddPhoto.UseVisualStyleBackColor = true;
            this.buttonAddPhoto.Click += new System.EventHandler(this.buttonAddPhoto_Click);
            // 
            // comboBoxPhotoList
            // 
            this.comboBoxPhotoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPhotoList.FormattingEnabled = true;
            this.comboBoxPhotoList.Location = new System.Drawing.Point(82, 308);
            this.comboBoxPhotoList.Name = "comboBoxPhotoList";
            this.comboBoxPhotoList.Size = new System.Drawing.Size(113, 21);
            this.comboBoxPhotoList.TabIndex = 35;
            this.comboBoxPhotoList.SelectedIndexChanged += new System.EventHandler(this.comboBoxPhotoList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "ft";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "ft";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "ft²";
            // 
            // labelMPH
            // 
            this.labelMPH.AutoSize = true;
            this.labelMPH.Location = new System.Drawing.Point(159, 61);
            this.labelMPH.Name = "labelMPH";
            this.labelMPH.Size = new System.Drawing.Size(31, 13);
            this.labelMPH.TabIndex = 27;
            this.labelMPH.Text = "MPH";
            // 
            // numericUpDownLanes
            // 
            this.numericUpDownLanes.Location = new System.Drawing.Point(82, 83);
            this.numericUpDownLanes.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownLanes.Name = "numericUpDownLanes";
            this.numericUpDownLanes.Size = new System.Drawing.Size(111, 20);
            this.numericUpDownLanes.TabIndex = 22;
            this.numericUpDownLanes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownSpeedLimit
            // 
            this.numericUpDownSpeedLimit.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSpeedLimit.Location = new System.Drawing.Point(83, 58);
            this.numericUpDownSpeedLimit.Name = "numericUpDownSpeedLimit";
            this.numericUpDownSpeedLimit.Size = new System.Drawing.Size(76, 20);
            this.numericUpDownSpeedLimit.TabIndex = 21;
            this.numericUpDownSpeedLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(7, 139);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(61, 13);
            this.labelTo.TabIndex = 24;
            this.labelTo.Text = "To Address";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(8, 113);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(71, 13);
            this.labelFrom.TabIndex = 23;
            this.labelFrom.Text = "From Address";
            // 
            // textBoxTo
            // 
            this.textBoxTo.Location = new System.Drawing.Point(82, 136);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(112, 20);
            this.textBoxTo.TabIndex = 24;
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(82, 110);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(112, 20);
            this.textBoxFrom.TabIndex = 23;
            // 
            // textBoxRoadName
            // 
            this.textBoxRoadName.Location = new System.Drawing.Point(82, 33);
            this.textBoxRoadName.Name = "textBoxRoadName";
            this.textBoxRoadName.Size = new System.Drawing.Size(112, 20);
            this.textBoxRoadName.TabIndex = 20;
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPhoto.InitialImage = null;
            this.pictureBoxPhoto.Location = new System.Drawing.Point(82, 335);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(113, 71);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPhoto.TabIndex = 32;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // labelPhoto
            // 
            this.labelPhoto.AutoSize = true;
            this.labelPhoto.Location = new System.Drawing.Point(8, 308);
            this.labelPhoto.Name = "labelPhoto";
            this.labelPhoto.Size = new System.Drawing.Size(54, 13);
            this.labelPhoto.TabIndex = 18;
            this.labelPhoto.Text = "Photo File";
            // 
            // labelSurface
            // 
            this.labelSurface.AutoSize = true;
            this.labelSurface.Location = new System.Drawing.Point(8, 281);
            this.labelSurface.Name = "labelSurface";
            this.labelSurface.Size = new System.Drawing.Size(44, 13);
            this.labelSurface.TabIndex = 15;
            this.labelSurface.Text = "Surface";
            // 
            // comboBoxSurface
            // 
            this.comboBoxSurface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSurface.FormattingEnabled = true;
            this.comboBoxSurface.Location = new System.Drawing.Point(83, 278);
            this.comboBoxSurface.Name = "comboBoxSurface";
            this.comboBoxSurface.Size = new System.Drawing.Size(112, 21);
            this.comboBoxSurface.TabIndex = 29;
            this.comboBoxSurface.SelectedIndexChanged += new System.EventHandler(this.comboBoxSurfaceChanged);
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(82, 246);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(113, 21);
            this.comboBoxType.TabIndex = 28;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeChanged);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(8, 243);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(68, 26);
            this.labelType.TabIndex = 12;
            this.labelType.Text = "Functional\r\nClassification";
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Location = new System.Drawing.Point(7, 219);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(32, 13);
            this.labelArea.TabIndex = 11;
            this.labelArea.Text = "Area ";
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Location = new System.Drawing.Point(7, 191);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(40, 13);
            this.labelLength.TabIndex = 10;
            this.labelLength.Text = "Length";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(7, 166);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 9;
            this.labelWidth.Text = "Width";
            // 
            // textBoxArea
            // 
            this.textBoxArea.Location = new System.Drawing.Point(82, 216);
            this.textBoxArea.Name = "textBoxArea";
            this.textBoxArea.ReadOnly = true;
            this.textBoxArea.Size = new System.Drawing.Size(77, 20);
            this.textBoxArea.TabIndex = 27;
            // 
            // textBoxLength
            // 
            this.textBoxLength.Location = new System.Drawing.Point(82, 188);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(77, 20);
            this.textBoxLength.TabIndex = 26;
            this.textBoxLength.TextChanged += new System.EventHandler(this.lengthChanged);
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(82, 162);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(77, 20);
            this.textBoxWidth.TabIndex = 25;
            this.textBoxWidth.TextChanged += new System.EventHandler(this.widthChanged);
            // 
            // labelLanes
            // 
            this.labelLanes.AutoSize = true;
            this.labelLanes.Location = new System.Drawing.Point(8, 85);
            this.labelLanes.Name = "labelLanes";
            this.labelLanes.Size = new System.Drawing.Size(36, 13);
            this.labelLanes.TabIndex = 4;
            this.labelLanes.Text = "Lanes";
            // 
            // labelSpeedLimit
            // 
            this.labelSpeedLimit.AutoSize = true;
            this.labelSpeedLimit.Location = new System.Drawing.Point(8, 61);
            this.labelSpeedLimit.Name = "labelSpeedLimit";
            this.labelSpeedLimit.Size = new System.Drawing.Size(62, 13);
            this.labelSpeedLimit.TabIndex = 2;
            this.labelSpeedLimit.Text = "Speed Limit";
            // 
            // labelSurveyDate
            // 
            this.labelSurveyDate.AutoSize = true;
            this.labelSurveyDate.Location = new System.Drawing.Point(7, 16);
            this.labelSurveyDate.Name = "labelSurveyDate";
            this.labelSurveyDate.Size = new System.Drawing.Size(66, 13);
            this.labelSurveyDate.TabIndex = 1;
            this.labelSurveyDate.Text = "Survey Date";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(7, 36);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(33, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Road";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSave,
            this.buttonReset,
            this.toolStripSeparator1,
            this.buttonSetDate,
            this.buttonHistory,
            this.btnNotes,
            this.toolStripSeparator2,
            this.toolStripButtonAnalysis,
            this.toolStripButtonSidewalk});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.MinimumSize = new System.Drawing.Size(200, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(220, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // buttonSave
            // 
            this.buttonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSave.Enabled = false;
            this.buttonSave.Image = global::tams4a.Properties.Resources.save;
            this.buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(23, 22);
            this.buttonSave.Text = "Save Changes";
            // 
            // buttonReset
            // 
            this.buttonReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonReset.Enabled = false;
            this.buttonReset.Image = global::tams4a.Properties.Resources.cancel;
            this.buttonReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(23, 22);
            this.buttonReset.Text = "Revert Changes";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonSetDate
            // 
            this.buttonSetDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSetDate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setTodayToolStripMenuItem,
            this.setOtherDateToolStripMenuItem});
            this.buttonSetDate.Image = global::tams4a.Properties.Resources.calendar;
            this.buttonSetDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSetDate.Name = "buttonSetDate";
            this.buttonSetDate.Size = new System.Drawing.Size(29, 22);
            this.buttonSetDate.Text = "Set Record Date";
            // 
            // setTodayToolStripMenuItem
            // 
            this.setTodayToolStripMenuItem.Checked = true;
            this.setTodayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
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
            // buttonHistory
            // 
            this.buttonHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonHistory.Enabled = false;
            this.buttonHistory.Image = global::tams4a.Properties.Resources.history;
            this.buttonHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(23, 22);
            this.buttonHistory.Text = "History";
            // 
            // btnNotes
            // 
            this.btnNotes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNotes.Image = global::tams4a.Properties.Resources.notes;
            this.btnNotes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.Size = new System.Drawing.Size(23, 22);
            this.btnNotes.Text = "Create a Note";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonAnalysis
            // 
            this.toolStripButtonAnalysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAnalysis.Image = global::tams4a.Properties.Resources.report1;
            this.toolStripButtonAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnalysis.Name = "toolStripButtonAnalysis";
            this.toolStripButtonAnalysis.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAnalysis.Text = "Analysis";
            this.toolStripButtonAnalysis.ToolTipText = "Create Report on Selected Roads";
            // 
            // toolStripButtonSidewalk
            // 
            this.toolStripButtonSidewalk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSidewalk.Enabled = false;
            this.toolStripButtonSidewalk.Image = global::tams4a.Properties.Resources.swdatabutton;
            this.toolStripButtonSidewalk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSidewalk.Name = "toolStripButtonSidewalk";
            this.toolStripButtonSidewalk.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSidewalk.Text = "Sidewalk Data";
            this.toolStripButtonSidewalk.Visible = false;
            // 
            // Panel_Road
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.groupBoxDistress);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.toolStrip);
            this.MaximumSize = new System.Drawing.Size(220, 2410);
            this.MinimumSize = new System.Drawing.Size(220, 750);
            this.Name = "Panel_Road";
            this.Size = new System.Drawing.Size(220, 784);
            this.groupBoxDistress.ResumeLayout(false);
            this.groupBoxDistress.PerformLayout();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLanes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpeedLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStrip toolStrip;
        public System.Windows.Forms.ToolStripButton buttonReset;
        public System.Windows.Forms.ToolStripDropDownButton buttonSetDate;
        public System.Windows.Forms.ToolStripButton buttonHistory;
        public System.Windows.Forms.ToolStripButton btnNotes;
        public System.Windows.Forms.ToolStripMenuItem setOtherDateToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem setTodayToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton toolStripButtonAnalysis;
        public System.Windows.Forms.Label labelName;
        public System.Windows.Forms.Label labelSurveyDate;
        private System.Windows.Forms.Label labelSpeedLimit;
        private System.Windows.Forms.Label labelLanes;
        public System.Windows.Forms.TextBox textBoxWidth;
        public System.Windows.Forms.TextBox textBoxLength;
        public System.Windows.Forms.TextBox textBoxArea;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Label labelType;
        public System.Windows.Forms.ComboBox comboBoxType;
        public System.Windows.Forms.ComboBox comboBoxSurface;
        private System.Windows.Forms.Label labelSurface;
        private System.Windows.Forms.Label labelPhoto;
        public System.Windows.Forms.PictureBox pictureBoxPhoto;
        public System.Windows.Forms.TextBox textBoxRoadName;
        public System.Windows.Forms.TextBox textBoxFrom;
        public System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        public System.Windows.Forms.GroupBox groupBoxInfo;
        public DistressEntry distress1;
        public DistressEntry distress2;
        public DistressEntry distress3;
        public DistressEntry distress4;
        public DistressEntry distress5;
        public DistressEntry distress6;
        public DistressEntry distress7;
        public DistressEntry distress8;
        public DistressEntry distress9;
        public System.Windows.Forms.ComboBox comboBoxTreatment;
        public System.Windows.Forms.Label labelSuggestedTreatment;
        public System.Windows.Forms.GroupBox groupBoxDistress;
        public System.Windows.Forms.NumericUpDown numericUpDownLanes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMPH;
        public System.Windows.Forms.NumericUpDown numericUpDownSpeedLimit;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox inputRsl;
        public System.Windows.Forms.Button buttonSuggest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton toolStripButtonSidewalk;
        public System.Windows.Forms.ToolStripButton buttonSave;
        public System.Windows.Forms.ComboBox comboBoxPhotoList;
        private System.Windows.Forms.Button buttonAddPhoto;
    }
}
