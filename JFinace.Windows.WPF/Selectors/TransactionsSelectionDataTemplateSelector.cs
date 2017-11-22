using JFinace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JFinace.Windows.WPF.Selectors
{
    class TransactionsSelectionDataTemplateSelector : DataTemplateSelector
    {
        #region Properties

        public DataTemplate TransactionTemplate { get; set; }

        #endregion

        #region Methods

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is TransactionModel)
                return this.TransactionTemplate;

            return null;
        }

        #endregion
    }
}
