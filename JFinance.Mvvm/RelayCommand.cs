using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JFinance.Mvvm
{
    public class RelayCommand : ICommand
    {
        #region Constructor

        public RelayCommand(Action action)
        {
            this.Action = action;
            this.CanExecuteChanged?.Invoke(this, null);
        }

        public RelayCommand(Action action, Func<bool> canExecute)
            : this(action)
        {
            this.CanExecuteFunc = canExecute;
            this.CanExecuteChanged?.Invoke(this, null);
        }

        #endregion

        #region Properties

        private Action Action { get; set; }

        private Func<bool> CanExecuteFunc { get; set; }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            return this.Action != null && (this.CanExecuteFunc == null || this.CanExecuteFunc.Invoke());
        }

        public void Execute(object parameter)
        {
            if (this.CanExecute(parameter))
                this.Action.Invoke();
        }

        #endregion
    }

    public class RelayCommand<T> : ICommand
    {
        #region Constructor

        public RelayCommand(Action<T> action)
        {
            this.Action = action;
            this.CanExecuteChanged?.Invoke(this, null);
        }

        public RelayCommand(Action<T> action, Func<T, bool> canExecute)
            : this(action)
        {
            this.CanExecuteFunc = canExecute;
            this.CanExecuteChanged?.Invoke(this, null);
        }

        #endregion

        #region Properties

        private Action<T> Action { get; set; }

        private Func<T, bool> CanExecuteFunc { get; set; }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            return this.Action != null && (this.CanExecuteFunc == null || this.CanExecuteFunc.Invoke((T) parameter));
        }

        public void Execute(object parameter)
        {
            if (this.CanExecute(parameter))
                this.Action.Invoke((T) parameter);
        }

        #endregion
    }
}
