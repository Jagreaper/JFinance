using JFinance.Models;
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
    class TransactionTypeToBrushConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Theme theme = ((App)App.Current).CurrentTheme;

            if (!(value is TransactionType))
                throw new NotSupportedException();

            switch ((TransactionType)value)
            {
                case TransactionType.Credit:
                    return theme.ValidBrush;
                case TransactionType.Debit:
                    return theme.InvalidBrush;
                case TransactionType.None:
                    return Brushes.Gray;
                default:
                    throw new NotSupportedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
