using Playground.leetcode;
using System;
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

[TestClass]
public class GroupAnagramsTest
{
    [TestMethod]
    public void calcGroupAnagramsTest()
    {
        var testCases = ImmutableList.Create(
            new KeyValuePair<List<List<string>>, ImmutableList<string>>(
                new List<List<string>> {
                    new List<string> { "bat" },
                    new List<string> { "nat", "tan" },
                    new List<string> { "ate", "eat", "tea" } },
            ImmutableList.Create( "eat", "tea", "tan", "ate", "nat", "bat" )),
            new KeyValuePair<List<List<string>>, ImmutableList<string>>(
                new List<List<string>> {
                    new List<string> { "a" }},
            ImmutableList.Create( "a" )),
            new KeyValuePair<List<List<string>>, ImmutableList<string>>(
                new List<List<string>> {
                    new List<string> { "" }},
            ImmutableList.Create( "" )));
        var expectedWithOutcome = testCases
            .Select(pair => new KeyValuePair<
                List<List<string>>, 
                List<List<string>>>(
                pair.Key,
                GroupAnagrams.calcGroupAnagrams(pair.Value)))
            .ToList();
        expectedWithOutcome.ForEach(pair =>
        {
            Assert.AreEqual(pair.Key, pair.Value);
        });
    }
}

