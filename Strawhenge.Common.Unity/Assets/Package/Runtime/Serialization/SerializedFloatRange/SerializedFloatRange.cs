using System;
using Strawhenge.Common.Ranges;
using UnityEngine;

namespace Strawhenge.Common.Unity.Serialization
{
    [Serializable]
    public class SerializedFloatRange
    {
        public static explicit operator FloatRange(SerializedFloatRange range) =>
            new FloatRange(range.min, range.max);

        public static string Max => nameof(max);

        public static string Min => nameof(min);

        [SerializeField] float min;
        [SerializeField] float max;
    }
}