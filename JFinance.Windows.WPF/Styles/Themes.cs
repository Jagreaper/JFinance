using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JFinance.Windows.WPF.Styles
{
    public static class Themes
    {
        #region Fields

        public static Theme classicTheme;

        #endregion

        #region Properties

        public static Theme ClassicTheme => Themes.classicTheme ?? (Themes.classicTheme = Themes.CreateClassicTheme());

        #endregion

        #region Methods

        private static Theme CreateClassicTheme()
        {
            return new Theme
            {
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

        #endregion
    }
}
