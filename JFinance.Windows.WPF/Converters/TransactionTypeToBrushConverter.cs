using JFinance.Models;
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
            if (!(value is TransactionType))
                throw new NotSupportedException();

            switch ((TransactionType)value)
            {
                case TransactionType.Credit:
                    return Brushes.Green;
                case TransactionType.Debit:
                    return Brushes.Red;
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
