namespace tams4a.Forms
{
    partial class FormBudgetEstimator
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBudgetEstimator));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.finishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlRSL = new System.Windows.Forms.TabControl();
            this.tabPageRSL = new System.Windows.Forms.TabPage();
            this.tabControlBudgetData = new System.Windows.Forms.TabControl();
            this.tabPageBudgetData = new System.Windows.Forms.TabPage();
            this.dataGridViewRSL = new System.Windows.Forms.DataGridView();
            this.tabPageBudgetGraph = new System.Windows.Forms.TabPage();
            this.chartBudgetRSL = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageYearlyDist = new System.Windows.Forms.TabPage();
            this.chartYearlyDistribution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelFocusedYear = new System.Windows.Forms.Label();
            this.checkBoxVaried = new System.Windows.Forms.CheckBox();
            this.numericUpDownDisplayYear = new System.Windows.Forms.NumericUpDown();
            this.buttonResetRSL = new System.Windows.Forms.Button();
            this.buttonFuture = new System.Windows.Forms.Button();
            this.numericUpDownYear1 = new System.Windows.Forms.NumericUpDown();
            this.labelYears1 = new System.Windows.Forms.Label();
            this.buttonComputeRSL = new System.Windows.Forms.Button();
            this.labelTotalArea = new System.Windows.Forms.Label();
            this.numericUpDownTotals = new System.Windows.Forms.NumericUpDown();
            this.groupBoxTreatment = new System.Windows.Forms.GroupBox();
            this.groupBoxRehabilitation = new System.Windows.Forms.GroupBox();
            this.panelRehabilitation = new System.Windows.Forms.Panel();
            this.groupBoxReconstruction = new System.Windows.Forms.GroupBox();
            this.panelReconstruction = new System.Windows.Forms.Panel();
            this.groupBoxPreventative = new System.Windows.Forms.GroupBox();
            this.panelPreventative = new System.Windows.Forms.Panel();
            this.groupBoxRoutine = new System.Windows.Forms.GroupBox();
            this.panelRoutine = new System.Windows.Forms.Panel();
            this.tabPageBudget = new System.Windows.Forms.TabPage();
            this.chartBudget = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxAverageRSL = new System.Windows.Forms.TextBox();
            this.textBoxTargetsMet = new System.Windows.Forms.TextBox();
            this.labelAverage = new System.Windows.Forms.Label();
            this.labelTargetsMet = new System.Windows.Forms.Label();
            this.numericUpDownYear2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGraph = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxMaxBudget = new System.Windows.Forms.TextBox();
            this.labelMaxBudget = new System.Windows.Forms.Label();
            this.groupBoxTargets = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.tabControlRSL.SuspendLayout();
            this.tabPageRSL.SuspendLayout();
            this.tabControlBudgetData.SuspendLayout();
            this.tabPageBudgetData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRSL)).BeginInit();
            this.tabPageBudgetGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBudgetRSL)).BeginInit();
            this.tabPageYearlyDist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartYearlyDistribution)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDisplayYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotals)).BeginInit();
            this.groupBoxTreatment.SuspendLayout();
            this.groupBoxRehabilitation.SuspendLayout();
            this.groupBoxReconstruction.SuspendLayout();
            this.groupBoxPreventative.SuspendLayout();
            this.groupBoxRoutine.SuspendLayout();
            this.tabPageBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBudget)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.finishToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.categoriesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1076, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // finishToolStripMenuItem
            // 
            this.finishToolStripMenuItem.Name = "finishToolStripMenuItem";
            this.finishToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.finishToolStripMenuItem.Text = "Finish";
            this.finishToolStripMenuItem.Click += new System.EventHandler(this.finishToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphToolStripMenuItem,
            this.tableToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // graphToolStripMenuItem
            // 
            this.graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            this.graphToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.graphToolStripMenuItem.Text = "Graph";
            this.graphToolStripMenuItem.Click += new System.EventHandler(this.graphToolStripMenuItem_Click);
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.tableToolStripMenuItem.Text = "Table";
            this.tableToolStripMenuItem.Click += new System.EventHandler(this.tableToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.categoriesToolStripMenuItem.Text = "Categories";
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.categoriesToolStripMenuItem_Click);
            // 
            // tabControlRSL
            // 
            this.tabControlRSL.Controls.Add(this.tabPageRSL);
            this.tabControlRSL.Controls.Add(this.tabPageBudget);
            this.tabControlRSL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlRSL.Location = new System.Drawing.Point(0, 24);
            this.tabControlRSL.Name = "tabControlRSL";
            this.tabControlRSL.SelectedIndex = 0;
            this.tabControlRSL.Size = new System.Drawing.Size(1076, 741);
            this.tabControlRSL.TabIndex = 1;
            // 
            // tabPageRSL
            // 
            this.tabPageRSL.Controls.Add(this.tabControlBudgetData);
            this.tabPageRSL.Controls.Add(this.groupBox3);
            this.tabPageRSL.Controls.Add(this.groupBoxTreatment);
            this.tabPageRSL.Location = new System.Drawing.Point(4, 22);
            this.tabPageRSL.Name = "tabPageRSL";
            this.tabPageRSL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRSL.Size = new System.Drawing.Size(1068, 715);
            this.tabPageRSL.TabIndex = 0;
            this.tabPageRSL.Text = "RSL by Budget";
            this.tabPageRSL.UseVisualStyleBackColor = true;
            // 
            // tabControlBudgetData
            // 
            this.tabControlBudgetData.Controls.Add(this.tabPageBudgetData);
            this.tabControlBudgetData.Controls.Add(this.tabPageBudgetGraph);
            this.tabControlBudgetData.Controls.Add(this.tabPageYearlyDist);
            this.tabControlBudgetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlBudgetData.Location = new System.Drawing.Point(3, 332);
            this.tabControlBudgetData.Name = "tabControlBudgetData";
            this.tabControlBudgetData.SelectedIndex = 0;
            this.tabControlBudgetData.Size = new System.Drawing.Size(1062, 380);
            this.tabControlBudgetData.TabIndex = 2;
            // 
            // tabPageBudgetData
            // 
            this.tabPageBudgetData.Controls.Add(this.dataGridViewRSL);
            this.tabPageBudgetData.Location = new System.Drawing.Point(4, 22);
            this.tabPageBudgetData.Name = "tabPageBudgetData";
            this.tabPageBudgetData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBudgetData.Size = new System.Drawing.Size(1054, 354);
            this.tabPageBudgetData.TabIndex = 0;
            this.tabPageBudgetData.Text = "Data Table";
            this.tabPageBudgetData.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRSL
            // 
            this.dataGridViewRSL.AllowUserToAddRows = false;
            this.dataGridViewRSL.AllowUserToDeleteRows = false;
            this.dataGridViewRSL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRSL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRSL.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRSL.Name = "dataGridViewRSL";
            this.dataGridViewRSL.Size = new System.Drawing.Size(1048, 348);
            this.dataGridViewRSL.TabIndex = 3;
            // 
            // tabPageBudgetGraph
            // 
            this.tabPageBudgetGraph.Controls.Add(this.chartBudgetRSL);
            this.tabPageBudgetGraph.Location = new System.Drawing.Point(4, 22);
            this.tabPageBudgetGraph.Name = "tabPageBudgetGraph";
            this.tabPageBudgetGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBudgetGraph.Size = new System.Drawing.Size(1054, 354);
            this.tabPageBudgetGraph.TabIndex = 1;
            this.tabPageBudgetGraph.Text = "Graph";
            this.tabPageBudgetGraph.UseVisualStyleBackColor = true;
            // 
            // chartBudgetRSL
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBudgetRSL.ChartAreas.Add(chartArea1);
            this.chartBudgetRSL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBudgetRSL.Location = new System.Drawing.Point(3, 3);
            this.chartBudgetRSL.Name = "chartBudgetRSL";
            this.chartBudgetRSL.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            this.chartBudgetRSL.Size = new System.Drawing.Size(1048, 348);
            this.chartBudgetRSL.TabIndex = 0;
            this.chartBudgetRSL.Text = "RSLs Following Treatment Plan";
            // 
            // tabPageYearlyDist
            // 
            this.tabPageYearlyDist.Controls.Add(this.chartYearlyDistribution);
            this.tabPageYearlyDist.Location = new System.Drawing.Point(4, 22);
            this.tabPageYearlyDist.Name = "tabPageYearlyDist";
            this.tabPageYearlyDist.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageYearlyDist.Size = new System.Drawing.Size(1054, 354);
            this.tabPageYearlyDist.TabIndex = 2;
            this.tabPageYearlyDist.Text = "Yearly Distribution";
            this.tabPageYearlyDist.UseVisualStyleBackColor = true;
            // 
            // chartYearlyDistribution
            // 
            this.chartYearlyDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartYearlyDistribution.Location = new System.Drawing.Point(3, 3);
            this.chartYearlyDistribution.Name = "chartYearlyDistribution";
            this.chartYearlyDistribution.Size = new System.Drawing.Size(1048, 348);
            this.chartYearlyDistribution.TabIndex = 0;
            this.chartYearlyDistribution.Text = "chart1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelFocusedYear);
            this.groupBox3.Controls.Add(this.checkBoxVaried);
            this.groupBox3.Controls.Add(this.numericUpDownDisplayYear);
            this.groupBox3.Controls.Add(this.buttonResetRSL);
            this.groupBox3.Controls.Add(this.buttonFuture);
            this.groupBox3.Controls.Add(this.numericUpDownYear1);
            this.groupBox3.Controls.Add(this.labelYears1);
            this.groupBox3.Controls.Add(this.buttonComputeRSL);
            this.groupBox3.Controls.Add(this.labelTotalArea);
            this.groupBox3.Controls.Add(this.numericUpDownTotals);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 273);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1062, 59);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // labelFocusedYear
            // 
            this.labelFocusedYear.AutoSize = true;
            this.labelFocusedYear.Location = new System.Drawing.Point(284, 27);
            this.labelFocusedYear.Name = "labelFocusedYear";
            this.labelFocusedYear.Size = new System.Drawing.Size(76, 13);
            this.labelFocusedYear.TabIndex = 9;
            this.labelFocusedYear.Text = "Focused Year:";
            // 
            // checkBoxVaried
            // 
            this.checkBoxVaried.AutoSize = true;
            this.checkBoxVaried.Location = new System.Drawing.Point(142, 26);
            this.checkBoxVaried.Name = "checkBoxVaried";
            this.checkBoxVaried.Size = new System.Drawing.Size(123, 17);
            this.checkBoxVaried.TabIndex = 8;
            this.checkBoxVaried.Text = "Use Changing Plan?";
            this.checkBoxVaried.UseVisualStyleBackColor = true;
            // 
            // numericUpDownDisplayYear
            // 
            this.numericUpDownDisplayYear.Location = new System.Drawing.Point(367, 24);
            this.numericUpDownDisplayYear.Maximum = new decimal(new int[] {
            2028,
            0,
            0,
            0});
            this.numericUpDownDisplayYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.numericUpDownDisplayYear.Name = "numericUpDownDisplayYear";
            this.numericUpDownDisplayYear.Size = new System.Drawing.Size(73, 20);
            this.numericUpDownDisplayYear.TabIndex = 7;
            this.numericUpDownDisplayYear.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.numericUpDownDisplayYear.ValueChanged += new System.EventHandler(this.numericUpDownDisplayYear_ValueChanged);
            // 
            // buttonResetRSL
            // 
            this.buttonResetRSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetRSL.Location = new System.Drawing.Point(938, 16);
            this.buttonResetRSL.Name = "buttonResetRSL";
            this.buttonResetRSL.Size = new System.Drawing.Size(98, 31);
            this.buttonResetRSL.TabIndex = 6;
            this.buttonResetRSL.Text = "Reset RSL";
            this.buttonResetRSL.UseVisualStyleBackColor = true;
            this.buttonResetRSL.Click += new System.EventHandler(this.buttonResetRSL_Click);
            // 
            // buttonFuture
            // 
            this.buttonFuture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFuture.Location = new System.Drawing.Point(7, 16);
            this.buttonFuture.Name = "buttonFuture";
            this.buttonFuture.Size = new System.Drawing.Size(129, 31);
            this.buttonFuture.TabIndex = 5;
            this.buttonFuture.Text = "Future Treatments";
            this.buttonFuture.UseVisualStyleBackColor = true;
            this.buttonFuture.Click += new System.EventHandler(this.buttonFuture_Click);
            // 
            // numericUpDownYear1
            // 
            this.numericUpDownYear1.Location = new System.Drawing.Point(546, 24);
            this.numericUpDownYear1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownYear1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownYear1.Name = "numericUpDownYear1";
            this.numericUpDownYear1.Size = new System.Drawing.Size(81, 20);
            this.numericUpDownYear1.TabIndex = 4;
            this.numericUpDownYear1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownYear1.ValueChanged += new System.EventHandler(this.numericUpDownYear1_ValueChanged);
            // 
            // labelYears1
            // 
            this.labelYears1.AutoSize = true;
            this.labelYears1.Location = new System.Drawing.Point(451, 26);
            this.labelYears1.Name = "labelYears1";
            this.labelYears1.Size = new System.Drawing.Size(92, 13);
            this.labelYears1.TabIndex = 3;
            this.labelYears1.Text = "Years to Simulate:";
            // 
            // buttonComputeRSL
            // 
            this.buttonComputeRSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonComputeRSL.Location = new System.Drawing.Point(639, 16);
            this.buttonComputeRSL.Name = "buttonComputeRSL";
            this.buttonComputeRSL.Size = new System.Drawing.Size(98, 31);
            this.buttonComputeRSL.TabIndex = 2;
            this.buttonComputeRSL.Text = "Compute RSL";
            this.buttonComputeRSL.UseVisualStyleBackColor = true;
            this.buttonComputeRSL.Click += new System.EventHandler(this.buttonComputeRSL_Click);
            // 
            // labelTotalArea
            // 
            this.labelTotalArea.AutoSize = true;
            this.labelTotalArea.Location = new System.Drawing.Point(749, 26);
            this.labelTotalArea.Name = "labelTotalArea";
            this.labelTotalArea.Size = new System.Drawing.Size(96, 13);
            this.labelTotalArea.TabIndex = 1;
            this.labelTotalArea.Text = "Total Area Treated";
            // 
            // numericUpDownTotals
            // 
            this.numericUpDownTotals.Enabled = false;
            this.numericUpDownTotals.Location = new System.Drawing.Point(853, 24);
            this.numericUpDownTotals.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownTotals.Name = "numericUpDownTotals";
            this.numericUpDownTotals.Size = new System.Drawing.Size(79, 20);
            this.numericUpDownTotals.TabIndex = 0;
            // 
            // groupBoxTreatment
            // 
            this.groupBoxTreatment.AutoSize = true;
            this.groupBoxTreatment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxTreatment.Controls.Add(this.groupBoxRehabilitation);
            this.groupBoxTreatment.Controls.Add(this.groupBoxReconstruction);
            this.groupBoxTreatment.Controls.Add(this.groupBoxPreventative);
            this.groupBoxTreatment.Controls.Add(this.groupBoxRoutine);
            this.groupBoxTreatment.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTreatment.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTreatment.MinimumSize = new System.Drawing.Size(1000, 270);
            this.groupBoxTreatment.Name = "groupBoxTreatment";
            this.groupBoxTreatment.Size = new System.Drawing.Size(1062, 270);
            this.groupBoxTreatment.TabIndex = 0;
            this.groupBoxTreatment.TabStop = false;
            this.groupBoxTreatment.Text = "Treatment by Percent Area";
            // 
            // groupBoxRehabilitation
            // 
            this.groupBoxRehabilitation.Controls.Add(this.panelRehabilitation);
            this.groupBoxRehabilitation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRehabilitation.Location = new System.Drawing.Point(494, 16);
            this.groupBoxRehabilitation.Name = "groupBoxRehabilitation";
            this.groupBoxRehabilitation.Size = new System.Drawing.Size(294, 251);
            this.groupBoxRehabilitation.TabIndex = 5;
            this.groupBoxRehabilitation.TabStop = false;
            this.groupBoxRehabilitation.Text = "Rehabilitation";
            // 
            // panelRehabilitation
            // 
            this.panelRehabilitation.AutoScroll = true;
            this.panelRehabilitation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRehabilitation.Location = new System.Drawing.Point(3, 16);
            this.panelRehabilitation.Name = "panelRehabilitation";
            this.panelRehabilitation.Size = new System.Drawing.Size(288, 232);
            this.panelRehabilitation.TabIndex = 1;
            // 
            // groupBoxReconstruction
            // 
            this.groupBoxReconstruction.Controls.Add(this.panelReconstruction);
            this.groupBoxReconstruction.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxReconstruction.Location = new System.Drawing.Point(788, 16);
            this.groupBoxReconstruction.Name = "groupBoxReconstruction";
            this.groupBoxReconstruction.Size = new System.Drawing.Size(271, 251);
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
            this.panelReconstruction.Size = new System.Drawing.Size(265, 232);
            this.panelReconstruction.TabIndex = 0;
            // 
            // groupBoxPreventative
            // 
            this.groupBoxPreventative.Controls.Add(this.panelPreventative);
            this.groupBoxPreventative.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxPreventative.Location = new System.Drawing.Point(245, 16);
            this.groupBoxPreventative.Name = "groupBoxPreventative";
            this.groupBoxPreventative.Size = new System.Drawing.Size(249, 251);
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
            this.panelPreventative.Size = new System.Drawing.Size(243, 232);
            this.panelPreventative.TabIndex = 0;
            // 
            // groupBoxRoutine
            // 
            this.groupBoxRoutine.Controls.Add(this.panelRoutine);
            this.groupBoxRoutine.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxRoutine.Location = new System.Drawing.Point(3, 16);
            this.groupBoxRoutine.Name = "groupBoxRoutine";
            this.groupBoxRoutine.Size = new System.Drawing.Size(242, 251);
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
            this.panelRoutine.Size = new System.Drawing.Size(236, 232);
            this.panelRoutine.TabIndex = 1;
            // 
            // tabPageBudget
            // 
            this.tabPageBudget.Controls.Add(this.chartBudget);
            this.tabPageBudget.Controls.Add(this.groupBox2);
            this.tabPageBudget.Controls.Add(this.groupBox1);
            this.tabPageBudget.Location = new System.Drawing.Point(4, 22);
            this.tabPageBudget.Name = "tabPageBudget";
            this.tabPageBudget.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBudget.Size = new System.Drawing.Size(1068, 715);
            this.tabPageBudget.TabIndex = 1;
            this.tabPageBudget.Text = "Budget by Target";
            this.tabPageBudget.UseVisualStyleBackColor = true;
            // 
            // chartBudget
            // 
            this.chartBudget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBudget.Location = new System.Drawing.Point(180, 61);
            this.chartBudget.Name = "chartBudget";
            series1.Name = "Series1";
            this.chartBudget.Series.Add(series1);
            this.chartBudget.Size = new System.Drawing.Size(885, 651);
            this.chartBudget.TabIndex = 7;
            this.chartBudget.Text = "Budget Projections";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxAverageRSL);
            this.groupBox2.Controls.Add(this.textBoxTargetsMet);
            this.groupBox2.Controls.Add(this.labelAverage);
            this.groupBox2.Controls.Add(this.labelTargetsMet);
            this.groupBox2.Controls.Add(this.numericUpDownYear2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonGraph);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(180, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(885, 58);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // textBoxAverageRSL
            // 
            this.textBoxAverageRSL.Enabled = false;
            this.textBoxAverageRSL.Location = new System.Drawing.Point(676, 24);
            this.textBoxAverageRSL.Name = "textBoxAverageRSL";
            this.textBoxAverageRSL.Size = new System.Drawing.Size(94, 20);
            this.textBoxAverageRSL.TabIndex = 9;
            // 
            // textBoxTargetsMet
            // 
            this.textBoxTargetsMet.Enabled = false;
            this.textBoxTargetsMet.Location = new System.Drawing.Point(472, 26);
            this.textBoxTargetsMet.Name = "textBoxTargetsMet";
            this.textBoxTargetsMet.Size = new System.Drawing.Size(94, 20);
            this.textBoxTargetsMet.TabIndex = 8;
            this.textBoxTargetsMet.Visible = false;
            // 
            // labelAverage
            // 
            this.labelAverage.AutoSize = true;
            this.labelAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.labelAverage.Location = new System.Drawing.Point(589, 27);
            this.labelAverage.Name = "labelAverage";
            this.labelAverage.Size = new System.Drawing.Size(81, 15);
            this.labelAverage.TabIndex = 7;
            this.labelAverage.Text = "Average RSL:";
            // 
            // labelTargetsMet
            // 
            this.labelTargetsMet.AutoSize = true;
            this.labelTargetsMet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.labelTargetsMet.Location = new System.Drawing.Point(387, 27);
            this.labelTargetsMet.Name = "labelTargetsMet";
            this.labelTargetsMet.Size = new System.Drawing.Size(79, 15);
            this.labelTargetsMet.TabIndex = 6;
            this.labelTargetsMet.Text = "Targets Met?";
            this.labelTargetsMet.Visible = false;
            // 
            // numericUpDownYear2
            // 
            this.numericUpDownYear2.Location = new System.Drawing.Point(128, 27);
            this.numericUpDownYear2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownYear2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownYear2.Name = "numericUpDownYear2";
            this.numericUpDownYear2.Size = new System.Drawing.Size(81, 20);
            this.numericUpDownYear2.TabIndex = 5;
            this.numericUpDownYear2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Years to Simulate:";
            // 
            // buttonGraph
            // 
            this.buttonGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonGraph.Location = new System.Drawing.Point(224, 16);
            this.buttonGraph.Name = "buttonGraph";
            this.buttonGraph.Size = new System.Drawing.Size(126, 36);
            this.buttonGraph.TabIndex = 0;
            this.buttonGraph.Text = "Generate Graph";
            this.buttonGraph.UseVisualStyleBackColor = true;
            this.buttonGraph.Click += new System.EventHandler(this.buttonGraph_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMaxBudget);
            this.groupBox1.Controls.Add(this.labelMaxBudget);
            this.groupBox1.Controls.Add(this.groupBoxTargets);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 709);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // textBoxMaxBudget
            // 
            this.textBoxMaxBudget.Location = new System.Drawing.Point(34, 38);
            this.textBoxMaxBudget.Name = "textBoxMaxBudget";
            this.textBoxMaxBudget.Size = new System.Drawing.Size(100, 20);
            this.textBoxMaxBudget.TabIndex = 2;
            // 
            // labelMaxBudget
            // 
            this.labelMaxBudget.AutoSize = true;
            this.labelMaxBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.labelMaxBudget.Location = new System.Drawing.Point(31, 16);
            this.labelMaxBudget.Name = "labelMaxBudget";
            this.labelMaxBudget.Size = new System.Drawing.Size(105, 15);
            this.labelMaxBudget.TabIndex = 1;
            this.labelMaxBudget.Text = "Maximum Budget";
            // 
            // groupBoxTargets
            // 
            this.groupBoxTargets.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxTargets.Location = new System.Drawing.Point(3, 85);
            this.groupBoxTargets.Name = "groupBoxTargets";
            this.groupBoxTargets.Size = new System.Drawing.Size(171, 621);
            this.groupBoxTargets.TabIndex = 0;
            this.groupBoxTargets.TabStop = false;
            this.groupBoxTargets.Text = "Target RSL Percentages";
            // 
            // FormBudgetEstimator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 765);
            this.Controls.Add(this.tabControlRSL);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1020, 800);
            this.Name = "FormBudgetEstimator";
            this.Text = "Budget Projections";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControlRSL.ResumeLayout(false);
            this.tabPageRSL.ResumeLayout(false);
            this.tabPageRSL.PerformLayout();
            this.tabControlBudgetData.ResumeLayout(false);
            this.tabPageBudgetData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRSL)).EndInit();
            this.tabPageBudgetGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBudgetRSL)).EndInit();
            this.tabPageYearlyDist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartYearlyDistribution)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDisplayYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotals)).EndInit();
            this.groupBoxTreatment.ResumeLayout(false);
            this.groupBoxRehabilitation.ResumeLayout(false);
            this.groupBoxReconstruction.ResumeLayout(false);
            this.groupBoxPreventative.ResumeLayout(false);
            this.groupBoxRoutine.ResumeLayout(false);
            this.tabPageBudget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBudget)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem finishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlRSL;
        private System.Windows.Forms.TabPage tabPageRSL;
        private System.Windows.Forms.TabPage tabPageBudget;
        private System.Windows.Forms.GroupBox groupBoxTargets;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonGraph;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBudget;
        private System.Windows.Forms.GroupBox groupBoxTreatment;
        private System.Windows.Forms.GroupBox groupBoxPreventative;
        private System.Windows.Forms.GroupBox groupBoxRoutine;
        private System.Windows.Forms.Button buttonComputeRSL;
        private System.Windows.Forms.Label labelTotalArea;
        private System.Windows.Forms.NumericUpDown numericUpDownTotals;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownYear1;
        private System.Windows.Forms.Label labelYears1;
        private System.Windows.Forms.GroupBox groupBoxReconstruction;
        private System.Windows.Forms.TabControl tabControlBudgetData;
        private System.Windows.Forms.TabPage tabPageBudgetData;
        private System.Windows.Forms.TabPage tabPageBudgetGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBudgetRSL;
        private System.Windows.Forms.DataGridView dataGridViewRSL;
        private System.Windows.Forms.NumericUpDown numericUpDownYear2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFuture;
        private System.Windows.Forms.Panel panelReconstruction;
        private System.Windows.Forms.Panel panelRehabilitation;
        private System.Windows.Forms.Panel panelPreventative;
        private System.Windows.Forms.Panel panelRoutine;
        private System.Windows.Forms.GroupBox groupBoxRehabilitation;
        private System.Windows.Forms.TabPage tabPageYearlyDist;
        private System.Windows.Forms.Button buttonResetRSL;
        private System.Windows.Forms.CheckBox checkBoxVaried;
        private System.Windows.Forms.NumericUpDown numericUpDownDisplayYear;
        private System.Windows.Forms.Label labelFocusedYear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartYearlyDistribution;
        private System.Windows.Forms.TextBox textBoxMaxBudget;
        private System.Windows.Forms.Label labelMaxBudget;
        private System.Windows.Forms.TextBox textBoxAverageRSL;
        private System.Windows.Forms.TextBox textBoxTargetsMet;
        private System.Windows.Forms.Label labelAverage;
        private System.Windows.Forms.Label labelTargetsMet;
    }
}