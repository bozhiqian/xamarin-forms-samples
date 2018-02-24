using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithPopups.Events
{
    public class ActionSheetEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Destruction { get; set; }
        public string Cancel { get; set; }

        public string[] Buttons { get; set; }

    }
}
