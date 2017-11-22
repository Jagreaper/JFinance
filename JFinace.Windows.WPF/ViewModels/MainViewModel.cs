using JFinace.Mvvm;
using JFinace.Windows.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JFinace.Windows.WPF.ViewModels
{
    class MainViewModel : ViewModel
    {
        #region Constructor

        public MainViewModel()
        {
            this.NavigateCommand = new RelayCommand<string>(this.Navigate);
            this.ContentControl = new SummaryView();
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
            switch(arg)
            {
                case "NavigateSummary":
                    this.ContentControl = new SummaryView();
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
