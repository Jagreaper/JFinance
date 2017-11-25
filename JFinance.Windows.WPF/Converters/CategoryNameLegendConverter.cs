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

namespace JFinance.Windows.WPF.Converters
{
    [ValueConversion(typeof(object), typeof(string))]
    public class CategoryNameLegendConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TextBlock label = (TextBlock)value;
            object item = label.Tag;

            DependencyObject container = (DependencyObject)WpfHelper.FindElementOfTypeUp((Visual)value, typeof(ListBoxItem));

            ItemsControl owner = ItemsControl.ItemsControlFromItemContainer(container);

            Legend legend = (Legend)WpfHelper.FindElementOfTypeUp(owner, typeof(Legend));

            PropertyDescriptorCollection filterPropDesc = TypeDescriptor.GetProperties(item);
            return filterPropDesc[legend.CategoryName].GetValue(item);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
