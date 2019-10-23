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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.tabControlAnalysis = new System.Windows.Forms.TabControl();
            this.tabPageTreatments = new System.Windows.Forms.TabPage();
            this.tabPageProjections = new System.Windows.Forms.TabPage();
            this.chartProjection = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCurrent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelAnalysisFilter.SuspendLayout();
            this.panelCalculator.SuspendLayout();
            this.tabControlAnalysis.SuspendLayout();
            this.tabPageTreatments.SuspendLayout();
            this.tabPageProjections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProjection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrent)).BeginInit();
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
            this.panelAnalysisFilter.Location = new System.Drawing.Point(11, 39);
            this.panelAnalysisFilter.Name = "panelAnalysisFilter";
            this.panelAnalysisFilter.Size = new System.Drawing.Size(613, 690);
            this.panelAnalysisFilter.TabIndex = 21;
            // 
            // buttonRemoveRow
            // 
            this.buttonRemoveRow.Enabled = false;
            this.buttonRemoveRow.Image = global::tams4a.Properties.Resources.baseremove;
            this.buttonRemoveRow.Location = new System.Drawing.Point(544, 8);
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
            this.panelRows.Size = new System.Drawing.Size(607, 653);
            this.panelRows.TabIndex = 30;
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Image = global::tams4a.Properties.Resources.baseadd;
            this.buttonAddRow.Location = new System.Drawing.Point(570, 8);
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
            this.buttonCalculate.Location = new System.Drawing.Point(14, 8);
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
            this.textBoxBudget.Location = new System.Drawing.Point(797, 36);
            this.textBoxBudget.Name = "textBoxBudget";
            this.textBoxBudget.Size = new System.Drawing.Size(159, 20);
            this.textBoxBudget.TabIndex = 25;
            this.textBoxBudget.Text = "$0.00";
            this.textBoxBudget.GotFocus += new System.EventHandler(this.textBoxBudget_RemovePlaceholder);
            this.textBoxBudget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBudget_EnterPress);
            this.textBoxBudget.LostFocus += new System.EventHandler(this.textBoxBudget_AddPlaceholder);
            // 
            // labelBudget
            // 
            this.labelBudget.AutoSize = true;
            this.labelBudget.Location = new System.Drawing.Point(709, 39);
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
            this.panelCalculator.Location = new System.Drawing.Point(642, 63);
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
            this.buttonTreatmentCosts.Location = new System.Drawing.Point(11, 10);
            this.buttonTreatmentCosts.Name = "buttonTreatmentCosts";
            this.buttonTreatmentCosts.Size = new System.Drawing.Size(108, 23);
            this.buttonTreatmentCosts.TabIndex = 28;
            this.buttonTreatmentCosts.Text = "Treatment Costs";
            this.buttonTreatmentCosts.UseVisualStyleBackColor = true;
            this.buttonTreatmentCosts.Click += new System.EventHandler(this.buttonTreatmentCosts_Click);
            // 
            // tabControlAnalysis
            // 
            this.tabControlAnalysis.Controls.Add(this.tabPageTreatments);
            this.tabControlAnalysis.Controls.Add(this.tabPageProjections);
            this.tabControlAnalysis.Location = new System.Drawing.Point(-2, 0);
            this.tabControlAnalysis.Name = "tabControlAnalysis";
            this.tabControlAnalysis.SelectedIndex = 0;
            this.tabControlAnalysis.Size = new System.Drawing.Size(638, 769);
            this.tabControlAnalysis.TabIndex = 29;
            this.tabControlAnalysis.Tag = "";
            // 
            // tabPageTreatments
            // 
            this.tabPageTreatments.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageTreatments.Controls.Add(this.panelAnalysisFilter);
            this.tabPageTreatments.Controls.Add(this.buttonTreatmentCosts);
            this.tabPageTreatments.Location = new System.Drawing.Point(4, 22);
            this.tabPageTreatments.Name = "tabPageTreatments";
            this.tabPageTreatments.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTreatments.Size = new System.Drawing.Size(630, 743);
            this.tabPageTreatments.TabIndex = 0;
            this.tabPageTreatments.Text = "Treatments";
            // 
            // tabPageProjections
            // 
            this.tabPageProjections.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageProjections.Controls.Add(this.chartProjection);
            this.tabPageProjections.Controls.Add(this.chartCurrent);
            this.tabPageProjections.Location = new System.Drawing.Point(4, 22);
            this.tabPageProjections.Name = "tabPageProjections";
            this.tabPageProjections.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjections.Size = new System.Drawing.Size(630, 743);
            this.tabPageProjections.TabIndex = 1;
            this.tabPageProjections.Text = "Projections";
            // 
            // chartProjection
            // 
            chartArea1.Name = "ChartArea1";
            this.chartProjection.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartProjection.Legends.Add(legend1);
            this.chartProjection.Location = new System.Drawing.Point(10, 377);
            this.chartProjection.Name = "chartProjection";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartProjection.Series.Add(series1);
            this.chartProjection.Size = new System.Drawing.Size(606, 354);
            this.chartProjection.TabIndex = 3;
            this.chartProjection.Text = "chart1";
            // 
            // chartCurrent
            // 
            chartArea2.Name = "ChartArea1";
            this.chartCurrent.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartCurrent.Legends.Add(legend2);
            this.chartCurrent.Location = new System.Drawing.Point(10, 6);
            this.chartCurrent.Name = "chartCurrent";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartCurrent.Series.Add(series2);
            this.chartCurrent.Size = new System.Drawing.Size(606, 354);
            this.chartCurrent.TabIndex = 2;
            this.chartCurrent.Text = "chart1";
            // 
            // FormAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 765);
            this.Controls.Add(this.panelCalculator);
            this.Controls.Add(this.tabControlAnalysis);
            this.Controls.Add(this.labelBudget);
            this.Controls.Add(this.textBoxBudget);
            this.Name = "FormAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAnalysis";
            this.panelAnalysisFilter.ResumeLayout(false);
            this.panelAnalysisFilter.PerformLayout();
            this.panelCalculator.ResumeLayout(false);
            this.panelCalculator.PerformLayout();
            this.tabControlAnalysis.ResumeLayout(false);
            this.tabPageTreatments.ResumeLayout(false);
            this.tabPageProjections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartProjection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrent)).EndInit();
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
        private System.Windows.Forms.TabControl tabControlAnalysis;
        private System.Windows.Forms.TabPage tabPageTreatments;
        private System.Windows.Forms.TabPage tabPageProjections;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProjection;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCurrent;
    }
}