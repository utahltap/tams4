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
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.labelTreatment = new System.Windows.Forms.Label();
            this.labelYears = new System.Windows.Forms.Label();
            this.labelFunctionalClassification = new System.Windows.Forms.Label();
            this.labelToRSL = new System.Windows.Forms.Label();
            this.labelFromRSL = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.textBoxTotalArea = new System.Windows.Forms.TextBox();
            this.textBoxTotalCost = new System.Windows.Forms.TextBox();
            this.textBoxBudget = new System.Windows.Forms.TextBox();
            this.labelBudget = new System.Windows.Forms.Label();
            this.panelCalculator = new System.Windows.Forms.Panel();
            this.tableBudgetControl = new System.Windows.Forms.TableLayoutPanel();
            this.labelAreaCovered = new System.Windows.Forms.Label();
            this.labelRSLx = new System.Windows.Forms.Label();
            this.labelBudgetUsed = new System.Windows.Forms.Label();
            this.labelPercentConvered = new System.Windows.Forms.Label();
            this.labelOverBudget = new System.Windows.Forms.Label();
            this.labelTotalCost = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.buttonTreatmentCosts = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelRows = new System.Windows.Forms.Panel();
            this.panelAnalysisFilter.SuspendLayout();
            this.panelCalculator.SuspendLayout();
            this.tableBudgetControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAnalysisFilter
            // 
            this.panelAnalysisFilter.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelAnalysisFilter.Controls.Add(this.panelRows);
            this.panelAnalysisFilter.Controls.Add(this.buttonAddRow);
            this.panelAnalysisFilter.Controls.Add(this.labelTreatment);
            this.panelAnalysisFilter.Controls.Add(this.labelYears);
            this.panelAnalysisFilter.Controls.Add(this.labelFunctionalClassification);
            this.panelAnalysisFilter.Controls.Add(this.labelToRSL);
            this.panelAnalysisFilter.Controls.Add(this.labelFromRSL);
            this.panelAnalysisFilter.Location = new System.Drawing.Point(12, 60);
            this.panelAnalysisFilter.Name = "panelAnalysisFilter";
            this.panelAnalysisFilter.Size = new System.Drawing.Size(601, 515);
            this.panelAnalysisFilter.TabIndex = 21;
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Image = global::tams4a.Properties.Resources.baseadd;
            this.buttonAddRow.Location = new System.Drawing.Point(564, 8);
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
            this.labelTreatment.Location = new System.Drawing.Point(336, 13);
            this.labelTreatment.Name = "labelTreatment";
            this.labelTreatment.Size = new System.Drawing.Size(55, 13);
            this.labelTreatment.TabIndex = 6;
            this.labelTreatment.Text = "Treatment";
            // 
            // labelYears
            // 
            this.labelYears.AutoSize = true;
            this.labelYears.Location = new System.Drawing.Point(278, 13);
            this.labelYears.Name = "labelYears";
            this.labelYears.Size = new System.Drawing.Size(40, 13);
            this.labelYears.TabIndex = 5;
            this.labelYears.Text = "Years+";
            // 
            // labelFunctionalClassification
            // 
            this.labelFunctionalClassification.AutoSize = true;
            this.labelFunctionalClassification.Location = new System.Drawing.Point(135, 13);
            this.labelFunctionalClassification.Name = "labelFunctionalClassification";
            this.labelFunctionalClassification.Size = new System.Drawing.Size(120, 13);
            this.labelFunctionalClassification.TabIndex = 4;
            this.labelFunctionalClassification.Text = "Functional Classification";
            // 
            // labelToRSL
            // 
            this.labelToRSL.AutoSize = true;
            this.labelToRSL.Location = new System.Drawing.Point(77, 13);
            this.labelToRSL.Name = "labelToRSL";
            this.labelToRSL.Size = new System.Drawing.Size(44, 13);
            this.labelToRSL.TabIndex = 3;
            this.labelToRSL.Text = "To RSL";
            // 
            // labelFromRSL
            // 
            this.labelFromRSL.AutoSize = true;
            this.labelFromRSL.Location = new System.Drawing.Point(14, 13);
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
            this.textBoxBudget.Location = new System.Drawing.Point(619, 34);
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
            this.labelBudget.Location = new System.Drawing.Point(616, 18);
            this.labelBudget.Name = "labelBudget";
            this.labelBudget.Size = new System.Drawing.Size(68, 13);
            this.labelBudget.TabIndex = 26;
            this.labelBudget.Text = "Total Budget";
            // 
            // panelCalculator
            // 
            this.panelCalculator.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelCalculator.Controls.Add(this.tableBudgetControl);
            this.panelCalculator.Controls.Add(this.labelOverBudget);
            this.panelCalculator.Controls.Add(this.labelTotalCost);
            this.panelCalculator.Controls.Add(this.labelArea);
            this.panelCalculator.Controls.Add(this.textBoxTotalArea);
            this.panelCalculator.Controls.Add(this.buttonCalculate);
            this.panelCalculator.Controls.Add(this.textBoxTotalCost);
            this.panelCalculator.Location = new System.Drawing.Point(619, 60);
            this.panelCalculator.Name = "panelCalculator";
            this.panelCalculator.Size = new System.Drawing.Size(331, 515);
            this.panelCalculator.TabIndex = 27;
            // 
            // tableBudgetControl
            // 
            this.tableBudgetControl.AutoScroll = true;
            this.tableBudgetControl.ColumnCount = 4;
            this.tableBudgetControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableBudgetControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableBudgetControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableBudgetControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableBudgetControl.Controls.Add(this.labelAreaCovered, 2, 0);
            this.tableBudgetControl.Controls.Add(this.labelRSLx, 0, 0);
            this.tableBudgetControl.Controls.Add(this.labelBudgetUsed, 1, 0);
            this.tableBudgetControl.Controls.Add(this.labelPercentConvered, 3, 0);
            this.tableBudgetControl.Location = new System.Drawing.Point(14, 95);
            this.tableBudgetControl.MaximumSize = new System.Drawing.Size(300, 415);
            this.tableBudgetControl.Name = "tableBudgetControl";
            this.tableBudgetControl.RowCount = 1;
            this.tableBudgetControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableBudgetControl.Size = new System.Drawing.Size(300, 15);
            this.tableBudgetControl.TabIndex = 32;
            this.tableBudgetControl.Visible = false;
            // 
            // labelAreaCovered
            // 
            this.labelAreaCovered.AutoSize = true;
            this.labelAreaCovered.Location = new System.Drawing.Point(138, 0);
            this.labelAreaCovered.Name = "labelAreaCovered";
            this.labelAreaCovered.Size = new System.Drawing.Size(75, 13);
            this.labelAreaCovered.TabIndex = 32;
            this.labelAreaCovered.Text = "Area  Covered";
            // 
            // labelRSLx
            // 
            this.labelRSLx.AutoSize = true;
            this.labelRSLx.Location = new System.Drawing.Point(3, 0);
            this.labelRSLx.Name = "labelRSLx";
            this.labelRSLx.Size = new System.Drawing.Size(28, 13);
            this.labelRSLx.TabIndex = 28;
            this.labelRSLx.Text = "RSL";
            // 
            // labelBudgetUsed
            // 
            this.labelBudgetUsed.AutoSize = true;
            this.labelBudgetUsed.Location = new System.Drawing.Point(43, 0);
            this.labelBudgetUsed.Name = "labelBudgetUsed";
            this.labelBudgetUsed.Size = new System.Drawing.Size(69, 13);
            this.labelBudgetUsed.TabIndex = 31;
            this.labelBudgetUsed.Text = "Budget Used";
            // 
            // labelPercentConvered
            // 
            this.labelPercentConvered.AutoSize = true;
            this.labelPercentConvered.Location = new System.Drawing.Point(233, 0);
            this.labelPercentConvered.Name = "labelPercentConvered";
            this.labelPercentConvered.Size = new System.Drawing.Size(58, 13);
            this.labelPercentConvered.TabIndex = 33;
            this.labelPercentConvered.Text = "% Covered";
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
            this.labelTotalCost.Size = new System.Drawing.Size(129, 13);
            this.labelTotalCost.TabIndex = 26;
            this.labelTotalCost.Text = "Estimated treatement cost";
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Location = new System.Drawing.Point(11, 66);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(113, 13);
            this.labelArea.TabIndex = 25;
            this.labelArea.Text = "Estimated area treated";
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
            // panelRows
            // 
            this.panelRows.Location = new System.Drawing.Point(6, 37);
            this.panelRows.Name = "panelRows";
            this.panelRows.Size = new System.Drawing.Size(595, 475);
            this.panelRows.TabIndex = 30;
            // 
            // FormAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 587);
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
            this.tableBudgetControl.ResumeLayout(false);
            this.tableBudgetControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelAnalysisFilter;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.TextBox textBoxTotalArea;
        private System.Windows.Forms.TextBox textBoxTotalCost;
        private System.Windows.Forms.TextBox textBoxBudget;
        private System.Windows.Forms.Label labelBudget;
        private System.Windows.Forms.Panel panelCalculator;
        private System.Windows.Forms.Label labelTotalCost;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Label labelOverBudget;
        private System.Windows.Forms.Button buttonTreatmentCosts;
        private System.Windows.Forms.TableLayoutPanel tableBudgetControl;
        private System.Windows.Forms.Label labelAreaCovered;
        private System.Windows.Forms.Label labelRSLx;
        private System.Windows.Forms.Label labelBudgetUsed;
        private System.Windows.Forms.Label labelPercentConvered;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Label labelTreatment;
        private System.Windows.Forms.Label labelYears;
        private System.Windows.Forms.Label labelFunctionalClassification;
        private System.Windows.Forms.Label labelToRSL;
        private System.Windows.Forms.Label labelFromRSL;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panelRows;
    }
}