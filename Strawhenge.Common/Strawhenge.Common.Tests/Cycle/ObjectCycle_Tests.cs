using System;
using System.Collections.Generic;
using System.Linq;
using Strawhenge.Common.Collections;
using Xunit;

namespace Strawhenge.Common.Tests.CycleTests
{
    public class ObjectCycle_Tests : BaseCycleTests<object>
    {
        static readonly object One = new object();
        static readonly object Two = "Two";
        static readonly object Three = new List<string>();

        static readonly BaseCycleTestCase<object>[] TestCases =
        {
            new Cycle_TestCase1<object>(One),
            new Cycle_TestCase2<object>(One),
            new Cycle_TestCase3<object>(One),
            new Cycle_TestCase4<object>(One, Two, Three),
            new Cycle_TestCase5<object>(One, Two, Three),
            new Cycle_TestCase6<object>(One, Two, Three),
            new Cycle_TestCase7<object>(One, Two, Three),
        };

        public static readonly IEnumerable<object[]> Current_TestData = TestCases.Select(x => x.CreateTestForCurrent());
        public static readonly IEnumerable<object[]> Next_TestData = TestCases.Select(x => x.CreateTestForNext());

        public static readonly IEnumerable<object[]> Previous_TestData =
            TestCases.Select(x => x.CreateTestForPrevious());

        [Theory]
        [MemberData(nameof(Current_TestData))]
        public override void Current(Cycle<object> cycle, Action<Cycle<object>> performSequence, object expected) =>
            base.Current(cycle, performSequence, expected);

        [Theory]
        [MemberData(nameof(Next_TestData))]
        public override void Next(Cycle<object> cycle, Action<Cycle<object>> performSequence, object expected) =>
            base.Next(cycle, performSequence, expected);

        [Theory]
        [MemberData(nameof(Previous_TestData))]
        public override void Previous(Cycle<object> cycle, Action<Cycle<object>> performTest, object expected) =>
            base.Previous(cycle, performTest, expected);
    }
}