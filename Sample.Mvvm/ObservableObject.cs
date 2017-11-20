using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Mvvm
{
    public class ObservableObject : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods
        
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName != null)
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            else
                throw new NullReferenceException();
        }

        public void Set<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            property = value;
            this.RaisePropertyChanged(propertyName);
        }

        #endregion
    }
}
