namespace tams4a.Controls
{
    partial class Panel_Module_OpenShp
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
            this.buttonOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonOpen.Location = new System.Drawing.Point(10, 10);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(186, 54);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Open SHP File";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // Panel_Module_OpenShp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonOpen);
            this.Name = "Panel_Module_OpenShp";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(206, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpen;
    }
}
