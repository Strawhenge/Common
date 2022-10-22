using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.Tests
{
    public partial class SerializedSource_Tests
    {
        class TestDataScriptableObject : ScriptableObject, ITestData
        {
            public Guid Id;

            Guid ITestData.Id => Id;
        }
    }
}
