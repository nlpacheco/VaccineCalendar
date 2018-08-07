using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace VaccineCalendar.Shared
{
    public static class ControlExtensions
    {
        public static void StyleClassInit(this Label lbl, string[] styleClasses)        {            if (lbl.StyleClass == null)
                lbl.StyleClass = new List<string>();
            
            foreach (var item in styleClasses)
            {
                lbl.StyleClass.Add(item);
            }
        }
    }
}
