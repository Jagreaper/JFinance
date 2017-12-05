using Jagerts.Arie.Standard.Mvvm;
using JFinance.Windows.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace JFinance.Windows.WPF.ViewModels
{
    class MainViewModel : ViewModel
    {
        #region Constructor

        public MainViewModel()
        {
            this.NavigateCommand = new RelayCommand<string>(this.Navigate);
        }

        #endregion

        #region Fields

        public object contentControl;

        #endregion

        #region Properties

        public ICommand NavigateCommand { get; private set; }

        public object ContentControl
        {
            get => this.contentControl;
            set => this.Set(ref this.contentControl, value);
        }

        #endregion

        #region Methods

        public void Navigate(string arg)
        {
            ((ViewModel)((UserControl)this.ContentControl)?.DataContext)?.OnClosing(this, EventArgs.Empty);
            switch(arg)
            {
                case "NavigateSummary":
                    this.ContentControl = new SummaryView();
                    break;
                case "NavigateGraph":
                    this.ContentControl = new GraphView();
                    break;
                case "NavigateThemes":
                    this.ContentControl = new ThemeView();
                    break;
                default:
                    this.ContentControl = null;
                    break;
            }
        }

        #endregion
    }
}
