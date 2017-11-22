﻿using JFinance.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace JFinance.Windows.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ObservableCollection<TransactionModel> Transactions { get; private set; } = new ObservableCollection<TransactionModel>();

        protected override void OnStartup(StartupEventArgs e)
        {
            Transactions.Add(new TransactionModel()
            {
                Amount = 50.34,
                TransactionType = TransactionType.Credit,
            });

            Transactions.Add(new TransactionModel()
            {
                Amount = 26.79,
                TransactionType = TransactionType.Debit,
            });
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
