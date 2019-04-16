using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using tams4a.Classes;
using System.Text.RegularExpressions;
using tams4a.Forms;

namespace tams4a.Controls
{
    public partial class Panel_Other : Panel_Module
    {
        private Dictionary<string, List<Control>> controlSets;
        private TextBox accidentDate = new TextBox();

        public Panel_Other()
        {
            InitializeComponent();

            new ToolTip().SetToolTip(buttonNextPhoto, "Get Next Photo");

            controlSets = new Dictionary<string, List<Control>>()
            {
                { "Sidewalk", new List<Control>() },
                { "ADA Ramp", new List<Control>() },
                { "Severe Road Distress", new List<Control>() },
                { "Accident", new List<Control>() },
                { "Drainage", new List<Control>() },
                { "Other", new List<Control>() }
            };
            int left = 11, right = 89;
            #region sidewalk
            ComboBox swFault = new ComboBox();
            swFault.Location = new Point(right, 24);
            swFault.Size = new Size(112, 20);
            swFault.Items.Add("");
            swFault.Items.Add("Less than 0.25 in.");
            swFault.Items.Add("0.25 - 0.5 in.");
            swFault.Items.Add("0.5 - 1 in.");
            swFault.Items.Add("More than 1 in.");
            controlSets["Sidewalk"].Add(swFault);

            ComboBox swBreak = new ComboBox();
            swBreak.Location = new Point(right, 48);
            swBreak.Size = new Size(112, 20);
            swBreak.Items.Add("");
            swBreak.Items.Add("Low");
            swBreak.Items.Add("Moderate");
            swBreak.Items.Add("Severe");
            controlSets["Sidewalk"].Add(swBreak);

            ComboBox rec3rd = new ComboBox();
            rec3rd.Location = new Point(right, 72);
            rec3rd.Size = new Size(112, 20);
            rec3rd.Items.Add("");
            rec3rd.Items.Add("Grind");
            rec3rd.Items.Add("Replace");
            rec3rd.Items.Add("Watch");
            rec3rd.Items.Add("Other (see notes)");
            controlSets["Sidewalk"].Add(rec3rd);

            TextBox notes = new TextBox();
            notes.Location = new Point(left, 120);
            notes.Size = new Size(193, 80);
            controlSets["Sidewalk"].Add(notes);

            Label swFaultLabel = new Label();
            swFaultLabel.Text = "Faults";
            swFaultLabel.Size = new Size(70, 14);
            swFaultLabel.Location = new Point(left, 26);
            controlSets["Sidewalk"].Add(swFaultLabel);

            Label swBreakLabel = new Label();
            swBreakLabel.Text = "Breaks";
            swBreakLabel.Size = new Size(70, 14);
            swBreakLabel.Location = new Point(left, 50);
            controlSets["Sidewalk"].Add(swBreakLabel);

            Label rec3rdLabel = new Label();
            rec3rdLabel.Text = "Recommend";
            rec3rdLabel.Size = new Size(70, 14);
            rec3rdLabel.Location = new Point(left, 74);
            controlSets["Sidewalk"].Add(rec3rdLabel);

            Label notesLabel = new Label();
            notesLabel.Text = "Notes";
            notesLabel.Size = new Size(70, 14);
            notesLabel.Location = new Point(left, 98);
            controlSets["Sidewalk"].Add(notesLabel);
            #endregion sidewalk

            #region ramp
            ComboBox adAcondition = new ComboBox();
            adAcondition.Location = new Point(right, 24);
            adAcondition.Size = new Size(112, 20);
            adAcondition.Items.Add("");
            adAcondition.Items.Add("Good");
            adAcondition.Items.Add("Acceptable");
            adAcondition.Items.Add("Bad");
            controlSets["ADA Ramp"].Add(adAcondition);

            ComboBox adAcompliant = new ComboBox();
            adAcompliant.Location = new Point(right, 48);
            adAcompliant.Size = new Size(112, 20);
            adAcompliant.Items.Add("");
            adAcompliant.Items.Add("Yes");
            adAcompliant.Items.Add("No");
            controlSets["ADA Ramp"].Add(adAcompliant);

            ComboBox tiles = new ComboBox();
            tiles.Location = new Point(right, 72);
            tiles.Size = new Size(112, 20);
            tiles.Items.Add("");
            tiles.Items.Add("Yes");
            tiles.Items.Add("No");
            controlSets["ADA Ramp"].Add(tiles);

            controlSets["ADA Ramp"].Add(notes);
            Label adAconditionLabel = new Label();
            adAconditionLabel.Text = "Condition";
            adAconditionLabel.Size = new Size(70, 14);
            adAconditionLabel.Location = new Point(left, 26);
            controlSets["ADA Ramp"].Add(adAconditionLabel);

            Label adAcompliantLabel = new Label();
            adAcompliantLabel.Text = "Compliant";
            adAcompliantLabel.Size = new Size(70, 14);
            adAcompliantLabel.Location = new Point(left, 50);
            controlSets["ADA Ramp"].Add(adAcompliantLabel);
            Label tilesLabel = new Label();

            tilesLabel.Text = "Has Tiles";
            tilesLabel.Size = new Size(70, 14);
            tilesLabel.Location = new Point(left, 74);
            controlSets["ADA Ramp"].Add(tilesLabel);

            controlSets["ADA Ramp"].Add(notesLabel);
            #endregion ramp

            #region distress
            TextBox distress = new TextBox();
            distress.Location = new Point(right, 24);
            distress.Size = new Size(112, 20);
            controlSets["Severe Road Distress"].Add(distress);

            TextBox rec2nd = new TextBox();
            rec2nd.Location = new Point(right, 48);
            rec2nd.Size = new Size(112, 20);
            controlSets["Severe Road Distress"].Add(rec2nd);

            TextBox nonElement = new TextBox();
            nonElement.Location = new Point(right, 72);
            nonElement.Size = new Size(112, 20);
            controlSets["Severe Road Distress"].Add(nonElement);
            nonElement.Visible = false;

            controlSets["Severe Road Distress"].Add(notes);

            Label distressLabel = new Label();
            distressLabel.Text = "Distress";
            distressLabel.Size = new Size(70, 14);
            distressLabel.Location = new Point(left, 26);
            controlSets["Severe Road Distress"].Add(distressLabel);

            Label rec2ndLabel = new Label();
            rec2ndLabel.Text = "Recommend";
            rec2ndLabel.Size = new Size(75, 14);
            rec2ndLabel.Location = new Point(left, 50);
            controlSets["Severe Road Distress"].Add(rec2ndLabel);

            controlSets["Severe Road Distress"].Add(notesLabel);
            #endregion distress

            #region drainage
            ComboBox type = new ComboBox();
            type.Location = new Point(right, 24);
            type.Size = new Size(112, 20);
            type.Items.Add("");
            type.Items.Add("Curb and Gutter");
            type.Items.Add("Roadway Ponding");
            type.Items.Add("Unpaved Shoulder");
            type.Items.Add("Turf Shoulder");
            type.Items.Add("Storm Grate");
            type.Items.Add("Other");
            controlSets["Drainage"].Add(type);

            controlSets["Drainage"].Add(rec2nd);

            nonElement = new TextBox();
            nonElement.Location = new Point(right, 72);
            nonElement.Size = new Size(112, 20);
            controlSets["Drainage"].Add(nonElement);
            nonElement.Visible = false;

            controlSets["Drainage"].Add(notes);

            Label typeLabel = new Label();
            typeLabel.Text = "Type";
            typeLabel.Location = new Point(left, 26);
            typeLabel.Size = new Size(70, 14);
            controlSets["Drainage"].Add(typeLabel);

            controlSets["Drainage"].Add(rec2ndLabel);

            controlSets["Drainage"].Add(notesLabel);
            #endregion drainage

            #region accidents
            accidentDate.Location = new Point(right + 23, 24);
            accidentDate.Size = new Size(89, 20);
            controlSets["Accident"].Add(accidentDate);

            TextBox accidentType = new TextBox();
            accidentType.Location = new Point(right, 48);
            accidentType.Size = new Size(112, 20);
            controlSets["Accident"].Add(accidentType);

            ComboBox accidentSeverity = new ComboBox();
            accidentSeverity.Location = new Point(right, 72);
            accidentSeverity.Size = new Size(112, 20);
            accidentSeverity.Items.Add("");
            accidentSeverity.Items.Add("Injury");
            accidentSeverity.Items.Add("Death");
            accidentSeverity.Items.Add("Property Damage");
            controlSets["Accident"].Add(accidentSeverity);

            controlSets["Accident"].Add(notes);

            nonElement = new TextBox();
            nonElement.Location = new Point(right, 72);
            nonElement.Size = new Size(112, 20);
            controlSets["Accident"].Add(nonElement);
            nonElement.Visible = false;

            Label accidentDateLabel = new Label();
            accidentDateLabel.Text = "Date";
            accidentDateLabel.Location = new Point(left, 26);
            accidentDateLabel.Size = new Size(70, 14);
            controlSets["Accident"].Add(accidentDateLabel);

            Label accidentTypeLabel = new Label();
            accidentTypeLabel.Text = "Type";
            accidentTypeLabel.Location = new Point(left, 50);
            accidentTypeLabel.Size = new Size(70, 14);
            controlSets["Accident"].Add(accidentTypeLabel);

            Label accidentSeverityLabel = new Label();
            accidentSeverityLabel.Text = "Severity";
            accidentSeverityLabel.Location = new Point(left, 74);
            accidentSeverityLabel.Size = new Size(70, 14);
            controlSets["Accident"].Add(accidentSeverityLabel);

            Button buttonAccidentDate = new Button();
            new ToolTip().SetToolTip(buttonAccidentDate, "Set Date of Accident");
            buttonAccidentDate.Image = Properties.Resources.calendar;
            buttonAccidentDate.Location = new Point(right, 23);
            buttonAccidentDate.Name = "buttonAccidentDate";
            buttonAccidentDate.Size = new Size(22, 22);
            buttonAccidentDate.UseVisualStyleBackColor = true;
            controlSets["Accident"].Add(buttonAccidentDate);

            controlSets["Accident"].Add(notesLabel);
            #endregion accidents

            #region other
            TextBox property1 = new TextBox();
            property1.Size = new Size(112, 20);
            property1.Location = new Point(right, 24);
            controlSets["Other"].Add(property1);

            TextBox property2 = new TextBox();
            property2.Size = new Size(112, 20);
            property2.Location = new Point(right, 48);
            controlSets["Other"].Add(property2);


            nonElement = new TextBox();
            nonElement.Location = new Point(right, 72);
            nonElement.Size = new Size(112, 20);
            controlSets["Other"].Add(nonElement);
            nonElement.Visible = false;

            controlSets["Other"].Add(notes);

            Label property1Label = new Label();
            property1Label.Text = "Property 1";
            property1Label.Size = new Size(70, 14);
            property1Label.Location = new Point(left, 26);
            controlSets["Other"].Add(property1Label);

            Label property2Label = new Label();
            property2Label.Text = "Property 2";
            property2Label.Size = new Size(70, 14);
            property2Label.Location = new Point(left, 50);
            controlSets["Other"].Add(property2Label);

            controlSets["Other"].Add(notesLabel);
            #endregion other

            comboBoxObject.TextChanged += moduleValueChanged;
            comboBoxObject.TextChanged += objectChanged;
            textBoxAddress.TextChanged += moduleValueChanged;
            textBoxDescription.TextChanged += moduleValueChanged;
            textBoxPhotoFile.TextChanged += moduleValueChanged;

            swFault.TextChanged += moduleValueChanged;
            swBreak.TextChanged += moduleValueChanged;
            rec3rd.TextChanged += moduleValueChanged;
            notes.TextChanged += moduleValueChanged;

            adAcondition.TextChanged += moduleValueChanged;
            adAcompliant.TextChanged += moduleValueChanged;
            tiles.TextChanged += moduleValueChanged;

            distress.TextChanged += moduleValueChanged;
            rec2nd.TextChanged += moduleValueChanged;

            type.TextChanged += moduleValueChanged;

            accidentDate.TextChanged += moduleValueChanged;
            accidentType.TextChanged += moduleValueChanged;
            accidentSeverity.TextChanged += moduleValueChanged;

            property1.TextChanged += moduleValueChanged;
            property2.TextChanged += moduleValueChanged;

            buttonNextPhoto.Click += buttonNextPhoto_Click;
            buttonAccidentDate.Click += ButtonAccidentDate_Click;
        }

