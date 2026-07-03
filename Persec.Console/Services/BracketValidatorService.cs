using Persec.Console.Core.Interfaces;

namespace Persec.Console.Services;

/// <summary>
/// Validates bracket sequences using a stack-based algorithm.
/// </summary>
public sealed class BracketValidatorService : IBracketValidatorService
{
    private static readonly Dictionary<char, char> MatchingBrackets = new()
    {
        { ')', '(' },
        { ']', '[' },
        { '}', '{' }
    };

    /// <inheritdoc />
    public bool IsValid(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        if (input.Length == 0)
        {
            return true;
        }

        var stack = new Stack<char>(input.Length);

        foreach (var character in input)
        {
            if (IsOpeningBracket(character))
            {
                stack.Push(character);
                continue;
            }

            if (IsClosingBracket(character))
            {
                if (stack.Count == 0 || stack.Peek() != MatchingBrackets[character])
                {
                    return false;
                }

                stack.Pop();
            }
        }

        return stack.Count == 0;
    }

    private static bool IsOpeningBracket(char character) => character is '(' or '[' or '{';

    private static bool IsClosingBracket(char character) => MatchingBrackets.ContainsKey(character);
}
