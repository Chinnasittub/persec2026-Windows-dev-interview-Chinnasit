namespace Persec.Console.Core.Interfaces;

/// <summary>
/// Sorts strings based on an alphabetic prefix, numeric value, and suffix.
/// </summary>
public interface ICustomStringSorterService
{
    /// <summary>
    /// Sorts the supplied items using the custom ordering rules.
    /// </summary>
    /// <param name="items">The items to sort.</param>
    /// <returns>A sorted array of the input items.</returns>
    string[] Sort(string[] items);
}
