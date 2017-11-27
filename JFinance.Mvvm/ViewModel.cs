using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFinance.Mvvm
{
    public abstract class ViewModel : ObservableObject
    {
        #region Events

        public EventHandler<EventArgs> Closing;

        #endregion

        #region Methods

        public virtual void OnClosing(object sender, EventArgs e) => this.Closing?.Invoke(sender, e);

        #endregion
    }
}
