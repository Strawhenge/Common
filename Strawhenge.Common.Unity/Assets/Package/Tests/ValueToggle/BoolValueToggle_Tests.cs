using System.Collections.Generic;

namespace Strawhenge.Common.Unity.Tests.ValueToggle
{
    public class BoolValueToggle_Tests : ValueToggle_Tests<bool>
    {
        protected override IEnumerable<bool> GetValues()
        {
            yield return true;
            yield return false;
        }
    }
}
