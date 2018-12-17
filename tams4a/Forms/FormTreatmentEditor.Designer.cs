namespace tams4a.Forms
{
    partial class FormTreatmentEditor
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
            this.groupBoxEdit = new System.Windows.Forms.GroupBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.numericUpDownCost = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRSLChange = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxRSL = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMinRSL = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRoad = new System.Windows.Forms.ComboBox();
            this.labelCost = new System.Windows.Forms.Label();
            this.labelChange = new System.Windows.Forms.Label();
            this.labelMaxRSL = new System.Windows.Forms.Label();
            this.labelMinRSL = new System.Windows.Forms.Label();
            this.labelRoad = new System.Windows.Forms.Label();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.labelName = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRSLChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinRSL)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEdit
            // 
            this.groupBoxEdit.Controls.Add(this.buttonClose);
            this.groupBoxEdit.Controls.Add(this.buttonCreate);
            this.groupBoxEdit.Controls.Add(this.buttonClear);
            this.groupBoxEdit.Controls.Add(this.buttonDelete);
            this.groupBoxEdit.Controls.Add(this.buttonUpdate);
            this.groupBoxEdit.Controls.Add(this.numericUpDownCost);
            this.groupBoxEdit.Controls.Add(this.numericUpDownRSLChange);
            this.groupBoxEdit.Controls.Add(this.numericUpDownMaxRSL);
            this.groupBoxEdit.Controls.Add(this.numericUpDownMinRSL);
            this.groupBoxEdit.Controls.Add(this.comboBoxRoad);
            this.groupBoxEdit.Controls.Add(this.labelCost);
            this.groupBoxEdit.Controls.Add(this.labelChange);
            this.groupBoxEdit.Controls.Add(this.labelMaxRSL);
            this.groupBoxEdit.Controls.Add(this.labelMinRSL);
            this.groupBoxEdit.Controls.Add(this.labelRoad);
            this.groupBoxEdit.Controls.Add(this.comboBoxCategory);
            this.groupBoxEdit.Controls.Add(this.labelCategory);
            this.groupBoxEdit.Controls.Add(this.comboBoxName);
            this.groupBoxEdit.Controls.Add(this.labelName);
            this.groupBoxEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxEdit.Location = new System.Drawing.Point(0, 24);
            this.groupBoxEdit.Name = "groupBoxEdit";
            this.groupBoxEdit.Size = new System.Drawing.Size(888, 158);
            this.groupBoxEdit.TabIndex = 0;
            this.groupBoxEdit.TabStop = false;
            this.groupBoxEdit.Text = "Edit Treatment";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(645, 85);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 17;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(726, 85);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 16;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(12, 85);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(807, 85);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 14;
            this.buttonUpdate.Text = "Save";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // numericUpDownCost
            // 
            this.numericUpDownCost.DecimalPlaces = 2;
            this.numericUpDownCost.Location = new System.Drawing.Point(786, 59);
            this.numericUpDownCost.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numericUpDownCost.Name = "numericUpDownCost";
            this.numericUpDownCost.Size = new System.Drawing.Size(88, 20);
            this.numericUpDownCost.TabIndex = 13;
            // 
            // numericUpDownRSLChange
            // 
            this.numericUpDownRSLChange.Location = new System.Drawing.Point(664, 59);
            this.numericUpDownRSLChange.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownRSLChange.Name = "numericUpDownRSLChange";
            this.numericUpDownRSLChange.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownRSLChange.TabIndex = 12;
            // 
            // numericUpDownMaxRSL
            // 
            this.numericUpDownMaxRSL.Location = new System.Drawing.Point(536, 58);
            this.numericUpDownMaxRSL.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownMaxRSL.Name = "numericUpDownMaxRSL";
            this.numericUpDownMaxRSL.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownMaxRSL.TabIndex = 11;
            // 
            // numericUpDownMinRSL
            // 
            this.numericUpDownMinRSL.Location = new System.Drawing.Point(416, 58);
            this.numericUpDownMinRSL.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownMinRSL.Name = "numericUpDownMinRSL";
            this.numericUpDownMinRSL.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownMinRSL.TabIndex = 10;
            // 
            // comboBoxRoad
            // 
            this.comboBoxRoad.FormattingEnabled = true;
            this.comboBoxRoad.Location = new System.Drawing.Point(297, 58);
            this.comboBoxRoad.Name = "comboBoxRoad";
            this.comboBoxRoad.Size = new System.Drawing.Size(109, 21);
            this.comboBoxRoad.TabIndex = 9;
            this.comboBoxRoad.Items.AddRange(new object[]
            {
                "Asphalt",
                "Gravel",
                "Concrete"
            });
            // 
            // labelCost
            // 
            this.labelCost.AutoSize = true;
            this.labelCost.Location = new System.Drawing.Point(783, 43);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(92, 13);
            this.labelCost.TabIndex = 8;
            this.labelCost.Text = "Cost/Square Yard";
            // 
            // labelChange
            // 
            this.labelChange.AutoSize = true;
            this.labelChange.Location = new System.Drawing.Point(661, 42);
            this.labelChange.Name = "labelChange";
            this.labelChange.Size = new System.Drawing.Size(116, 13);
            this.labelChange.TabIndex = 7;
            this.labelChange.Text = "Expected RSL Change";
            // 
            // labelMaxRSL
            // 
            this.labelMaxRSL.AutoSize = true;
            this.labelMaxRSL.Location = new System.Drawing.Point(536, 42);
            this.labelMaxRSL.Name = "labelMaxRSL";
            this.labelMaxRSL.Size = new System.Drawing.Size(119, 13);
            this.labelMaxRSL.TabIndex = 6;
            this.labelMaxRSL.Text = "Highest Applicable RSL";
            // 
            // labelMinRSL
            // 
            this.labelMinRSL.AutoSize = true;
            this.labelMinRSL.Location = new System.Drawing.Point(413, 42);
            this.labelMinRSL.Name = "labelMinRSL";
            this.labelMinRSL.Size = new System.Drawing.Size(117, 13);
            this.labelMinRSL.TabIndex = 5;
            this.labelMinRSL.Text = "Lowest Applicable RSL";
            // 
            // labelRoad
            // 
            this.labelRoad.AutoSize = true;
            this.labelRoad.Location = new System.Drawing.Point(294, 42);
            this.labelRoad.Name = "labelRoad";
            this.labelRoad.Size = new System.Drawing.Size(73, 13);
            this.labelRoad.TabIndex = 4;
            this.labelRoad.Text = "Road Surface";
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
                "Nothing",
                "Routine",
                "Patching",
                "Preventative",
                "Preventative with Patching",
                "Rehabilitation",
                "Reconstruction"
            });
            this.comboBoxCategory.Location = new System.Drawing.Point(157, 58);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(134, 21);
            this.comboBoxCategory.TabIndex = 3;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(157, 42);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(49, 13);
            this.labelCategory.TabIndex = 2;
            this.labelCategory.Text = "Category";
            // 
            // comboBoxName
            // 
            this.comboBoxName.DropDownWidth = 250;
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(6, 58);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(145, 21);
            this.comboBoxName.TabIndex = 1;
            this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 42);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Treatment";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(888, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(807, 129);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 18;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // FormTreatmentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 182);
            this.Controls.Add(this.groupBoxEdit);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTreatmentEditor";
            this.Text = "Treatment Editor";
            this.groupBoxEdit.ResumeLayout(false);
            this.groupBoxEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRSLChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinRSL)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEdit;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NumericUpDown numericUpDownMinRSL;
        private System.Windows.Forms.ComboBox comboBoxRoad;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Label labelChange;
        private System.Windows.Forms.Label labelMaxRSL;
        private System.Windows.Forms.Label labelMinRSL;
        private System.Windows.Forms.Label labelRoad;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.NumericUpDown numericUpDownCost;
        private System.Windows.Forms.NumericUpDown numericUpDownRSLChange;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxRSL;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonClose;
    }
}