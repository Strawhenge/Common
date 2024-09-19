using System;
using System.Collections.Generic;
using System.Linq;
using FunctionalUtilities;

namespace Strawhenge.Common.Collections
{
    public class CycleList<T>
    {
        readonly List<T> _items;
        readonly Func<T, bool> _predicate;
        int _currentIndex;

        public CycleList(int? capacity = null, Func<T, bool> predicate = null)
        {
            _items = capacity.HasValue
                ? new List<T>(capacity.Value)
                : new List<T>();
            _predicate = predicate ?? (_ => true);
        }

        public CycleList(IEnumerable<T> items, Func<T, bool> predicate = null)
        {
            _items = items == null
                ? new List<T>()
                : items.ToList();
            _predicate = predicate ?? (_ => true);
        }

        public int Count => _items.Count;

        public void Add(T item) => _items.Add(item);

        public void Add(IEnumerable<T> items) => _items.AddRange(items);

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

        public IEnumerable<T> ToArray() => _items.ToArray();
    }
}