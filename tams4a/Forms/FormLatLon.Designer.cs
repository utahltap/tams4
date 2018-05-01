namespace tams4a.Forms
{
    partial class FormLatLon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLatLon));
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOkay = new System.Windows.Forms.Button();
            this.tabControlDegree = new System.Windows.Forms.TabControl();
            this.tabPageDecimal = new System.Windows.Forms.TabPage();
            this.labelInstructions2 = new System.Windows.Forms.Label();
            this.groupBoxEW1 = new System.Windows.Forms.GroupBox();
            this.radioButtonEast1 = new System.Windows.Forms.RadioButton();
            this.radioButtonWest1 = new System.Windows.Forms.RadioButton();
            this.groupBoxNS1 = new System.Windows.Forms.GroupBox();
            this.radioButtonNorth1 = new System.Windows.Forms.RadioButton();
            this.radioButtonSouth1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLon1 = new System.Windows.Forms.Label();
            this.labelLat1 = new System.Windows.Forms.Label();
            this.textBoxLongitude = new System.Windows.Forms.TextBox();
            this.textBoxLatitude = new System.Windows.Forms.TextBox();
            this.tabPageDMS = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxLonSec = new System.Windows.Forms.TextBox();
            this.textBoxLatSec = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxLonMin = new System.Windows.Forms.TextBox();
            this.textBoxLatMin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxEW2 = new System.Windows.Forms.GroupBox();
            this.radioButtonEast2 = new System.Windows.Forms.RadioButton();
            this.radioButtonWest2 = new System.Windows.Forms.RadioButton();
            this.groupBoxNS2 = new System.Windows.Forms.GroupBox();
            this.radioButtonNorth2 = new System.Windows.Forms.RadioButton();
            this.radioButtonSout2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxLonDeg = new System.Windows.Forms.TextBox();
            this.textBoxLatDeg = new System.Windows.Forms.TextBox();
            this.groupBoxButtons.SuspendLayout();
            this.tabControlDegree.SuspendLayout();
            this.tabPageDecimal.SuspendLayout();
            this.groupBoxEW1.SuspendLayout();
            this.groupBoxNS1.SuspendLayout();
            this.tabPageDMS.SuspendLayout();
            this.groupBoxEW2.SuspendLayout();
            this.groupBoxNS2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.buttonCancel);
            this.groupBoxButtons.Controls.Add(this.buttonOkay);
            this.groupBoxButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxButtons.Location = new System.Drawing.Point(0, 156);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(452, 60);
            this.groupBoxButtons.TabIndex = 1;
            this.groupBoxButtons.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(12, 20);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOkay
            // 
            this.buttonOkay.Location = new System.Drawing.Point(365, 20);
            this.buttonOkay.Name = "buttonOkay";
            this.buttonOkay.Size = new System.Drawing.Size(75, 23);
            this.buttonOkay.TabIndex = 0;
            this.buttonOkay.Text = "Okay";
            this.buttonOkay.UseVisualStyleBackColor = true;
            this.buttonOkay.Click += new System.EventHandler(this.buttonOkay_Click);
            // 
            // tabControlDegree
            // 
            this.tabControlDegree.Controls.Add(this.tabPageDecimal);
            this.tabControlDegree.Controls.Add(this.tabPageDMS);
            this.tabControlDegree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDegree.Location = new System.Drawing.Point(0, 0);
            this.tabControlDegree.Name = "tabControlDegree";
            this.tabControlDegree.SelectedIndex = 0;
            this.tabControlDegree.Size = new System.Drawing.Size(452, 156);
            this.tabControlDegree.TabIndex = 2;
            // 
            // tabPageDecimal
            // 
            this.tabPageDecimal.Controls.Add(this.labelInstructions2);
            this.tabPageDecimal.Controls.Add(this.groupBoxEW1);
            this.tabPageDecimal.Controls.Add(this.groupBoxNS1);
            this.tabPageDecimal.Controls.Add(this.label2);
            this.tabPageDecimal.Controls.Add(this.label1);
            this.tabPageDecimal.Controls.Add(this.labelLon1);
            this.tabPageDecimal.Controls.Add(this.labelLat1);
            this.tabPageDecimal.Controls.Add(this.textBoxLongitude);
            this.tabPageDecimal.Controls.Add(this.textBoxLatitude);
            this.tabPageDecimal.Location = new System.Drawing.Point(4, 22);
            this.tabPageDecimal.Name = "tabPageDecimal";
            this.tabPageDecimal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDecimal.Size = new System.Drawing.Size(444, 130);
            this.tabPageDecimal.TabIndex = 0;
            this.tabPageDecimal.Text = "Degrees";
            this.tabPageDecimal.UseVisualStyleBackColor = true;
            // 
            // labelInstructions2
            // 
            this.labelInstructions2.AutoSize = true;
            this.labelInstructions2.Location = new System.Drawing.Point(66, 18);
            this.labelInstructions2.Name = "labelInstructions2";
            this.labelInstructions2.Size = new System.Drawing.Size(302, 26);
            this.labelInstructions2.TabIndex = 8;
            this.labelInstructions2.Text = "Enter the latitude and longitude for this sign in degrees.\r\nFor accuracty, please" +
    " use as many decimal places as you can.";
            this.labelInstructions2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBoxEW1
            // 
            this.groupBoxEW1.Controls.Add(this.radioButtonEast1);
            this.groupBoxEW1.Controls.Add(this.radioButtonWest1);
            this.groupBoxEW1.Location = new System.Drawing.Point(273, 78);
            this.groupBoxEW1.Name = "groupBoxEW1";
            this.groupBoxEW1.Size = new System.Drawing.Size(74, 28);
            this.groupBoxEW1.TabIndex = 7;
            this.groupBoxEW1.TabStop = false;
            // 
            // radioButtonEast1
            // 
            this.radioButtonEast1.AutoSize = true;
            this.radioButtonEast1.Location = new System.Drawing.Point(5, 9);
            this.radioButtonEast1.Name = "radioButtonEast1";
            this.radioButtonEast1.Size = new System.Drawing.Size(32, 17);
            this.radioButtonEast1.TabIndex = 1;
            this.radioButtonEast1.Text = "E";
            this.radioButtonEast1.UseVisualStyleBackColor = true;
            // 
            // radioButtonWest1
            // 
            this.radioButtonWest1.AutoSize = true;
            this.radioButtonWest1.Checked = true;
            this.radioButtonWest1.Location = new System.Drawing.Point(39, 9);
            this.radioButtonWest1.Name = "radioButtonWest1";
            this.radioButtonWest1.Size = new System.Drawing.Size(36, 17);
            this.radioButtonWest1.TabIndex = 0;
            this.radioButtonWest1.TabStop = true;
            this.radioButtonWest1.Text = "W";
            this.radioButtonWest1.UseVisualStyleBackColor = true;
            // 
            // groupBoxNS1
            // 
            this.groupBoxNS1.Controls.Add(this.radioButtonNorth1);
            this.groupBoxNS1.Controls.Add(this.radioButtonSouth1);
            this.groupBoxNS1.Location = new System.Drawing.Point(273, 51);
            this.groupBoxNS1.Name = "groupBoxNS1";
            this.groupBoxNS1.Size = new System.Drawing.Size(74, 28);
            this.groupBoxNS1.TabIndex = 6;
            this.groupBoxNS1.TabStop = false;
            // 
            // radioButtonNorth1
            // 
            this.radioButtonNorth1.AutoSize = true;
            this.radioButtonNorth1.Checked = true;
            this.radioButtonNorth1.Location = new System.Drawing.Point(5, 9);
            this.radioButtonNorth1.Name = "radioButtonNorth1";
            this.radioButtonNorth1.Size = new System.Drawing.Size(33, 17);
            this.radioButtonNorth1.TabIndex = 1;
            this.radioButtonNorth1.TabStop = true;
            this.radioButtonNorth1.Text = "N";
            this.radioButtonNorth1.UseVisualStyleBackColor = true;
            // 
            // radioButtonSouth1
            // 
            this.radioButtonSouth1.AutoSize = true;
            this.radioButtonSouth1.Location = new System.Drawing.Point(39, 9);
            this.radioButtonSouth1.Name = "radioButtonSouth1";
            this.radioButtonSouth1.Size = new System.Drawing.Size(32, 17);
            this.radioButtonSouth1.TabIndex = 0;
            this.radioButtonSouth1.Text = "S";
            this.radioButtonSouth1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label2.Location = new System.Drawing.Point(255, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "°";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label1.Location = new System.Drawing.Point(255, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "°";
            // 
            // labelLon1
            // 
            this.labelLon1.AutoSize = true;
            this.labelLon1.Location = new System.Drawing.Point(81, 87);
            this.labelLon1.Name = "labelLon1";
            this.labelLon1.Size = new System.Drawing.Size(54, 13);
            this.labelLon1.TabIndex = 3;
            this.labelLon1.Text = "Longitude";
            // 
            // labelLat1
            // 
            this.labelLat1.AutoSize = true;
            this.labelLat1.Location = new System.Drawing.Point(81, 60);
            this.labelLat1.Name = "labelLat1";
            this.labelLat1.Size = new System.Drawing.Size(45, 13);
            this.labelLat1.TabIndex = 2;
            this.labelLat1.Text = "Latitude";
            // 
            // textBoxLongitude
            // 
            this.textBoxLongitude.Location = new System.Drawing.Point(141, 84);
            this.textBoxLongitude.Name = "textBoxLongitude";
            this.textBoxLongitude.Size = new System.Drawing.Size(108, 20);
            this.textBoxLongitude.TabIndex = 1;
            // 
            // textBoxLatitude
            // 
            this.textBoxLatitude.Location = new System.Drawing.Point(141, 57);
            this.textBoxLatitude.Name = "textBoxLatitude";
            this.textBoxLatitude.Size = new System.Drawing.Size(108, 20);
            this.textBoxLatitude.TabIndex = 0;
            // 
            // tabPageDMS
            // 
            this.tabPageDMS.Controls.Add(this.label10);
            this.tabPageDMS.Controls.Add(this.label11);
            this.tabPageDMS.Controls.Add(this.textBoxLonSec);
            this.tabPageDMS.Controls.Add(this.textBoxLatSec);
            this.tabPageDMS.Controls.Add(this.label8);
            this.tabPageDMS.Controls.Add(this.label9);
            this.tabPageDMS.Controls.Add(this.textBoxLonMin);
            this.tabPageDMS.Controls.Add(this.textBoxLatMin);
            this.tabPageDMS.Controls.Add(this.label7);
            this.tabPageDMS.Controls.Add(this.groupBoxEW2);
            this.tabPageDMS.Controls.Add(this.groupBoxNS2);
            this.tabPageDMS.Controls.Add(this.label3);
            this.tabPageDMS.Controls.Add(this.label4);
            this.tabPageDMS.Controls.Add(this.label5);
            this.tabPageDMS.Controls.Add(this.label6);
            this.tabPageDMS.Controls.Add(this.textBoxLonDeg);
            this.tabPageDMS.Controls.Add(this.textBoxLatDeg);
            this.tabPageDMS.Location = new System.Drawing.Point(4, 22);
            this.tabPageDMS.Name = "tabPageDMS";
            this.tabPageDMS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDMS.Size = new System.Drawing.Size(444, 130);
            this.tabPageDMS.TabIndex = 1;
            this.tabPageDMS.Text = "Minutes Seconds";
            this.tabPageDMS.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label10.Location = new System.Drawing.Point(332, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "\"";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label11.Location = new System.Drawing.Point(332, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "\"";
            // 
            // textBoxLonSec
            // 
            this.textBoxLonSec.Location = new System.Drawing.Point(258, 96);
            this.textBoxLonSec.Name = "textBoxLonSec";
            this.textBoxLonSec.Size = new System.Drawing.Size(68, 20);
            this.textBoxLonSec.TabIndex = 22;
            // 
            // textBoxLatSec
            // 
            this.textBoxLatSec.Location = new System.Drawing.Point(258, 68);
            this.textBoxLatSec.Name = "textBoxLatSec";
            this.textBoxLatSec.Size = new System.Drawing.Size(68, 20);
            this.textBoxLatSec.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label8.Location = new System.Drawing.Point(245, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "\'";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label9.Location = new System.Drawing.Point(245, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "\'";
            // 
            // textBoxLonMin
            // 
            this.textBoxLonMin.Location = new System.Drawing.Point(171, 96);
            this.textBoxLonMin.Name = "textBoxLonMin";
            this.textBoxLonMin.Size = new System.Drawing.Size(68, 20);
            this.textBoxLonMin.TabIndex = 18;
            // 
            // textBoxLatMin
            // 
            this.textBoxLatMin.Location = new System.Drawing.Point(171, 69);
            this.textBoxLatMin.Name = "textBoxLatMin";
            this.textBoxLatMin.Size = new System.Drawing.Size(68, 20);
            this.textBoxLatMin.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(302, 26);
            this.label7.TabIndex = 16;
            this.label7.Text = "Enter the latitude and longitude for this sign using degrees,\r\nminutes, and secon" +
    "ds. Decimal points may be used in any box.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBoxEW2
            // 
            this.groupBoxEW2.Controls.Add(this.radioButtonEast2);
            this.groupBoxEW2.Controls.Add(this.radioButtonWest2);
            this.groupBoxEW2.Location = new System.Drawing.Point(349, 88);
            this.groupBoxEW2.Name = "groupBoxEW2";
            this.groupBoxEW2.Size = new System.Drawing.Size(74, 28);
            this.groupBoxEW2.TabIndex = 15;
            this.groupBoxEW2.TabStop = false;
            // 
            // radioButtonEast2
            // 
            this.radioButtonEast2.AutoSize = true;
            this.radioButtonEast2.Location = new System.Drawing.Point(5, 9);
            this.radioButtonEast2.Name = "radioButtonEast2";
            this.radioButtonEast2.Size = new System.Drawing.Size(32, 17);
            this.radioButtonEast2.TabIndex = 1;
            this.radioButtonEast2.Text = "E";
            this.radioButtonEast2.UseVisualStyleBackColor = true;
            // 
            // radioButtonWest2
            // 
            this.radioButtonWest2.AutoSize = true;
            this.radioButtonWest2.Checked = true;
            this.radioButtonWest2.Location = new System.Drawing.Point(39, 9);
            this.radioButtonWest2.Name = "radioButtonWest2";
            this.radioButtonWest2.Size = new System.Drawing.Size(36, 17);
            this.radioButtonWest2.TabIndex = 0;
            this.radioButtonWest2.TabStop = true;
            this.radioButtonWest2.Text = "W";
            this.radioButtonWest2.UseVisualStyleBackColor = true;
            // 
            // groupBoxNS2
            // 
            this.groupBoxNS2.Controls.Add(this.radioButtonNorth2);
            this.groupBoxNS2.Controls.Add(this.radioButtonSout2);
            this.groupBoxNS2.Location = new System.Drawing.Point(349, 61);
            this.groupBoxNS2.Name = "groupBoxNS2";
            this.groupBoxNS2.Size = new System.Drawing.Size(74, 28);
            this.groupBoxNS2.TabIndex = 14;
            this.groupBoxNS2.TabStop = false;
            // 
            // radioButtonNorth2
            // 
            this.radioButtonNorth2.AutoSize = true;
            this.radioButtonNorth2.Checked = true;
            this.radioButtonNorth2.Location = new System.Drawing.Point(5, 9);
            this.radioButtonNorth2.Name = "radioButtonNorth2";
            this.radioButtonNorth2.Size = new System.Drawing.Size(33, 17);
            this.radioButtonNorth2.TabIndex = 1;
            this.radioButtonNorth2.TabStop = true;
            this.radioButtonNorth2.Text = "N";
            this.radioButtonNorth2.UseVisualStyleBackColor = true;
            // 
            // radioButtonSout2
            // 
            this.radioButtonSout2.AutoSize = true;
            this.radioButtonSout2.Location = new System.Drawing.Point(39, 9);
            this.radioButtonSout2.Name = "radioButtonSout2";
            this.radioButtonSout2.Size = new System.Drawing.Size(32, 17);
            this.radioButtonSout2.TabIndex = 0;
            this.radioButtonSout2.Text = "S";
            this.radioButtonSout2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label3.Location = new System.Drawing.Point(153, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "°";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.label4.Location = new System.Drawing.Point(153, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "°";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Longitude";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Latitude";
            // 
            // textBoxLonDeg
            // 
            this.textBoxLonDeg.Location = new System.Drawing.Point(78, 96);
            this.textBoxLonDeg.Name = "textBoxLonDeg";
            this.textBoxLonDeg.Size = new System.Drawing.Size(68, 20);
            this.textBoxLonDeg.TabIndex = 9;
            // 
            // textBoxLatDeg
            // 
            this.textBoxLatDeg.Location = new System.Drawing.Point(78, 69);
            this.textBoxLatDeg.Name = "textBoxLatDeg";
            this.textBoxLatDeg.Size = new System.Drawing.Size(68, 20);
            this.textBoxLatDeg.TabIndex = 8;
            // 
            // FormLatLon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 216);
            this.ControlBox = false;
            this.Controls.Add(this.tabControlDegree);
            this.Controls.Add(this.groupBoxButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLatLon";
            this.Text = "FormLatLon";
            this.groupBoxButtons.ResumeLayout(false);
            this.tabControlDegree.ResumeLayout(false);
            this.tabPageDecimal.ResumeLayout(false);
            this.tabPageDecimal.PerformLayout();
            this.groupBoxEW1.ResumeLayout(false);
            this.groupBoxEW1.PerformLayout();
            this.groupBoxNS1.ResumeLayout(false);
            this.groupBoxNS1.PerformLayout();
            this.tabPageDMS.ResumeLayout(false);
            this.tabPageDMS.PerformLayout();
            this.groupBoxEW2.ResumeLayout(false);
            this.groupBoxEW2.PerformLayout();
            this.groupBoxNS2.ResumeLayout(false);
            this.groupBoxNS2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxButtons;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOkay;
        private System.Windows.Forms.Label labelLon1;
        private System.Windows.Forms.Label labelLat1;
        private System.Windows.Forms.TabPage tabPageDMS;
        private System.Windows.Forms.Label labelInstructions2;
        private System.Windows.Forms.GroupBox groupBoxEW1;
        private System.Windows.Forms.GroupBox groupBoxNS1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxEW2;
        private System.Windows.Forms.GroupBox groupBoxNS2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBoxLatSec;
        public System.Windows.Forms.TextBox textBoxLonSec;
        public System.Windows.Forms.TextBox textBoxLatMin;
        public System.Windows.Forms.TextBox textBoxLonMin;
        public System.Windows.Forms.TextBox textBoxLatDeg;
        public System.Windows.Forms.TextBox textBoxLonDeg;
        public System.Windows.Forms.RadioButton radioButtonSout2;
        public System.Windows.Forms.RadioButton radioButtonNorth2;
        public System.Windows.Forms.RadioButton radioButtonWest2;
        public System.Windows.Forms.RadioButton radioButtonEast2;
        public System.Windows.Forms.TabControl tabControlDegree;
        public System.Windows.Forms.TextBox textBoxLatitude;
        public System.Windows.Forms.TextBox textBoxLongitude;
        public System.Windows.Forms.RadioButton radioButtonSouth1;
        public System.Windows.Forms.RadioButton radioButtonNorth1;
        public System.Windows.Forms.RadioButton radioButtonWest1;
        public System.Windows.Forms.RadioButton radioButtonEast1;
        public System.Windows.Forms.TabPage tabPageDecimal;
    }
}