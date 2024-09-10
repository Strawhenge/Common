using System;
using System.Collections.Generic;

namespace Strawhenge.Common
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrAddValue<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> factoryMethod)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (factoryMethod == null) throw new ArgumentNullException(nameof(factoryMethod));

            if (!dictionary.TryGetValue(key, out var value))
            {
                value = factoryMethod();
                dictionary.Add(key, value);
            }

            return value;
        }
    }
}