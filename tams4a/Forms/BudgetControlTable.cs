using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace tams4a.Forms
{
    internal class BudgetControlTable : TableLayoutPanel
    {
        private Label labelAreaCovered = new Label();
        private Label labelRSLx = new Label();
        private Label labelBudgetUsed = new Label();
        private Label labelPercentCovered = new Label();
        private RowStyle rowStyle = new RowStyle();
        private Dictionary<NumericUpDown, decimal> costBreakdown = new Dictionary<NumericUpDown, decimal>();
        private Dictionary<NumericUpDown, decimal> areaBreakdown = new Dictionary<NumericUpDown, decimal>();
        private bool beingHandled = false;
        private FormAnalysis formAnalysis;
        private double estBudget;

        public BudgetControlTable(FormAnalysis form, double budget)
        {
            formAnalysis = form;
            estBudget = budget;
            // 
            // labelAreaCovered
            // 
            labelAreaCovered.AutoSize = true;
            labelAreaCovered.Location = new System.Drawing.Point(138, 0);
            labelAreaCovered.Name = "labelAreaCovered";
            labelAreaCovered.Size = new System.Drawing.Size(75, 13);
            labelAreaCovered.TabIndex = 32;
            labelAreaCovered.Text = "Area  Covered";
            // 
            // labelRSLx
            // 
            labelRSLx.AutoSize = true;
            labelRSLx.Location = new System.Drawing.Point(3, 0);
            labelRSLx.Name = "labelRSLx";
            labelRSLx.Size = new System.Drawing.Size(28, 13);
            labelRSLx.TabIndex = 28;
            labelRSLx.Text = "RSL";
            // 
            // labelBudgetUsed
            // 
            labelBudgetUsed.AutoSize = true;
            labelBudgetUsed.Location = new System.Drawing.Point(43, 0);
            labelBudgetUsed.Name = "labelBudgetUsed";
            labelBudgetUsed.Size = new System.Drawing.Size(69, 13);
            labelBudgetUsed.TabIndex = 31;
            labelBudgetUsed.Text = "Budget Used";
            // 
            // labelPercentConvered
            // 
            labelPercentCovered.AutoSize = true;
            labelPercentCovered.Location = new System.Drawing.Point(233, 0);
            labelPercentCovered.Name = "labelPercentConvered";
            labelPercentCovered.Size = new System.Drawing.Size(58, 13);
            labelPercentCovered.TabIndex = 33;
            labelPercentCovered.Text = "% Covered";
            // 
            // tableBudgetControl
            // 
            AutoScroll = true;
            ColumnCount = 4;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            Controls.Add(labelAreaCovered, 2, 0);
            Controls.Add(labelRSLx, 0, 0);
            Controls.Add(labelBudgetUsed, 1, 0);
            Controls.Add(labelPercentCovered, 3, 0);
            Location = new System.Drawing.Point(14, 119);
            MaximumSize = new System.Drawing.Size(300, 565);
            Name = "tableBudgetControl";
            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Size = new System.Drawing.Size(300, 15);
            TabIndex = 32;
            Visible = true;
        }

        public void addRowTable(Dictionary<string, double> pricePerYard, Dictionary<int, double> rslArea, AnalysisRowPanel currentRow)
        {
            foreach (int i in rslArea.Keys)
            {
                if (rslArea[i] > 0)
                {
                    rowStyle = RowStyles[0];
                    Height += (int)(rowStyle.Height - 60);
                    RowStyles.Add(new RowStyle(rowStyle.SizeType, rowStyle.Height));
                    Controls.Add(new TextBox() { Text = i.ToString(), ReadOnly = true }, 0, RowCount++);
                    NumericUpDown budgetUpDown = new NumericUpDown()
                    {
                        Increment = 100,
                        Minimum = 0,
                        Maximum = (decimal)(pricePerYard[currentRow.getTreatment()] * (rslArea[i] / 9)),
                        Value = (decimal)(pricePerYard[currentRow.getTreatment()] * (rslArea[i] / 9)),
                    };
                    NumericUpDown areaUpDown = new NumericUpDown()
                    {
                        Increment = 100,
                        Minimum = 0,
                        Maximum = (decimal)(rslArea[i] / 9),
                        Value = (decimal)(rslArea[i] / 9)
                    };
                    NumericUpDown percentCoveredUpDown = new NumericUpDown()
                    {
                        Increment = 5,
                        Minimum = 0,
                        Maximum = 100,
                        Value = 100
                    };

                    double costPerYard = (double)(budgetUpDown.Value / areaUpDown.Value);

                    budgetUpDown.ValueChanged += new EventHandler(delegate (object sender, EventArgs e) { BudgetUpDown_ValueChanged(sender, e, costPerYard, budgetUpDown, areaUpDown, percentCoveredUpDown); });
                    areaUpDown.ValueChanged += new EventHandler(delegate (object sender, EventArgs e) { AreaUpDown_ValueChanged(sender, e, costPerYard, budgetUpDown, areaUpDown, percentCoveredUpDown); });
                    percentCoveredUpDown.ValueChanged += new EventHandler(delegate (object sender, EventArgs e) { PercentCoveredUpDown_ValueChanged(sender, e, costPerYard, budgetUpDown, areaUpDown, percentCoveredUpDown); });


                    costBreakdown[budgetUpDown] = budgetUpDown.Value;
                    areaBreakdown[areaUpDown] = areaUpDown.Value;
                    Controls.Add(budgetUpDown, 1, RowCount - 1);
                    Controls.Add(areaUpDown, 2, RowCount - 1);
                    Controls.Add(percentCoveredUpDown, 3, RowCount - 1);
                }
            }
            currentRow.tableCreated = true;
        }

        private void BudgetUpDown_ValueChanged(object sender, EventArgs e, double costPerYard, NumericUpDown budgetUpDown, NumericUpDown areaUpDown, NumericUpDown percentCoveredUpDown)
        {
            handleNumericUpDownChanges(costPerYard, budgetUpDown, areaUpDown, percentCoveredUpDown, "budget");
        }

        private void AreaUpDown_ValueChanged(object sender, EventArgs e, double costPerYard, NumericUpDown budgetUpDown, NumericUpDown areaUpDown, NumericUpDown percentCoveredUpDown)
        {
            handleNumericUpDownChanges(costPerYard, budgetUpDown, areaUpDown, percentCoveredUpDown, "area");
        }

        private void PercentCoveredUpDown_ValueChanged(object sender, EventArgs e, double costPerYard, NumericUpDown budgetUpDown, NumericUpDown areaUpDown, NumericUpDown percentCoveredUpDown)
        {
            handleNumericUpDownChanges(costPerYard, budgetUpDown, areaUpDown, percentCoveredUpDown, "percent");
        }

        private void handleNumericUpDownChanges(double costPerYard, NumericUpDown budgetUpDown, NumericUpDown areaUpDown, NumericUpDown percentCoveredUpDown, string caller)
        {
            if (beingHandled) return;
            beingHandled = true;


            //*********************************************
            //*      TOTAL AREA/COST ARE NOT WORKING      *
            //*********************************************

            double maxArea = (double)areaUpDown.Maximum;
            double maxCost = maxArea * costPerYard;

            decimal newArea = 0;
            decimal newCost = 0;
            decimal newPercentCovered = 0;

            if (caller == "area")
            {
                newCost = (decimal)((double)areaUpDown.Value * costPerYard);
                newPercentCovered = (decimal)(((double)areaUpDown.Value / (double)areaUpDown.Maximum) * 100);
                budgetUpDown.Value = newCost;
                percentCoveredUpDown.Value = newPercentCovered;
            }

            if (caller == "budget")
            {
                newArea = (decimal)((double)budgetUpDown.Value / costPerYard);
                newPercentCovered = (decimal)(((double)newArea / (double)areaUpDown.Maximum) * 100);
                areaUpDown.Value = newArea;
                percentCoveredUpDown.Value = newPercentCovered;
            }

            if (caller == "percent")
            {
                newArea = (decimal)((double)areaUpDown.Maximum * (((double)percentCoveredUpDown.Value) / 100));
                newCost = (decimal)((double)newArea * costPerYard);
                areaUpDown.Value = newArea;
                budgetUpDown.Value = newCost;
            }

            areaBreakdown[areaUpDown] = areaUpDown.Value;
            decimal totalTableArea = 0;
            foreach (decimal area in areaBreakdown.Values)
            {
                totalTableArea += area;
            }
            formAnalysis.totalArea -= maxArea - (double)totalTableArea;
            formAnalysis.textBoxTotalArea.Text = String.Format("{0:n0}", (Math.Round(formAnalysis.totalArea, 2))) + " yds\u00b2";

            costBreakdown[budgetUpDown] = budgetUpDown.Value;
            decimal totalTableCost = 0;
            foreach (decimal price in costBreakdown.Values)
            {
                totalTableCost += price;
            }
            formAnalysis.totalCost -= maxCost - (double)totalTableCost;
            formAnalysis.textBoxTotalCost.Text = "$" + String.Format("{0:n0}", formAnalysis.totalCost); ;
            if (formAnalysis.totalCost > estBudget)
            {
                formAnalysis.labelOverBudget.Text = "$" + String.Format("{0:n0}", (formAnalysis.totalCost - estBudget)) + " over budget!";
                formAnalysis.labelOverBudget.Visible = true;
            }
            else
            {
                formAnalysis.labelOverBudget.Visible = false;
            }

            beingHandled = false;
        }

    }
}