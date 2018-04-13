namespace tams4a.Controls
{
    partial class DistressEntry
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonGet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(4, 4);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(71, 13);
            this.label.TabIndex = 0;
            this.label.Text = "Distress Type";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(103, 0);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(36, 20);
            this.textBox.TabIndex = 1;
            //this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // buttonGet
            // 
            this.buttonGet.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonGet.Image = global::tams4a.Properties.Resources.properties;
            this.buttonGet.Location = new System.Drawing.Point(145, 0);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(21, 20);
            this.buttonGet.TabIndex = 2;
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // DistressEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.buttonGet);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "DistressEntry";
            this.Size = new System.Drawing.Size(166, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonGet;
    }
}
