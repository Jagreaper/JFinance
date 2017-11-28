using JFinance.Windows.WPF.Styles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace JFinance.Windows.WPF.Converters
{
    class StringToBrushValidationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Theme theme = ((App)App.Current).CurrentTheme;

            if (!string.IsNullOrEmpty((string)value))
                return theme.ValidBrush;
            else
                return theme.InvalidBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
