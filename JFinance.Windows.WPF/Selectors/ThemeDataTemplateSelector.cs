using JFinance.Windows.WPF.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static JFinance.Windows.WPF.Styles.Themes;

namespace JFinance.Windows.WPF.Selectors
{
    class ThemeDataTemplateSelector : DataTemplateSelector
    {
        #region Properties

        public DataTemplate SystemThemeTemplate { get; set; }

        public DataTemplate ThemeTemplate { get; set; }

        #endregion

        #region Methods

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is SystemTheme)
                return this.SystemThemeTemplate;

            if (item is Theme)
                return this.ThemeTemplate;

            return null;
        }

        #endregion
    }
}
