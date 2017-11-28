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
    class DoubleToBrushValidationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Theme theme = ((App)App.Current).CurrentTheme;

            if ((double)value >= 0)
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
