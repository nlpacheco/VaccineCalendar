using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace VaccineCalendar.Converter
{
    public class GenderToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string gender = value as string;
            if (gender == null)
                return "";

            return gender == "F" ? "Menina" : gender== "M" ? "Menino" : "??";
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string gender = value as string;
            if (gender == null)
                return "";

            return gender == "Menina" ? "F" : gender == "Menino" ? "M" : "";
        }

    }
}
