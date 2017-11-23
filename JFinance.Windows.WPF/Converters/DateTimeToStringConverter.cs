using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JFinance.Windows.WPF.Converters
{
    class DateTimeToStringConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime))
                throw new NotSupportedException();

            return ((DateTime)value).ToString("dd/MM/yyyy hh:mm:ss");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
                throw new NotSupportedException();

            string[] timeSplit = ((string)value).Split(' ');
            string[] yearSplit = timeSplit[0].Split('/');
            string[] hourSplit = timeSplit[1].Split(':');

            int days = int.Parse(yearSplit[0]);
            int months = int.Parse(yearSplit[1]);
            int years = int.Parse(yearSplit[2]);

            int hours = int.Parse(hourSplit[0]);
            int minutes = int.Parse(hourSplit[1]);
            int seconds = int.Parse(hourSplit[2]);

            return new DateTime(years, months, days, hours, minutes, seconds);
        }

        #endregion
    }
}
