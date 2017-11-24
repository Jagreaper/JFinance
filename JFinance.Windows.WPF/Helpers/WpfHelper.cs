using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace JFinance.Windows.WPF.Helpers
{

    static class WpfHelper
    {
        public static void FindUpInTree(List<FrameworkElement> lst, Visual parent, Visual ignore, IFinderMatchVisualHelper helper)
        {
            if (helper.DoesMatch(parent))
                lst.Add((FrameworkElement)parent);
            
            if (!(lst.Count > 0 && helper.FindFirst) && parent is FrameworkElement element)
            {
                FrameworkElement nParent = (FrameworkElement)element.Parent;
                if (nParent == null || nParent == element)
                    nParent = (FrameworkElement)element.TemplatedParent;

                if (nParent != null && nParent != element)
                    WpfHelper.FindUpInTree(lst, nParent, element, helper);
            }
        }

        public static List<FrameworkElement> FindInTree(Visual parent, IFinderMatchVisualHelper helper)
        {
            List<FrameworkElement> list = new List<FrameworkElement>();
            WpfHelper.FindUpInTree(list, parent, null, helper);
            return list;
        }


        public static FrameworkElement SingleFindInTree(Visual parent, IFinderMatchVisualHelper helper)
        {
            helper.FindFirst = true;
            List<FrameworkElement> list = WpfHelper.FindInTree(parent, helper);

            if (list.Count > 0)
                return list[0];

            return null;
        }

        public static FrameworkElement FindElementOfTypeUp(Visual parent, Type ty) => WpfHelper.SingleFindInTree(parent, new FinderMatchType(ty));
    }
}
