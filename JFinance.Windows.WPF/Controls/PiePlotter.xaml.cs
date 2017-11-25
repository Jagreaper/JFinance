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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

using System.Windows.Media.Animation;
using JFinance.Windows.WPF.Selectors;

namespace JFinance.Windows.WPF.Controls
{
    /// <summary>
    /// Renders a bound dataset as a pie chart
    /// </summary>
    public partial class PiePlotter : UserControl
    {
        #region Constructor
        
        public PiePlotter()
        {
            DependencyPropertyDescriptor property = DependencyPropertyDescriptor.FromProperty(PieChartLayout.PlottedPropertyProperty, typeof(PiePlotter));
            property.AddValueChanged(this, PlottedPropertyChanged);

            this.InitializeComponent();
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(DataContextChangedHandler);
        }

        #endregion

        #region Properties

        public static readonly DependencyProperty HoleSizeProperty = DependencyProperty.Register("HoleSize", typeof(double), typeof(PiePlotter), new UIPropertyMetadata(0.0));

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

        public double HoleSize
        {
            get => (double)GetValue(PiePlotter.HoleSizeProperty);
            set
            {
                this.SetValue(PiePlotter.HoleSizeProperty, value);
                this.ConstructPiePieces();
            }
        }
        
        private List<PiePiece> PiePieces { get; set; } = new List<PiePiece>();

        #endregion

        #region Methods

        private void DataContextChangedHandler(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.DataContext is INotifyCollectionChanged observable)
                observable.CollectionChanged += new NotifyCollectionChangedEventHandler(this.BoundCollectionChanged);

            CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(this.DataContext);
            collectionView.CurrentChanged += new EventHandler(this.CollectionViewCurrentChanged);
            collectionView.CurrentChanging += new CurrentChangingEventHandler(this.CollectionViewCurrentChanging);

            this.ConstructPiePieces();
            this.ObserveBoundCollectionChanges();
        }

        private void PlottedPropertyChanged(object sender, EventArgs e) => this.ConstructPiePieces();

        private void PiePieceMouseUp(object sender, MouseButtonEventArgs e)
        {
            CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(this.DataContext);
            if (collectionView == null)
                return;

            PiePiece piece = (PiePiece)sender;
            if (piece == null)
                return;
            
            int index = (int)piece.Tag;
            collectionView.MoveCurrentToPosition(index);
        }

        private void CollectionViewCurrentChanging(object sender, CurrentChangingEventArgs e)
        {
            CollectionView collectionView = (CollectionView)sender;

            if (collectionView != null && collectionView.CurrentPosition >= 0 && collectionView.CurrentPosition <= this.PiePieces.Count)
            {
                PiePiece piece = this.PiePieces[collectionView.CurrentPosition];

                DoubleAnimation a = new DoubleAnimation
                {
                    To = 0,
                    Duration = new Duration(TimeSpan.FromMilliseconds(200))
                };

                piece.BeginAnimation(PiePiece.PushOutProperty, a);
            }
        }

        private void CollectionViewCurrentChanged(object sender, EventArgs e)
        {
            CollectionView collectionView = (CollectionView)sender;

            if (collectionView != null && collectionView.CurrentPosition >= 0 && collectionView.CurrentPosition <= this.PiePieces.Count)
            {
                PiePiece piece = this.PiePieces[collectionView.CurrentPosition];

                DoubleAnimation a = new DoubleAnimation
                {
                    To = 10,
                    Duration = new Duration(TimeSpan.FromMilliseconds(200))
                };

                piece.BeginAnimation(PiePiece.PushOutProperty, a);
            }
        }

        private void BoundCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.ConstructPiePieces();
            this.ObserveBoundCollectionChanges();
        }

        private void ObserveBoundCollectionChanges()
        {
            CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(this.DataContext);

            foreach(object item in myCollectionView)
            {
                if (item is INotifyPropertyChanged observable)
                    observable.PropertyChanged += new PropertyChangedEventHandler(this.ItemPropertyChanged);
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(this.PlottedProperty))
                this.ConstructPiePieces();
        }

        private double GetPlottedPropertyValue(object item) => (double)TypeDescriptor.GetProperties(item)[this.PlottedProperty].GetValue(item);

        private double GetCategoryNameValue(object item) => (double)TypeDescriptor.GetProperties(item)[this.PlottedProperty].GetValue(item);

        private void ConstructPiePieces()
        {
            CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(this.DataContext);
            if (myCollectionView == null)
                return;

            double halfWidth = this.Width / 2;
            double innerRadius = halfWidth * HoleSize;

            double total = 0;
            foreach (object item in myCollectionView)
                total += this.GetPlottedPropertyValue(item);

            this.canvas.Children.Clear();
            this.PiePieces.Clear();

            double accumulativeAngle = 0;
            foreach (object item in myCollectionView)
            {
                bool selectedItem = item == myCollectionView.CurrentItem;
                double wedgeAngle = this.GetPlottedPropertyValue(item) * 360 / total;

                PiePiece piece = new PiePiece()
                {
                    Radius = halfWidth,
                    InnerRadius = innerRadius,
                    CentreX = halfWidth,
                    CentreY = halfWidth,
                    PushOut = (selectedItem ? 10.0 : 0),
                    WedgeAngle = wedgeAngle,
                    PieceValue = this.GetPlottedPropertyValue(item),
                    RotationAngle = accumulativeAngle,
                    Fill = this.ColorSelector != null ? this.ColorSelector.SelectBrush(item, myCollectionView.IndexOf(item)) : Brushes.Black,
                    Tag = myCollectionView.IndexOf(item),
                    ToolTip = new ToolTip()
                };

                piece.ToolTipOpening += new ToolTipEventHandler(this.PiePieceToolTipOpening);
                piece.MouseUp += new MouseButtonEventHandler(this.PiePieceMouseUp);

                this.PiePieces.Add(piece);
                this.canvas.Children.Insert(0, piece);

                accumulativeAngle += wedgeAngle;
            }
        }

        private void PiePieceToolTipOpening(object sender, ToolTipEventArgs e)
        {
            PiePiece piece = (PiePiece)sender;

            CollectionView collectionView = (CollectionView)CollectionViewSource.GetDefaultView(this.DataContext);
            if (collectionView == null)
                return;

            int index = (int)piece.Tag;
            if (piece.ToolTip != null)
            {
                ToolTip tip = (ToolTip)piece.ToolTip;
                tip.DataContext = collectionView.GetItemAt(index);
            }
        }

        #endregion
    }
}
