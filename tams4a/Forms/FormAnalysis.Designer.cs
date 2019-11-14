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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnalysis));
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
            this.panelRowTotal = new System.Windows.Forms.Panel();
            this.textBoxRowPercent = new System.Windows.Forms.TextBox();
            this.textBoxRowArea = new System.Windows.Forms.TextBox();
            this.textBoxRowCost = new System.Windows.Forms.TextBox();
            this.labelRowTotal = new System.Windows.Forms.Label();
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
            this.labelLength = new System.Windows.Forms.Label();
            this.labelProject = new System.Windows.Forms.Label();
            this.labelSlider = new System.Windows.Forms.Label();
            this.sliderProjectLength = new System.Windows.Forms.TrackBar();
            this.buttonAllRows = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.chartProjection = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCurrent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelAnalysisFilter.SuspendLayout();
            this.panelCalculator.SuspendLayout();
            this.panelRowTotal.SuspendLayout();
            this.tabControlAnalysis.SuspendLayout();
            this.tabPageTreatments.SuspendLayout();
            this.tabPageProjections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderProjectLength)).BeginInit();
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
            this.panelAnalysisFilter.Size = new System.Drawing.Size(613, 730);
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
            this.panelRows.Size = new System.Drawing.Size(607, 692);
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
            this.panelCalculator.Controls.Add(this.panelRowTotal);
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
            this.panelCalculator.Size = new System.Drawing.Size(331, 728);
            this.panelCalculator.TabIndex = 27;
            // 
            // panelRowTotal
            // 
            this.panelRowTotal.Controls.Add(this.textBoxRowPercent);
            this.panelRowTotal.Controls.Add(this.textBoxRowArea);
            this.panelRowTotal.Controls.Add(this.textBoxRowCost);
            this.panelRowTotal.Controls.Add(this.labelRowTotal);
            this.panelRowTotal.Location = new System.Drawing.Point(3, 150);
            this.panelRowTotal.Name = "panelRowTotal";
            this.panelRowTotal.Size = new System.Drawing.Size(325, 26);
            this.panelRowTotal.TabIndex = 37;
            this.panelRowTotal.Visible = false;
            // 
            // textBoxRowPercent
            // 
            this.textBoxRowPercent.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRowPercent.Location = new System.Drawing.Point(244, 3);
            this.textBoxRowPercent.Name = "textBoxRowPercent";
            this.textBoxRowPercent.ReadOnly = true;
            this.textBoxRowPercent.Size = new System.Drawing.Size(64, 20);
            this.textBoxRowPercent.TabIndex = 39;
            // 
            // textBoxRowArea
            // 
            this.textBoxRowArea.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRowArea.Location = new System.Drawing.Point(149, 3);
            this.textBoxRowArea.Name = "textBoxRowArea";
            this.textBoxRowArea.ReadOnly = true;
            this.textBoxRowArea.Size = new System.Drawing.Size(90, 20);
            this.textBoxRowArea.TabIndex = 38;
            // 
            // textBoxRowCost
            // 
            this.textBoxRowCost.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRowCost.Location = new System.Drawing.Point(54, 3);
            this.textBoxRowCost.Name = "textBoxRowCost";
            this.textBoxRowCost.ReadOnly = true;
            this.textBoxRowCost.Size = new System.Drawing.Size(90, 20);
            this.textBoxRowCost.TabIndex = 37;
            // 
            // labelRowTotal
            // 
            this.labelRowTotal.AutoSize = true;
            this.labelRowTotal.Location = new System.Drawing.Point(-2, 6);
            this.labelRowTotal.Name = "labelRowTotal";
            this.labelRowTotal.Size = new System.Drawing.Size(56, 13);
            this.labelRowTotal.TabIndex = 36;
            this.labelRowTotal.Text = "Row Total";
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
            this.tabControlAnalysis.Size = new System.Drawing.Size(638, 800);
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
            this.tabPageTreatments.Size = new System.Drawing.Size(630, 774);
            this.tabPageTreatments.TabIndex = 0;
            this.tabPageTreatments.Text = "Treatments";
            // 
            // tabPageProjections
            // 
            this.tabPageProjections.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageProjections.Controls.Add(this.labelLength);
            this.tabPageProjections.Controls.Add(this.labelProject);
            this.tabPageProjections.Controls.Add(this.labelSlider);
            this.tabPageProjections.Controls.Add(this.sliderProjectLength);
            this.tabPageProjections.Controls.Add(this.buttonAllRows);
            this.tabPageProjections.Controls.Add(this.buttonRefresh);
            this.tabPageProjections.Controls.Add(this.chartProjection);
            this.tabPageProjections.Controls.Add(this.chartCurrent);
            this.tabPageProjections.Location = new System.Drawing.Point(4, 22);
            this.tabPageProjections.Name = "tabPageProjections";
            this.tabPageProjections.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjections.Size = new System.Drawing.Size(630, 774);
            this.tabPageProjections.TabIndex = 1;
            this.tabPageProjections.Text = "Projections";
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelLength.Location = new System.Drawing.Point(17, 437);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(40, 13);
            this.labelLength.TabIndex = 9;
            this.labelLength.Text = "Length";
            // 
            // labelProject
            // 
            this.labelProject.AutoSize = true;
            this.labelProject.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelProject.Location = new System.Drawing.Point(17, 422);
            this.labelProject.Name = "labelProject";
            this.labelProject.Size = new System.Drawing.Size(40, 13);
            this.labelProject.TabIndex = 8;
            this.labelProject.Text = "Project";
            // 
            // labelSlider
            // 
            this.labelSlider.AutoSize = true;
            this.labelSlider.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSlider.Location = new System.Drawing.Point(65, 439);
            this.labelSlider.Name = "labelSlider";
            this.labelSlider.Size = new System.Drawing.Size(109, 13);
            this.labelSlider.TabIndex = 7;
            this.labelSlider.Text = "0 1 2 3 4 5 6 7 8 9 10";
            // 
            // sliderProjectLength
            // 
            this.sliderProjectLength.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sliderProjectLength.Location = new System.Drawing.Point(58, 417);
            this.sliderProjectLength.Name = "sliderProjectLength";
            this.sliderProjectLength.Size = new System.Drawing.Size(117, 45);
            this.sliderProjectLength.TabIndex = 6;
            this.sliderProjectLength.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderProjectLength.Scroll += new System.EventHandler(this.sliderProjectLength_Scroll);
            // 
            // buttonAllRows
            // 
            this.buttonAllRows.Location = new System.Drawing.Point(448, 429);
            this.buttonAllRows.Name = "buttonAllRows";
            this.buttonAllRows.Size = new System.Drawing.Size(75, 23);
            this.buttonAllRows.TabIndex = 5;
            this.buttonAllRows.Text = "All Rows";
            this.buttonAllRows.UseVisualStyleBackColor = true;
            this.buttonAllRows.Click += new System.EventHandler(this.buttonAllRows_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(529, 429);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // chartProjection
            // 
            chartArea1.Name = "ChartArea1";
            this.chartProjection.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartProjection.Legends.Add(legend1);
            this.chartProjection.Location = new System.Drawing.Point(10, 415);
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
            this.chartCurrent.Location = new System.Drawing.Point(10, 41);
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
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(985, 803);
            this.Controls.Add(this.panelCalculator);
            this.Controls.Add(this.tabControlAnalysis);
            this.Controls.Add(this.labelBudget);
            this.Controls.Add(this.textBoxBudget);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1001, 842);
            this.MinimumSize = new System.Drawing.Size(1001, 842);
            this.Name = "FormAnalysis";
            this.Opacity = 0.9D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAnalysis";
            this.panelAnalysisFilter.ResumeLayout(false);
            this.panelAnalysisFilter.PerformLayout();
            this.panelCalculator.ResumeLayout(false);
            this.panelCalculator.PerformLayout();
            this.panelRowTotal.ResumeLayout(false);
            this.panelRowTotal.PerformLayout();
            this.tabControlAnalysis.ResumeLayout(false);
            this.tabPageTreatments.ResumeLayout(false);
            this.tabPageProjections.ResumeLayout(false);
            this.tabPageProjections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderProjectLength)).EndInit();
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
        public System.Windows.Forms.ComboBox comboBoxResultsRow;
        private System.Windows.Forms.Label labelResultsRow;
        private System.Windows.Forms.Button buttonFullRowData;
        private System.Windows.Forms.TabControl tabControlAnalysis;
        private System.Windows.Forms.TabPage tabPageTreatments;
        private System.Windows.Forms.TabPage tabPageProjections;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProjection;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCurrent;
        public System.Windows.Forms.Panel panelRowTotal;
        public System.Windows.Forms.TextBox textBoxRowPercent;
        public System.Windows.Forms.TextBox textBoxRowArea;
        public System.Windows.Forms.TextBox textBoxRowCost;
        private System.Windows.Forms.Label labelRowTotal;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonAllRows;
        private System.Windows.Forms.TrackBar sliderProjectLength;
        private System.Windows.Forms.Label labelSlider;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.Label labelProject;
    }
}