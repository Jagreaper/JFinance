using Jagerts.Arie.Standard.Mvvm;
using JFinance.Windows.WPF.Styles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JFinance.Windows.WPF.ViewModels
{
    class ThemeViewModel : ViewModel
    {
        #region Constructor

        public ThemeViewModel()
        {
            this.Themes = Styles.Themes.All;
            this.SelectCommand = new RelayCommand<Theme>(this.Select);
            this.SaveCommand = new RelayCommand(this.Save);
            this.OldTheme = ((App)App.Current).CurrentTheme;
        }

        #endregion

        #region Fields

        private ObservableCollection<Theme> themes;

        private bool isButtonEnabled;

        #endregion

        #region Properties

        public ICommand SaveCommand { get; private set; }

        public ICommand SelectCommand { get; private set; }

        public ObservableCollection<Theme> Themes
        {
            get => this.themes;
            set => this.Set(ref this.themes, value);
        }

        public bool IsButtonEnabled
        {
            get => this.isButtonEnabled;
            set => this.Set(ref this.isButtonEnabled, value);
        }

        private Theme OldTheme { get; set; }

        #endregion

        #region Methods

        public void Save()
        {
            this.OldTheme = ((App) App.Current).CurrentTheme;
            this.IsButtonEnabled = false;
        }

        public void Select(Theme theme)
        {
            ((App)App.Current).CurrentTheme = theme;
            this.IsButtonEnabled = theme != this.OldTheme ? true : false;
        }

        public override void OnClosing(object sender, EventArgs e) => ((App)App.Current).CurrentTheme = this.OldTheme;

        #endregion
    }
}
