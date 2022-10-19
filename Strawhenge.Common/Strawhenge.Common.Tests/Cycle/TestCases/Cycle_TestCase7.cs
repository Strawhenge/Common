using Strawhenge.Common.Collections;

namespace Strawhenge.Common.Tests.CycleTests
{
    public class Cycle_TestCase7<T> : BaseCycleTestCase<T>
    {
        readonly T _one;
        readonly T _two;
        readonly T _three;

        public Cycle_TestCase7(T one, T two, T three)
        {
            _one = one;
            _two = two;
            _three = three;
        }

        public override T ExpectedCurrent => _two;

        public override T ExpectedNext => _three;

        public override T ExpectedPrevious => _one;

        public override Cycle<T> CreateSut() => new Cycle<T>(_one, _two, _three);

        public override void PerformTest(Cycle<T> cycle)
        {
            cycle.Previous();
            cycle.Previous();
        }
    }
}
