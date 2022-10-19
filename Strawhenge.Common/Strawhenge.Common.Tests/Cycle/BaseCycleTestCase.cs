using System;
using Strawhenge.Common.Collections;

namespace Strawhenge.Common.Tests.CycleTests
{
    public abstract class BaseCycleTestCase<T>
    {
        public object[] CreateTestForCurrent() =>
            new object[] { CreateSut(), (Action<Cycle<T>>)PerformTest, ExpectedCurrent };

        public object[] CreateTestForNext() =>
            new object[] { CreateSut(), (Action<Cycle<T>>)PerformTest, ExpectedNext };

        public object[] CreateTestForPrevious() =>
            new object[] { CreateSut(), (Action<Cycle<T>>)PerformTest, ExpectedPrevious };

        public abstract T ExpectedCurrent { get; }

        public abstract T ExpectedNext { get; }

        public abstract T ExpectedPrevious { get; }

        public abstract Cycle<T> CreateSut();

        public abstract void PerformTest(Cycle<T> cycle);
    }
}