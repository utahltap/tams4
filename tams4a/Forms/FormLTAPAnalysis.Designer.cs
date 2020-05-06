namespace tams4a.Forms
{
    partial class FormLTAPAnalysis
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
            this.textBoxCityName = new System.Windows.Forms.TextBox();
            this.labelCityName = new System.Windows.Forms.Label();
            this.labelContactDate = new System.Windows.Forms.Label();
            this.labelProposalDate = new System.Windows.Forms.Label();
            this.dateTimePickerContactDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerProposalDate = new System.Windows.Forms.DateTimePicker();
            this.labelCityDepartment = new System.Windows.Forms.Label();
            this.textBoxCityDepartment = new System.Windows.Forms.TextBox();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSurveyMonth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownSurveyYear = new System.Windows.Forms.NumericUpDown();
            this.labelOrganization = new System.Windows.Forms.Label();
            this.textBoxOrganization = new System.Windows.Forms.TextBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonPreviousSet = new System.Windows.Forms.Button();
            this.buttonNextSet = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelPictureSelect = new System.Windows.Forms.Label();
            this.buttonPrevious = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSurveyYear)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCityName
            // 
            this.textBoxCityName.Location = new System.Drawing.Point(166, 34);
            this.textBoxCityName.Name = "textBoxCityName";
            this.textBoxCityName.Size = new System.Drawing.Size(100, 20);
            this.textBoxCityName.TabIndex = 0;
            // 
            // labelCityName
            // 
            this.labelCityName.AutoSize = true;
            this.labelCityName.Location = new System.Drawing.Point(6, 37);
            this.labelCityName.Name = "labelCityName";
            this.labelCityName.Size = new System.Drawing.Size(55, 13);
            this.labelCityName.TabIndex = 1;
            this.labelCityName.Text = "City Name";
            // 
            // labelContactDate
            // 
            this.labelContactDate.AutoSize = true;
            this.labelContactDate.Location = new System.Drawing.Point(5, 63);
            this.labelContactDate.Name = "labelContactDate";
            this.labelContactDate.Size = new System.Drawing.Size(130, 13);
            this.labelContactDate.TabIndex = 3;
            this.labelContactDate.Text = "Date city contacted LTAP";
            // 
            // labelProposalDate
            // 
            this.labelProposalDate.AutoSize = true;
            this.labelProposalDate.Location = new System.Drawing.Point(6, 89);
            this.labelProposalDate.Name = "labelProposalDate";
            this.labelProposalDate.Size = new System.Drawing.Size(126, 13);
            this.labelProposalDate.TabIndex = 5;
            this.labelProposalDate.Text = "Date LTAP sent proposal";
            // 
            // dateTimePickerContactDate
            // 
            this.dateTimePickerContactDate.Location = new System.Drawing.Point(166, 60);
            this.dateTimePickerContactDate.Name = "dateTimePickerContactDate";
            this.dateTimePickerContactDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerContactDate.TabIndex = 6;
            // 
            // dateTimePickerProposalDate
            // 
            this.dateTimePickerProposalDate.Location = new System.Drawing.Point(166, 86);
            this.dateTimePickerProposalDate.Name = "dateTimePickerProposalDate";
            this.dateTimePickerProposalDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerProposalDate.TabIndex = 7;
            // 
            // labelCityDepartment
            // 
            this.labelCityDepartment.AutoSize = true;
            this.labelCityDepartment.Location = new System.Drawing.Point(6, 115);
            this.labelCityDepartment.Name = "labelCityDepartment";
            this.labelCityDepartment.Size = new System.Drawing.Size(154, 13);
            this.labelCityDepartment.TabIndex = 9;
            this.labelCityDepartment.Text = "Department working with LTAP";
            // 
            // textBoxCityDepartment
            // 
            this.textBoxCityDepartment.Location = new System.Drawing.Point(166, 112);
            this.textBoxCityDepartment.Name = "textBoxCityDepartment";
            this.textBoxCityDepartment.Size = new System.Drawing.Size(100, 20);
            this.textBoxCityDepartment.TabIndex = 8;
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.Location = new System.Drawing.Point(426, 336);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.Size = new System.Drawing.Size(112, 23);
            this.buttonGenerateReport.TabIndex = 10;
            this.buttonGenerateReport.Text = "Generate Report";
            this.buttonGenerateReport.UseVisualStyleBackColor = true;
            this.buttonGenerateReport.Click += new System.EventHandler(this.buttonGenerateReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Month survey was done";
            // 
            // textBoxSurveyMonth
            // 
            this.textBoxSurveyMonth.Location = new System.Drawing.Point(166, 138);
            this.textBoxSurveyMonth.Name = "textBoxSurveyMonth";
            this.textBoxSurveyMonth.Size = new System.Drawing.Size(100, 20);
            this.textBoxSurveyMonth.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Year survey was done";
            // 
            // numericUpDownSurveyYear
            // 
            this.numericUpDownSurveyYear.Location = new System.Drawing.Point(166, 165);
            this.numericUpDownSurveyYear.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownSurveyYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownSurveyYear.Name = "numericUpDownSurveyYear";
            this.numericUpDownSurveyYear.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSurveyYear.TabIndex = 15;
            this.numericUpDownSurveyYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // labelOrganization
            // 
            this.labelOrganization.AutoSize = true;
            this.labelOrganization.Location = new System.Drawing.Point(6, 11);
            this.labelOrganization.Name = "labelOrganization";
            this.labelOrganization.Size = new System.Drawing.Size(66, 13);
            this.labelOrganization.TabIndex = 17;
            this.labelOrganization.Text = "Organization";
            // 
            // textBoxOrganization
            // 
            this.textBoxOrganization.Location = new System.Drawing.Point(166, 8);
            this.textBoxOrganization.Name = "textBoxOrganization";
            this.textBoxOrganization.Size = new System.Drawing.Size(100, 20);
            this.textBoxOrganization.TabIndex = 16;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(608, 336);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 18;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePickerContactDate);
            this.panel1.Controls.Add(this.textBoxCityName);
            this.panel1.Controls.Add(this.labelOrganization);
            this.panel1.Controls.Add(this.labelCityName);
            this.panel1.Controls.Add(this.textBoxOrganization);
            this.panel1.Controls.Add(this.labelContactDate);
            this.panel1.Controls.Add(this.numericUpDownSurveyYear);
            this.panel1.Controls.Add(this.labelProposalDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePickerProposalDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxCityDepartment);
            this.panel1.Controls.Add(this.textBoxSurveyMonth);
            this.panel1.Controls.Add(this.labelCityDepartment);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 318);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonPreviousSet);
            this.panel2.Controls.Add(this.buttonNextSet);
            this.panel2.Controls.Add(this.pictureBox6);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.labelPictureSelect);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(674, 318);
            this.panel2.TabIndex = 20;
            // 
            // buttonPreviousSet
            // 
            this.buttonPreviousSet.Enabled = false;
            this.buttonPreviousSet.Location = new System.Drawing.Point(3, 37);
            this.buttonPreviousSet.Name = "buttonPreviousSet";
            this.buttonPreviousSet.Size = new System.Drawing.Size(24, 247);
            this.buttonPreviousSet.TabIndex = 23;
            this.buttonPreviousSet.Text = "<";
            this.buttonPreviousSet.UseVisualStyleBackColor = true;
            this.buttonPreviousSet.Click += new System.EventHandler(this.buttonPreviousSet_Click);
            // 
            // buttonNextSet
            // 
            this.buttonNextSet.Location = new System.Drawing.Point(647, 37);
            this.buttonNextSet.Name = "buttonNextSet";
            this.buttonNextSet.Size = new System.Drawing.Size(24, 247);
            this.buttonNextSet.TabIndex = 22;
            this.buttonNextSet.Text = ">";
            this.buttonNextSet.UseVisualStyleBackColor = true;
            this.buttonNextSet.Click += new System.EventHandler(this.buttonNextSet_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(452, 167);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(179, 117);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 6;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(452, 37);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(179, 117);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(246, 167);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(179, 117);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(247, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(178, 117);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(41, 167);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(179, 117);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(41, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelPictureSelect
            // 
            this.labelPictureSelect.AutoSize = true;
            this.labelPictureSelect.Location = new System.Drawing.Point(38, 11);
            this.labelPictureSelect.Name = "labelPictureSelect";
            this.labelPictureSelect.Size = new System.Drawing.Size(314, 13);
            this.labelPictureSelect.TabIndex = 0;
            this.labelPictureSelect.Text = "Select an image to use as an example for FAILED road condition.";
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(12, 336);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevious.TabIndex = 21;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Visible = false;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // FormLTAPAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 371);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonGenerateReport);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormLTAPAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTAMSReport";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSurveyYear)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxCityName;
        private System.Windows.Forms.Label labelCityName;
        private System.Windows.Forms.Label labelContactDate;
        private System.Windows.Forms.Label labelProposalDate;
        public System.Windows.Forms.DateTimePicker dateTimePickerContactDate;
        public System.Windows.Forms.DateTimePicker dateTimePickerProposalDate;
        private System.Windows.Forms.Label labelCityDepartment;
        public System.Windows.Forms.TextBox textBoxCityDepartment;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxSurveyMonth;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numericUpDownSurveyYear;
        private System.Windows.Forms.Label labelOrganization;
        public System.Windows.Forms.TextBox textBoxOrganization;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelPictureSelect;
        private System.Windows.Forms.Button buttonNextSet;
        private System.Windows.Forms.Button buttonPreviousSet;
    }
}