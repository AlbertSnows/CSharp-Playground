using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundTests.leetcode;
[TestClass]
public class TopKFrequentElementsTest
{
    [TestMethod]
    public void calcTopKFrequencies()
    {
        var testCases = new[]{
            (new[] { 1, 2 }, (new []{1, 1, 1, 2, 2, 3 }, 2)),
            (new[] {1}, (new []{1}, 1))};
        var expectedWithOutcome = testCases
            .Select(pair => (
                pair.Item1,
                TopKfrequentElements.calcTopKFrequncies(pair.Item2.Item1, pair.Item2.Item2)))
            .ToList();
        expectedWithOutcome.ForEach(pair => {
            var expected = pair.Item1;
            var outcome = pair.Item2;
            var areEqual = Enumerable.SequenceEqual(expected, outcome);
            Assert.IsTrue(areEqual);
        });
    }
}
