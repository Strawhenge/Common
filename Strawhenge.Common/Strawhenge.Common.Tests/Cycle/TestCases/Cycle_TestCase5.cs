using Strawhenge.Common.Collections;

namespace Strawhenge.Common.Tests.CycleTests
{
    public class Cycle_TestCase5<T> : BaseCycleTestCase<T>
    {
        readonly T _one;
        readonly T _two;
        readonly T _three;

        public Cycle_TestCase5(T one, T two, T three)
        {
            _one = one;
            _two = two;
            _three = three;
        }

        public override T ExpectedCurrent => _three;

        public override T ExpectedNext => _one;

        public override T ExpectedPrevious => _two;

        public override Cycle<T> CreateSut() => new Cycle<T>(_one, _two, _three);

        public override void PerformTest(Cycle<T> cycle)
        {
            cycle.Next();
            cycle.Next();
        }
    }
}
