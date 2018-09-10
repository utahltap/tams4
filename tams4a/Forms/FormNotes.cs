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
    public partial class FormNotes : Form
    {
        public String OldNotes { get; protected set; }
        public String Value
        {
            get { return OldNotes; }
            set
            {
                setNotes(value);
            }
        }

        public FormNotes()
        {
            OldNotes = "";
            InitializeComponent();
            CenterToScreen();
            buttonSave.Enabled = false;
            this.MaximumSize = new Size(this.Width, int.MaxValue);  // only allow vertical resizing
            textBoxNewNotes.Focus();
            ActiveControl = textBoxNewNotes;
        }

        public FormNotes(String notes):this()
        {
            setNotes(notes);
        }

        // updates value and display of old notes
        private void setNotes(String notes)
        {
            OldNotes = notes;
            textBoxOldNotes.Text = notes;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;    // need to know if anything changed
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxNewNotes.Text != "")
            {
                //String date = DateTime.Now.ToString("d MMM yyyy");
                String note = textBoxNewNotes.Text + Environment.NewLine + Environment.NewLine + OldNotes;
                setNotes(note);
                textBoxNewNotes.Text = "";
                this.DialogResult = DialogResult.OK;
            } else 
            {
                this.DialogResult = DialogResult.Cancel;    // need to know if anything changed
            }
        }

        private void textBoxNewNotes_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNewNotes.Text == "")
            {
                buttonSave.Enabled = false;
            } else
            {
                buttonSave.Enabled = true;
            }
        }
    }
}
