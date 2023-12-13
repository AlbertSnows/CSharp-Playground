using Playground.leetcode;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundTests.leetcode;

//3. Longest Substring Without Repeating Characters
//Medium
//37.5K
//1.7K
//Companies

//Given a string s, find the length of the longest
//substring
//without repeating characters.



//Example 1:

//Input: s = "abcabcbb"
//Output: 3
//Explanation: The answer is "abc", with the length of 3.

[TestClass]
public class LongestSubstringWithoutRepeatsTest
{
    [TestMethod]
    public void FindLongestSubstringWithoutRepeatsTest()
    {
        var testCases = ImmutableList.Create(
            new KeyValuePair<int, string>(3, "abcabcbb"),
            new KeyValuePair<int, string>(1, "bbbbb"),
            new KeyValuePair<int, string>(3, "pwwkew"));
        var expectedWithOutcome = testCases
            .Select(pair => new KeyValuePair<int, int>(
                pair.Key,
                LongestSubstringWithoutRepeats.findLongestSubstringWithoutRepeatsTest(pair.Value)))
            .ToList();
        expectedWithOutcome.ForEach(pair =>
        {
            //Assert.AreEqual(pair.Key, pair.Value);
        });
    }
}
