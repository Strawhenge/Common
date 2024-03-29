﻿using System.Collections.Generic;

namespace Strawhenge.Common.Unity.Tests.ValueToggle
{
    public class FloatValueToggleTests : ValueToggleTests<float>
    {
        protected override IEnumerable<float> GetValues()
        {
            yield return float.MaxValue;
            yield return float.MinValue;
            yield return 0;
            yield return 3.14f;
            yield return -10;
        }
    }
}
