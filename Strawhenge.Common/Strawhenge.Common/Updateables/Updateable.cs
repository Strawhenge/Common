using System;

namespace Strawhenge.Common.Updateables
{
    public abstract class Updateable<T>
    {
        protected Updateable(T value)
        {
            Current = value;
        }

        public event Action<T> Changed;

        public T Current { get; private set; }

        protected void Update(T value)
        {
            if (AreEqual(Current, value))
                return;

            Current = value;
            Changed?.Invoke(value);
        }

        protected virtual bool AreEqual(T first, T second) => first.Equals(second);
    }
}