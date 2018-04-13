namespace tams4a.Forms
{
    partial class FormNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNotes));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.textBoxOldNotes = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxNewNotes = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.MaximumSize = new System.Drawing.Size(404, 0);
            this.splitContainer.MinimumSize = new System.Drawing.Size(404, 350);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.Controls.Add(this.textBoxOldNotes);
            this.splitContainer.Panel1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer.Panel1MinSize = 100;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.buttonSave);
            this.splitContainer.Panel2.Controls.Add(this.textBoxNewNotes);
            this.splitContainer.Panel2.Controls.Add(this.buttonCancel);
            this.splitContainer.Panel2MinSize = 250;
            this.splitContainer.Size = new System.Drawing.Size(404, 411);
            this.splitContainer.SplitterDistance = 157;
            this.splitContainer.TabIndex = 0;
            // 
            // textBoxOldNotes
            // 
            this.textBoxOldNotes.AcceptsReturn = true;
            this.textBoxOldNotes.AcceptsTab = true;
            this.textBoxOldNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOldNotes.Location = new System.Drawing.Point(13, 8);
            this.textBoxOldNotes.Multiline = true;
            this.textBoxOldNotes.Name = "textBoxOldNotes";
            this.textBoxOldNotes.ReadOnly = true;
            this.textBoxOldNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOldNotes.Size = new System.Drawing.Size(379, 142);
            this.textBoxOldNotes.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(236, 206);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Done";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxNewNotes
            // 
            this.textBoxNewNotes.AcceptsReturn = true;
            this.textBoxNewNotes.AcceptsTab = true;
            this.textBoxNewNotes.Location = new System.Drawing.Point(13, 13);
            this.textBoxNewNotes.Multiline = true;
            this.textBoxNewNotes.Name = "textBoxNewNotes";
            this.textBoxNewNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNewNotes.Size = new System.Drawing.Size(379, 187);
            this.textBoxNewNotes.TabIndex = 1;
            this.textBoxNewNotes.TextChanged += new System.EventHandler(this.textBoxNewNotes_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(317, 206);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 411);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(420, 450);
            this.MinimumSize = new System.Drawing.Size(420, 450);
            this.Name = "FormNotes";
            this.ShowInTaskbar = false;
            this.Text = "Notes";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox textBoxNewNotes;
        private System.Windows.Forms.Button buttonCancel;
        protected System.Windows.Forms.TextBox textBoxOldNotes;
        private System.Windows.Forms.Button buttonSave;
    }
}