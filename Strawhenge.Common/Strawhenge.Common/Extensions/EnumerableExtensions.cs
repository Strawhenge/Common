using System;
using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Common
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
                action(item);
        }

        public static IEnumerable<T> ExcludeNull<T>(this IEnumerable<T> enumerable) =>
            enumerable == null
                ? Enumerable.Empty<T>()
                : enumerable.Where(x => x != null);

        public static TResult[] ToArray<TSource, TResult>(
            this IEnumerable<TSource> enumerable,
            Func<TSource, TResult> selector) => enumerable.Select(selector).ToArray();
    }
}