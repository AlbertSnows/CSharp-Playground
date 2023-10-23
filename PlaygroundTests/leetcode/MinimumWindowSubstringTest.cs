using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundTests.leetcode;

[TestClass]
public class MinimumWindowSubstringTest
{
    [TestMethod]
    public void findMinimumSubstringTest    ()
    {
        var testCases = new[]{
        ("BANC", ("ADOBECODEBANC", "ABC")),
        ("a", ("a", "a")),
        ("", ("a", "aa"))};
        var expectedWithOutcome = testCases
            .Select(pair => (
                pair.Item1,
                MinimumWindowSubstring
                .findMinimumSubstring(pair.Item2.Item1, pair.Item2.Item2)))
            .ToList();
        expectedWithOutcome.ForEach(pair => {
            Assert.AreEqual(pair.Item1, pair.Item2);
        });
    }
}
