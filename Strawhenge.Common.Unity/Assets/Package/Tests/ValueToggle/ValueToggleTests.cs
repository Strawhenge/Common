using NUnit.Framework;
using Strawhenge.Common.Unity.Serialization;
using System.Collections.Generic;

namespace Strawhenge.Common.Unity.Tests.ValueToggle
{
    public abstract class ValueToggleTests<T> where T : struct
    {
        readonly ValueToggle<T> _sut;

        protected ValueToggleTests()
        {
            _sut = new ValueToggle<T>();
        }

        [Test]
        public void TryGetValue_ShouldReturnFalse()
        {
            var result = _sut.TryGetValue(out var value);

            Assert.False(result);
            Assert.AreEqual(default(T), value);
        }

        [Test]
        public void TryGetValue_ShouldReturnFalse_WhenValueIsSet()
        {
            foreach (var newValue in GetValues())
            {
                _sut.Value = newValue;

                var result = _sut.TryGetValue(out var value);

                Assert.False(result);
                Assert.AreEqual(default(T), value);
            }
        }

        [Test]
        public void TryGetValue_ShouldReturnTrue_WhenValueIsSet_AndToggleIsTrue()
        {
            _sut.Toggle = true;

            foreach (var newValue in GetValues())
            {
                _sut.Value = newValue;

                var result = _sut.TryGetValue(out var value);

                Assert.True(result);
                Assert.AreEqual(newValue, value);
            }
        }

        protected abstract IEnumerable<T> GetValues();
    }
}