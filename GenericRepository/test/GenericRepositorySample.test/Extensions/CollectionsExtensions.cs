using System.Collections.Generic;

namespace GenericRepositorySample.test.Extensions
{
    public static class CollectionsExtensions
    {
        public static ICollection<T> AddRange<T>(this ICollection<T> collection, IEnumerable<T> objects)
        {
            foreach (var o in objects)
                collection.Add(o);

            return collection;
        }

        public static IList<T> AddRange<T>(this IList<T> collection, IEnumerable<T> objects)
            => AddRange<T>((ICollection<T>)collection, objects) as IList<T>;


        public static ICollection<T> RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> objects)
        {
            foreach (var o in objects)
                collection.Remove(o);

            return collection;
        }

        public static IList<T> RemoveRange<T>(this IList<T> collection, IEnumerable<T> objects)
            => RemoveRange<T>((ICollection<T>)collection, objects) as IList<T>;
    }
}
