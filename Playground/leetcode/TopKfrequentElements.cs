namespace PlaygroundTests.leetcode;

public class TopKfrequentElements
{
    public static int[] calcTopKFrequncies(int[] nums, int numberToReturn)
    {
        var sortedFrequencies = new SortedDictionary<int, int>();
        foreach(var number in nums)
        {
            var numberInDict = sortedFrequencies.ContainsKey(number);
            if(numberInDict)
            {
                sortedFrequencies[number] = sortedFrequencies[number] + 1;
            } else
            {
                sortedFrequencies[number] = 1;
            }
        }
        var beginning = 0;
        var numsByMostFrequentOccurance = sortedFrequencies.Keys.ToArray();
        if(beginning >= 0)
        {
            var subset = new ArraySegment<int>(numsByMostFrequentOccurance, beginning, numberToReturn);
            var asArray = subset.ToArray();
            return asArray;
        } else
        {
            return new int[0];
        }
    }
}