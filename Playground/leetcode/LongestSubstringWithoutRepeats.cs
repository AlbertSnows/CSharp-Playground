using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.leetcode;

public static class LongestSubstringWithoutRepeats
{
    public static int 
        findLongestSubstringWithoutRepeatsTest(string input)
    {
        var left = 0;
        var right = 0;
        var currentUniqueCharacters = new HashSet<char>();
        foreach(var character in input)
        {
            var alreadyHaveCharacter = 
                currentUniqueCharacters.Contains(character);
            if (alreadyHaveCharacter)
            {
                left++;
                currentUniqueCharacters.Remove(character);
            } else
            {
                currentUniqueCharacters.Add(character);
                right++;
            }
        }
        return right - left; 
    }
}
