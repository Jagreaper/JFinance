using JFinace.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace JFinace.Data
{
    public enum TransactionType
    {
        None,
        Credit,
        Debit,
    }

    public class TransactionModel : ObservableObject
    {
        #region Fields

        public double amount;

        private string category = "None";

        public string description = "None";

        private ObservableCollection<string> tags = new ObservableCollection<string>();

        public DateTime timestamp = DateTime.Now;

        public TransactionType transactionType = TransactionType.None;

        #endregion

        #region Properties

        public double Amount
        {
            get => this.amount;
            set => this.Set(ref this.amount, value);
        }

        public string Category
        {
            get => this.category;
            set => this.Set(ref this.category, value);
        }

        public string Description
        {
            get => this.description;
            set => this.Set(ref this.description, value);
        }

        public ObservableCollection<string> Tags
        {
            get => this.tags;
            set => this.Set(ref this.tags, value);
        }

        public DateTime Timestamp
        {
            get => this.timestamp;
            set => this.Set(ref this.timestamp, value);
        }

        public TransactionType TransactionType
        {
            get => this.transactionType;
            set => this.Set(ref this.transactionType, value);
        }

        #endregion
    }
}
