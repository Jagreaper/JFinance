using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JFinance.Windows.WPF.Styles
{
    internal sealed class SystemTheme : Theme
    {
        // Skip
    }

    public static class Themes
    {
        #region Fields

        private static Theme classicBlueTheme;

        private static Theme classicDarkTheme;

        private static ObservableCollection<Theme> all;

        #endregion

        #region Properties

        public static Theme ClassicBlueTheme => Themes.classicBlueTheme ?? (Themes.classicBlueTheme = Themes.CreateClassicBlueTheme());

        public static Theme ClassicDarkTheme => Themes.classicDarkTheme ?? (Themes.classicDarkTheme = Themes.CreateClassicDarkTheme());

        public static ObservableCollection<Theme> All => Themes.all ?? (Themes.all = Themes.CreateThemesList());

        #endregion

        #region Methods
        
        private static ObservableCollection<Theme> CreateThemesList()
        {
            return new ObservableCollection<Theme>()
            {
                Themes.ClassicBlueTheme,
                Themes.ClassicDarkTheme,
            };
        }

        private static Theme CreateClassicBlueTheme()
        {
            return new SystemTheme
            {
                Name = "Classic Blue",
                AccentMainBrush    = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF3399FF")),
                AccentDarkBrush    = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF007ACC")),
                SelectedBrush      = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF")),
                ValidationBrush    = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF33333")),
                AccentBrush        = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF007ACC")),
                MarkerBrush        = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1E1E1E")),
                StrongBrush        = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF717171")),
                MainBrush          = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF")),
                PrimaryBrush       = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFEEEEF2")),
                AlternativeBrush   = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF5F5F5")),
                MouseOverBrush     = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFC9DEF5")),
                BasicBrush         = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFCCCEDB")),
                SemiBasicBrush     = (SolidColorBrush)(new BrushConverter().ConvertFrom("#66CCCEDB")),
                HeaderBrush        = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF007ACC")),
                ComplementaryBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDBDDE6")),
                BackgroundBrush    = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF")),
            };
        }

        private static Theme CreateClassicDarkTheme()
        {
            return new SystemTheme
            {
                Name = "Classic Dark",
                AccentMainBrush    = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF666666")),
                AccentDarkBrush    = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF555555")),
                SelectedBrush      = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF")),
                ValidationBrush    = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF33333")),
                AccentBrush        = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF363636")),
                MarkerBrush        = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF")),
                StrongBrush        = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF717171")),
                MainBrush          = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF")),
                PrimaryBrush       = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF666666")),
                AlternativeBrush   = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF575757")),
                MouseOverBrush     = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF505050")),
                BasicBrush         = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFCCCEDB")),
                SemiBasicBrush     = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFCCCEDB")),
                HeaderBrush        = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF007ACC")),
                ComplementaryBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDBDDE6")),
                BackgroundBrush    = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF444444")),
            };
        }

        #endregion
    }
}
