using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JFinance.Windows.WPF.Helpers
{

    public interface IFinderMatchVisualHelper
    {
        #region Properties

        bool FindFirst { get; set; }

        #endregion

        #region Methods

        bool DoesMatch(DependencyObject item);

        #endregion
    }
}
