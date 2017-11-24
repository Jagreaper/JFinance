using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace JFinance.Windows.WPF.Selectors
{
    public class IndexedColourSelector : DependencyObject, IColorSelector
    {
        #region Properties

        public static readonly DependencyProperty BrushesProperty = DependencyProperty.Register("BrushesProperty", typeof(Brush[]), typeof(IndexedColourSelector), new UIPropertyMetadata(null));

        public Brush[] Brushes
        {
            get => (Brush[])this.GetValue(IndexedColourSelector.BrushesProperty);
            set => this.SetValue(IndexedColourSelector.BrushesProperty, value);
        }

        #endregion

        #region Methods

        public Brush SelectBrush(object item, int index)
        {
            if (this.Brushes == null || this.Brushes.Length == 0)
                return System.Windows.Media.Brushes.Black;

            return this.Brushes[index % this.Brushes.Length];
        }

        #endregion
    }
}
