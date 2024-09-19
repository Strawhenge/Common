using System;
using System.Collections.Generic;
using System.Linq;
using FunctionalUtilities;

namespace Strawhenge.Common.Collections
{
    public class CycleList<T>
    {
        readonly Func<T, bool> _predicate;
        readonly List<T> _items;
        int _currentIndex;

        public CycleList(Func<T, bool> predicate, params T[] items) : this(predicate, items.AsEnumerable())
        {
        }

        public CycleList(Func<T, bool> predicate, IEnumerable<T> items)
        {
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            _items = items.ToList();
        }

        public int Count => _items.Count;

        public void Add(T item)
        {
            _items.Add(item);
        }

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

                    if (_currentIndex >= _items.Count)
                        _currentIndex = 0;
                }
            }
            while (_currentIndex != startingIndex);

            return Maybe.None<T>();
        }

        public IEnumerable<T> AsEnumerable() => _items.ToArray();
    }
}