        public void updateDisplay(Dictionary<string, string> values)
        {
            comboBoxObject.Text = Util.DictionaryItemString(values, "type");
            textBoxAddress.Text = Util.DictionaryItemString(values, "address");
            textBoxDescription.Text = Util.DictionaryItemString(values, "description");
            textBoxPhotoFile.Text = Util.DictionaryItemString(values, "photo");
            if (controlSets.ContainsKey(Util.DictionaryItemString(values, "type")))
            {
                controlSets[values["type"]][0].Text = Util.DictionaryItemString(values, "property1");
                controlSets[values["type"]][1].Text = Util.DictionaryItemString(values, "property2");
                controlSets[values["type"]][2].Text = Util.DictionaryItemString(values, "property3");
                controlSets[values["type"]][3].Text = Util.DictionaryItemString(values, "notes");
            }
        }

        public void chooseAltProperties(string propSet)
        {
            groupBoxProperties.Controls.Clear();
            if (controlSets.ContainsKey(propSet))
            {
                foreach (Control ct in controlSets[propSet])
                {
                    groupBoxProperties.Controls.Add(ct);
                }
                controlSets[propSet][0].Text = "";
                controlSets[propSet][1].Text = "";
                controlSets[propSet][2].Text = "";
                controlSets[propSet][3].Text = "";
            }
            else
            {
                foreach (Control ct in controlSets["Other"])
                {
                    groupBoxProperties.Controls.Add(ct);
                }
                controlSets["Other"][0].Text = "";
                controlSets["Other"][1].Text = "";
                controlSets["Other"][2].Text = "";
                controlSets["Other"][3].Text = "";
            }
        }

