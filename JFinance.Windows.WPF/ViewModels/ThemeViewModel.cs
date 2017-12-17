using Jagerts.Arie.Standard.Controls;
using Jagerts.Arie.Standard.Mvvm;
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
            this.ColorSchemes = Jagerts.Arie.Standard.Controls.ColorSchemes.All;
            this.SelectCommand = new RelayCommand<ColorScheme>(this.Select);
            this.SaveCommand = new RelayCommand(this.Save);
            this.OldColorScheme = ((App)App.Current).CurrentColorScheme;
        }

        #endregion

        #region Fields

        private ObservableCollection<ColorScheme> colorSchemes;

        private bool isButtonEnabled;

        #endregion

        #region Properties

        public ICommand SaveCommand { get; private set; }

        public ICommand SelectCommand { get; private set; }

        public ObservableCollection<ColorScheme> ColorSchemes
        {
            get => this.colorSchemes;
            set => this.Set(ref this.colorSchemes, value);
        }

        public bool IsButtonEnabled
        {
            get => this.isButtonEnabled;
            set => this.Set(ref this.isButtonEnabled, value);
        }

        private ColorScheme OldColorScheme { get; set; }

        #endregion

        #region Methods

        public void Save()
        {
            this.OldColorScheme = ((App)App.Current).CurrentColorScheme;
            this.IsButtonEnabled = false;
        }

        public void Select(ColorScheme theme)
        {
            ((App)App.Current).CurrentColorScheme = theme;
            this.IsButtonEnabled = theme != this.OldColorScheme ? true : false;
        }

        public override void OnClosing(object sender, EventArgs e) => ((App)App.Current).CurrentColorScheme = this.OldColorScheme;

        #endregion
    }
}
