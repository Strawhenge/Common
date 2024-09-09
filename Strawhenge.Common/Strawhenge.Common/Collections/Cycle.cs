using System;
using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Common.Collections
{
    public class Cycle<T>
    {
        readonly T[] _all;

        int _currentIndex;

        public Cycle(T initial, params T[] others) : this(initial, (IEnumerable<T>)others)
        {
        }

        public Cycle(T initial, IEnumerable<T> others)
        {
            if (initial == null)
                throw new ArgumentNullException(nameof(initial));
            if (others == null)
                throw new ArgumentNullException(nameof(others));

            _all = others
                .Prepend(initial)
                .ToArray();
        }

        public Cycle(IEnumerable<T> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            _all = items.ToArray();
            if (_all.Length == 0)
                throw new ArgumentException("Collection must not be empty.", nameof(items));
        }

        public int Count => _all.Length;

        public T Current => _all[_currentIndex];

        public T Next()
        {
            _currentIndex++;

            if (_currentIndex >= _all.Length)
                _currentIndex = 0;

            return Current;
        }

        public T Previous()
        {
            _currentIndex--;

            if (_currentIndex < 0)
                _currentIndex = _all.Length - 1;

            return Current;
        }

        public IEnumerable<T> AsEnumerable() => _all;
    }
}