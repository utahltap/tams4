namespace tams4a.Forms
{
    partial class FormStartup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStartup));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBuild = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelRecent = new System.Windows.Forms.Label();
            this.button_openExisting = new System.Windows.Forms.Button();
            this.button_StartNew = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 128);
            this.label1.TabIndex = 1;
            this.label1.Text = "TAMS 4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(516, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Transportation Asset Management System";
            // 
            // labelBuild
            // 
            this.labelBuild.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuild.Location = new System.Drawing.Point(12, 177);
            this.labelBuild.Name = "labelBuild";
            this.labelBuild.Size = new System.Drawing.Size(550, 22);
            this.labelBuild.TabIndex = 3;
            this.labelBuild.Text = "build number:";
            this.labelBuild.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelRecent);
            this.groupBox1.Controls.Add(this.button_openExisting);
            this.groupBox1.Controls.Add(this.button_StartNew);
            this.groupBox1.Controls.Add(this.buttonContinue);
            this.groupBox1.Location = new System.Drawing.Point(12, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 199);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // labelRecent
            // 
            this.labelRecent.AutoEllipsis = true;
            this.labelRecent.Location = new System.Drawing.Point(6, 90);
            this.labelRecent.Name = "labelRecent";
            this.labelRecent.Size = new System.Drawing.Size(598, 25);
            this.labelRecent.TabIndex = 3;
            this.labelRecent.Text = "filename of recent project";
            this.labelRecent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_openExisting
            // 
            this.button_openExisting.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_openExisting.Location = new System.Drawing.Point(324, 145);
            this.button_openExisting.Name = "button_openExisting";
            this.button_openExisting.Size = new System.Drawing.Size(240, 48);
            this.button_openExisting.TabIndex = 2;
            this.button_openExisting.Text = "Open Existing Project";
            this.button_openExisting.UseVisualStyleBackColor = true;
            this.button_openExisting.Click += new System.EventHandler(this.button_openExisting_Click);
            // 
            // button_StartNew
            // 
            this.button_StartNew.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartNew.Location = new System.Drawing.Point(39, 145);
            this.button_StartNew.Name = "button_StartNew";
            this.button_StartNew.Size = new System.Drawing.Size(240, 48);
            this.button_StartNew.TabIndex = 1;
            this.button_StartNew.Text = "Start New Project";
            this.button_StartNew.UseVisualStyleBackColor = true;
            this.button_StartNew.Click += new System.EventHandler(this.button_StartNew_click);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContinue.Location = new System.Drawing.Point(39, 21);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(525, 66);
            this.buttonContinue.TabIndex = 0;
            this.buttonContinue.Text = "Continue Recent Project";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonQuit.Location = new System.Drawing.Point(547, 411);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 5;
            this.buttonQuit.Text = "Quit Tams";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::tams4a.Properties.Resources.tams_logo;
            this.pictureBox1.Location = new System.Drawing.Point(51, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormStartup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonQuit;
            this.ClientSize = new System.Drawing.Size(634, 442);
            this.ControlBox = false;
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelBuild);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStartup";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TAMS: Select Project";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelBuild;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_StartNew;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label labelRecent;
        private System.Windows.Forms.Button button_openExisting;
    }
}