using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.Serialization
{
    [Serializable]
    public class Layer
    {
        [SerializeField] int _value;

        public int Value => _value;
    }
}