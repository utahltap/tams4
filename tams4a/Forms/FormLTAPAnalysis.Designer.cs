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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSurveyYear)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCityName
            // 
            this.textBoxCityName.Location = new System.Drawing.Point(173, 31);
            this.textBoxCityName.Name = "textBoxCityName";
            this.textBoxCityName.Size = new System.Drawing.Size(100, 20);
            this.textBoxCityName.TabIndex = 0;
            // 
            // labelCityName
            // 
            this.labelCityName.AutoSize = true;
            this.labelCityName.Location = new System.Drawing.Point(13, 34);
            this.labelCityName.Name = "labelCityName";
            this.labelCityName.Size = new System.Drawing.Size(55, 13);
            this.labelCityName.TabIndex = 1;
            this.labelCityName.Text = "City Name";
            // 
            // labelContactDate
            // 
            this.labelContactDate.AutoSize = true;
            this.labelContactDate.Location = new System.Drawing.Point(12, 60);
            this.labelContactDate.Name = "labelContactDate";
            this.labelContactDate.Size = new System.Drawing.Size(130, 13);
            this.labelContactDate.TabIndex = 3;
            this.labelContactDate.Text = "Date city contacted LTAP";
            // 
            // labelProposalDate
            // 
            this.labelProposalDate.AutoSize = true;
            this.labelProposalDate.Location = new System.Drawing.Point(13, 86);
            this.labelProposalDate.Name = "labelProposalDate";
            this.labelProposalDate.Size = new System.Drawing.Size(126, 13);
            this.labelProposalDate.TabIndex = 5;
            this.labelProposalDate.Text = "Date LTAP sent proposal";
            // 
            // dateTimePickerContactDate
            // 
            this.dateTimePickerContactDate.Location = new System.Drawing.Point(173, 57);
            this.dateTimePickerContactDate.Name = "dateTimePickerContactDate";
            this.dateTimePickerContactDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerContactDate.TabIndex = 6;
            // 
            // dateTimePickerProposalDate
            // 
            this.dateTimePickerProposalDate.Location = new System.Drawing.Point(173, 83);
            this.dateTimePickerProposalDate.Name = "dateTimePickerProposalDate";
            this.dateTimePickerProposalDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerProposalDate.TabIndex = 7;
            // 
            // labelCityDepartment
            // 
            this.labelCityDepartment.AutoSize = true;
            this.labelCityDepartment.Location = new System.Drawing.Point(13, 112);
            this.labelCityDepartment.Name = "labelCityDepartment";
            this.labelCityDepartment.Size = new System.Drawing.Size(154, 13);
            this.labelCityDepartment.TabIndex = 9;
            this.labelCityDepartment.Text = "Department working with LTAP";
            // 
            // textBoxCityDepartment
            // 
            this.textBoxCityDepartment.Location = new System.Drawing.Point(173, 109);
            this.textBoxCityDepartment.Name = "textBoxCityDepartment";
            this.textBoxCityDepartment.Size = new System.Drawing.Size(100, 20);
            this.textBoxCityDepartment.TabIndex = 8;
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.Location = new System.Drawing.Point(16, 336);
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
            this.label1.Location = new System.Drawing.Point(13, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Month survey was done";
            // 
            // textBoxSurveyMonth
            // 
            this.textBoxSurveyMonth.Location = new System.Drawing.Point(173, 135);
            this.textBoxSurveyMonth.Name = "textBoxSurveyMonth";
            this.textBoxSurveyMonth.Size = new System.Drawing.Size(100, 20);
            this.textBoxSurveyMonth.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Year survey was done";
            // 
            // numericUpDownSurveyYear
            // 
            this.numericUpDownSurveyYear.Location = new System.Drawing.Point(173, 162);
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
            // FormLTAPAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 371);
            this.Controls.Add(this.numericUpDownSurveyYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSurveyMonth);
            this.Controls.Add(this.buttonGenerateReport);
            this.Controls.Add(this.labelCityDepartment);
            this.Controls.Add(this.textBoxCityDepartment);
            this.Controls.Add(this.dateTimePickerProposalDate);
            this.Controls.Add(this.dateTimePickerContactDate);
            this.Controls.Add(this.labelProposalDate);
            this.Controls.Add(this.labelContactDate);
            this.Controls.Add(this.labelCityName);
            this.Controls.Add(this.textBoxCityName);
            this.Name = "FormLTAPAnalysis";
            this.Text = "FormTAMSReport";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSurveyYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}