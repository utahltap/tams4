namespace tams4a.Forms
{
    partial class FormNewSign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewSign));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonBlank = new System.Windows.Forms.RadioButton();
            this.radioButtonFavorites = new System.Windows.Forms.RadioButton();
            this.radioButtonMUTCD = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cancel);
            this.groupBox1.Controls.Add(this.buttonContinue);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(12, 19);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Enabled = false;
            this.buttonContinue.Location = new System.Drawing.Point(309, 19);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(75, 23);
            this.buttonContinue.TabIndex = 0;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonBlank);
            this.groupBox2.Controls.Add(this.radioButtonFavorites);
            this.groupBox2.Controls.Add(this.radioButtonMUTCD);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 151);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // radioButtonBlank
            // 
            this.radioButtonBlank.AutoSize = true;
            this.radioButtonBlank.Location = new System.Drawing.Point(278, 50);
            this.radioButtonBlank.Name = "radioButtonBlank";
            this.radioButtonBlank.Size = new System.Drawing.Size(76, 17);
            this.radioButtonBlank.TabIndex = 3;
            this.radioButtonBlank.TabStop = true;
            this.radioButtonBlank.Text = "Blank Sign";
            this.radioButtonBlank.UseVisualStyleBackColor = true;
            this.radioButtonBlank.CheckedChanged += new System.EventHandler(this.onChoose);
            // 
            // radioButtonFavorites
            // 
            this.radioButtonFavorites.AutoSize = true;
            this.radioButtonFavorites.Location = new System.Drawing.Point(158, 50);
            this.radioButtonFavorites.Name = "radioButtonFavorites";
            this.radioButtonFavorites.Size = new System.Drawing.Size(68, 17);
            this.radioButtonFavorites.TabIndex = 2;
            this.radioButtonFavorites.TabStop = true;
            this.radioButtonFavorites.Text = "Favorites";
            this.radioButtonFavorites.UseVisualStyleBackColor = true;
            this.radioButtonFavorites.CheckedChanged += new System.EventHandler(this.onChoose);
            // 
            // radioButtonMUTCD
            // 
            this.radioButtonMUTCD.AutoSize = true;
            this.radioButtonMUTCD.Location = new System.Drawing.Point(25, 50);
            this.radioButtonMUTCD.Name = "radioButtonMUTCD";
            this.radioButtonMUTCD.Size = new System.Drawing.Size(92, 17);
            this.radioButtonMUTCD.TabIndex = 1;
            this.radioButtonMUTCD.TabStop = true;
            this.radioButtonMUTCD.Text = "MUTCD Code";
            this.radioButtonMUTCD.UseVisualStyleBackColor = true;
            this.radioButtonMUTCD.CheckedChanged += new System.EventHandler(this.onChoose);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create New Sign from...";
            // 
            // FormNewSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 210);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(412, 249);
            this.MinimumSize = new System.Drawing.Size(412, 249);
            this.Name = "FormNewSign";
            this.Text = "Add New Sign";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RadioButton radioButtonMUTCD;
        public System.Windows.Forms.RadioButton radioButtonFavorites;
        public System.Windows.Forms.RadioButton radioButtonBlank;
    }
}