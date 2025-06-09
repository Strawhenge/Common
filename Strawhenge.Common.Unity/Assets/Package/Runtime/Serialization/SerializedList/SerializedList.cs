using System;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Common.Unity.Serialization
{
    [Serializable]
    public partial class SerializedList<T> where T : Component
    {
        [SerializeField] T[] _values;

        public IReadOnlyList<T> Values => _values;
    }
}