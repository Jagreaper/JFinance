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
using System.ComponentModel;
using System.Collections.Specialized;
using JFinance.Windows.WPF.Selectors;

namespace JFinance.Windows.WPF.Controls
{
    /// <summary>
    /// A pie chart legend
    /// </summary>
    public partial class Legend : UserControl
    {
        #region Constructor
        
        public Legend()
        {
            DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor.FromProperty(PieChartLayout.PlottedPropertyProperty, typeof(PiePlotter));
            dpd.AddValueChanged(this, this.PlottedPropertyChanged);

            this.DataContextChanged += new DependencyPropertyChangedEventHandler(this.DataContextChangedHandler);
            this.InitializeComponent();
        }

        #endregion

        #region Properties

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

        private double GetPlottedPropertyValue(object item) => (double)TypeDescriptor.GetProperties(item)[this.PlottedProperty].GetValue(item);

        private double GetCategoryNameValue(object item) => (double)TypeDescriptor.GetProperties(item)[this.PlottedProperty].GetValue(item);

        private void DataContextChangedHandler(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.DataContext is INotifyCollectionChanged observable)
                observable.CollectionChanged += new NotifyCollectionChangedEventHandler(this.BoundCollectionChanged);

            this.ObserveBoundCollectionChanges();
        }

        private void BoundCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.RefreshView();
            this.ObserveBoundCollectionChanges();
        }

        private void PlottedPropertyChanged(object sender, EventArgs e) => this.RefreshView();

        private void ObserveBoundCollectionChanges()
        {
            CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(this.DataContext);

            foreach (object item in myCollectionView)
            {
                if (item is INotifyPropertyChanged observable)
                    observable.PropertyChanged += new PropertyChangedEventHandler(this.ItemPropertyChanged);
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(this.PlottedProperty))
                this.RefreshView();
        }
        
        private void RefreshView()
        {
            object context = this.legend.DataContext;
            if (context != null)
            {
                this.legend.DataContext = null;
                this.legend.DataContext = context;
            }
        }

        #endregion

    }
}
