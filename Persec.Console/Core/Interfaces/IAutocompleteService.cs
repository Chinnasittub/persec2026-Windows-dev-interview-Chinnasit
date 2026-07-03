namespace Persec.Console.Core.Interfaces;

/// <summary>
/// Provides autocomplete-style search over a collection of strings.
/// </summary>
public interface IAutocompleteService
{
    /// <summary>
    /// Searches for items that match the provided query.
    /// </summary>
    /// <param name="search">The search string.</param>
    /// <param name="items">The candidate items.</param>
    /// <param name="maxResult">The maximum number of results to return.</param>
    /// <returns>A list of matched items.</returns>
    List<string> Search(string search, IEnumerable<string> items, int maxResult);
}
