namespace tams4a.Forms
{
    partial class FormQueryBuilder
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
            this.labelTable = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.comboBoxColumn = new System.Windows.Forms.ComboBox();
            this.comboBoxComparision = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelComparison = new System.Windows.Forms.Label();
            this.labelColumn = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTable
            // 
            this.labelTable.AutoSize = true;
            this.labelTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelTable.Location = new System.Drawing.Point(12, 9);
            this.labelTable.Name = "labelTable";
            this.labelTable.Size = new System.Drawing.Size(147, 15);
            this.labelTable.TabIndex = 0;
            this.labelTable.Text = "Create a Custom Report";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(447, 154);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "Okay";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 154);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxValue);
            this.panel1.Controls.Add(this.comboBoxColumn);
            this.panel1.Controls.Add(this.comboBoxComparision);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelComparison);
            this.panel1.Controls.Add(this.labelColumn);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 121);
            this.panel1.TabIndex = 3;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(243, 25);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(131, 20);
            this.textBoxValue.TabIndex = 14;
            // 
            // comboBoxColumn
            // 
            this.comboBoxColumn.FormattingEnabled = true;
            this.comboBoxColumn.Items.AddRange(new object[] {
                "ID",
                "TAMDID",
                "Survey Date",
                "Name",
                "Speed Limit",
                "Lanes",
                "Width",
                "Length",
                "Functional Classification",
                "Surface",
                "From Address",
                "To Address",
                "RSL",
                "Suggested Treatment",
            });
            this.comboBoxColumn.Location = new System.Drawing.Point(13, 25);
            this.comboBoxColumn.Name = "comboBoxColumn";
            this.comboBoxColumn.Size = new System.Drawing.Size(134, 21);
            this.comboBoxColumn.TabIndex = 13;
            // 
            // comboBoxComparision
            // 
            this.comboBoxComparision.FormattingEnabled = true;
            this.comboBoxComparision.Items.AddRange(new object[] {
                "=",
                ">=",
                ">",
                "<=",
                "<",
                "<>"
            });
            this.comboBoxComparision.Location = new System.Drawing.Point(153, 24);
            this.comboBoxComparision.Name = "comboBoxComparision";
            this.comboBoxComparision.Size = new System.Drawing.Size(84, 21);
            this.comboBoxComparision.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Value";
            // 
            // labelComparison
            // 
            this.labelComparison.AutoSize = true;
            this.labelComparison.Location = new System.Drawing.Point(150, 8);
            this.labelComparison.Name = "labelComparison";
            this.labelComparison.Size = new System.Drawing.Size(64, 13);
            this.labelComparison.TabIndex = 10;
            this.labelComparison.Text = "Comparision";
            // 
            // labelColumn
            // 
            this.labelColumn.AutoSize = true;
            this.labelColumn.Location = new System.Drawing.Point(10, 9);
            this.labelColumn.Name = "labelColumn";
            this.labelColumn.Size = new System.Drawing.Size(42, 13);
            this.labelColumn.TabIndex = 9;
            this.labelColumn.Text = "Column";
            // 
            // FormQueryBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 189);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelTable);
            this.Name = "FormQueryBuilder";
            this.Text = "Report Builder";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTable;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelColumn;
        private System.Windows.Forms.Label labelComparison;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxComparision;
        private System.Windows.Forms.ComboBox comboBoxColumn;
        private System.Windows.Forms.TextBox textBoxValue;
    }
}