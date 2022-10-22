using System;

namespace Strawhenge.Common.Unity.Tests
{
    public partial class SerializedSource_Tests
    {
        class TestData : ITestData
        {
            public Guid Id;

            Guid ITestData.Id => Id;
        }
    }
}
