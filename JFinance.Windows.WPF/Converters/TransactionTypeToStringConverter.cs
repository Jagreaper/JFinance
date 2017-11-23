using JFinance.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JFinance.Windows.WPF.Converters
{
    class TransactionTypeToStringConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TransactionType))
                throw new NotSupportedException();

            switch ((TransactionType)value)
            {
                case TransactionType.Credit:
                    return "CR";
                case TransactionType.Debit:
                    return "DB";
                case TransactionType.None:
                    return "NO";
                default:
                    throw new NotSupportedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
                throw new NotSupportedException();

            switch ((string)value)
            {
                case "CR":
                    return TransactionType.Credit;
                case "DB":
                    return TransactionType.Debit;
                case "NO":
                    return TransactionType.None;
                default:
                    throw new NotSupportedException();
            }
        }

        #endregion
    }
}
