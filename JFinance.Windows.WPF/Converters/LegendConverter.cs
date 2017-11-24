using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.ComponentModel;
using JFinance.Windows.WPF.Helpers;

namespace JFinance.Windows.WPF.Controls
{
    /// <summary>
    /// Obtain the value of the property from the item, which is currently displayed by the pie chart.
    /// </summary>
    [ValueConversion(typeof(object), typeof(string))]
    public class LegendConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TextBlock label = (TextBlock)value;
            object item = label.Tag;
            
            DependencyObject container = (DependencyObject)WpfHelper.FindElementOfTypeUp((Visual)value, typeof(ListBoxItem));
            
            ItemsControl owner = ItemsControl.ItemsControlFromItemContainer(container);

            Legend legend = (Legend)WpfHelper.FindElementOfTypeUp(owner, typeof(Legend));
            
            PropertyDescriptorCollection filterPropDesc = TypeDescriptor.GetProperties(item);
            return filterPropDesc[legend.PlottedProperty].GetValue(item);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
        
}
