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
using JFinance.Windows.WPF.Controls;

namespace JFinance.Windows.WPF.Converters
{
    [ValueConversion(typeof(object), typeof(Brush))]
    public class ColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FrameworkElement element = (FrameworkElement)value;
            object item = element.Tag;
            
            DependencyObject container = (DependencyObject)WpfHelper.FindElementOfTypeUp(element, typeof(ListBoxItem));
            
            ItemsControl owner = ItemsControl.ItemsControlFromItemContainer(container);
            
            Legend legend = (Legend)WpfHelper.FindElementOfTypeUp(owner, typeof(Legend));

            CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(owner.DataContext);
            
            int index = collectionView.IndexOf(item);

            if (legend.ColorSelector != null)
                return legend.ColorSelector.SelectBrush(item, index);
            else
                return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
        
}
