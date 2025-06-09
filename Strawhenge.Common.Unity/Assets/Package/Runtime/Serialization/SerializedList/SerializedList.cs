using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.Serialization
{
    [Serializable]
    public class SerializedList<T> where T : Component
    {
        [SerializeField] T[] _values;
        
        internal static string ValuesPropertyName => nameof(_values);
    }
}