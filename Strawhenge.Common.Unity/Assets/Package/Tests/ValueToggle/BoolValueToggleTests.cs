using System.Collections.Generic;

namespace Strawhenge.Common.Unity.Tests.ValueToggle
{
    public class BoolValueToggleTests : ValueToggleTests<bool>
    {
        protected override IEnumerable<bool> GetValues()
        {
            yield return true;
            yield return false;
        }
    }
}
