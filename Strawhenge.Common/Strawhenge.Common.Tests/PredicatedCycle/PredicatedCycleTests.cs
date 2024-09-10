using System.Linq;
using Strawhenge.Common.Collections;
using Xunit;

namespace Strawhenge.Common.Tests
{
    public class PredicatedCycleTests
    {
        readonly SampleItem[] _items;
        readonly PredicatedCycle<SampleItem> _cycle;

        public PredicatedCycleTests()
        {
            _items = Enumerable.Range(0, 5).ToArray(_ => new SampleItem());

            _cycle = new PredicatedCycle<SampleItem>(item => item.IsEnabled, _items);
        }

        class SampleItem
        {
            public bool IsEnabled { get; set; }
        }

        [Fact]
        public void Next_should_return_none_when_all_fail_predicate()
        {
            var item = _cycle.Next();

            Assert.False(item.HasSome());
        }

        [Fact]
        public void Next_should_return_all_items_in_sequence_when_all_pass_predicate()
        {
            _items.ForEach(x => x.IsEnabled = true);

            for (int i = 0; i < _items.Length; i++)
            {
                var result = _cycle.Next();

                Assert.True(result.HasSome(out var item));
                Assert.Same(_items[i], item);
            }
        }

        [Fact]
        public void Next_should_return_all_items_again_in_second_sequence_when_all_pass_predicate()
        {
            _items.ForEach(x => x.IsEnabled = true);

            for (int i = 0; i < _items.Length; i++)
            {
                _cycle.Next();
            }

            for (int i = 0; i < _items.Length; i++)
            {
                var result = _cycle.Next();

                Assert.True(result.HasSome(out var item));
                Assert.Same(_items[i], item);
            }
        }

        [Fact]
        public void Next_should_return_first_item_to_pass_predicate()
        {
            _items[3].IsEnabled = true;
            _items[4].IsEnabled = true;

            var result = _cycle.Next();

            Assert.True(result.HasSome(out var item));
            Assert.Same(_items[3], item);
        }

        [Fact]
        public void Next_should_return_sequence_of_items_that_pass_predicate()
        {
            _items[0].IsEnabled = true;
            _items[3].IsEnabled = true;
            _items[4].IsEnabled = true;

            var expectedSequence = new[] { 0, 3, 4, 0, 3, 4, 0 };

            foreach (var expectedItemIndex in expectedSequence)
            {
                var result = _cycle.Next();

                Assert.True(result.HasSome(out var item));
                Assert.Same(_items[expectedItemIndex], item);
            }
        }

        [Fact]
        public void Next_should_return_item_to_newly_pass_predicate_when_last_item_was_previous_index()
        {
            _items[3].IsEnabled = true;
            _cycle.Next();
            
            _items[4].IsEnabled = true;
            var result = _cycle.Next();

            Assert.True(result.HasSome(out var item));
            Assert.Same(_items[4], item);
        }
    }
}