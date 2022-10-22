using System;

namespace Strawhenge.Common.Unity.Tests
{
    public partial class SerializedSourceTests
    {
        class TestData : ITestData
        {
            public Guid Id;

            Guid ITestData.Id => Id;
        }
    }
}
