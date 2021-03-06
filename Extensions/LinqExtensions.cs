﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ToqueToqueApi.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
            => ExceptBy(first, second, keySelector, null);

        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> keyComparer)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return _();

            IEnumerable<TSource> _()
            {
                var keys = new HashSet<TKey>(second.Select(keySelector), keyComparer);
                foreach (var element in first)
                {
                    var key = keySelector(element);
                    if (keys.Contains(key))
                        continue;

                    yield return element;

                    keys.Add(key);
                }
            }
        }
    }
}