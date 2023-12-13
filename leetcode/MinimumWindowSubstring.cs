using System.Data;

namespace PlaygroundTests.leetcode;

public class MinimumWindowSubstring
{
    public static Dictionary<char, int> frequencies(string phrase)
    {
        var map = new Dictionary<char, int>();
        foreach(var character in phrase)
        {
            var alreadyExists = map.ContainsKey(character);
            if(alreadyExists)
            {
                map[character] = map[character] + 1;
            } else
            {
                map[character] = 1;
            }
        }
        return map;
    }

    public static string findMinimumSubstring(string bigPhrase, string smallPhrase)
    {
//
        var asArray = bigPhrase.ToCharArray();
        var left = 0;
        var right = 0;
        var length = asArray.Length;
        var keyFrequencies = frequencies(smallPhrase);
        var remaining = keyFrequencies.ToDictionary(
            p => p.Key,
            p => p.Value);
        var upsert = (Dictionary<char, int> m, char k) =>
        {
            var exists = m.ContainsKey(k);
            if (exists)
            {
                m[k] = m[k] + 1;
            } else
            {
                m[k] = 1;
            }
            return m;
        };
        var decert = (Dictionary<char, int> m, char k) =>
                    {
                        var count = m[k];
                        if (count == 1)
                        {
                            m.Remove(k);
                        }
                        else
                        {
                            m[k] = count - 1;
                        }
                        return m;
                    };
        //    s = "ADOBECODEBANC", t = "ABC"
        // a | b c b a 
        // "BANC"

        var longest = new KeyValuePair<int, int>(0, length);
        var amountRemaining = smallPhrase.Length;
        while(((right < length && amountRemaining != 0) ||
            amountRemaining == 0) && 
            left < length
            )
        {
            var oldestCharacter = asArray[left];
            var newestCharacter = asArray[right];
            var atEnd = right + 1 == length;
            var subStringHasAll = amountRemaining == 0;
            var oldestCharacterInSet =
                keyFrequencies.ContainsKey(oldestCharacter);
            var newestIsInRemaining = remaining.ContainsKey(newestCharacter);
            if(subStringHasAll && oldestCharacterInSet)
            {
                var newSubSet = new KeyValuePair<int, int>(left, right);
                var newDiff = right - left;
                var oldDiff = longest.Value - longest.Key;
                var keepNew = newDiff < oldDiff;
                longest = keepNew ? newSubSet : longest;
                left++;
                remaining[oldestCharacter] = remaining[oldestCharacter] + 1;
                var isPositive = remaining[oldestCharacter] > 0;
                if(isPositive)
                {
                    amountRemaining++;
                }
            } 
            else if(subStringHasAll)
            {
                var newSubSet = new KeyValuePair<int, int>(left, right);
                var newDiff = right - left;
                var oldDiff = longest.Key - longest.Value;
                var keepNew = newDiff < oldDiff;
                longest = keepNew ? newSubSet : longest;
                left++;
            } 
            else if(newestIsInRemaining)
            {
                remaining[newestCharacter] = remaining[newestCharacter] - 1;
                var isPositive = remaining[newestCharacter] >= 0;
                if (isPositive)
                {
                    amountRemaining--;
                }
                if (!atEnd || (atEnd && amountRemaining > 0))
                {
                    right++;
                }
            } else if(!atEnd || (atEnd && amountRemaining > 0))
            {
                right++;
            }

        }
        var answer = bigPhrase.Substring(longest.Key, longest.Value - longest.Key);
        return answer;
    }
}