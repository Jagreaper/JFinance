using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JFinance.Windows.WPF.Helpers
{
    public class FinderMatchType : IFinderMatchVisualHelper
    {
        #region Constructor

        public FinderMatchType(Type type) => this.Type = type;

        #endregion

        #region Properties

        private Type Type { get; set; }

        public bool FindFirst { get; set; } = false;

        #endregion

        #region Methods

        public FinderMatchType(Type type, bool findFirst)
        {
            this.Type = type;
            this.FindFirst = findFirst;
        }

        public bool DoesMatch(DependencyObject item) => Type.IsInstanceOfType(item);

        #endregion


    }
}
