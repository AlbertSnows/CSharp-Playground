using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundTests.leetcode;
[TestClass]
public class NumberOfIslandsTest
{
    [TestMethod]
    public void ValidateParenthesisTest()
    {
        var testCases = new[]{
        (1, new[]{
            new []{"1","1","1","1","0"},
            new []{"1","1","0","1","0"},
            new []{"1","1","0","0","0"},
            new []{"0","0","0","0","0"} }),
        (3, new[]{
            new []{"1","1","0","0","0"},
            new []{"1","1","0","0","0"},
            new []{"0","0","1","0","0"},
            new []{ "0", "0", "0", "1", "1" } })};
        var expectedWithOutcome = testCases
            .Select(pair => (
                pair.Item1,
                NumberOfIslands.calcNumberOfIslands(pair.Item2)))
            .ToList();
        expectedWithOutcome.ForEach(pair => {
            Assert.AreEqual(pair.Item1, pair.Item2);
        });
    }
}
