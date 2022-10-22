using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.Serialization
{
    [Serializable]
    public partial class ValueToggle<T> where T : struct
    {
        [SerializeField] bool _toggle;
        [SerializeField] T _value;

        public bool TryGetValue(out T value)
        {
            if (_toggle)
            {
                value = _value;
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