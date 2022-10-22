using System;

namespace Strawhenge.Common.Unity.Serialization
{
    [Serializable]
    public class ValueToggle<T> where T : struct
    {
        public bool Toggle;
        public T Value;

        public bool TryGetValue(out T value)
        {
            if (Toggle)
            {
                value = Value;
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }
    }
}