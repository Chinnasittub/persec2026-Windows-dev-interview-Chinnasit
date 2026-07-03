using FluentAssertions;
using Persec.Console.Core.Interfaces;
using Persec.Console.Services;

namespace Persec.Tests;

public class DigitSorterServiceTests
{
    private readonly IDigitSorterService _service = new DigitSorterService();

    [Theory]
    [InlineData(3008, 8300)]
    [InlineData(1989, 9981)]
    [InlineData(2679, 9762)]
    [InlineData(9163, 9631)]
    [InlineData(0, 0)]
    [InlineData(12, 21)]
    public void SortDescending_ShouldReturnExpectedValue(int value, int expected)
    {
        _service.SortDescending(value).Should().Be(expected);
    }

    [Fact]
    public void SortDescending_ShouldThrow_WhenValueIsNegative()
    {
        Action act = () => _service.SortDescending(-12);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}
