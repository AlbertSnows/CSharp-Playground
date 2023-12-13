namespace PlaygroundTests.leetcode;

public class FindMinimumInRotatedSortedArray
{
    public static int findMinimumInRotated(int[] nums)
    {
        var leftIndex = 0;
        var rightIndex = nums.Length - 1;
        while(leftIndex < rightIndex)
        {
            var leftValue = nums[leftIndex];
            var rightValue = nums[rightIndex];
            var scale = (rightIndex - leftIndex) / 2;

            var middleIndex = leftIndex + scale;
            var middleValue = nums[middleIndex];

            //var leftIsBiggerThanMiddle = leftValue > middleValue;
            var rightIsBiggerThanMiddle = rightValue > middleValue;
            var leftIsLessThanMiddle = leftValue < middleValue;
            //var leftIsLessThanMiddle = leftValue < middleValue;
            //var rightIsLessThanMiddle = rightValue < middleValue;
            var leftIsBiggerThanMiddle = leftValue > middleValue;
            // 3 4 5 [1] 2
            // 2 3 [4] 5 1
            if (rightIsBiggerThanMiddle && leftIsBiggerThanMiddle) // 3 1 2
            {
                leftIndex = middleIndex;
                rightIndex = middleIndex;
            }
            else if (rightIsBiggerThanMiddle) // 1 2 3
            {
                rightIndex = middleIndex;
            } else // 2 3 1
            {
                leftIndex = middleIndex;
            }
        }
        return nums[leftIndex];
    }
}