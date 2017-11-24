using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace JFinance.Windows.WPF.Selectors
{
    public interface IColorSelector
    {
        Brush SelectBrush(object item, int index);
    }
}
