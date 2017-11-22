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
    class SummaryViewModel : ViewModel
    {
        #region Constructor

        public SummaryViewModel()
        {
            this.Transactions = ((App)App.Current).Transactions;
            this.ComboBoxItems.Add("7 Days");
            this.ComboBoxItems.Add("14 Days");
            this.ComboBoxItems.Add("30 Days");
            this.ComboBoxItems.Add("60 Days");
            this.ComboBoxItems.Add("90 Days");
            this.ComboBoxItems.Add("6 Months");
            this.ComboBoxItems.Add("1 Year");
            this.ComboBoxItems.Add("2 Years");
            this.ComboBoxItems.Add("5 Years");
            this.ComboBoxItems.Add("Lifetime");
            this.durationString = "30 Days";
        }

        #endregion

        #region Fields

        private ObservableCollection<TransactionModel> transactions;

        private string durationString;

        #endregion

        #region Properties

        public ObservableCollection<TransactionModel> Transactions
        {
            get => this.transactions;
            set => this.Set(ref this.transactions, value);
        }

        public double Income
        {
            get
            {
                IEnumerable<TransactionModel> income = this.Transactions.Where(t => t.TransactionType == TransactionType.Credit);

                if (this.Duration != null)
                    income = income.Where(t => (DateTime.Now - t.Timestamp).TotalDays <= this.Duration.Value);

                return income.Select(t => t.Amount).Sum();
            }
        }

        public double Spendings
        {
            get
            {
                IEnumerable<TransactionModel> spendings = this.Transactions.Where(t => t.TransactionType == TransactionType.Debit);

                if (this.Duration != null)
                    spendings = spendings.Where(t => (DateTime.Now - t.Timestamp).TotalDays <= this.Duration.Value);

                return spendings.Select(t => t.Amount).Sum();
            }
        }

        public double Balance => this.Income - this.Spendings;

        public TransactionType BalanceTransactionType => this.Balance >= 0 ? TransactionType.Credit : TransactionType.Debit;

        public string IncomeString => string.Format("${0} CR", this.Income);

        public string SpendingsString => string.Format("${0} DB", this.Spendings);

        public string BalanceString => string.Format("${0} {1}", this.Balance, this.Balance >= 0 ? "CR" : "DB");

        public string DurationString
        {
            get => this.durationString;
            set
            {
                this.RaisePropertyChanged("IncomeString");
                this.RaisePropertyChanged("SpendingsString");
                this.RaisePropertyChanged("BalanceString");
                this.Set(ref this.durationString, value);
            }
        }

        public int? Duration
        {
            get
            {
                if (this.DurationString == "Lifetime")
                    return null;
                else if (this.DurationString.Contains("Days"))
                    return int.Parse(this.DurationString.Split(' ')[0]);
                else if (this.DurationString.Contains("Months"))
                    return int.Parse(this.DurationString.Split(' ')[0]) * 30;
                else if (this.DurationString.Contains("Year") || this.DurationString.Contains("Years"))
                    return int.Parse(this.DurationString.Split(' ')[0]) * 30;

                throw new NotSupportedException();
            }
        }

        public ObservableCollection<string> ComboBoxItems { get; private set; } = new ObservableCollection<string>();

        #endregion
    }
}
