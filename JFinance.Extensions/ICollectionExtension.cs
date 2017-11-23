using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class ICollectionExtension
    {
        public static void AddRange<T>(this ICollection<T> host, IEnumerable<T> items)
        {
            foreach (T item in items)
                host.Add(item);
        }
    }
}
