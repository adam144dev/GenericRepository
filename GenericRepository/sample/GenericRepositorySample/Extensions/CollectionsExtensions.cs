using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace CollectionsExtensions
{
    static class IListExtension
    {
        public static void ForEach<T>(this IList<T> list, Action<T> action)
        {
            foreach (T t in list)
                action(t);
        }
    }
}
