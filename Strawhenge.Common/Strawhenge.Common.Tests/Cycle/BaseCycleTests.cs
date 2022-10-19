using System;
using Strawhenge.Common.Collections;
using Xunit;

namespace Strawhenge.Common.Tests.CycleTests
{
    public class BaseCycleTests<T>
    {
        public virtual void Current(Cycle<T> cycle, Action<Cycle<T>> performSequence, T expected)
        {
            performSequence(cycle);

            Assert.Equal(expected, cycle.Current);
        }

        public virtual void Next(Cycle<T> cycle, Action<Cycle<T>> performSequence, T expected)
        {
            performSequence(cycle);

            Assert.Equal(expected, cycle.Next());
        }

        public virtual void Previous(Cycle<T> cycle, Action<Cycle<T>> performTest, T expected)
        {
            performTest(cycle);

            Assert.Equal(expected, cycle.Previous());
        }
    }
}