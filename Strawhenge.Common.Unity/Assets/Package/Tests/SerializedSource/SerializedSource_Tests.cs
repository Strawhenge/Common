using NUnit.Framework;
using System;
using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Common.Unity.Tests
{
    public partial class SerializedSource_Tests
    {
        readonly TestData serialized;
        readonly TestDataScriptableObject scriptableObject;
        readonly SerializedSource<ITestData, TestData, TestDataScriptableObject> sut;

        public SerializedSource_Tests()
        {
            serialized = new TestData();
            scriptableObject = (TestDataScriptableObject)ScriptableObject.CreateInstance(typeof(TestDataScriptableObject));

            sut = new SerializedSource<ITestData, TestData, TestDataScriptableObject>();
        }

        [SetUp]
        public void Setup()
        {
            serialized.Id = Guid.NewGuid();
            scriptableObject.Id = Guid.NewGuid();
        }

        [TearDown]
        public void TearDown()
        {
            sut.Type = SerializedSourceType.None;
            sut.Serialized = null;
            sut.ScriptableObject = null;
        }

        [Test]
        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public void TryGetValue_WhenSourceTypeIsNone_ShouldReturnFalse(bool setSerialized, bool setScriptableObject)
        {
            sut.Type = SerializedSourceType.None;

            if (setSerialized)
                sut.Serialized = serialized;

            if (setScriptableObject)
                sut.ScriptableObject = scriptableObject;

            var result = sut.TryGetValue(out var value);

            Assert.False(result);
            Assert.Null(value);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void TryGetValue_WhenSourceIsSerialized_ShouldReturnFalse(bool setScriptableObject)
        {
            sut.Type = SerializedSourceType.Serialized;

            if (setScriptableObject)
                sut.ScriptableObject = scriptableObject;

            var result = sut.TryGetValue(out var value);

            Assert.False(result);
            Assert.Null(value);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void TryGetValue_WhenSourceIsSerialized_ShouldReturnTrue(bool setScriptableObject)
        {
            sut.Type = SerializedSourceType.Serialized;
            sut.Serialized = serialized;

            if (setScriptableObject)
                sut.ScriptableObject = scriptableObject;

            var result = sut.TryGetValue(out var value);

            Assert.True(result);
            Assert.AreEqual(serialized.Id, value.Id);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void TryGetValue_WhenSourceIsScriptableObject_ShouldReturnFalse(bool setSerialized)
        {
            sut.Type = SerializedSourceType.ScriptableObject;

            if (setSerialized)
                sut.Serialized = serialized;

            var result = sut.TryGetValue(out var value);

            Assert.False(result);
            Assert.Null(value);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void TryGetValue_WhenSourceIsScriptableObject_ShouldReturnTrue(bool setSerialized)
        {
            sut.Type = SerializedSourceType.ScriptableObject;
            sut.ScriptableObject = scriptableObject;

            if (setSerialized)
                sut.Serialized = serialized;

            var result = sut.TryGetValue(out var value);

            Assert.True(result);
            Assert.AreEqual(scriptableObject.Id, value.Id);
        }
    }
}
