using System;
using System.Collections.Generic;

namespace tams4a.Classes
{
    public class ProjectSetting : IComparable<ProjectSetting>
    {
        public String Name { get; set; }
        public String Value { get; set; }
        public String Module { get; set; }
        public String Display_Name { get; set; }
        public String Display_Type { get; set; }
        public Int32 Display_Weight { get; set; }
        public String Description { get; set; }
        public Boolean Required { get; set; }
        public List<String> options;       // settings MAY have a list of possible values (List may or may not be enforced depending on control type)

        /// <summary>
        /// Constructor for the project setting object, can then be referenced by program features that rely on project specific settings.
        /// </summary>
        /// <param name="name">Reqired: The name of the setting</param>
        /// <param name="value"></param>
        /// <param name="module"></param>
        /// <param name="display_text"></param>
        /// <param name="display_type"></param>
        /// <param name="display_weight"></param>
        /// <param name="description"></param>
        /// <param name="required"></param>
        public ProjectSetting(String name, String value="", String module="", String display_text="", 
                                String display_type="", Int32 display_weight=5, String description="",
                                Boolean required=false)
        {
            Name = name;
            Value = value;
            Module = module;
            Display_Name = display_text;
            Display_Type = display_type;
            Display_Weight = display_weight;
            Description = description;
            Required = required;
            options = new List<String>();
        }

        // -1 => This before other
        //  0 => Equal (or undefined)
        //  1 => This after other
        // note that since we've defined a default value, we shouldn't run into instances where 
        // display_weight is undefined or null, but just in case. ;) 
        public int CompareTo(ProjectSetting other)
        {
            try
            {
                int weight_this = this.Display_Weight;
                int weight_that = other.Display_Weight;
                return weight_this.CompareTo(weight_that);
            }
            catch
            {
                return 0;
            }
        }

    }
}
