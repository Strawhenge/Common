using System;

namespace Strawhenge.Common.Ranges
{
    public abstract class Range<T> where T : IComparable<T>
    {
        public static bool IsValidRange(T min, T max) => max.CompareTo(min) >= 0;

        protected Range(T min, T max)
        {
            if (!IsValidRange(min, max))
                throw new ArgumentException($"'{nameof(max)}' cannot be smaller than '{nameof(min)}'", nameof(max));

            Min = min;
            Max = max;
        }

        public T Max { get; }

        public T Min { get; }

        public bool IsInRange(T value) =>
            value.CompareTo(Min) >= 0 &&
            value.CompareTo(Max) <= 0;

        public T Clamp(T value)
        {
            if (value.CompareTo(Min) < 0)
                return Min;

            if (value.CompareTo(Max) > 0)
                return Max;

            return value;
        }
    }
}