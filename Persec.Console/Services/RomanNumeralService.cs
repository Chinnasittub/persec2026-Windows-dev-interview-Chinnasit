using Persec.Console.Core.Interfaces;

namespace Persec.Console.Services;

/// <summary>
/// Converts between integers and Roman numerals using standard modern Roman numeral rules.
/// </summary>
public sealed class RomanNumeralService : IRomanNumeralService
{
    private static readonly (int Value, string Symbol)[] RomanValues =
    [
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I")
    ];

    /// <inheritdoc />
    public string ToRoman(int value)
    {
        if (value is <= 0 or > 3999)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 1 and 3999 inclusive.");
        }

        var result = new System.Text.StringBuilder();

        foreach (var (romanValue, symbol) in RomanValues)
        {
            while (value >= romanValue)
            {
                result.Append(symbol);
                value -= romanValue;
            }
        }

        return result.ToString();
    }

    /// <inheritdoc />
    public int FromRoman(string roman)
    {
        ArgumentNullException.ThrowIfNull(roman);

        if (string.IsNullOrWhiteSpace(roman))
        {
            throw new ArgumentException("Roman numeral cannot be empty.", nameof(roman));
        }

        var normalized = roman.Trim().ToUpperInvariant();
        if (!IsValidRoman(normalized))
        {
            throw new ArgumentException("The supplied value is not a valid Roman numeral.", nameof(roman));
        }

        var total = 0;
        var currentIndex = 0;

        while (currentIndex < normalized.Length)
        {
            var currentSymbol = normalized[currentIndex];
            var nextSymbol = currentIndex + 1 < normalized.Length ? normalized[currentIndex + 1] : '\0';

            var currentValue = GetValue(currentSymbol);
            var nextValue = nextSymbol != '\0' ? GetValue(nextSymbol) : 0;

            if (nextValue > currentValue)
            {
                total += nextValue - currentValue;
                currentIndex += 2;
            }
            else
            {
                total += currentValue;
                currentIndex += 1;
            }
        }

        return total;
    }

    private static bool IsValidRoman(string roman)
    {
        if (string.IsNullOrEmpty(roman))
        {
            return false;
        }

        var regex = new System.Text.RegularExpressions.Regex(@"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$", System.Text.RegularExpressions.RegexOptions.Compiled);
        return regex.IsMatch(roman);
    }

    private static int GetValue(char symbol) => symbol switch
    {
        'I' => 1,
        'V' => 5,
        'X' => 10,
        'L' => 50,
        'C' => 100,
        'D' => 500,
        'M' => 1000,
        _ => throw new ArgumentException("The supplied value is not a valid Roman numeral.", "roman")
    };
}
