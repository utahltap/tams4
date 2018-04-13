using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Forms
{
    public partial class FormReport : Form
    {
        private bool submitted = false;

        public FormReport()
        {
            InitializeComponent();

            String errors = "LOGGED ERRORS:\n";
            errors += Log.GetTop("error");
            errors += "\n\n\n\n====================================================================\nLOGGED WARNINGS:\n";
            errors += Log.GetTop("warning");

            String pattern = @"(?<!\r)\n";
            String replacement = Environment.NewLine;
            Regex regx = new Regex(pattern);
            textBoxLogs.Text = regx.Replace(errors, replacement);
        }

        private void FormReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!submitted && !String.IsNullOrWhiteSpace(textBoxComment.Text))
            {
                DialogResult result = MessageBox.Show("This has not yet been submitted.  Discard report?", "Not Submitted", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxComment.Text))
            {
                MessageBox.Show("Please include a comment or problem description");
                return;
            }

            Dictionary<String, String> postitems = new Dictionary<String, String>();
            postitems["email"] = inputEmail.Value;
            postitems["message"] = textBoxComment.Text;
            if (!String.IsNullOrWhiteSpace(inputName.Value))
            {
                postitems["message"] = "FROM: " + inputName.Value + "\n\n" + postitems["message"];
            }

            postitems["errors"] = "LOGS:\r\n" + textBoxLogs.Text;     // our web app wants non-empty value here
            postitems["software"] = "tams";
            postitems["version"] = Program.GetVersion();


            using (HttpClient client = new HttpClient())
            {
                try
                {
                    FormUrlEncodedContent content = new FormUrlEncodedContent(postitems);
                    var response = client.PostAsync(Properties.Settings.Default.ReportUrl, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        submitted = true;
                        MessageBox.Show("Thank you for your report.");
                        this.Close();
                    } else
                    {
                        MessageBox.Show("Could not submit bug report.  Please email utahltap@gmail.com");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Could not report bug.\n" + ex.ToString());
                    MessageBox.Show("Could not submit bug report.  Please email utahltap@gmail.com");
                }
            }
        }
    }
}
