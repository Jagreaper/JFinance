using JFinance.Windows.WPF.Selectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JFinance.Windows.WPF.Controls
{
    /// <summary>
    /// Defines the layout of the pie chart
    /// </summary>
    public partial class PieChartLayout : UserControl
    {
        #region Constructor

        public PieChartLayout() => this.InitializeComponent();

        #endregion
        
        #region Properties

        public static readonly DependencyProperty PlottedPropertyProperty = DependencyProperty.RegisterAttached("PlottedProperty", typeof(String), typeof(PieChartLayout), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty CategoryNameProperty = DependencyProperty.RegisterAttached("CategoryName", typeof(String), typeof(PieChartLayout), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ColorSelectorProperty = DependencyProperty.RegisterAttached("ColorSelectorProperty", typeof(IColorSelector), typeof(PieChartLayout), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public String PlottedProperty
        {
            get => PieChartLayout.GetPlottedProperty(this);
            set => PieChartLayout.SetPlottedProperty(this, value);
        }

        public String CategoryName
        {
            get => PieChartLayout.GetCategoryName(this);
            set => PieChartLayout.SetCategoryName(this, value);
        }

        public IColorSelector ColorSelector
        {
            get => PieChartLayout.GetColorSelector(this);
            set => PieChartLayout.SetColorSelector(this, value);
        }

        #endregion

        #region Methods

        public static void SetPlottedProperty(UIElement element, String value) => element.SetValue(PieChartLayout.PlottedPropertyProperty, value);

        public static String GetPlottedProperty(UIElement element) => (String)element.GetValue(PieChartLayout.PlottedPropertyProperty);

        public static void SetCategoryName(UIElement element, String value) => element.SetValue(PieChartLayout.CategoryNameProperty, value);

        public static String GetCategoryName(UIElement element) => (String)element.GetValue(PieChartLayout.CategoryNameProperty);

        public static void SetColorSelector(UIElement element, IColorSelector value) => element.SetValue(PieChartLayout.ColorSelectorProperty, value);

        public static IColorSelector GetColorSelector(UIElement element) => (IColorSelector)element.GetValue(PieChartLayout.ColorSelectorProperty);


        #endregion
    }
}
