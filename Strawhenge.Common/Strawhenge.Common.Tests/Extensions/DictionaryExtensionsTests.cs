using System.Collections.Generic;
using Xunit;

namespace Strawhenge.Common.Tests.Extensions
{
    public class DictionaryExtensionsTests
    {
        const int Key = 1;
        const string ExpectedValue = "This is the expected string.";
        readonly Dictionary<int, string> _dictionary = new Dictionary<int, string>();

        [Fact]
        public void GetOrAddValue_should_add_supplied_value_when_key_not_present()
        {
            var value = _dictionary.GetOrAddValue(Key, () => ExpectedValue);

            Assert.Equal(ExpectedValue, value);
            Assert.True(_dictionary.ContainsKey(Key));
            Assert.Equal(_dictionary[Key], value);
        }

        [Fact]
        public void GetOrAddValue_should_retain_existing_value_when_key_present()
        {
            _dictionary.Add(Key, ExpectedValue);

            var value = _dictionary.GetOrAddValue(Key, () => "This is not the expected string.");

            Assert.Equal(ExpectedValue, value);
            Assert.True(_dictionary.ContainsKey(Key));
            Assert.Equal(_dictionary[Key], value);
        }
    }
}