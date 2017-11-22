using JFinace.Data;
using JFinace.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFinace.Windows.WPF.ViewModels
{
    class SummaryViewModel : ViewModel
    {
        #region Constructor

        public SummaryViewModel()
        {
            this.Transactions = ((App)App.Current).Transactions;
        }

        #endregion

        #region Fields

        public ObservableCollection<TransactionModel> transactions;

        #endregion

        #region Properties

        public ObservableCollection<TransactionModel> Transactions
        {
            get => this.transactions;
            set => this.Set(ref this.transactions, value);
        }

        #endregion
    }
}
