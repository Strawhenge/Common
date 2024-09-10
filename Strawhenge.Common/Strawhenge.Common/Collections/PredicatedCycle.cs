using System;
using System.Collections.Generic;
using System.Linq;
using FunctionalUtilities;

namespace Strawhenge.Common.Collections
{
    public class PredicatedCycle<T>
    {
        readonly Func<T, bool> _predicate;
        readonly T[] _items;
        int _currentIndex;

        public PredicatedCycle(Func<T, bool> predicate, params T[] items) : this(predicate, items.AsEnumerable())
        {
        }

        public PredicatedCycle(Func<T, bool> predicate, IEnumerable<T> items)
        {
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            _items = items.ToArray();

            if (_items.Length == 0)
                throw new ArgumentException($"'{nameof(items)}' cannot be empty.", nameof(items));
        }

        public int Count => _items.Length;

        public Maybe<T> Next()
        {
            var startingIndex = _currentIndex;

            do
            {
                try
                {
                    if (_predicate(_items[_currentIndex]))
                        return _items[_currentIndex];
                }
                finally
                {
                    _currentIndex++;

                    if (_currentIndex >= _items.Length)
                        _currentIndex = 0;
                }
            }
            while (_currentIndex != startingIndex);

            return Maybe.None<T>();
        }

        public IEnumerable<T> AsEnumerable() => _items.ToArray();
    }
}