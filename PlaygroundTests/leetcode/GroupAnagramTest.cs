using Playground.leetcode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Given an array of strings strs, group the anagrams together. You can return the answer in any order.

//An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once. 

//Example 1:

//Input: strs = ["eat", "tea", "tan", "ate", "nat", "bat"]
//Output: [["bat"],["nat","tan"],["ate","eat","tea"]]


namespace PlaygroundTests.leetcode;
// dotnet restore
[TestClass]
public class GroupAnagramsTest
{
    [TestMethod]
    public void calcGroupAnagramsTest()
    {
        var testCases = ImmutableList.Create(
            (new[]{
                new []{ "bat" },
                new []{ "nat", "tan" },
                new []{ "ate", "eat", "tea" } },
                new[] { "eat", "tea", "tan", "ate", "nat", "bat" }),
            (new[] {
                new []{ "a" }},
                new []{ "a" }),
            (new[] {
                new []{ "" }},
                new []{ "" }));
        var expectedWithOutcome = testCases
            .Select(pair => (
                pair.Item1,
                GroupAnagrams.calcGroupAnagrams(pair.Item2)))
            .ToList();
        expectedWithOutcome.ForEach(pair => {
            var sortedExpected = pair.Item1
            .Select(innerArray => innerArray.ToList())
            .ToList()
            ;
            var sortedOutcome = pair.Item2
            .OrderBy(innerArray => innerArray.Count)
            .Select(innerArray => innerArray.OrderBy(deeperArray => deeperArray).ToList())
            .ToList()
            ;

            foreach (var index in Enumerable.Range(0, sortedExpected.Count)) {
                var expected = sortedExpected[index];
                var outcome = sortedOutcome[index];
                var areEqual = Enumerable.SequenceEqual(expected, outcome);
                Assert.IsTrue(areEqual);
            }
        });
    }
}

