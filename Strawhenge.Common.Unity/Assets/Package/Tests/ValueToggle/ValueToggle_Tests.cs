using NUnit.Framework;
using Strawhenge.Common.Unity.Serialization;
using System.Collections.Generic;

namespace Strawhenge.Common.Unity.Tests.ValueToggle
{
    public abstract class ValueToggle_Tests<T> where T : struct
    {
        readonly ValueToggle<T> sut;

        public ValueToggle_Tests()
        {
            sut = new ValueToggle<T>();
        }

        [Test]
        public void TryGetValue_ShouldReturnFalse()
        {
            var result = sut.TryGetValue(out var value);

            Assert.False(result);
            Assert.AreEqual(default(T), value);
        }

        [Test]
        public void TryGetValue_ShouldReturnFalse_WhenValueIsSet()
        {
            foreach (var newValue in GetValues())
            {
                sut.Value = newValue;

                var result = sut.TryGetValue(out var value);

                Assert.False(result);
                Assert.AreEqual(default(T), value);
            }
        }

        [Test]
        public void TryGetValue_ShouldReturnTrue_WhenValueIsSet_AndToggleIsTrue()
        {
            sut.Toggle = true;

            foreach (var newValue in GetValues())
            {
                sut.Value = newValue;

                var result = sut.TryGetValue(out var value);

                Assert.True(result);
                Assert.AreEqual(newValue, value);
            }
        }

        protected abstract IEnumerable<T> GetValues();
    }
}