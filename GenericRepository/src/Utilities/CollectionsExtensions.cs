using System;
using System.Collections.Generic;

namespace Utilities
{
    public static class CollectionsExtensions
    {
        // works as well for:   T[] sequence
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (T t in sequence)
                action(t);
        }


        public static ICollection<T> AddRange<T>(this ICollection<T> collection, IEnumerable<T> objects)
        {
            foreach (var o in objects)
                collection.Add(o);

            return collection;
        }
        public static ICollection<T> AddRange<T>(this ICollection<T> collection, params T[] objects)
            => AddRange(collection, (IEnumerable<T>)objects);

        // For Array (IList) always throws a NotSupportedException exception. 
        public static IList<T> AddRange<T>(this IList<T> collection, IEnumerable<T> objects)
            => (AddRange((ICollection<T>)collection, objects) as IList<T>);
        // For Array (IList) always throws a NotSupportedException exception. 
        public static IList<T> AddRange<T>(this IList<T> collection, params T[] objects)
            => (AddRange((ICollection<T>)collection, objects) as IList<T>);

        public static List<T> AddRange<T>(this List<T> collection, IEnumerable<T> objects)
            => (AddRange((ICollection<T>)collection, objects) as List<T>);
        public static List<T> AddRange<T>(this List<T> collection, params T[] objects)
            => (AddRange((ICollection<T>)collection, objects) as List<T>);


        public static ICollection<T> RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> objects)
        {
            foreach (var o in objects)
                collection.Remove(o);

            return collection;
        }
        public static ICollection<T> RemoveRange<T>(this ICollection<T> collection, params T[] objects)
            => RemoveRange(collection, (IEnumerable<T>)objects);

        // For Array (IList) always throws a NotSupportedException exception. 
        public static IList<T> RemoveRange<T>(this IList<T> collection, IEnumerable<T> objects)
            => (RemoveRange((ICollection<T>)collection, objects) as IList<T>);
        // For Array (IList) always throws a NotSupportedException exception. 
        public static IList<T> RemoveRange<T>(this IList<T> collection, params T[] objects)
            => (RemoveRange((ICollection<T>)collection, objects) as IList<T>);

        public static List<T> RemoveRange<T>(this List<T> collection, IEnumerable<T> objects)
            => (RemoveRange((ICollection<T>)collection, objects) as List<T>);
        public static List<T> RemoveRange<T>(this List<T> collection, params T[] objects)
            => (RemoveRange((ICollection<T>)collection, objects) as List<T>);
    }
}
