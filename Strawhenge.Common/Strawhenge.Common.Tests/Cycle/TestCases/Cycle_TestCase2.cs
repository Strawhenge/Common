using Strawhenge.Common.Collections;

namespace Strawhenge.Common.Tests.CycleTests
{
    public class Cycle_TestCase2<T> : BaseCycleTestCase<T>
    {
        readonly T _one;

        public Cycle_TestCase2(T one)
        {
            _one = one;
        }

        public override T ExpectedCurrent => _one;

        public override T ExpectedNext => _one;

        public override T ExpectedPrevious => _one;

        public override Cycle<T> CreateSut() => new Cycle<T>(_one);

        public override void PerformTest(Cycle<T> cycle)
        {
            cycle.Next();
        }
    }
}
