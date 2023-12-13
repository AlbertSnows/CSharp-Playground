using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground; 

public static class Core
{
    public static void experiments()
    {
        var n = 20;
        var solved = new Dictionary<int, int>()
        {
            {0, 0},
            {1, 1},
            {2, 1},
        };
        var range = Enumerable.Range(3, n);
        foreach (var num in range)
        {
            var answer = solved[num - 1] + solved[num - 2] + solved[num - 3];
            solved.Add(num, answer);
        }
        System.Console.WriteLine(solved.ToString());
    }
}
