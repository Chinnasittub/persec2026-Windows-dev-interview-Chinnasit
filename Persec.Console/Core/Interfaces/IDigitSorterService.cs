namespace Persec.Console.Core.Interfaces;

/// <summary>
/// Sorts digits of a non-negative integer in descending order.
/// </summary>
public interface IDigitSorterService
{
    /// <summary>
    /// Rearranges the digits of the supplied value in descending order.
    /// </summary>
    /// <param name="value">The value to process.</param>
    /// <returns>The resulting number with digits sorted descending.</returns>
    int SortDescending(int value);
}
