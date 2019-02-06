using System;
using System.Windows.Forms;

namespace tams4a.Forms
{
    public partial class FormSurveyDate : Form
    {
        public FormSurveyDate()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public DateTime getDate()
        {
            return dateTimePicker1.Value;
        }

        public void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.getDate();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void setText(string s)
        {
            labelNote.Text = s;
        }
    }
}
