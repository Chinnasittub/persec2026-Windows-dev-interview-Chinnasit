using System.Text.RegularExpressions;
using Persec.Console.Core.Interfaces;

namespace Persec.Console.Services;

/// <summary>
/// Sorts strings according to prefix, numeric value, and suffix rules.
/// </summary>
public sealed class CustomStringSorterService : ICustomStringSorterService
{
    private static readonly Regex Pattern = new(@"^(\D+)(\d+)?(.*)$", RegexOptions.Compiled);

    /// <inheritdoc />
    public string[] Sort(string[] items)
    {
        ArgumentNullException.ThrowIfNull(items);

        return items
            .OrderBy(item => ExtractPrefix(item), StringComparer.OrdinalIgnoreCase)
            .ThenBy(item => ExtractNumericValue(item))
            .ThenBy(item => ExtractSuffix(item), StringComparer.OrdinalIgnoreCase)
            .ToArray();
    }

    private static string ExtractPrefix(string item)
    {
        ArgumentNullException.ThrowIfNull(item);

        var match = Pattern.Match(item);
        return match.Success ? match.Groups[1].Value : string.Empty;
    }

    private static int ExtractNumericValue(string item)
    {
        ArgumentNullException.ThrowIfNull(item);

        var match = Pattern.Match(item);
        return match.Success && int.TryParse(match.Groups[2].Value, out var number) ? number : 0;
    }

    private static string ExtractSuffix(string item)
    {
        ArgumentNullException.ThrowIfNull(item);

        var match = Pattern.Match(item);
        return match.Success ? match.Groups[3].Value : string.Empty;
    }
}
