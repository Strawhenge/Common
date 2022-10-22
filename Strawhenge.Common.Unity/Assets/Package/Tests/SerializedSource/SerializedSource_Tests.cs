using NUnit.Framework;
using System;
using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Common.Unity.Tests
{
    public partial class SerializedSourceTests
    {
        readonly TestData _serialized;
        readonly TestDataScriptableObject _scriptableObject;
        readonly SerializedSource<ITestData, TestData, TestDataScriptableObject> _sut;

        public SerializedSourceTests()
        {
            _serialized = new TestData();
            _scriptableObject = (TestDataScriptableObject)ScriptableObject.CreateInstance(typeof(TestDataScriptableObject));

            _sut = new SerializedSource<ITestData, TestData, TestDataScriptableObject>();
        }

        [SetUp]
        public void Setup()
        {
            _serialized.Id = Guid.NewGuid();
            _scriptableObject.Id = Guid.NewGuid();
        }

        [TearDown]
        public void TearDown()
        {
            _sut.Type = SerializedSourceType.None;
            _sut.Serialized = null;
            _sut.ScriptableObject = null;
        }

        [Test]
        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public void TryGetValue_WhenSourceTypeIsNone_ShouldReturnFalse(bool setSerialized, bool setScriptableObject)
        {
            _sut.Type = SerializedSourceType.None;

            if (setSerialized)
                _sut.Serialized = _serialized;

            if (setScriptableObject)
                _sut.ScriptableObject = _scriptableObject;

            var result = _sut.TryGetValue(out var value);

            Assert.False(result);
            Assert.Null(value);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void TryGetValue_WhenSourceIsSerialized_ShouldReturnFalse(bool setScriptableObject)
        {
            _sut.Type = SerializedSourceType.Serialized;

            if (setScriptableObject)
                _sut.ScriptableObject = _scriptableObject;

            var result = _sut.TryGetValue(out var value);

            Assert.False(result);
            Assert.Null(value);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void TryGetValue_WhenSourceIsSerialized_ShouldReturnTrue(bool setScriptableObject)
        {
            _sut.Type = SerializedSourceType.Serialized;
            _sut.Serialized = _serialized;

            if (setScriptableObject)
                _sut.ScriptableObject = _scriptableObject;

            var result = _sut.TryGetValue(out var value);

            Assert.True(result);
            Assert.AreEqual(_serialized.Id, value.Id);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void TryGetValue_WhenSourceIsScriptableObject_ShouldReturnFalse(bool setSerialized)
        {
            _sut.Type = SerializedSourceType.ScriptableObject;

            if (setSerialized)
                _sut.Serialized = _serialized;

            var result = _sut.TryGetValue(out var value);

            Assert.False(result);
            Assert.Null(value);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void TryGetValue_WhenSourceIsScriptableObject_ShouldReturnTrue(bool setSerialized)
        {
            _sut.Type = SerializedSourceType.ScriptableObject;
            _sut.ScriptableObject = _scriptableObject;

            if (setSerialized)
                _sut.Serialized = _serialized;

            var result = _sut.TryGetValue(out var value);

            Assert.True(result);
            Assert.AreEqual(_scriptableObject.Id, value.Id);
        }
    }
}
