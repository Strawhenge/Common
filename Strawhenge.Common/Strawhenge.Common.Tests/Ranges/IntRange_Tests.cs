using Strawhenge.Common.Ranges;
using Xunit;

namespace Strawhenge.Common.Tests.RangeTests
{
    public class IntRange_Tests
    {
        [Theory]
        [InlineData(0, -1)]
        [InlineData(20, 19)]
        [InlineData(100, -100)]
        [InlineData(int.MaxValue, int.MinValue)]
        public void IsValidRange_ShouldBeFalse(int min, int max)
        {
            Assert.False(
                IntRange.IsValidRange(min, max));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 10)]
        [InlineData(-100, 100)]
        [InlineData(int.MinValue, int.MaxValue)]
        public void IsValidRange_ShouldBeTrue(int min, int max)
        {
            Assert.True(
                IntRange.IsValidRange(min, max));
        }

        [Theory]
        [InlineData(0, 0, 1)]
        [InlineData(0, 0, -1)]
        [InlineData(0, 10, 11)]
        [InlineData(0, 10, -11)]
        [InlineData(int.MinValue, 0, int.MaxValue)]
        public void IsInRange_ShouldBeFalse(int min, int max, int value)
        {
            var sut = new IntRange(min, max);

            Assert.False(
                sut.IsInRange(value));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 10, 5)]
        [InlineData(0, 10, 0)]
        [InlineData(int.MinValue, int.MaxValue, 0)]
        public void IsInRange_ShouldBeTrue(int min, int max, int value)
        {
            var sut = new IntRange(min, max);

            Assert.True(
                sut.IsInRange(value));
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(0, 0, 10, 0)]
        [InlineData(0, 0, -10, 0)]
        [InlineData(0, 10, 5, 5)]
        [InlineData(-10, 10, -11, -10)]
        public void Clamp_ShouldReturnExpectedValue(int min, int max, int value, int expected)
        {
            var sut = new FloatRange(min, max);

            var result = sut.Clamp(value);

            Assert.Equal(expected, result);
        }
    }
}