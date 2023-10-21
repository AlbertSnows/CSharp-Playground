using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundTests.leetcode;
[TestClass]
public class FindMinimumInRotatedSortedArrayTest
{
    [TestMethod]
    public void ValidateParenthesisTest()
    {
        var testCases = new[]{
            (1, new[]{3,4,5,1,2}),
            (0, new[]{4,5,6,7,0,1,2}),
            (11, new[]{11,13,15,17})};
        var expectedWithOutcome = testCases
            .Select(pair => (
                pair.Item1,
                FindMinimumInRotatedSortedArray.findMinimumInRotated(pair.Item2)))
            .ToList();
        expectedWithOutcome.ForEach(pair => {
            Assert.AreEqual(pair.Item1, pair.Item2);
        });
    }
}
