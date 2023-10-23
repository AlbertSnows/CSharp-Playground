using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundTests.leetcode;
[TestClass]
public class FindDistanceFromGraphCycleTest
{
    [TestMethod]
    public void findMinimumSubstringTest()
    {
        var testCases = new[]{
        (new int[]{0, 0, 0, 1, 1, 1}, new (int, int)[]
        {
            (1, 2),
            (1, 3),
            (1, 4),
            (2, 3),
            (2, 5),
            (3, 6)}),
        (new int[]{0, 0, 0, 1, 1, 1, 2}, new (int, int)[]
        {
            (1, 2),
            (1, 3),
            (1, 4),
            (2, 3),
            (2, 5),
            (3, 6), 
            (4, 7)})};
        var expectedWithOutcome = testCases
            .Select(pair => (
                pair.Item1,
                FindDistanceFromGraphCycle
                .calcNodeDistanceFromCycle(pair.Item2)))
            .ToList();
        expectedWithOutcome.ForEach(pair => {
            Assert.AreEqual(pair.Item1, pair.Item2);
        });
    }
}
