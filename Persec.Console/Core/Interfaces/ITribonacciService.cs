namespace Persec.Console.Core.Interfaces;

/// <summary>
/// Generates Tribonacci sequences from a supplied seed.
/// </summary>
public interface ITribonacciService
{
    /// <summary>
    /// Generates a Tribonacci sequence of the requested length.
    /// </summary>
    /// <param name="seed">The initial seed values.</param>
    /// <param name="length">The number of values to generate.</param>
    /// <returns>The generated sequence.</returns>
    List<int> Generate(IEnumerable<int> seed, int length);
}
