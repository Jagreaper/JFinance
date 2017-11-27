using JFinance.Mvvm;
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

        #endregion

        #region Properties

        public ICommand SaveCommand { get; private set; }

        public ICommand SelectCommand { get; private set; }

        public ObservableCollection<Theme> Themes
        {
            get => this.themes;
            set => this.Set(ref this.themes, value);
        }

        private Theme OldTheme { get; set; }

        #endregion

        #region Methods

        public void Save() => this.OldTheme = ((App)App.Current).CurrentTheme;

        public void Select(Theme theme) => ((App)App.Current).CurrentTheme = theme;

        public override void OnClosing(object sender, EventArgs e) => ((App)App.Current).CurrentTheme = this.OldTheme;

        #endregion
    }
}
