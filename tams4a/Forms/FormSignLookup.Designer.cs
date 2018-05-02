namespace tams4a.Forms
{
    partial class FormSignLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSignLookup));
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.buttonCanel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.groupBoxSigns = new System.Windows.Forms.GroupBox();
            this.panelSigns = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxFilter.SuspendLayout();
            this.groupBoxButtons.SuspendLayout();
            this.groupBoxSigns.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.label5);
            this.groupBoxFilter.Controls.Add(this.label4);
            this.groupBoxFilter.Controls.Add(this.label3);
            this.groupBoxFilter.Controls.Add(this.label2);
            this.groupBoxFilter.Controls.Add(this.buttonSearch);
            this.groupBoxFilter.Controls.Add(this.textBoxFilter);
            this.groupBoxFilter.Controls.Add(this.label1);
            this.groupBoxFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFilter.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(829, 82);
            this.groupBoxFilter.TabIndex = 0;
            this.groupBoxFilter.TabStop = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.buttonSearch.Location = new System.Drawing.Point(523, 18);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(264, 19);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(253, 20);
            this.textBoxFilter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(189, 20);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter Signs:";
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.buttonCanel);
            this.groupBoxButtons.Controls.Add(this.buttonConfirm);
            this.groupBoxButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxButtons.Location = new System.Drawing.Point(0, 656);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(829, 61);
            this.groupBoxButtons.TabIndex = 1;
            this.groupBoxButtons.TabStop = false;
            // 
            // buttonCanel
            // 
            this.buttonCanel.Location = new System.Drawing.Point(12, 18);
            this.buttonCanel.Name = "buttonCanel";
            this.buttonCanel.Size = new System.Drawing.Size(94, 31);
            this.buttonCanel.TabIndex = 1;
            this.buttonCanel.Text = "Cancel";
            this.buttonCanel.UseVisualStyleBackColor = true;
            this.buttonCanel.Click += new System.EventHandler(this.buttonCanel_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(729, 18);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(88, 31);
            this.buttonConfirm.TabIndex = 0;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // groupBoxSigns
            // 
            this.groupBoxSigns.Controls.Add(this.panelSigns);
            this.groupBoxSigns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSigns.Location = new System.Drawing.Point(0, 82);
            this.groupBoxSigns.Name = "groupBoxSigns";
            this.groupBoxSigns.Size = new System.Drawing.Size(829, 574);
            this.groupBoxSigns.TabIndex = 2;
            this.groupBoxSigns.TabStop = false;
            // 
            // panelSigns
            // 
            this.panelSigns.AutoScroll = true;
            this.panelSigns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSigns.Location = new System.Drawing.Point(3, 16);
            this.panelSigns.Name = "panelSigns";
            this.panelSigns.Size = new System.Drawing.Size(823, 555);
            this.panelSigns.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "MUTCD Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(520, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Text";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(761, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Symbol";
            // 
            // FormSignLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 717);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxSigns);
            this.Controls.Add(this.groupBoxButtons);
            this.Controls.Add(this.groupBoxFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSignLookup";
            this.Text = "Lookup Sign";
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.groupBoxButtons.ResumeLayout(false);
            this.groupBoxSigns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.GroupBox groupBoxButtons;
        private System.Windows.Forms.GroupBox groupBoxSigns;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSigns;
        private System.Windows.Forms.Button buttonCanel;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}