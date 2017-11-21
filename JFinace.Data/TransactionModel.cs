using JFinace.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace JFinace.Data
{
    public enum TransactionType
    {
        Credit,
        Debit,
    }

    public class TransactionModel : ObservableObject
    {
        #region Fields

        private ObservableCollection<string> tags;

        private string category;

        public TransactionType transactionType;

        public double amount;

        public DateTime timestamp;

        public string description;

        #endregion

        #region Properties

        public ObservableCollection<string> Tags
        {
            get => this.tags;
            set => this.Set(ref this.tags, value);
        }

        public string Category
        {
            get => this.category;
            set => this.Set(ref this.category, value);
        }

        public TransactionType TransactionType
        {
            get => this.transactionType;
            set => this.Set(ref this.transactionType, value);
        }

        public double Amount
        {
            get => this.amount;
            set => this.Set(ref this.amount, value);
        }

        public DateTime Timestamp
        {
            get => this.timestamp;
            set => this.Set(ref this.timestamp, value);
        }

        public string Description
        {
            get => this.description;
            set => this.Set(ref this.description, value);
        }

        #endregion
    }
}
