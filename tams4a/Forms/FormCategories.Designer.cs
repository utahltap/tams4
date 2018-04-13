namespace tams4a.Forms
{
    partial class FormCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCategories));
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.numericUpDownCategories = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.groupBoxCategories = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.groupBoxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCategories)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.numericUpDownCategories);
            this.groupBoxInfo.Controls.Add(this.label1);
            this.groupBoxInfo.Controls.Add(this.labelInstructions);
            this.groupBoxInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxInfo.Location = new System.Drawing.Point(0, 0);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(361, 89);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            // 
            // numericUpDownCategories
            // 
            this.numericUpDownCategories.Location = new System.Drawing.Point(194, 60);
            this.numericUpDownCategories.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.numericUpDownCategories.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownCategories.Name = "numericUpDownCategories";
            this.numericUpDownCategories.Size = new System.Drawing.Size(68, 20);
            this.numericUpDownCategories.TabIndex = 6;
            this.numericUpDownCategories.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownCategories.ValueChanged += new System.EventHandler(this.categoryNumber_changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Categories";
            // 
            // labelInstructions
            // 
            this.labelInstructions.AutoSize = true;
            this.labelInstructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelInstructions.Location = new System.Drawing.Point(3, 16);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(356, 30);
            this.labelInstructions.TabIndex = 4;
            this.labelInstructions.Text = "Select the number of categories to use in the budget projections.\r\nThen set the m" +
    "ax RSL for each category. (Min 4, Max 20)";
            this.labelInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxCategories
            // 
            this.groupBoxCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCategories.Location = new System.Drawing.Point(0, 89);
            this.groupBoxCategories.Name = "groupBoxCategories";
            this.groupBoxCategories.Size = new System.Drawing.Size(361, 238);
            this.groupBoxCategories.TabIndex = 1;
            this.groupBoxCategories.TabStop = false;
            this.groupBoxCategories.Text = "Categories";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDone);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 289);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 38);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // buttonDone
            // 
            this.buttonDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonDone.Location = new System.Drawing.Point(271, 10);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(81, 24);
            this.buttonDone.TabIndex = 3;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // FormCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 327);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxCategories);
            this.Controls.Add(this.groupBoxInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(377, 366);
            this.MinimumSize = new System.Drawing.Size(377, 366);
            this.Name = "FormCategories";
            this.Text = "Set Distress Categories";
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCategories)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.GroupBox groupBoxCategories;
        private System.Windows.Forms.NumericUpDown numericUpDownCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button buttonDone;
    }
}