using System;
using UnityEngine;

namespace Strawhenge.Common.Unity.Tests
{
    public partial class SerializedSourceTests
    {
        class TestDataScriptableObject : ScriptableObject, ITestData
        {
            [SerializeField] Guid _id;

            public Guid Id
            {
                get => _id;
                set => _id = value;
            }
        }
    }
}