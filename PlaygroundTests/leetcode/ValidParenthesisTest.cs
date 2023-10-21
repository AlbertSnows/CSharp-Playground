using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundTests.leetcode;
[TestClass]
public class ValidParenthesisTest
{
    [TestMethod]
    public void ValidateParenthesisTest()
    {
        var testCases = new[]{
            (true, "()"),
            (true, "()[]{}"),
            (false, "(]")};
        var expectedWithOutcome = testCases
            .Select(pair => (
                pair.Item1,
                ValidParenthesis.validateParenthesis(pair.Item2)))
            .ToList();
        expectedWithOutcome.ForEach(pair => {
            Assert.AreEqual(pair.Item1, pair.Item2);
        });
    }
}
