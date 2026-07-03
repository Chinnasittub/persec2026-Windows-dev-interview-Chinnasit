using FluentAssertions;
using Persec.Console.Core.Interfaces;
using Persec.Console.Services;

namespace Persec.Tests;

public class CustomStringSorterServiceTests
{
    private readonly ICustomStringSorterService _service = new CustomStringSorterService();

    [Fact]
    public void Sort_ShouldReturnSingleItem_WhenCollectionHasOneItem()
    {
        _service.Sort(["TH19"]).Should().Equal(["TH19"]);
    }

    [Fact]
    public void Sort_ShouldOrderByPrefixThenNumericValueThenSuffix()
    {
        var items = new[] { "TH19", "TH2", "TH3Netflix", "SG20" };

        _service.Sort(items).Should().Equal("SG20", "TH2", "TH3Netflix", "TH19");
    }

    [Fact]
    public void Sort_ShouldHandleSamePrefixAndDifferentNumbers()
    {
        var items = new[] { "AB10", "AB2", "AB1", "AB20" };

        _service.Sort(items).Should().Equal("AB1", "AB2", "AB10", "AB20");
    }

    [Fact]
    public void Sort_ShouldHandleSuffixes()
    {
        var items = new[] { "AB2Beta", "AB2Alpha", "AB2" };

        _service.Sort(items).Should().Equal("AB2", "AB2Alpha", "AB2Beta");
    }

    [Fact]
    public void Sort_ShouldThrow_WhenItemsIsNull()
    {
        Action act = () => _service.Sort(null!);

        act.Should().Throw<ArgumentNullException>();
    }
}
