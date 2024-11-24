using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.Tests
{
    public partial class SerializedSourceTests
    {
        class TestDataScriptableObject : ScriptableObject, ITestData
        {
            public Guid Id { get; set; }
        }
    }
}