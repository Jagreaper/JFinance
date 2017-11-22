using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace JFinance.Windows.WPF.Controls
{
    public class PathRadioButton : RadioButton
    {
        #region Constructor

        static PathRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PathRadioButton), new FrameworkPropertyMetadata(typeof(PathRadioButton)));
        }

        #endregion

        #region Properties

        public static readonly DependencyProperty PathDataProperty = DependencyProperty.Register("PathData", typeof(Geometry), typeof(PathRadioButton), new PropertyMetadata(null));

        public static readonly DependencyProperty PathStyleProperty = DependencyProperty.Register( "PathStyle", typeof(Style), typeof(PathRadioButton), new PropertyMetadata(null));

        public Geometry PathData
        {
            get => (Geometry)this.GetValue(PathDataProperty);
            set => this.SetValue(PathDataProperty, value);
        }

        public Style PathStyle
        {
            get => (Style)this.GetValue(PathStyleProperty);
            set => this.SetValue(PathStyleProperty, value);
        }

        #endregion

        #region Events
        
        public static readonly RoutedEvent ActivateEvent = EventManager.RegisterRoutedEvent("Activate", RoutingStrategy.Bubble, typeof(EventHandler<RoutedEventArgs>), typeof(PathRadioButton));

        public event EventHandler<RoutedEventArgs> Activate
        {
            add => this.AddHandler(ActivateEvent, value);
            remove => this.RemoveHandler(ActivateEvent, value);
        }

        #endregion

        #region Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.UpdateVisualStates();
        }

        internal void UpdateVisualStates()
        {
            if (!this.IsEnabled)
            {
                if (this.IsChecked == true)
                    VisualStateManager.GoToState(this, "DisabledChecked", true);
                else
                    VisualStateManager.GoToState(this, "Disabled", true);
            }
            else if (this.IsPressed)
                VisualStateManager.GoToState(this, "Pressed", true);
            else if (this.IsMouseOver)
            {
                if (this.IsChecked == true)
                    VisualStateManager.GoToState(this, "MouseOverChecked", true);
                else
                    VisualStateManager.GoToState(this, "MouseOver", true);
            }
            else
                VisualStateManager.GoToState(this, "Normal", true);

            if (this.IsChecked == true)
                VisualStateManager.GoToState(this, "Checked", true);
            else if (this.IsChecked == false)
                VisualStateManager.GoToState(this, "Unchecked", true);
            else if (!VisualStateManager.GoToState(this, "Indeterminate", true))
                VisualStateManager.GoToState(this, "Unchecked", true);

            if (this.IsFocused && this.IsEnabled)
                VisualStateManager.GoToState(this, "Focused", true);
            else
                VisualStateManager.GoToState(this, "Unfocused", true);
        }

        protected internal virtual void OnActivate()
        {
            this.RaiseEvent(new RoutedEventArgs(ActivateEvent, this));
        }

        protected override void OnToggle()
        {
            base.OnToggle();
            this.OnActivate();
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            this.UpdateVisualStates();
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            this.UpdateVisualStates();
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            this.UpdateVisualStates();
        }

        #endregion
    }
}
