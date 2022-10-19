using Strawhenge.Common.Ranges;
using Xunit;

namespace Strawhenge.Common.Tests.RangeTests
{
    public class FloatRange_Tests
    {
        [Theory]
        [InlineData(0, -1)]
        [InlineData(20, 19.9f)]
        [InlineData(100, -100)]
        [InlineData(1.5f, 1.49f)]
        [InlineData(float.MaxValue, float.MinValue)]
        public void IsValidRange_ShouldBeFalse(float min, float max)
        {
            Assert.False(
                FloatRange.IsValidRange(min, max));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0.5f, 0.51f)]
        [InlineData(0, 10)]
        [InlineData(-100, 100)]
        [InlineData(float.MinValue, float.MaxValue)]
        public void IsValidRange_ShouldBeTrue(float min, float max)
        {
            Assert.True(
                FloatRange.IsValidRange(min, max));
        }

        [Theory]
        [InlineData(0, 0, 1)]
        [InlineData(0, 0.5f, -1)]
        [InlineData(0, 1, 1.000001f)]
        [InlineData(0, 10, 11)]
        [InlineData(0, 10, -11)]
        [InlineData(float.MinValue, 0, float.MaxValue)]
        public void IsInRange_ShouldBeFalse(float min, float max, float value)
        {
            var sut = new FloatRange(min, max);

            Assert.False(
                sut.IsInRange(value));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 1, 0.5f)]
        [InlineData(0, 10, 5)]
        [InlineData(0, 10, 0)]
        [InlineData(0, 10, 0.001f)]
        [InlineData(float.MinValue, float.MaxValue, 0)]
        public void IsInRange_ShouldBeTrue(float min, float max, float value)
        {
            var sut = new FloatRange(min, max);

            Assert.True(
                sut.IsInRange(value));
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(0, 0, 10, 0)]
        [InlineData(0, 0, -10, 0)]
        [InlineData(0, 1, 0.5f, 0.5f)]
        [InlineData(-10, 10, -10.5f, -10)]
        public void Clamp_ShouldReturnExpectedValue(float min, float max, float value, float expected)
        {
            var sut = new FloatRange(min, max);

            var result = sut.Clamp(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0.5f, 0.51f)]
        [InlineData(0, 10)]
        [InlineData(-100, 100)]
        [InlineData(float.MinValue, float.MaxValue)]
        public void ImplicitOperator_ShouldInstantiateViaTuple(float min, float max)
        {
            FloatRange sut = (min, max);

            Assert.NotNull(sut);
            Assert.IsType<FloatRange>(sut);
            Assert.Equal(min, sut.Min);
            Assert.Equal(max, sut.Max);
        }
    }
}