        public void clearValues()
        {
            textBoxAddress.Text = "";
            comboBoxObject.Text = "";
            textBoxPhotoFile.Text = "";
            pictureBoxPhoto.ImageLocation = null;
            textBoxDescription.Text = "";
            for (int i = 0; i < 3; i ++)
            {
                foreach (string key in controlSets.Keys)
                {
                    controlSets[key][i].Text = "";
                }
            }
            pictureBoxPhoto.Image = null;
        }

        public string getProperty(string type, int index)
        {
            return controlSets[type][index].Text;
        }

        private void objectChanged(object sender, EventArgs e)
        {
            chooseAltProperties(comboBoxObject.Text);
        }

        private void buttonNextPhoto_Click(object sender, EventArgs e)
        {
            string oldPhoto = Properties.Settings.Default.lastPhoto;
            if (string.IsNullOrWhiteSpace(oldPhoto))
            {
                textBoxPhotoFile.Text = "0001";
                return;
            }

            string pattern = @"(.*?)(\d+)(.*)";
            Regex rex = new Regex(pattern, RegexOptions.IgnoreCase);

            Match mat = rex.Match(oldPhoto);
            if (!mat.Success)
            {
                textBoxPhotoFile.Text = MakePictureNumbered(oldPhoto);
                return;
            }

            try
            {
                string nextPhoto = mat.Groups[1].ToString();
                string numPart = mat.Groups[2].ToString();
                int num = Convert.ToInt16(numPart);
                num++;
                string numFormat = "D" + numPart.Length.ToString();
                nextPhoto += num.ToString(numFormat);

                nextPhoto += mat.Groups[3].ToString();

                textBoxPhotoFile.Text = nextPhoto;
            }
            catch
            {
                textBoxPhotoFile.Text = MakePictureNumbered(oldPhoto);
                return;
            }
        }

        private void ButtonAccidentDate_Click(object sender, EventArgs e)
        {
            FormSurveyDate ad = new FormSurveyDate();
            ad.Text = "Select Accident Date";
            ad.setText("Select the date the accident took place.");
            ad.ShowDialog();
            accidentDate.Text = Util.SortableDate(ad.getDate());
            ad.Close();
        }

    }
}
