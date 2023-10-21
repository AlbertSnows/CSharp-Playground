using Microsoft.VisualStudio.TestPlatform.Utilities;
using Playground;
using Playground.leetcode;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundTests.leetcode;
//Given an integer array nums, return all the triplets[nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

//Notice that the solution set must not contain duplicate triplets.



//Example 1:

//Input: nums = [-1, 0, 1, 2, -1, -4]
//Output: [[-1,-1,2], [-1,0,1]]
//Explanation: 
//nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
//nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
//nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
//The distinct triplets are[-1, 0, 1] and[-1, -1, 2].
//Notice that the order of the output and the order of the triplets does not matter.

//Example 2:

//Input: nums = [0, 1, 1]
//Output: []
//Explanation: The only possible triplet does not sum up to 0.

//Example 3:

//Input: nums = [0, 0, 0]
//Output: [[0,0,0]]
//Explanation: The only possible triplet sums up to 0.
[TestClass]
public class _3SumTest
{
    [TestMethod]
    public void calc3Sum()
    {
        var testCases = new[]{
            (new List<int[]>(){new[] { -1, -1, 2 }, new[] { -1, 0, 1 }},
             new[] {-1,0,1,2,-1,-4}),
            (new List<int[]>(),
             new[] {0, 1, 1}),
            (new List<int[]>(){ new[] {0, 0, 0 }},
             new[] {0, 0, 0})};
        var expectedWithOutcome = testCases
            .Select(pair => (
                pair.Item1,
                _3Sum.calc3Sum(pair.Item2)))
            .ToList();
        expectedWithOutcome.ForEach(pair => {
            if(pair.Item1.Count > 0)
            {
                var range = Enumerable.Range(0, pair.Item2.Count);
                foreach (var index in range)
                {
                    // does not work
                    var expected = pair.Item1[index];

                    var outcome = pair.Item2[index];
                    var areEqual = Enumerable.SequenceEqual(expected, outcome);
                    Assert.IsTrue(areEqual);
                }

            }
        });
    }
}
