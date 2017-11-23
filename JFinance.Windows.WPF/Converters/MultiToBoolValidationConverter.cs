using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JFinance.Windows.WPF.Converters
{
    class MultiToBoolValidationConverter : IMultiValueConverter
    {
        #region Methods

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool enabled = true;
            foreach (object value in values)
            {
                if (value is string)
                    enabled = enabled && !string.IsNullOrEmpty(((string)value));

                if (value is double)
                    enabled = enabled && ((double)value) >= 0;
            }

            return enabled;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
