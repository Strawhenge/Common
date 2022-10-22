using System;
using Strawhenge.Common.Ranges;
using UnityEngine;

namespace Strawhenge.Common.Unity.Serialization
{
    [Serializable]
    public partial class SerializedFloatRange
    {
        [SerializeField] float _min;
        [SerializeField] float _max;

        public FloatRange Value => new FloatRange(_min, _max);
    }
}