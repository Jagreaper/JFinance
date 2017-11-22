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
    class TransactionTypeDoubleStringConverter : IMultiValueConverter
    {
        #region Methods

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double amount = 0.0;
            string type = "";

            foreach (object value in values)
            {
                if (value is TransactionType)
                {
                    switch ((TransactionType)value)
                    {
                        case TransactionType.Credit:
                            type = "CR";
                            break;
                        case TransactionType.Debit:
                            type = "DB";
                            break;
                        case TransactionType.None:
                            type = "NO";
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }

                if (value is double)
                    amount = (double)((int)((double)value * 100)) / 100;
            }

            return string.Format("${0} {1}", amount, type);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
