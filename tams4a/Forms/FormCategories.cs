using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tams4a.Forms
{
    public partial class FormCategories : Form
    {
        private Label[] categoryLabels;
        private NumericUpDown[] categoryInput;

        /// <summary>
        /// Used to set the number of categories and the max RSL for each category in the budget estimation tool.
        /// </summary>
        public FormCategories()
        {
            InitializeComponent();
            numericUpDownCategories.Value = 8;
            enableCategories();
            categoryInput[0].Value = 0;
            for (int i = 1; i < 7; i++)
            {
                categoryInput[i].Value = 3 * i;
            }
        }

        private void categoryNumber_changed(object sender, EventArgs e)
        {
            enableCategories();
        }

        /// <summary>
        /// Initializes controls and sets their properties and default values.
        /// </summary>
        private void enableCategories()
        {
            groupBoxCategories.Controls.Clear();
            categoryLabels = new Label[(int)numericUpDownCategories.Value];
            categoryInput = new NumericUpDown[(int)numericUpDownCategories.Value];
            int min = 0;
            for (int i = 1; i <= numericUpDownCategories.Value; i++)
            {
                int x = 27 + 78 * ((i - 1) / 6);
                int y = 50 + 24 * ((i - 1) % 6);
                categoryLabels[i-1] = new Label();
                categoryLabels[i-1].Text = i.ToString();
                categoryLabels[i - 1].Size = new Size(24, 12);
                categoryLabels[i-1].Location = new Point(x, y);
                groupBoxCategories.Controls.Add(categoryLabels[i - 1]);

                categoryInput[i - 1] = new NumericUpDown();
                if (numericUpDownCategories.Value < 21)
                {
                    categoryInput[i - 1].Minimum = min;
                    categoryInput[i - 1].Maximum = 20 - (numericUpDownCategories.Value - i);
                    min = 20 / (int)numericUpDownCategories.Value * i + 1;
                    categoryInput[i - 1].Value = min - 1;
                }
                else
                {
                    categoryInput[i - 1].Minimum = i-1;
                    categoryInput[i - 1].Maximum = i-1;
                    categoryInput[i - 1].Value = i-1;
                }
                categoryInput[i - 1].Location = new Point(x + 24, y);
                categoryInput[i - 1].Size = new Size(48, 12);
                categoryInput[i - 1].Increment = 1;
                if (i == numericUpDownCategories.Value)
                {
                    categoryInput[i - 1].Value = 20;
                    categoryInput[i - 1].Enabled = false;
                }
                categoryInput[i - 1].ValueChanged += setLimits;
                groupBoxCategories.Controls.Add(categoryInput[i - 1]);
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void setLimits(object sender, EventArgs e)
        {
            int min = 0;
            for (int i = 0; i < numericUpDownCategories.Value; i++)
            {
                categoryInput[i].Minimum = min;
                min = (int)categoryInput[i].Value + 1;
            }
        }

        /// <summary>
        /// Returns an arrray of integers representing the RSL categories for use in the budget estimator.
        /// </summary>
        /// <returns></returns>
        public int[] getRSLcategories()
        {
            int[] values = new int[(int)numericUpDownCategories.Value];
            for (int i = 0; i < numericUpDownCategories.Value; i++)
            {
                values[i] = (int)categoryInput[i].Value;
            }
            return values;
        }
    }
}
