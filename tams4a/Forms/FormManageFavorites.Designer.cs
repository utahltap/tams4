namespace tams4a.Forms
{
    partial class FormManageFavorites
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManageFavorites));
            this.groupBoxSigns = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelSign = new System.Windows.Forms.Label();
            this.comboBoxSign = new System.Windows.Forms.ComboBox();
            this.labelMUTCD = new System.Windows.Forms.Label();
            this.textBoxMUTCD = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.labelText = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxSheeting = new System.Windows.Forms.ComboBox();
            this.comboBoxBacking = new System.Windows.Forms.ComboBox();
            this.labelSheeting = new System.Windows.Forms.Label();
            this.labelBacking = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMountHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelMount = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxSigns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMountHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSigns
            // 
            this.groupBoxSigns.Controls.Add(this.buttonClear);
            this.groupBoxSigns.Controls.Add(this.buttonCreate);
            this.groupBoxSigns.Controls.Add(this.labelMount);
            this.groupBoxSigns.Controls.Add(this.labelHeight);
            this.groupBoxSigns.Controls.Add(this.label5);
            this.groupBoxSigns.Controls.Add(this.label4);
            this.groupBoxSigns.Controls.Add(this.label3);
            this.groupBoxSigns.Controls.Add(this.numericUpDownMountHeight);
            this.groupBoxSigns.Controls.Add(this.numericUpDownHeight);
            this.groupBoxSigns.Controls.Add(this.numericUpDownWidth);
            this.groupBoxSigns.Controls.Add(this.labelWidth);
            this.groupBoxSigns.Controls.Add(this.labelBacking);
            this.groupBoxSigns.Controls.Add(this.labelSheeting);
            this.groupBoxSigns.Controls.Add(this.comboBoxBacking);
            this.groupBoxSigns.Controls.Add(this.comboBoxSheeting);
            this.groupBoxSigns.Controls.Add(this.textBoxDescription);
            this.groupBoxSigns.Controls.Add(this.labelText);
            this.groupBoxSigns.Controls.Add(this.buttonRemove);
            this.groupBoxSigns.Controls.Add(this.buttonUpdate);
            this.groupBoxSigns.Controls.Add(this.buttonSearch);
            this.groupBoxSigns.Controls.Add(this.textBoxText);
            this.groupBoxSigns.Controls.Add(this.labelDescription);
            this.groupBoxSigns.Controls.Add(this.textBoxMUTCD);
            this.groupBoxSigns.Controls.Add(this.labelMUTCD);
            this.groupBoxSigns.Controls.Add(this.comboBoxSign);
            this.groupBoxSigns.Controls.Add(this.labelSign);
            this.groupBoxSigns.Controls.Add(this.buttonClose);
            this.groupBoxSigns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSigns.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSigns.Name = "groupBoxSigns";
            this.groupBoxSigns.Size = new System.Drawing.Size(403, 326);
            this.groupBoxSigns.TabIndex = 0;
            this.groupBoxSigns.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(316, 291);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelSign
            // 
            this.labelSign.AutoSize = true;
            this.labelSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelSign.Location = new System.Drawing.Point(24, 16);
            this.labelSign.Name = "labelSign";
            this.labelSign.Size = new System.Drawing.Size(32, 15);
            this.labelSign.TabIndex = 1;
            this.labelSign.Text = "Sign";
            // 
            // comboBoxSign
            // 
            this.comboBoxSign.FormattingEnabled = true;
            this.comboBoxSign.Location = new System.Drawing.Point(154, 15);
            this.comboBoxSign.Name = "comboBoxSign";
            this.comboBoxSign.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSign.TabIndex = 2;
            this.comboBoxSign.SelectionChangeCommitted += new System.EventHandler(this.selectedSignChanged);
            // 
            // labelMUTCD
            // 
            this.labelMUTCD.AutoSize = true;
            this.labelMUTCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelMUTCD.Location = new System.Drawing.Point(24, 40);
            this.labelMUTCD.Name = "labelMUTCD";
            this.labelMUTCD.Size = new System.Drawing.Size(51, 15);
            this.labelMUTCD.TabIndex = 3;
            this.labelMUTCD.Text = "MUTCD";
            // 
            // textBoxMUTCD
            // 
            this.textBoxMUTCD.Location = new System.Drawing.Point(184, 39);
            this.textBoxMUTCD.Name = "textBoxMUTCD";
            this.textBoxMUTCD.Size = new System.Drawing.Size(100, 20);
            this.textBoxMUTCD.TabIndex = 4;
            this.textBoxMUTCD.TextChanged += new System.EventHandler(this.parameterChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelDescription.Location = new System.Drawing.Point(24, 66);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(69, 15);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "Description";
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(154, 91);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(237, 20);
            this.textBoxText.TabIndex = 6;
            this.textBoxText.TextChanged += new System.EventHandler(this.parameterChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Image = global::tams4a.Properties.Resources.find;
            this.buttonSearch.Location = new System.Drawing.Point(154, 39);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(24, 22);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(316, 262);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(73, 262);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 9;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelText.Location = new System.Drawing.Point(24, 92);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(58, 15);
            this.labelText.TabIndex = 10;
            this.labelText.Text = "Sign Text";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(154, 65);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(130, 20);
            this.textBoxDescription.TabIndex = 11;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.parameterChanged);
            // 
            // comboBoxSheeting
            // 
            this.comboBoxSheeting.FormattingEnabled = true;
            this.comboBoxSheeting.Location = new System.Drawing.Point(154, 117);
            this.comboBoxSheeting.Name = "comboBoxSheeting";
            this.comboBoxSheeting.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSheeting.TabIndex = 12;
            this.comboBoxSheeting.SelectionChangeCommitted += new System.EventHandler(this.parameterChanged);
            // 
            // comboBoxBacking
            // 
            this.comboBoxBacking.FormattingEnabled = true;
            this.comboBoxBacking.Location = new System.Drawing.Point(154, 144);
            this.comboBoxBacking.Name = "comboBoxBacking";
            this.comboBoxBacking.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBacking.TabIndex = 13;
            this.comboBoxBacking.SelectionChangeCommitted += new System.EventHandler(this.parameterChanged);
            // 
            // labelSheeting
            // 
            this.labelSheeting.AutoSize = true;
            this.labelSheeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelSheeting.Location = new System.Drawing.Point(24, 118);
            this.labelSheeting.Name = "labelSheeting";
            this.labelSheeting.Size = new System.Drawing.Size(56, 15);
            this.labelSheeting.TabIndex = 14;
            this.labelSheeting.Text = "Sheeting";
            // 
            // labelBacking
            // 
            this.labelBacking.AutoSize = true;
            this.labelBacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelBacking.Location = new System.Drawing.Point(24, 145);
            this.labelBacking.Name = "labelBacking";
            this.labelBacking.Size = new System.Drawing.Size(51, 15);
            this.labelBacking.TabIndex = 15;
            this.labelBacking.Text = "Backing";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelWidth.Location = new System.Drawing.Point(24, 171);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(38, 15);
            this.labelWidth.TabIndex = 16;
            this.labelWidth.Text = "Width";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "ft";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "in";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "in";
            // 
            // numericUpDownMountHeight
            // 
            this.numericUpDownMountHeight.DecimalPlaces = 1;
            this.numericUpDownMountHeight.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numericUpDownMountHeight.Location = new System.Drawing.Point(154, 217);
            this.numericUpDownMountHeight.Name = "numericUpDownMountHeight";
            this.numericUpDownMountHeight.Size = new System.Drawing.Size(83, 20);
            this.numericUpDownMountHeight.TabIndex = 29;
            this.numericUpDownMountHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMountHeight.ValueChanged += new System.EventHandler(this.parameterChanged);
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.DecimalPlaces = 1;
            this.numericUpDownHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownHeight.Location = new System.Drawing.Point(154, 194);
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(83, 20);
            this.numericUpDownHeight.TabIndex = 28;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.parameterChanged);
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.DecimalPlaces = 1;
            this.numericUpDownWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownWidth.Location = new System.Drawing.Point(154, 171);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(83, 20);
            this.numericUpDownWidth.TabIndex = 27;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.parameterChanged);
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelHeight.Location = new System.Drawing.Point(24, 194);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(43, 15);
            this.labelHeight.TabIndex = 33;
            this.labelHeight.Text = "Height";
            // 
            // labelMount
            // 
            this.labelMount.AutoSize = true;
            this.labelMount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelMount.Location = new System.Drawing.Point(24, 217);
            this.labelMount.Name = "labelMount";
            this.labelMount.Size = new System.Drawing.Size(81, 15);
            this.labelMount.TabIndex = 34;
            this.labelMount.Text = "Mount Height";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(235, 262);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 35;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(154, 262);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 36;
            this.buttonClear.Text = "Reset";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // FormManageFavorites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 326);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxSigns);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormManageFavorites";
            this.Text = "Manage Favorite Signs";
            this.groupBoxSigns.ResumeLayout(false);
            this.groupBoxSigns.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMountHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSigns;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxMUTCD;
        private System.Windows.Forms.Label labelMUTCD;
        private System.Windows.Forms.ComboBox comboBoxSign;
        private System.Windows.Forms.Label labelSign;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelBacking;
        private System.Windows.Forms.Label labelSheeting;
        private System.Windows.Forms.ComboBox comboBoxBacking;
        private System.Windows.Forms.ComboBox comboBoxSheeting;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown numericUpDownMountHeight;
        public System.Windows.Forms.NumericUpDown numericUpDownHeight;
        public System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelMount;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonClear;
    }
}