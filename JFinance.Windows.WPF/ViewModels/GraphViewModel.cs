using JFinance.Models;
using JFinance.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFinance.Windows.WPF.ViewModels
{

    class GraphViewModel : ViewModel
    {
        #region Types

        public class PieElement : ObservableObject
        {
            #region Constructor

            public PieElement(string @class, double amount)
            {
                this.Class = @class;
                this.Amount = amount;
            }

            #endregion

            #region Fields

            public string @class;

            public double amount;

            #endregion

            #region Properties

            public string Class
            {
                get => this.@class;
                set => this.Set(ref this.@class, value);
            }

            public double Amount
            {
                get => this.amount;
                set => this.Set(ref this.amount, value);
            }

            #endregion
        }

        #endregion

        #region Constructor

        public GraphViewModel()
        {
            this.Transactions = ((App)App.Current).Transactions;
            this.CategorizedTransactions = new ObservableCollection<PieElement>();

            IEnumerable<string> categories = this.Transactions.Select(t => t.Category).Distinct();
            foreach (string category in categories)
                this.CategorizedTransactions.Add(new PieElement(category, this.Transactions.Where(t => t.Category == category).Select(t => t.Amount).Sum()));
        }

        #endregion

        #region Fields

        private ObservableCollection<TransactionModel> transactions;

        private ObservableCollection<PieElement> categorizedTransactions;

        #endregion

        #region Properties
        
        public ObservableCollection<TransactionModel> Transactions
        {
            get => this.transactions;
            set => this.Set(ref this.transactions, value);
        }

        public ObservableCollection<PieElement> CategorizedTransactions
        {
            get => this.categorizedTransactions;
            set => this.Set(ref this.categorizedTransactions, value);
        }

        #endregion
    }
}
