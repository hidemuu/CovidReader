using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Infrastructure.Wpf.Helpers
{
    public static class CollectionHelper
    {
        public static void AddRange<T>(this ICollection<T> addTo, IEnumerable<T> source)
        {
            foreach(var item in source)
            {
                addTo.Add(item);
            }
        }
    }
}
