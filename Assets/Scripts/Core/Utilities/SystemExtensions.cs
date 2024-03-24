// file SystemExtensions.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using System;
using System.Collections.Generic;

#endregion

namespace twinkocat.Core.Utilities
{
    public static class CollectionExtensions
    {
        public static bool IsNull<T>(this ICollection<T> iCollection)
        {
            return iCollection is null;
        }

        public static bool IsEmpty<T>(this ICollection<T> iCollection)
        {
            return iCollection.Count == 0;
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> iCollection)
        {
            return iCollection.IsNull() || iCollection.IsEmpty();
        }

        public static bool TryFind<T>(this List<T> list, Predicate<T> match, out T item)
        {
            item = default;

            if (list.IsNullOrEmpty()) return false;

            item = list.Find(match);
            return item != null;
        }
    }

    public static class ActionExtensions
    {
        public static void SafeInvoke(this Action action)
        {
            action?.Invoke();
        }

        public static void SafeInvoke<T>(this Action<T> action, T obj0)
        {
            action?.Invoke(obj0);
        }

        public static void SafeInvoke<T0, T1>(this Action<T0, T1> action, T0 obj0, T1 obj1)
        {
            action?.Invoke(obj0, obj1);
        }

        public static void SafeInvoke<T0, T1, T2>(this Action<T0, T1, T2> action, T0 obj0, T1 obj1, T2 obj2)
        {
            action?.Invoke(obj0, obj1, obj2);
        }
    }
}