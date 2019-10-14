namespace tams4a.Forms
{
    partial class FormAnalysis
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
            this.components = new System.ComponentModel.Container();
            this.panelAnalysisFilter = new System.Windows.Forms.Panel();
            this.buttonRemoveRow = new System.Windows.Forms.Button();
            this.panelRows = new System.Windows.Forms.Panel();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.labelTreatment = new System.Windows.Forms.Label();
            this.labelFunctionalClassification = new System.Windows.Forms.Label();
            this.labelToRSL = new System.Windows.Forms.Label();
            this.labelFromRSL = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.textBoxTotalArea = new System.Windows.Forms.TextBox();
            this.textBoxTotalCost = new System.Windows.Forms.TextBox();
            this.textBoxBudget = new System.Windows.Forms.TextBox();
            this.labelBudget = new System.Windows.Forms.Label();
            this.panelCalculator = new System.Windows.Forms.Panel();
            this.buttonFullRowData = new System.Windows.Forms.Button();
            this.comboBoxResultsRow = new System.Windows.Forms.ComboBox();
            this.labelResultsRow = new System.Windows.Forms.Label();
            this.labelOverBudget = new System.Windows.Forms.Label();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.buttonTreatmentCosts = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelAnalysisFilter.SuspendLayout();
            this.panelCalculator.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAnalysisFilter
            // 
            this.panelAnalysisFilter.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelAnalysisFilter.Controls.Add(this.buttonRemoveRow);
            this.panelAnalysisFilter.Controls.Add(this.panelRows);
            this.panelAnalysisFilter.Controls.Add(this.buttonAddRow);
            this.panelAnalysisFilter.Controls.Add(this.labelTreatment);
            this.panelAnalysisFilter.Controls.Add(this.labelFunctionalClassification);
            this.panelAnalysisFilter.Controls.Add(this.labelToRSL);
            this.panelAnalysisFilter.Controls.Add(this.labelFromRSL);
            this.panelAnalysisFilter.Location = new System.Drawing.Point(12, 60);
            this.panelAnalysisFilter.Name = "panelAnalysisFilter";
            this.panelAnalysisFilter.Size = new System.Drawing.Size(552, 690);
            this.panelAnalysisFilter.TabIndex = 21;
            // 
            // buttonRemoveRow
            // 
            this.buttonRemoveRow.Enabled = false;
            this.buttonRemoveRow.Image = global::tams4a.Properties.Resources.baseremove;
            this.buttonRemoveRow.Location = new System.Drawing.Point(494, 8);
            this.buttonRemoveRow.Name = "buttonRemoveRow";
            this.buttonRemoveRow.Size = new System.Drawing.Size(23, 23);
            this.buttonRemoveRow.TabIndex = 31;
            this.toolTip.SetToolTip(this.buttonRemoveRow, "Remove Row");
            this.buttonRemoveRow.UseVisualStyleBackColor = true;
            this.buttonRemoveRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // panelRows
            // 
            this.panelRows.Location = new System.Drawing.Point(3, 37);
            this.panelRows.Name = "panelRows";
            this.panelRows.Size = new System.Drawing.Size(546, 653);
            this.panelRows.TabIndex = 30;
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Image = global::tams4a.Properties.Resources.baseadd;
            this.buttonAddRow.Location = new System.Drawing.Point(520, 8);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(23, 23);
            this.buttonAddRow.TabIndex = 29;
            this.toolTip.SetToolTip(this.buttonAddRow, "Add Row");
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // labelTreatment
            // 
            this.labelTreatment.AutoSize = true;
            this.labelTreatment.Location = new System.Drawing.Point(292, 13);
            this.labelTreatment.Name = "labelTreatment";
            this.labelTreatment.Size = new System.Drawing.Size(55, 13);
            this.labelTreatment.TabIndex = 6;
            this.labelTreatment.Text = "Treatment";
            // 
            // labelFunctionalClassification
            // 
            this.labelFunctionalClassification.AutoSize = true;
            this.labelFunctionalClassification.Location = new System.Drawing.Point(149, 13);
            this.labelFunctionalClassification.Name = "labelFunctionalClassification";
            this.labelFunctionalClassification.Size = new System.Drawing.Size(120, 13);
            this.labelFunctionalClassification.TabIndex = 4;
            this.labelFunctionalClassification.Text = "Functional Classification";
            // 
            // labelToRSL
            // 
            this.labelToRSL.AutoSize = true;
            this.labelToRSL.Location = new System.Drawing.Point(91, 13);
            this.labelToRSL.Name = "labelToRSL";
            this.labelToRSL.Size = new System.Drawing.Size(44, 13);
            this.labelToRSL.TabIndex = 3;
            this.labelToRSL.Text = "To RSL";
            // 
            // labelFromRSL
            // 
            this.labelFromRSL.AutoSize = true;
            this.labelFromRSL.Location = new System.Drawing.Point(28, 13);
            this.labelFromRSL.Name = "labelFromRSL";
            this.labelFromRSL.Size = new System.Drawing.Size(54, 13);
            this.labelFromRSL.TabIndex = 2;
            this.labelFromRSL.Text = "From RSL";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(7, 8);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(119, 23);
            this.buttonCalculate.TabIndex = 22;
            this.buttonCalculate.Text = "Calculate Cost";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // textBoxTotalArea
            // 
            this.textBoxTotalArea.Location = new System.Drawing.Point(155, 63);
            this.textBoxTotalArea.Name = "textBoxTotalArea";
            this.textBoxTotalArea.ReadOnly = true;
            this.textBoxTotalArea.Size = new System.Drawing.Size(159, 20);
            this.textBoxTotalArea.TabIndex = 23;
            // 
            // textBoxTotalCost
            // 
            this.textBoxTotalCost.Location = new System.Drawing.Point(155, 37);
            this.textBoxTotalCost.Name = "textBoxTotalCost";
            this.textBoxTotalCost.ReadOnly = true;
            this.textBoxTotalCost.Size = new System.Drawing.Size(159, 20);
            this.textBoxTotalCost.TabIndex = 24;
            // 
            // textBoxBudget
            // 
            this.textBoxBudget.Location = new System.Drawing.Point(570, 34);
            this.textBoxBudget.Name = "textBoxBudget";
            this.textBoxBudget.Size = new System.Drawing.Size(144, 20);
            this.textBoxBudget.TabIndex = 25;
            this.textBoxBudget.Text = "$0.00";
            this.textBoxBudget.GotFocus += new System.EventHandler(this.textBoxBudget_RemovePlaceholder);
            this.textBoxBudget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBudget_EnterPress);
            this.textBoxBudget.LostFocus += new System.EventHandler(this.textBoxBudget_AddPlaceholder);
            // 
            // labelBudget
            // 
            this.labelBudget.AutoSize = true;
            this.labelBudget.Location = new System.Drawing.Point(567, 18);
            this.labelBudget.Name = "labelBudget";
            this.labelBudget.Size = new System.Drawing.Size(68, 13);
            this.labelBudget.TabIndex = 26;
            this.labelBudget.Text = "Total Budget";
            // 
            // panelCalculator
            // 
            this.panelCalculator.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelCalculator.Controls.Add(this.buttonFullRowData);
            this.panelCalculator.Controls.Add(this.comboBoxResultsRow);
            this.panelCalculator.Controls.Add(this.labelResultsRow);
            this.panelCalculator.Controls.Add(this.labelOverBudget);
            this.panelCalculator.Controls.Add(this.labelTotalCost);
            this.panelCalculator.Controls.Add(this.labelArea);
            this.panelCalculator.Controls.Add(this.textBoxTotalArea);
            this.panelCalculator.Controls.Add(this.buttonCalculate);
            this.panelCalculator.Controls.Add(this.textBoxTotalCost);
            this.panelCalculator.Location = new System.Drawing.Point(570, 60);
            this.panelCalculator.Name = "panelCalculator";
            this.panelCalculator.Size = new System.Drawing.Size(331, 690);
            this.panelCalculator.TabIndex = 27;
            // 
            // buttonFullRowData
            // 
            this.buttonFullRowData.Enabled = false;
            this.buttonFullRowData.Location = new System.Drawing.Point(198, 90);
            this.buttonFullRowData.Name = "buttonFullRowData";
            this.buttonFullRowData.Size = new System.Drawing.Size(116, 23);
            this.buttonFullRowData.TabIndex = 35;
            this.buttonFullRowData.Text = "Full Report for Row";
            this.buttonFullRowData.UseVisualStyleBackColor = true;
            this.buttonFullRowData.Click += new System.EventHandler(this.buttonFullRowData_Click);
            // 
            // comboBoxResultsRow
            // 
            this.comboBoxResultsRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResultsRow.FormattingEnabled = true;
            this.comboBoxResultsRow.Items.AddRange(new object[] {
            "1"});
            this.comboBoxResultsRow.Location = new System.Drawing.Point(155, 90);
            this.comboBoxResultsRow.Name = "comboBoxResultsRow";
            this.comboBoxResultsRow.Size = new System.Drawing.Size(36, 21);
            this.comboBoxResultsRow.TabIndex = 34;
            this.comboBoxResultsRow.SelectedIndexChanged += new System.EventHandler(this.comboBoxResultsRow_SelectedIndexChanged);
            // 
            // labelResultsRow
            // 
            this.labelResultsRow.AutoSize = true;
            this.labelResultsRow.Location = new System.Drawing.Point(11, 93);
            this.labelResultsRow.Name = "labelResultsRow";
            this.labelResultsRow.Size = new System.Drawing.Size(124, 13);
            this.labelResultsRow.TabIndex = 33;
            this.labelResultsRow.Text = "Showing results from row";
            // 
            // labelOverBudget
            // 
            this.labelOverBudget.AutoSize = true;
            this.labelOverBudget.ForeColor = System.Drawing.Color.Red;
            this.labelOverBudget.Location = new System.Drawing.Point(152, 13);
            this.labelOverBudget.Name = "labelOverBudget";
            this.labelOverBudget.Size = new System.Drawing.Size(70, 13);
            this.labelOverBudget.TabIndex = 27;
            this.labelOverBudget.Text = "Over Budget!";
            this.labelOverBudget.Visible = false;
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Location = new System.Drawing.Point(11, 40);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(107, 13);
            this.labelTotalCost.TabIndex = 26;
            this.labelTotalCost.Text = "Total treatement cost";
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Location = new System.Drawing.Point(11, 66);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(91, 13);
            this.labelArea.TabIndex = 25;
            this.labelArea.Text = "Total area treated";
            // 
            // buttonTreatmentCosts
            // 
            this.buttonTreatmentCosts.Location = new System.Drawing.Point(12, 34);
            this.buttonTreatmentCosts.Name = "buttonTreatmentCosts";
            this.buttonTreatmentCosts.Size = new System.Drawing.Size(108, 23);
            this.buttonTreatmentCosts.TabIndex = 28;
            this.buttonTreatmentCosts.Text = "Treatment Costs";
            this.buttonTreatmentCosts.UseVisualStyleBackColor = true;
            this.buttonTreatmentCosts.Click += new System.EventHandler(this.buttonTreatmentCosts_Click);
            // 
            // FormAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 762);
            this.Controls.Add(this.panelCalculator);
            this.Controls.Add(this.buttonTreatmentCosts);
            this.Controls.Add(this.labelBudget);
            this.Controls.Add(this.textBoxBudget);
            this.Controls.Add(this.panelAnalysisFilter);
            this.Name = "FormAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAnalysis";
            this.panelAnalysisFilter.ResumeLayout(false);
            this.panelAnalysisFilter.PerformLayout();
            this.panelCalculator.ResumeLayout(false);
            this.panelCalculator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelAnalysisFilter;
        private System.Windows.Forms.Button buttonCalculate;
        public System.Windows.Forms.TextBox textBoxTotalArea;
        public System.Windows.Forms.TextBox textBoxTotalCost;
        private System.Windows.Forms.TextBox textBoxBudget;
        private System.Windows.Forms.Label labelBudget;
        private System.Windows.Forms.Panel panelCalculator;
        private System.Windows.Forms.Label labelTotalCost;
        private System.Windows.Forms.Label labelArea;
        public System.Windows.Forms.Label labelOverBudget;
        private System.Windows.Forms.Button buttonTreatmentCosts;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Label labelTreatment;
        private System.Windows.Forms.Label labelFunctionalClassification;
        private System.Windows.Forms.Label labelToRSL;
        private System.Windows.Forms.Label labelFromRSL;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panelRows;
        private System.Windows.Forms.Button buttonRemoveRow;
        private System.Windows.Forms.ComboBox comboBoxResultsRow;
        private System.Windows.Forms.Label labelResultsRow;
        private System.Windows.Forms.Button buttonFullRowData;
    }
}