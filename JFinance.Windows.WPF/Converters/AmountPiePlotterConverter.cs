using JFinance.Windows.WPF.Controls;
using JFinance.Windows.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using static JFinance.Windows.WPF.ViewModels.GraphViewModel;

namespace JFinance.Windows.WPF.Converters
{
    [ValueConversion(typeof(object), typeof(string))]
    public class AmountPiePlotterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            PiePlotter plotter = null;
            PieElement element = null;

            foreach (object value in values)
            {
                if (value is PiePlotter)
                    plotter = (PiePlotter)value;

                if (value is PieElement)
                    element = (PieElement)value;
            }
            return TypeDescriptor.GetProperties(element)[plotter.PlottedProperty].GetValue(element).ToString();
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
