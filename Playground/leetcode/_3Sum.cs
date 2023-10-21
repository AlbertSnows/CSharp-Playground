using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.leetcode;

public class _3Sum
{

    public static List<int[]> 
        calc2Sum(int[] sortedNums, int target)
    {
        var leftIndex = 0;
        var rightIndex = sortedNums.Length - 1;
        var answers = new List<int[]>();
        while(leftIndex < rightIndex) 
        {
            var leftValue = sortedNums[leftIndex];
            var rightValue = sortedNums[rightIndex];
            var currentValue = leftValue + rightValue;
            var greaterThanTarget = currentValue > target;
            var lessThanTarget = currentValue < target;
            if (lessThanTarget)
            {
                leftIndex = leftIndex + 1;
            } else if(greaterThanTarget)
            {
                rightIndex = rightIndex - 1;
            } else
            {
                leftIndex = leftIndex + 1;
                answers.Add(new[] { leftValue, rightValue });
            }
        }
        return answers;
    }

    public static List<int[]> calc3Sum(int[] nums)
    {
        Array.Sort(nums);
        var indexes = Enumerable.Range(0, nums.Length).ToArray();
        var uniqueValues = new HashSet<int>();
        var uniqueIndexes = new List<int>();
        foreach(var index in indexes)
        {
            var number = nums[index];
            var alreadyHaveIndex = uniqueValues.Contains(number);
            if(!alreadyHaveIndex)
            {
                uniqueValues.Add(number);
                uniqueIndexes.Add(index);
            }
        }
        var numTo2Sums = new Dictionary<int, List<int[]>>();
        var end = nums.Length;
        foreach (var index in uniqueIndexes)
        {
            var numsFor2SumSegment = nums[(index + 1)..end];
            var numsFor2Sum = numsFor2SumSegment
                .ToArray();
            var target = nums[index];
            var _2sumsAnswers = calc2Sum(numsFor2Sum, target * -1);
            if(_2sumsAnswers.Count > 0)
            {
                numTo2Sums[target] = _2sumsAnswers;
            }
        }

        var answer = new List<int[]>();
        foreach(var pair in numTo2Sums)
        {
            var target = pair.Key;
            var _2sums = pair.Value;
            foreach(var _2sum in _2sums) {
                answer.Add(new[] { target, _2sum[0], _2sum[1] });
            }
        }

        return answer;
    }
}
