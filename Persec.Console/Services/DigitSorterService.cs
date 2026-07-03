using Persec.Console.Core.Interfaces;

namespace Persec.Console.Services;

/// <summary>
/// Sorts the digits of a non-negative integer in descending order.
/// </summary>
public sealed class DigitSorterService : IDigitSorterService
{
    /// <inheritdoc />
    public int SortDescending(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be non-negative.");
        }

        if (value == 0)
        {
            return 0;
        }

        var digits = value.ToString().Select(character => int.Parse(character.ToString())).OrderByDescending(digit => digit);
        return int.Parse(string.Concat(digits));
    }
}
