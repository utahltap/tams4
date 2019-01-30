namespace tams4a.Forms
{
    partial class FormDisplaySettings
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
            this.radioButtonLight = new System.Windows.Forms.RadioButton();
            this.radioButtonDark = new System.Windows.Forms.RadioButton();
            this.labelTheme = new System.Windows.Forms.Label();
            this.comboBoxRoadColors = new System.Windows.Forms.ComboBox();
            this.labelLegend = new System.Windows.Forms.Label();
            this.radioButtonOn = new System.Windows.Forms.RadioButton();
            this.radioButtonOff = new System.Windows.Forms.RadioButton();
            this.panelTheme = new System.Windows.Forms.Panel();
            this.panelLegend = new System.Windows.Forms.Panel();
            this.labelRoadColors = new System.Windows.Forms.Label();
            this.panelTheme.SuspendLayout();
            this.panelLegend.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonLight
            // 
            this.radioButtonLight.AccessibleName = "";
            this.radioButtonLight.AutoSize = true;
            this.radioButtonLight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLight.Location = new System.Drawing.Point(14, 28);
            this.radioButtonLight.Name = "radioButtonLight";
            this.radioButtonLight.Size = new System.Drawing.Size(54, 20);
            this.radioButtonLight.TabIndex = 0;
            this.radioButtonLight.TabStop = true;
            this.radioButtonLight.Text = "Light";
            this.radioButtonLight.UseVisualStyleBackColor = true;
            this.radioButtonLight.CheckedChanged += new System.EventHandler(this.radioButtonLight_CheckedChanged);
            // 
            // radioButtonDark
            // 
            this.radioButtonDark.AccessibleName = "";
            this.radioButtonDark.AutoSize = true;
            this.radioButtonDark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDark.Location = new System.Drawing.Point(14, 54);
            this.radioButtonDark.Name = "radioButtonDark";
            this.radioButtonDark.Size = new System.Drawing.Size(55, 20);
            this.radioButtonDark.TabIndex = 1;
            this.radioButtonDark.Text = "Dark";
            this.radioButtonDark.UseVisualStyleBackColor = true;
            this.radioButtonDark.CheckedChanged += new System.EventHandler(this.radioButtonDark_CheckedChanged);
            // 
            // labelTheme
            // 
            this.labelTheme.AutoSize = true;
            this.labelTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTheme.Location = new System.Drawing.Point(10, 5);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(58, 20);
            this.labelTheme.TabIndex = 3;
            this.labelTheme.Text = "Theme";
            // 
            // comboBoxRoadColors
            // 
            this.comboBoxRoadColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoadColors.FormattingEnabled = true;
            this.comboBoxRoadColors.Items.AddRange(new object[] {
            "RSL",
            "Treatment"});
            this.comboBoxRoadColors.Location = new System.Drawing.Point(148, 104);
            this.comboBoxRoadColors.Name = "comboBoxRoadColors";
            this.comboBoxRoadColors.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRoadColors.TabIndex = 4;
            this.comboBoxRoadColors.SelectedIndexChanged += new System.EventHandler(this.comboBoxRoadColors_SelectedIndexChanged);
            // 
            // labelLegend
            // 
            this.labelLegend.AutoSize = true;
            this.labelLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLegend.Location = new System.Drawing.Point(20, 5);
            this.labelLegend.Name = "labelLegend";
            this.labelLegend.Size = new System.Drawing.Size(63, 20);
            this.labelLegend.TabIndex = 5;
            this.labelLegend.Text = "Legend";
            // 
            // radioButtonOn
            // 
            this.radioButtonOn.AccessibleName = "";
            this.radioButtonOn.AutoSize = true;
            this.radioButtonOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOn.Location = new System.Drawing.Point(24, 28);
            this.radioButtonOn.Name = "radioButtonOn";
            this.radioButtonOn.Size = new System.Drawing.Size(43, 20);
            this.radioButtonOn.TabIndex = 6;
            this.radioButtonOn.Text = "On";
            this.radioButtonOn.UseVisualStyleBackColor = true;
            this.radioButtonOn.CheckedChanged += new System.EventHandler(this.radioButtonOn_CheckedChanged);
            // 
            // radioButtonOff
            // 
            this.radioButtonOff.AccessibleName = "";
            this.radioButtonOff.AutoSize = true;
            this.radioButtonOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOff.Location = new System.Drawing.Point(24, 54);
            this.radioButtonOff.Name = "radioButtonOff";
            this.radioButtonOff.Size = new System.Drawing.Size(42, 20);
            this.radioButtonOff.TabIndex = 7;
            this.radioButtonOff.Text = "Off";
            this.radioButtonOff.UseVisualStyleBackColor = true;
            this.radioButtonOff.CheckedChanged += new System.EventHandler(this.radioButtonOff_CheckedChanged);
            // 
            // panelTheme
            // 
            this.panelTheme.Controls.Add(this.labelTheme);
            this.panelTheme.Controls.Add(this.radioButtonDark);
            this.panelTheme.Controls.Add(this.radioButtonLight);
            this.panelTheme.Location = new System.Drawing.Point(7, 9);
            this.panelTheme.Name = "panelTheme";
            this.panelTheme.Size = new System.Drawing.Size(101, 75);
            this.panelTheme.TabIndex = 8;
            // 
            // panelLegend
            // 
            this.panelLegend.Controls.Add(this.radioButtonOff);
            this.panelLegend.Controls.Add(this.radioButtonOn);
            this.panelLegend.Controls.Add(this.labelLegend);
            this.panelLegend.Location = new System.Drawing.Point(124, 9);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(159, 75);
            this.panelLegend.TabIndex = 9;
            // 
            // labelRoadColors
            // 
            this.labelRoadColors.AutoSize = true;
            this.labelRoadColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoadColors.Location = new System.Drawing.Point(17, 104);
            this.labelRoadColors.Name = "labelRoadColors";
            this.labelRoadColors.Size = new System.Drawing.Size(97, 20);
            this.labelRoadColors.TabIndex = 10;
            this.labelRoadColors.Text = "Road Colors";
            // 
            // FormDisplaySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 151);
            this.Controls.Add(this.labelRoadColors);
            this.Controls.Add(this.panelLegend);
            this.Controls.Add(this.panelTheme);
            this.Controls.Add(this.comboBoxRoadColors);
            this.Name = "FormDisplaySettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormDisplaySettings";
            this.panelTheme.ResumeLayout(false);
            this.panelTheme.PerformLayout();
            this.panelLegend.ResumeLayout(false);
            this.panelLegend.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonLight;
        private System.Windows.Forms.RadioButton radioButtonDark;
        private System.Windows.Forms.Label labelTheme;
        private System.Windows.Forms.ComboBox comboBoxRoadColors;
        private System.Windows.Forms.Label labelLegend;
        private System.Windows.Forms.RadioButton radioButtonOn;
        public System.Windows.Forms.RadioButton radioButtonOff;
        private System.Windows.Forms.Panel panelTheme;
        private System.Windows.Forms.Panel panelLegend;
        private System.Windows.Forms.Label labelRoadColors;
    }
}