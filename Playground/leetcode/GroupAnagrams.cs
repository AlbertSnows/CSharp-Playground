using System.Collections.Immutable;

namespace PlaygroundTests.leetcode;

public class GroupAnagrams
{
    public static List<List<string>> 
        calcGroupAnagrams(IEnumerable<string> value)
    {
        //Input: strs = ["eat", "tea", "tan", "ate", "nat", "bat"]
        //Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
        var frequencies = value.Aggregate(new Dictionary<string, List<string>>(), 
            (frequencies, phrase) => {
                var sortedWord = new string(phrase.OrderBy(character => character)
                    .ToArray());
                var hasWord = frequencies.ContainsKey(sortedWord);
                if(hasWord)
                {
                    var list = frequencies[sortedWord];
                    list.Add(phrase);
                    frequencies[sortedWord] = list;
                } else
                {
                    frequencies.Add(sortedWord, new List<string> { phrase });
                }
                return frequencies;
        });
        var values = frequencies.Values.ToList();
        return values;
    }
}