namespace PlaygroundTests.leetcode;

public class ValidParenthesis
{
    public static bool 
        validateParenthesis(string parens)
    {
        var parenthesisStack = new Stack<char>();
        var openingParens = new HashSet<char>()
        { '(', '{', '[' };
        var closingToOpening = new Dictionary<char, char>()
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }};
        var validSet = true;
        foreach (var character in parens)
        {
            var isOpening = openingParens.Contains(character);
            var hasOpeners = parenthesisStack.Count > 0;
            var mostRecentParen = hasOpeners? parenthesisStack.Peek() : 'X';
            char expectedOpener;
            closingToOpening.TryGetValue(character, out expectedOpener);
            var parensMatch = expectedOpener == mostRecentParen;
            if(isOpening)
            {
                parenthesisStack.Push(character);
            } else if(parensMatch)
            {
                parenthesisStack.Pop();
            }
            else
            {
                 validSet = false;
                break;
            }
        }
        return validSet;
    }
}