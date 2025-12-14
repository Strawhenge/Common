using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.Serialization
{
    [Serializable]
    public class NavMeshAreaMask
    {
        internal static string ValueFieldName => nameof(_value);

        [SerializeField] int _value;

        public int Value => _value;
    }
}