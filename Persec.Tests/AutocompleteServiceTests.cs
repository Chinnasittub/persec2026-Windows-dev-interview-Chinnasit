using FluentAssertions;
using Persec.Console.Core.Interfaces;
using Persec.Console.Services;

namespace Persec.Tests;

public class AutocompleteServiceTests
{
    private readonly IAutocompleteService _service = new AutocompleteService();

    [Fact]
    public void Search_ShouldThrow_WhenSearchIsNull()
    {
        Action act = () => _service.Search(null!, ["alpha"], 5);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Search_ShouldReturnEmpty_WhenItemsAreEmpty()
    {
        _service.Search("a", Array.Empty<string>(), 5).Should().BeEmpty();
    }

    [Fact]
    public void Search_ShouldReturnAlphabeticallyOrderedMatches_ForEmptySearch()
    {
        var items = new[] { "Zulu", "Alpha", "Mike" };

        _service.Search(string.Empty, items, 10).Should().Equal("Alpha", "Mike", "Zulu");
    }

    [Fact]
    public void Search_ShouldHandleDuplicatesAndIgnoreCase()
    {
        var items = new[] { "Alpha", "alpha", "Beta", "ALPHA" };

        _service.Search("alp", items, 10).Should().Equal("Alpha", "alpha", "ALPHA");
    }

    [Fact]
    public void Search_ShouldRespectMaxResult()
    {
        var items = new[] { "Alpha", "Alpine", "Albatross", "Zulu" };

        _service.Search("al", items, 2).Should().HaveCount(2);
    }

    [Fact]
    public void Search_ShouldReturnEmpty_WhenMaxResultIsZero()
    {
        _service.Search("al", ["Alpha", "Alpine"], 0).Should().BeEmpty();
    }

    [Fact]
    public void Search_ShouldThrow_WhenItemsAreNull()
    {
        Action act = () => _service.Search("al", null!, 5);

        act.Should().Throw<ArgumentNullException>();
    }
}
