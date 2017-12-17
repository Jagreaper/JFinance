using Jagerts.Arie.Standard.Controls;
using JFinance.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace JFinance.Windows.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Jagerts.Arie.Windows.Classic.Controls.Application
    {
        #region Fields
        
        private ColorScheme currentColorScheme;

        #endregion

        #region Properties

        public ObservableCollection<TransactionModel> Transactions { get; private set; } = new ObservableCollection<TransactionModel>();

        public string WorkingPath { get; private set; } = string.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JFinance");

        public DirectoryInfo WorkingDirectory => new DirectoryInfo(this.WorkingPath);

        public ColorScheme CurrentColorScheme
        {
            get => this.currentColorScheme;
            set
            {
                this.currentColorScheme = value;
                this.currentColorScheme.Apply();
            }
        }

        #endregion

        #region Methods

        private void ReadTransactions()
        {
            FileInfo file = new FileInfo(string.Format("{0}\\{1}", this.WorkingPath, "Transactions.json"));
            if (file.Exists)
            {
                string json = File.ReadAllText(file.FullName);
                List<TransactionModel> transactions = JsonConvert.DeserializeObject<List<TransactionModel>>(json);
                this.Transactions.AddRange(transactions);
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            if (this.WorkingDirectory.Exists)
                this.ReadTransactions();

            this.currentColorScheme = ColorSchemes.Default;

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            string json = JsonConvert.SerializeObject(this.Transactions, Formatting.Indented);
            
            if (!this.WorkingDirectory.Exists)
                this.WorkingDirectory.Create();

            File.WriteAllText(string.Format("{0}\\{1}", this.WorkingPath, "Transactions.json"), json);

            base.OnExit(e);
        }

        #endregion
    }
}
