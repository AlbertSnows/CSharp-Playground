using System.Collections.Immutable;

namespace PlaygroundTests.leetcode;

public class GroupAnagrams
{
    public static List<List<string>> 
        calcGroupAnagrams(ImmutableList<string> value)
    {
        //Input: strs = ["eat", "tea", "tan", "ate", "nat", "bat"]
        //Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
        var frequencies = value.Aggregate(new Dictionary<string, List<string>>(), 
            (frequencies, phrase) => {
                var sortedWord = new string(phrase.OrderBy(character => character)
                    .ToArray());
                var hasWord = frequencies.Contains(sortedWord);
                if(hasWord)
                {
                    frequencies.get(sortedWord).add(phrase);
                } else
                {
                    frequencies.put(sortedWord, new List<string>(phrase));
                }
                return frequencies;
        });
        //throw new NotImplementedException();
    }
}