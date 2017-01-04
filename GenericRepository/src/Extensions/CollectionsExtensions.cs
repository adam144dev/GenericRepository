using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class CollectionsExtensions
    {
        public static void ForEach<T>(this IList<T> list, Action<T> action)
        {
            foreach (T t in list)
                action(t);
        }


        public static ICollection<T> AddRange<T>(this ICollection<T> collection, params T[] objects)
        {
            foreach (var o in objects)
                collection.Add(o);

            return collection;
        }

        public static IList<T> AddRange<T>(this IList<T> collection, params T[] objects)
            => (AddRange((ICollection<T>)collection, objects) as IList<T>);

        public static List<T> AddRange<T>(this List<T> collection, params T[] objects)
            => (AddRange((ICollection<T>)collection, objects) as List<T>);


        public static ICollection<T> RemoveRange<T>(this ICollection<T> collection, params T[] objects)
        {
            foreach (var o in objects)
                collection.Remove(o);

            return collection;
        }

        public static IList<T> RemoveRange<T>(this IList<T> collection, params T[] objects)
            => (RemoveRange((ICollection<T>)collection, objects) as IList<T>);

        public static List<T> RemoveRange<T>(this List<T> collection, params T[] objects)
            => (RemoveRange((ICollection<T>)collection, objects) as List<T>);
    }
}
