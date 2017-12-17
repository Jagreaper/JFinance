using Jagerts.Arie.Standard.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JFinance.Windows.WPF.Selectors
{
    class ThemeDataTemplateSelector : DataTemplateSelector
    {
        #region Properties

        public DataTemplate ThemeTemplate { get; set; }

        #endregion

        #region Methods

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ColorScheme)
                return this.ThemeTemplate;

            return null;
        }

        #endregion
    }
}
