namespace Persec.Console.Core.Interfaces;

/// <summary>
/// Converts between integers and Roman numerals.
/// </summary>
public interface IRomanNumeralService
{
    /// <summary>
    /// Converts an integer into a Roman numeral.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The Roman numeral representation.</returns>
    string ToRoman(int value);

    /// <summary>
    /// Converts a Roman numeral into an integer.
    /// </summary>
    /// <param name="roman">The Roman numeral to convert.</param>
    /// <returns>The decimal value.</returns>
    int FromRoman(string roman);
}
