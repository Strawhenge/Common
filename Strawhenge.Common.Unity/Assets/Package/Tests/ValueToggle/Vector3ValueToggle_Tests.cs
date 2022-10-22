using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Common.Unity.Tests.ValueToggle
{
    public class Vector3ValueToggle_Tests : ValueToggle_Tests<Vector3>
    {
        protected override IEnumerable<Vector3> GetValues()
        {
            yield return Vector3.zero;
            yield return Vector3.one;
            yield return Vector3.back;
            yield return Vector3.positiveInfinity;
            yield return Vector3.negativeInfinity;
            yield return new Vector3(100, 123, -61);
        }
    }
}
