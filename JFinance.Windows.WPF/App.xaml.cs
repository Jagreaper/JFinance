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
            string path = string.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JFinance");
            DirectoryInfo dinfo = new DirectoryInfo(path);
            if (dinfo.Exists)
            {
                FileInfo file = new FileInfo(string.Format("{0}\\{1}", path, "Transactions.json"));
                if (file.Exists)
                {
                    string json = File.ReadAllText(file.FullName);
                    List<TransactionModel> transactions = JsonConvert.DeserializeObject<List<TransactionModel>>(json);
                    this.Transactions.AddRange(transactions);
                }
            }

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            string json = JsonConvert.SerializeObject(this.Transactions, Formatting.Indented);
            string path = string.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JFinance");

            DirectoryInfo dinfo = new DirectoryInfo(path);
            if (!dinfo.Exists)
                dinfo.Create();

            File.WriteAllText(string.Format("{0}\\{1}", path, "Transactions.json"), json);

            base.OnExit(e);
        }
    }
}
