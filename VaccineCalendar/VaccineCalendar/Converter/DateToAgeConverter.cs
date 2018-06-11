using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace VaccineCalendar.Converter
{
    public class DateToAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? birthDate = value as DateTime?;
            if (!birthDate.HasValue)
                return "";
            return Shared.Calendar.IdadeTexto(birthDate.Value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
