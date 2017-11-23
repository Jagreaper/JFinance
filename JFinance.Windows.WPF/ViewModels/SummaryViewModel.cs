using JFinance.Models;
using JFinance.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

            this.TransactionComboBoxItems.Add(TransactionType.Credit);
            this.TransactionComboBoxItems.Add(TransactionType.Debit);

            this.AddCommand = new RelayCommand(this.AddTransaction);
        }

        #endregion

        #region Fields

        private ObservableCollection<TransactionModel> transactions;

        private string durationString = "";

        public string addAmountString = "0";

        public string addCategory = "";

        public string addTags = "";

        public string addDescription = "";

        public DateTime addSelectedDate = DateTime.Now;

        public TransactionType addTransactionTime = TransactionType.Credit;

        #endregion

        #region Properties

        public ICommand AddCommand { get; private set; }

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

                return ((double)((int)(income.Select(t => t.Amount).Sum() * 100))) / 100;
            }
        }

        public double Spendings
        {
            get
            {
                IEnumerable<TransactionModel> spendings = this.Transactions.Where(t => t.TransactionType == TransactionType.Debit);

                if (this.Duration != null)
                    spendings = spendings.Where(t => (DateTime.Now - t.Timestamp).TotalDays <= this.Duration.Value);

                return ((double)((int)(spendings.Select(t => t.Amount).Sum() * 100))) / 100;
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
                this.Set(ref this.durationString, value);
                this.RaisePropertyChanged("IncomeString");
                this.RaisePropertyChanged("SpendingsString");
                this.RaisePropertyChanged("BalanceString");
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

        public ObservableCollection<TransactionType> TransactionComboBoxItems { get; private set; } = new ObservableCollection<TransactionType>();

        public double AddAmount
        {
            get
            {
                if (!double.TryParse(this.AddAmountString, out double result))
                    return -1;

                return result;
            }
        }

        public string AddAmountString
        {
            get => this.addAmountString;
            set
            {
                this.Set(ref this.addAmountString, value);
                this.RaisePropertyChanged("AddAmount");
            }
        }

        public string AddCategory
        {
            get => this.addCategory;
            set => this.Set(ref this.addCategory, value);
        }

        public string AddTags
        {
            get => this.addTags;
            set => this.Set(ref this.addTags, value);
        }

        public string AddDescription
        {
            get => this.addDescription;
            set => this.Set(ref this.addDescription, value);
        }

        public DateTime AddSelectedDate
        {
            get => this.addSelectedDate;
            set => this.Set(ref this.addSelectedDate, value);
        }

        public TransactionType AddTransactionType
        {
            get => this.addTransactionTime;
            set => this.Set(ref this.addTransactionTime, value);
        }

        #endregion

        #region Methods

        public void AddTransaction()
        {
            ObservableCollection<string> tags = new ObservableCollection<string>();
            string[] sTags = this.AddTags.Split('#');
            tags.AddRange(sTags);

            this.Transactions.Add(new TransactionModel()
            {
                Amount = this.AddAmount,
                Category = this.AddCategory,
                Description = this.AddDescription,
                Timestamp = this.AddSelectedDate,
                TransactionType = this.AddTransactionType,
                Tags = tags,
            });

            this.AddAmountString = "";
            this.AddCategory = "";
            this.AddDescription = "";
            this.AddSelectedDate = DateTime.Now;
            this.AddTransactionType = TransactionType.Credit;
            this.AddTags = "";

            this.RaisePropertyChanged("IncomeString");
            this.RaisePropertyChanged("SpendingsString");
            this.RaisePropertyChanged("BalanceString");
        }

        #endregion
    }
}
