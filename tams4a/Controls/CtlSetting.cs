using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using tams4a.Classes;

namespace tams4a.Controls
{
    public abstract partial class CtlSetting : UserControl
    {
        public String Description { get; set; }
        public String Display_Text { set { label.Text = value; } }
        public String Key { get; set; }
        public Boolean Changed { get; protected set; }
        public Boolean Required
        {
            get { return required; }
            set { setRequired(value); } 
        }
        private Boolean required;
        protected List<String> options;

        // key *Must Be Set* (for retrieval)
        public CtlSetting(String key)
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Inherit;
            Key = key;
            Changed = false;
            resetStatus();
        }

        // return the control that is accessed to change this usercontrol
        public abstract Control GetFocusControl();


        // Loads a control from a setting
        public void FromSetting(ProjectSetting setting)
        {
            Description = setting.Description;
            toolTip.SetToolTip(GetFocusControl(), Description);
            Display_Text = setting.Display_Name;
            Key = setting.Name;
            setValue(setting.Value);
            Changed = false;
            setOptions(setting.options);


            if (setting.Required)
            {
                label.Font = new Font(label.Font, FontStyle.Bold);
            } else
            {
                label.Font = new Font(label.Font, FontStyle.Regular);
            }

            resetStatus();
        }

        // attempts to set the control to value
        public abstract void setValue(String value);

        // returns the current value of the control as a string
        public abstract String getValue();

//        // attempt to reset control to default
//        public void resetValue(TamsProject project)
//        {
//            try
//            {
//                String value = project.settings.GetValue(Key);
//                setValue(value);
//                resetStatus();
//            }
//            catch
//            {
//                // ignore any errors
//#if DEBUG
//                MessageBox.Show("Could not reset value for " + Key);
//#endif
//            }
//        }

        // reset changed status / appearance
        public void resetStatus()
        {
            this.BackColor = default(Color);
            this.ForeColor = default(Color);
            Changed = false;
        }

        // highlights items that have changed
        protected void HandleValueChanged(object sender, EventArgs e)
        {
            Changed = true;
            this.BackColor = SystemColors.Info;
            this.ForeColor = SystemColors.InfoText;
        }


        // Get focus
        [Category("GotFocus")]
        [Description("Setting Control gets focus.")]
        public event EventHandler<CustomEventArgs> OnFocus;

        // raises the correct event
        protected virtual void OnFocussed(CustomEventArgs e)
        {
            if (OnFocus != null)
            {
                OnFocus(this, e);
            }
        }

        // method for controls in the settingBase control to call
        protected void ux_gotFocus(object sender, EventArgs e)
        {
            OnFocussed(new CustomEventArgs());
        }


        // doesn't really do anything. ;)
        public virtual void setOptions(List<String> values)
        {
            options = values;
        }


        // bolds the label when required is true
        private void setRequired(Boolean value)
        {
            required = value;
            if (required)
            {
                label.Font = new Font(label.Font, FontStyle.Bold);
            }
            else
            {
                label.Font = new Font(label.Font, FontStyle.Regular);
            }
        }
    }
}
