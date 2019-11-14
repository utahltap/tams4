using DotSpatial.Symbology;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using tams4a.Classes;
using tams4a.Controls;

namespace tams4a.Forms
{
    public partial class FormSettings : Form
    {
        private List<CtlSetting> settingControls; // useful for accesssing different settings.
        private ProjectSettings Settings;
        private TamsProject Project;

        public FormSettings(ProjectSettings settings, TamsProject theProject)
        {
            InitializeComponent();
            CenterToScreen();
            settingControls = new List<CtlSetting>();
            Settings = settings;
            Project = theProject;
            textBoxNotes.Text = ""; // default instructions
        }


        public void Init()
        {
            HashSet<String> listedModules = new HashSet<string>();
            List<ProjectSetting> sortedSettings = Settings.List().ToList<ProjectSetting>();
            sortedSettings.Sort();

            // get all modules that have displayed options
            foreach (ProjectSetting setting in sortedSettings)
            {
                if (!   (String.IsNullOrWhiteSpace(setting.Display_Type) ||
                            String.IsNullOrWhiteSpace(setting.Module)
                        )
                   )
                {
                    listedModules.Add(setting.Module);   // returns false if already there.  Don't care.
                }
            }


            foreach (String module in listedModules)
            {
                //TabPage page = new TabPage(module);
                String tabText = new CultureInfo("en-US").TextInfo.ToTitleCase(module);
                TabControl.TabPageCollection pages = tabControlSettings.TabPages;
                if (!pages.ContainsKey(module))     // should only happen for general tab
                {
                    pages.Add(module, tabText);
                    //pages[module].BackColor = Color.Transparent;        // for some reason, the general page is a different background color?!
                    // TODO: Fix                                                  
                }

                // general tab doesn't currently have these things.
                FlowLayoutPanel flowpanel = new FlowLayoutPanel();
                flowpanel.Name = "flowpanel_" + module;

                flowpanel.FlowDirection = FlowDirection.LeftToRight;
                flowpanel.WrapContents = true;
                flowpanel.Dock = DockStyle.Fill;
                //flowpanel.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                flowpanel.AutoScroll = true;


                pages[module].Controls.Add(flowpanel);
            }

        
            foreach (ProjectSetting setting in sortedSettings)
            {
                CtlSetting control;
                switch (setting.Display_Type)
                {
                    case "":
                        continue;
                    case "info":
                        control = new CtlSettingInfo(setting.Name);
                        break;
                    case "select":
                    case "field":
                        control = new CtlSettingSelect(setting.Name);
                        if (setting.Display_Type == "field")
                        {
                            // if it's not required, add in a blank
                            if (!setting.Required)
                            {
                                if (!setting.options.Contains(""))
                                {
                                    setting.options.Insert(0, "");
                                }
                            }
                            control.setOptions(setting.options);
                        }
                        break;
                    case "bool":
                        control = new CtlSettingBool(setting.Name);
                        break;
                    default:
                        control = new CtlSettingText(setting.Name);
                        break;
                }

                // ??? FromSetting would remove the options we addded above?
                control.FromSetting(setting);
                control.Display_Text = setting.Display_Name == "" ? new CultureInfo("en-US").TextInfo.ToTitleCase(setting.Name) : setting.Display_Name;
                control.Visible = true;
                control.resetStatus();
                control.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                TabPage page = tabControlSettings.TabPages[setting.Module];
                Control.ControlCollection controls = page.Controls;
                FlowLayoutPanel panel = (FlowLayoutPanel)controls["flowpanel_" + setting.Module];


                panel.SuspendLayout();
                panel.Controls.Add(control);
                panel.ResumeLayout(true);
                settingControls.Add(control);

                //tabControlSettings.TabPages[setting.Module].Controls.Add(control);

                control.OnFocus += Set_Description;
                //control.LostFocus += new EventHandler(Clear_Description);
            }

            // remove any pages, add any, etc
            foreach (TabPage page in tabControlSettings.TabPages)
            {
                if (page.Controls.Count <= 0)
                {
                    tabControlSettings.TabPages.Remove(page);
                }
            }
        }


        protected void Set_Description(object sender, EventArgs e)
        {
            textBoxNotes.Text = ((CtlSetting)sender).Description;
        }


        protected void Clear_Description(object sender, EventArgs e)
        {
            textBoxNotes.Text = "";
        }


