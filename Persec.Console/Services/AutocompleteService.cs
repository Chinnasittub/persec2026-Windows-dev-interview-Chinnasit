using Persec.Console.Core.Interfaces;

namespace Persec.Console.Services;

/// <summary>
/// Searches a collection of strings using priority-based autocomplete matching.
/// </summary>
public sealed class AutocompleteService : IAutocompleteService
{
    /// <inheritdoc />
    public List<string> Search(string search, IEnumerable<string> items, int maxResult)
    {
        ArgumentNullException.ThrowIfNull(search);
        ArgumentNullException.ThrowIfNull(items);

        if (maxResult < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxResult));
        }

        if (maxResult == 0)
        {
            return [];
        }

        var normalizedSearch = search.Trim();
        var normalizedItems = items
            .Where(item => item is not null)
            .Select(item => item!)
            .ToList();

        var matches = normalizedItems
            .Select(item => new { Item = item, Rank = GetRank(normalizedSearch, item) })
            .Where(entry => entry.Rank >= 0)
            .OrderBy(entry => entry.Rank)
            .ThenBy(entry => entry.Item, StringComparer.OrdinalIgnoreCase)
            .Take(maxResult)
            .Select(entry => entry.Item)
            .ToList();

        return matches;
    }

    private static int GetRank(string search, string item)
    {
        if (string.IsNullOrEmpty(search))
        {
            return 0;
        }

        var normalizedItem = item ?? string.Empty;
        var comparison = StringComparison.OrdinalIgnoreCase;

        if (normalizedItem.StartsWith(search, comparison))
        {
            return 1;
        }

        if (normalizedItem.IndexOf(search, comparison) >= 0)
        {
            return 2;
        }

        if (normalizedItem.EndsWith(search, comparison))
        {
            return 3;
        }

        return -1;
    }
}
