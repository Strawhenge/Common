using System;
using System.Collections.Generic;
using System.Linq;
using Strawhenge.Common.Collections;
using Xunit;

namespace Strawhenge.Common.Tests.CycleTests
{
    public class IntCycle_Tests : BaseCycleTests<int>
    {
        static readonly BaseCycleTestCase<int>[] TestCases = {
            new Cycle_TestCase1<int>(0),
            new Cycle_TestCase2<int>(0),
            new Cycle_TestCase3<int>(0),
            new Cycle_TestCase4<int>(0, 10, int.MaxValue),
            new Cycle_TestCase5<int>(0, 10, int.MaxValue),
            new Cycle_TestCase6<int>(0, 10, int.MaxValue),
            new Cycle_TestCase7<int>(0, 10, int.MaxValue),
        };

        public static readonly IEnumerable<object[]> Current_TestData = TestCases.Select(x => x.CreateTestForCurrent());
        public static readonly IEnumerable<object[]> Next_TestData = TestCases.Select(x => x.CreateTestForNext());
        public static readonly IEnumerable<object[]> Previous_TestData = TestCases.Select(x => x.CreateTestForPrevious());

        [Theory]
        [MemberData(nameof(Current_TestData))]
        public override void Current(Cycle<int> cycle, Action<Cycle<int>> performSequence, int expected) => base.Current(cycle, performSequence, expected);

        [Theory]
        [MemberData(nameof(Next_TestData))]
        public override void Next(Cycle<int> cycle, Action<Cycle<int>> performSequence, int expected) => base.Next(cycle, performSequence, expected);

        [Theory]
        [MemberData(nameof(Previous_TestData))]
        public override void Previous(Cycle<int> cycle, Action<Cycle<int>> performTest, int expected) => base.Previous(cycle, performTest, expected);
    }
}