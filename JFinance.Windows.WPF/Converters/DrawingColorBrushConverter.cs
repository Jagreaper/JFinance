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
    class DrawingColorBrushConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Drawing.Color dColor)
                return new SolidColorBrush(Color.FromArgb(dColor.A, dColor.R, dColor.G, dColor.B));

            if (value is Color mColor)
                return new SolidColorBrush(mColor);

            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
