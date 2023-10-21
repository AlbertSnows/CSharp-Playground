using Playground.leetcode;
using System;
using System.Collections.Generic;
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
    public static void findLongestSubstringWithoutRepeatsTest()
    {
        var input = "abcabcbb";
        var outcome = LongestSubstringWithoutRepeats.findLongestSubstringWithoutRepeatsTest(input);
        var expected = 3;
        Assert.AreEqual(expected, outcome);
    }
}
