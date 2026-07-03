using Persec.Console.Core.Interfaces;

namespace Persec.Console.Services;

/// <summary>
/// Generates Tribonacci sequences from a provided seed.
/// </summary>
public sealed class TribonacciService : ITribonacciService
{
    /// <inheritdoc />
    public List<int> Generate(IEnumerable<int> seed, int length)
    {
        ArgumentNullException.ThrowIfNull(seed);

        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length), "Length must be non-negative.");
        }

        if (length == 0)
        {
            return [];
        }

        var sequence = seed.ToList();
        if (sequence.Count == 0)
        {
            return [];
        }

        if (sequence.Count > length)
        {
            return sequence.Take(length).ToList();
        }

        while (sequence.Count < length)
        {
            var nextValue = sequence.TakeLast(3).Sum();
            sequence.Add(nextValue);
        }

        return sequence;
    }
}
