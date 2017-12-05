using Jagerts.Arie.Standard.Mvvm;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace JFinance.Models
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

        [JsonIgnore]
        public double amount;

        [JsonIgnore]
        private string category = "None";

        [JsonIgnore]
        public string description = "None";

        [JsonIgnore]
        private ObservableCollection<string> tags = new ObservableCollection<string>();

        [JsonIgnore]
        public DateTime timestamp = DateTime.Now;

        [JsonIgnore]
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