        public void TrySelectTab(String tabname)
        {
            if (tabControlSettings.TabPages.ContainsKey(tabname))
            {
                tabControlSettings.SelectTab(tabname);
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (!Settings.HaveRequired())
            {
                MessageBox.Show("All required settings have not been set. TAMS may not work properly until the required settings are valid.");
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            string colors = "", labels = "", surfacetype = "", endaddr = "", startaddr = "",
                speedlimit = "", length = "", width = "", streetname = "", tamsid = "";
            bool updateColors = false, updateLabels = false, updateSurface = false, updateEndaddr = false, updateStartaddr = false,
                updateSpeedlimit = false, updateLength = false, updateWidth = false, updateStreetname = false, updateTamsid = false;
            string sql = "";
            bool success = true;
            foreach (CtlSetting setting in settingControls)
            {
                try
                {
                    Settings.SetValue(setting.Key, setting.getValue());
                    if (setting.Key.ToString() == "road_colors")
                    {
                        colors = setting.getValue();
                        if (!String.IsNullOrEmpty(colors)) updateColors = true;
                    }
                    if (setting.Key.ToString() == "road_labels")
                    {
                        labels = setting.getValue();
                        FeatureLayer selectionLayer = (FeatureLayer)Project.map.Layers[0];
                        if (setting.getValue() == "true")
                        {
                            selectionLayer.ShowLabels = true;
                            Project.map.Refresh();
                        }
                        else
                        {
                            selectionLayer.ShowLabels = false;
                            Project.map.Refresh();
                        }

                        if (!String.IsNullOrEmpty(labels)) updateLabels = true;
                    }

                    if (setting.Key.ToString() == "road_f_surfacetype")
                    {
                        surfacetype = setting.getValue();
                        if (!String.IsNullOrEmpty(surfacetype)) updateSurface = true;
                    }
                    if (setting.Key.ToString() == "road_f_endaddr") {
                        endaddr = setting.getValue();
                        if (!String.IsNullOrEmpty(endaddr)) updateEndaddr = true;
                    }
                    if (setting.Key.ToString() == "road_f_startaddr")
                    {
                        startaddr = setting.getValue();
                        if (!String.IsNullOrEmpty(startaddr)) updateStartaddr = true;
                    }
                    if (setting.Key.ToString() == "road_f_speedlimit")
                    {
                        speedlimit = setting.getValue();
                        if (!int.TryParse(speedlimit, out int n)) continue;
                        if (!String.IsNullOrEmpty(speedlimit)) updateSpeedlimit = true;
                    }
                    if (setting.Key.ToString() == "road_f_length")
                    {
                        length = setting.getValue();
                        if (!double.TryParse(length, out double n)) continue;
                        if (!String.IsNullOrEmpty(length)) updateLength = true;
                    }
                    if (setting.Key.ToString() == "road_f_width")
                    {
                        width = setting.getValue();
                        if (!double.TryParse(width, out double n)) continue;
                        if (!String.IsNullOrEmpty(width)) updateWidth = true;
                    }
                    if (setting.Key.ToString() == "road_f_streetname")
                    {
                        streetname = setting.getValue();
                        if (!String.IsNullOrEmpty(streetname)) updateStreetname = true;
                    }
                    if (setting.Key.ToString() == "road_f_TAMSID")
                    {
                        tamsid = setting.getValue();
                        if (!int.TryParse(tamsid, out int n)) continue;
                        if (!String.IsNullOrEmpty(tamsid)) updateTamsid = true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Could not save setting.\n" + e.ToString());
                    success = false;
                }
            }

            if (success)
            {
                if (updateColors)sql += "\nUPDATE settings SET value = '" + colors + "' WHERE name = 'road_colors';";
                if (updateLabels)sql += "\nUPDATE settings SET value = '" + labels + "' WHERE name = 'road_labels';";
                if (updateSurface)sql += "\nUPDATE road SET surface = (SELECT " + surfacetype + " FROM shape WHERE road.TAMSID = " + tamsid + ");";
                if (updateEndaddr)sql += "\nUPDATE road SET to_address = (SELECT " + endaddr + " FROM shape WHERE road.TAMSID = " + tamsid + ");";
                if (updateStartaddr)sql += "\nUPDATE road SET from_address = (SELECT " + startaddr + " FROM shape WHERE road.TAMSID = " + tamsid + ");";
                if (updateSpeedlimit)sql += "\nUPDATE road SET speed_limit = (SELECT " + speedlimit + " FROM shape WHERE road.TAMSID = " + tamsid + ");";
                if (updateLength)sql += "\nUPDATE road SET length = (SELECT " + length + " FROM shape WHERE road.TAMSID = " + tamsid + ");";
                if (updateWidth)sql += "\nUPDATE road SET width = (SELECT " + width + " FROM shape WHERE road.TAMSID = " + tamsid + ");";
                if (updateStreetname)sql += "\nUPDATE road SET name = (SELECT " + streetname + " FROM shape WHERE road.TAMSID = " + tamsid + ");";
                if (updateTamsid)sql += "\nUPDATE road SET TAMSID = (SELECT " + tamsid + " FROM shape WHERE road.TAMSID = " + tamsid + ");";
                Database.ExecuteNonQuery(Project.conn, sql);
            }

            if (!Settings.HaveRequired())
            {
                MessageBox.Show("Missing some required settings. TAMS may not work properly.");
            }
            this.Close();
        }
    }
}
