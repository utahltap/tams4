using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tams4a
{
    // Custom event for user controls
    public class CustomEventArgs : EventArgs
    {
        public int EventValue { get; set; }
        // included a default value for times you don't care about the event value.
        public CustomEventArgs(int eventValue=0)
        {
            EventValue = eventValue;
        }
    }
}
