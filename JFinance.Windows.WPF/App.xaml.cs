using JFinance.Models;
using JFinance.Windows.WPF.Styles;
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
    public partial class App : Application
    {
        #region Fields

        public Theme currentTheme;

        #endregion

        #region Properties

        public ObservableCollection<TransactionModel> Transactions { get; private set; } = new ObservableCollection<TransactionModel>();

        public string WorkingPath { get; private set; } = string.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "JFinance");

        public DirectoryInfo WorkingDirectory => new DirectoryInfo(this.WorkingPath);

        public Theme CurrentTheme
        {
            get => this.currentTheme;
            set
            {
                this.currentTheme = value;
                this.UpdateTheme(this.currentTheme);
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

            this.CurrentTheme = Themes.ClassicTheme;

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


        private void UpdateTheme(Theme theme)
        {
            this.Resources["AccentMainBrush"] = theme.AccentMainBrush;
            this.Resources["AccentDarkBrush"] = theme.AccentDarkBrush;
            this.Resources["SelectedBrush"] = theme.SelectedBrush;
            this.Resources["ValidationBrush"] = theme.ValidationBrush;
            this.Resources["AccentBrush"] = theme.AccentBrush;
            this.Resources["MarkerBrush"] = theme.MarkerBrush;
            this.Resources["StrongBrush"] = theme.StrongBrush;
            this.Resources["MainBrush"] = theme.MainBrush;
            this.Resources["PrimaryBrush"] = theme.PrimaryBrush;
            this.Resources["AlternativeBrush"] = theme.AlternativeBrush;
            this.Resources["MouseOverBrush"] = theme.MouseOverBrush;
            this.Resources["BasicBrush"] = theme.BasicBrush;
            this.Resources["SemiBasicBrush"] = theme.SemiBasicBrush;
            this.Resources["HeaderBrush"] = theme.HeaderBrush;
            this.Resources["ComplementaryBrush"] = theme.ComplementaryBrush;
            this.Resources["BackgroundBrush"] = theme.BackgroundBrush;
        }

        #endregion
    }
}
