namespace tams4a.Forms
{
    partial class FormReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReport));
            this.labelComments = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.labelLog = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.inputName = new tams4a.Controls.LabeledInput();
            this.inputEmail = new tams4a.Controls.LabeledInput();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelComments
            // 
            this.labelComments.AutoSize = true;
            this.labelComments.Location = new System.Drawing.Point(13, 13);
            this.labelComments.Name = "labelComments";
            this.labelComments.Size = new System.Drawing.Size(171, 13);
            this.labelComments.TabIndex = 0;
            this.labelComments.Text = "Description of problem / comments";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(13, 29);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxComment.Size = new System.Drawing.Size(759, 192);
            this.textBoxComment.TabIndex = 1;
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLogs.Location = new System.Drawing.Point(13, 257);
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.ReadOnly = true;
            this.textBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogs.Size = new System.Drawing.Size(759, 192);
            this.textBoxLogs.TabIndex = 3;
            // 
            // labelLog
            // 
            this.labelLog.AutoSize = true;
            this.labelLog.Location = new System.Drawing.Point(13, 240);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(192, 13);
            this.labelLog.TabIndex = 2;
            this.labelLog.Text = "Information from TAMS logs (automatic)";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(542, 488);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(230, 62);
            this.buttonSubmit.TabIndex = 4;
            this.buttonSubmit.Text = "Submit via internet";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // inputName
            // 
            this.inputName.Label = "Name";
            this.inputName.Location = new System.Drawing.Point(9, 502);
            this.inputName.Margin = new System.Windows.Forms.Padding(0);
            this.inputName.Name = "inputName";
            this.inputName.Padding = new System.Windows.Forms.Padding(2);
            this.inputName.ReadOnly = false;
            this.inputName.Size = new System.Drawing.Size(255, 24);
            this.inputName.TabIndex = 5;
            this.inputName.Value = null;
            // 
            // inputEmail
            // 
            this.inputEmail.Label = "Email";
            this.inputEmail.Location = new System.Drawing.Point(9, 526);
            this.inputEmail.Margin = new System.Windows.Forms.Padding(0);
            this.inputEmail.Name = "inputEmail";
            this.inputEmail.Padding = new System.Windows.Forms.Padding(2);
            this.inputEmail.ReadOnly = false;
            this.inputEmail.Size = new System.Drawing.Size(255, 24);
            this.inputEmail.TabIndex = 6;
            this.inputEmail.Value = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 486);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Optional Information";
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputEmail);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxLogs);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.labelComments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReport";
            this.Text = "TAMS Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReport_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelComments;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.Button buttonSubmit;
        public System.Windows.Forms.TextBox textBoxComment;
        public System.Windows.Forms.TextBox textBoxLogs;
        private Controls.LabeledInput inputName;
        private Controls.LabeledInput inputEmail;
        private System.Windows.Forms.Label label1;
    }
}