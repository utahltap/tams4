﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Controls
{
    public partial class Panel_Other : Panel_Module
    {
        private Dictionary<string, List<Control>> controlSets;

        public Panel_Other()
        {
            InitializeComponent();

            new ToolTip().SetToolTip(buttonNextPhoto, "Get Next Photo");
            new ToolTip().SetToolTip(comboBoxIcon, "Select Icon to Show on Map");

            controlSets = new Dictionary<string, List<Control>>()
            {
                { "Sidewalk", new List<Control>() },
                { "ADA Ramp", new List<Control>() },
                { "Severe Road Distress", new List<Control>() },
                { "Accident Hotspot", new List<Control>() },
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
            swBreak.Items.Add("low");
            swBreak.Items.Add("moderate");
            swBreak.Items.Add("severe");
            controlSets["Sidewalk"].Add(swBreak);
            TextBox notes = new TextBox();
            notes.Location = new Point(left, 96);
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
            Label notesLabel = new Label();
            notesLabel.Text = "Notes";
            notesLabel.Size = new Size(70, 14);
            notesLabel.Location = new Point(left, 74);
            controlSets["Sidewalk"].Add(notesLabel);
            #endregion sidewalk
            #region ramp
            ComboBox ADAcondition = new ComboBox();
            ADAcondition.Location = new Point(right, 24);
            ADAcondition.Size = new Size(112, 20);
            ADAcondition.Items.Add("");
            ADAcondition.Items.Add("Good");
            ADAcondition.Items.Add("Acceptable");
            ADAcondition.Items.Add("Bad");
            controlSets["ADA Ramp"].Add(ADAcondition);
            ComboBox ADAcompliant = new ComboBox();
            ADAcompliant.Location = new Point(right, 48);
            ADAcompliant.Size = new Size(112, 20);
            ADAcompliant.Items.Add("");
            ADAcompliant.Items.Add("Yes");
            ADAcompliant.Items.Add("No");
            controlSets["ADA Ramp"].Add(ADAcompliant);
            controlSets["ADA Ramp"].Add(notes);
            Label ADAconditionLabel = new Label();
            ADAconditionLabel.Text = "Condition";
            ADAconditionLabel.Size = new Size(70, 14);
            ADAconditionLabel.Location = new Point(left, 26);
            controlSets["ADA Ramp"].Add(ADAconditionLabel);
            Label ADAcompliantLabel = new Label();
            ADAcompliantLabel.Text = "Compliant";
            ADAcompliantLabel.Size = new Size(70, 14);
            ADAcompliantLabel.Location = new Point(left, 50);
            controlSets["ADA Ramp"].Add(ADAcompliantLabel);
            controlSets["ADA Ramp"].Add(notesLabel);
            #endregion ramp
            #region distress
            TextBox distress = new TextBox();
            distress.Location = new Point(right, 24);
            distress.Size = new Size(112, 20);
            controlSets["Severe Road Distress"].Add(distress);
            TextBox reccomendation = new TextBox();
            reccomendation.Location = new Point(right, 48);
            reccomendation.Size = new Size(112, 20);
            controlSets["Severe Road Distress"].Add(reccomendation);
            controlSets["Severe Road Distress"].Add(notes);
            Label distressLabel = new Label();
            distressLabel.Text = "Distress";
            distressLabel.Size = new Size(70, 14);
            distressLabel.Location = new Point(left, 26);
            controlSets["Severe Road Distress"].Add(distressLabel);
            Label recommendationLabel = new Label();
            recommendationLabel.Text = "Recommend";
            recommendationLabel.Size = new Size(75, 14);
            recommendationLabel.Location = new Point(left, 50);
            controlSets["Severe Road Distress"].Add(recommendationLabel);
            controlSets["Severe Road Distress"].Add(notesLabel);
            #endregion distress
            #region drainage
            ComboBox cause = new ComboBox();
            cause.Location = new Point(right, 24);
            cause.Size = new Size(112, 20);
            cause.Items.Add("");
            cause.Items.Add("Curb and Gutter");
            cause.Items.Add("Roadway Ponding");
            cause.Items.Add("Unpaved Shoulder");
            cause.Items.Add("Turf Shoulder");
            cause.Items.Add("Storm Grate");
            cause.Items.Add("Other");
            controlSets["Drainage"].Add(cause);
            TextBox comment = new TextBox();
            comment.Location = new Point(right, 48);
            comment.Size = new Size(112, 20);
            controlSets["Drainage"].Add(comment);
            controlSets["Drainage"].Add(notes);
            Label causeLabel = new Label();
            causeLabel.Text = "Cause";
            causeLabel.Location = new Point(left, 26);
            causeLabel.Size = new Size(70, 14);
            controlSets["Drainage"].Add(causeLabel);
            Label commentLabel = new Label();
            commentLabel.Text = "Comment";
            commentLabel.Location = new Point(left, 50);
            commentLabel.Size = new Size(70, 14);
            controlSets["Drainage"].Add(commentLabel);
            controlSets["Drainage"].Add(notesLabel);
            #endregion drainage
            #region accidents
            TextBox lastAccident = new TextBox();
            lastAccident.Location = new Point(right, 24);
            lastAccident.Size = new Size(112, 20);
            controlSets["Accident Hotspot"].Add(lastAccident);
            //TextBox comment = new TextBox();
            //comment.Location = new Point(right, 48);
            //comment.Size = new Size(112, 20);
            controlSets["Accident Hotspot"].Add(comment);
            controlSets["Accident Hotspot"].Add(notes);
            Label lastAccidentLabel = new Label();
            lastAccidentLabel.Text = "Last Accident";
            lastAccidentLabel.Location = new Point(left, 26);
            lastAccidentLabel.Size = new Size(70, 14);
            controlSets["Accident Hotspot"].Add(lastAccidentLabel);
            //Label commentLabel = new Label();
            //commentLabel.Text = "Comment";
            //commentLabel.Location = new Point(left, 50);
            //commentLabel.Size = new Size(70, 14);
            controlSets["Accident Hotspot"].Add(commentLabel);
            controlSets["Accident Hotspot"].Add(notesLabel);
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
            comboBoxIcon.TextChanged += moduleValueChanged;
            textBoxAddress.TextChanged += moduleValueChanged;
            textBoxDescription.TextChanged += moduleValueChanged;
            textBoxPhotoFile.TextChanged += moduleValueChanged;
            swFault.TextChanged += moduleValueChanged;
            swBreak.TextChanged += moduleValueChanged;
            notes.TextChanged += moduleValueChanged;
            ADAcondition.TextChanged += moduleValueChanged;
            ADAcompliant.TextChanged += moduleValueChanged;
            distress.TextChanged += moduleValueChanged;
            reccomendation.TextChanged += moduleValueChanged;
            lastAccident.TextChanged += moduleValueChanged;
            comment.TextChanged += moduleValueChanged;
            property1.TextChanged += moduleValueChanged;
            property2.TextChanged += moduleValueChanged;
        }

        public void updateDisplay(Dictionary<string, string> values)
        {
            comboBoxObject.Text = Util.DictionaryItemString(values, "type");
            comboBoxIcon.Text = Util.DictionaryItemString(values, "icon");
            textBoxAddress.Text = Util.DictionaryItemString(values, "address");
            textBoxDescription.Text = Util.DictionaryItemString(values, "description");
            textBoxPhotoFile.Text = Util.DictionaryItemString(values, "photo");
            if (controlSets.ContainsKey(Util.DictionaryItemString(values, "type")))
            {
                controlSets[values["type"]][0].Text = Util.DictionaryItemString(values, "property1");
                controlSets[values["type"]][1].Text = Util.DictionaryItemString(values, "property2");
                controlSets[values["type"]][2].Text = Util.DictionaryItemString(values, "notes");
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
            }
        }

        public void clearValues()
        {
            textBoxAddress.Text = "";
            comboBoxObject.Text = "";
            comboBoxIcon.Text = "";
            textBoxPhotoFile.Text = "";
            textBoxDescription.Text = "";
            for (int i = 0; i < 3; i ++)
            {
                foreach (string key in controlSets.Keys)
                {
                    controlSets[key][i].Text = "";
                }
            }
        }

        public string getProperty(string type, int index)
        {
            return controlSets[type][index].Text;
        }

        private void objectChanged(object sender, EventArgs e)
        {
            chooseAltProperties(comboBoxObject.Text);
        }
    }
}