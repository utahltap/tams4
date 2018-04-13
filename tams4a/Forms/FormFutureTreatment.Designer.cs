namespace tams4a.Forms
{
    partial class FormFutureTreatment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxYear = new System.Windows.Forms.CheckBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownTotals = new System.Windows.Forms.NumericUpDown();
            this.buttonDone = new System.Windows.Forms.Button();
            this.groupBoxTreatments = new System.Windows.Forms.GroupBox();
            this.groupBoxReconstruction = new System.Windows.Forms.GroupBox();
            this.panelReconstruction = new System.Windows.Forms.Panel();
            this.groupBoxRehabilitation = new System.Windows.Forms.GroupBox();
            this.panelRehabilitation = new System.Windows.Forms.Panel();
            this.groupBoxPreventative = new System.Windows.Forms.GroupBox();
            this.panelPreventative = new System.Windows.Forms.Panel();
            this.groupBoxRoutine = new System.Windows.Forms.GroupBox();
            this.panelRoutine = new System.Windows.Forms.Panel();
            this.buttonResetAll = new System.Windows.Forms.Button();
            this.buttonResetYear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotals)).BeginInit();
            this.groupBoxTreatments.SuspendLayout();
            this.groupBoxReconstruction.SuspendLayout();
            this.groupBoxRehabilitation.SuspendLayout();
            this.groupBoxPreventative.SuspendLayout();
            this.groupBoxRoutine.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxYear);
            this.groupBox1.Controls.Add(this.comboBoxYear);
            this.groupBox1.Controls.Add(this.labelYear);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1209, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // checkBoxYear
            // 
            this.checkBoxYear.AutoSize = true;
            this.checkBoxYear.Location = new System.Drawing.Point(157, 23);
            this.checkBoxYear.Name = "checkBoxYear";
            this.checkBoxYear.Size = new System.Drawing.Size(138, 17);
            this.checkBoxYear.TabIndex = 2;
            this.checkBoxYear.Text = "Change Treatment Plan";
            this.checkBoxYear.UseVisualStyleBackColor = true;
            this.checkBoxYear.CheckedChanged += new System.EventHandler(this.checkBoxYear_Changed);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(54, 21);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(97, 21);
            this.comboBoxYear.TabIndex = 1;
            this.comboBoxYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxYear_selectionChange);
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.labelYear.Location = new System.Drawing.Point(13, 21);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(35, 15);
            this.labelYear.TabIndex = 0;
            this.labelYear.Text = "Year:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonResetYear);
            this.groupBox2.Controls.Add(this.buttonResetAll);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDownTotals);
            this.groupBox2.Controls.Add(this.buttonDone);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 357);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1209, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(906, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Totals";
            // 
            // numericUpDownTotals
            // 
            this.numericUpDownTotals.Enabled = false;
            this.numericUpDownTotals.Location = new System.Drawing.Point(957, 28);
            this.numericUpDownTotals.Name = "numericUpDownTotals";
            this.numericUpDownTotals.Size = new System.Drawing.Size(76, 20);
            this.numericUpDownTotals.TabIndex = 1;
            // 
            // buttonDone
            // 
            this.buttonDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonDone.Location = new System.Drawing.Point(1099, 19);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(98, 39);
            this.buttonDone.TabIndex = 0;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.UseWaitCursor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // groupBoxTreatments
            // 
            this.groupBoxTreatments.Controls.Add(this.groupBoxReconstruction);
            this.groupBoxTreatments.Controls.Add(this.groupBoxRehabilitation);
            this.groupBoxTreatments.Controls.Add(this.groupBoxPreventative);
            this.groupBoxTreatments.Controls.Add(this.groupBoxRoutine);
            this.groupBoxTreatments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTreatments.Location = new System.Drawing.Point(0, 54);
            this.groupBoxTreatments.Name = "groupBoxTreatments";
            this.groupBoxTreatments.Size = new System.Drawing.Size(1209, 303);
            this.groupBoxTreatments.TabIndex = 2;
            this.groupBoxTreatments.TabStop = false;
            this.groupBoxTreatments.Text = "treatments";
            // 
            // groupBoxReconstruction
            // 
            this.groupBoxReconstruction.Controls.Add(this.panelReconstruction);
            this.groupBoxReconstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxReconstruction.Location = new System.Drawing.Point(875, 16);
            this.groupBoxReconstruction.Name = "groupBoxReconstruction";
            this.groupBoxReconstruction.Size = new System.Drawing.Size(331, 284);
            this.groupBoxReconstruction.TabIndex = 4;
            this.groupBoxReconstruction.TabStop = false;
            this.groupBoxReconstruction.Text = "Reconstruction";
            // 
            // panelReconstruction
            // 
            this.panelReconstruction.AutoScroll = true;
            this.panelReconstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReconstruction.Location = new System.Drawing.Point(3, 16);
            this.panelReconstruction.Name = "panelReconstruction";
            this.panelReconstruction.Size = new System.Drawing.Size(325, 265);
            this.panelReconstruction.TabIndex = 0;
            // 
            // groupBoxRehabilitation
            // 
            this.groupBoxRehabilitation.Controls.Add(this.panelRehabilitation);
            this.groupBoxRehabilitation.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxRehabilitation.Location = new System.Drawing.Point(571, 16);
            this.groupBoxRehabilitation.Name = "groupBoxRehabilitation";
            this.groupBoxRehabilitation.Size = new System.Drawing.Size(304, 284);
            this.groupBoxRehabilitation.TabIndex = 3;
            this.groupBoxRehabilitation.TabStop = false;
            this.groupBoxRehabilitation.Text = "Rehabilitation";
            // 
            // panelRehabilitation
            // 
            this.panelRehabilitation.AutoScroll = true;
            this.panelRehabilitation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRehabilitation.Location = new System.Drawing.Point(3, 16);
            this.panelRehabilitation.Name = "panelRehabilitation";
            this.panelRehabilitation.Size = new System.Drawing.Size(298, 265);
            this.panelRehabilitation.TabIndex = 0;
            // 
            // groupBoxPreventative
            // 
            this.groupBoxPreventative.Controls.Add(this.panelPreventative);
            this.groupBoxPreventative.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxPreventative.Location = new System.Drawing.Point(268, 16);
            this.groupBoxPreventative.Name = "groupBoxPreventative";
            this.groupBoxPreventative.Size = new System.Drawing.Size(303, 284);
            this.groupBoxPreventative.TabIndex = 1;
            this.groupBoxPreventative.TabStop = false;
            this.groupBoxPreventative.Text = "Preventative";
            // 
            // panelPreventative
            // 
            this.panelPreventative.AutoScroll = true;
            this.panelPreventative.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPreventative.Location = new System.Drawing.Point(3, 16);
            this.panelPreventative.Name = "panelPreventative";
            this.panelPreventative.Size = new System.Drawing.Size(297, 265);
            this.panelPreventative.TabIndex = 0;
            // 
            // groupBoxRoutine
            // 
            this.groupBoxRoutine.Controls.Add(this.panelRoutine);
            this.groupBoxRoutine.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxRoutine.Location = new System.Drawing.Point(3, 16);
            this.groupBoxRoutine.Name = "groupBoxRoutine";
            this.groupBoxRoutine.Size = new System.Drawing.Size(265, 284);
            this.groupBoxRoutine.TabIndex = 0;
            this.groupBoxRoutine.TabStop = false;
            this.groupBoxRoutine.Text = "Routine";
            // 
            // panelRoutine
            // 
            this.panelRoutine.AutoScroll = true;
            this.panelRoutine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRoutine.Location = new System.Drawing.Point(3, 16);
            this.panelRoutine.Name = "panelRoutine";
            this.panelRoutine.Size = new System.Drawing.Size(259, 265);
            this.panelRoutine.TabIndex = 0;
            // 
            // buttonResetAll
            // 
            this.buttonResetAll.Location = new System.Drawing.Point(781, 19);
            this.buttonResetAll.Name = "buttonResetAll";
            this.buttonResetAll.Size = new System.Drawing.Size(91, 39);
            this.buttonResetAll.TabIndex = 3;
            this.buttonResetAll.Text = "Reset All";
            this.buttonResetAll.UseVisualStyleBackColor = true;
            this.buttonResetAll.Click += new System.EventHandler(this.buttonResetAll_Click);
            // 
            // buttonResetYear
            // 
            this.buttonResetYear.Location = new System.Drawing.Point(679, 19);
            this.buttonResetYear.Name = "buttonResetYear";
            this.buttonResetYear.Size = new System.Drawing.Size(96, 39);
            this.buttonResetYear.TabIndex = 4;
            this.buttonResetYear.Text = "Reset Year";
            this.buttonResetYear.UseVisualStyleBackColor = true;
            this.buttonResetYear.Click += new System.EventHandler(this.buttonResetYear_Click);
            // 
            // FormFutureTreatment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 427);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxTreatments);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormFutureTreatment";
            this.Text = "Future Treatment Plan";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotals)).EndInit();
            this.groupBoxTreatments.ResumeLayout(false);
            this.groupBoxReconstruction.ResumeLayout(false);
            this.groupBoxRehabilitation.ResumeLayout(false);
            this.groupBoxPreventative.ResumeLayout(false);
            this.groupBoxRoutine.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxTreatments;
        private System.Windows.Forms.GroupBox groupBoxRoutine;
        private System.Windows.Forms.GroupBox groupBoxPreventative;
        private System.Windows.Forms.GroupBox groupBoxRehabilitation;
        private System.Windows.Forms.GroupBox groupBoxReconstruction;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.CheckBox checkBoxYear;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Panel panelReconstruction;
        private System.Windows.Forms.Panel panelRehabilitation;
        private System.Windows.Forms.Panel panelPreventative;
        private System.Windows.Forms.Panel panelRoutine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownTotals;
        private System.Windows.Forms.Button buttonResetYear;
        private System.Windows.Forms.Button buttonResetAll;
    }
}