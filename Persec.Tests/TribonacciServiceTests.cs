using FluentAssertions;
using Persec.Console.Core.Interfaces;
using Persec.Console.Services;

namespace Persec.Tests;

public class TribonacciServiceTests
{
    private readonly ITribonacciService _service = new TribonacciService();

    [Fact]
    public void Generate_ShouldReturnEmpty_WhenLengthIsZero()
    {
        _service.Generate([], 0).Should().BeEmpty();
    }

    [Fact]
    public void Generate_ShouldReturnSeed_WhenLengthIsLessThanSeedCount()
    {
        _service.Generate([1, 2, 3], 2).Should().Equal(1, 2);
    }

    [Fact]
    public void Generate_ShouldGenerateSequenceFromSeed()
    {
        _service.Generate([1, 2, 3], 10).Should().Equal(1, 2, 3, 6, 11, 20, 37, 68, 125, 230);
    }

    [Fact]
    public void Generate_ShouldThrow_WhenSeedIsNull()
    {
        Action act = () => _service.Generate(null!, 5);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Generate_ShouldThrow_WhenLengthIsNegative()
    {
        Action act = () => _service.Generate([1, 2], -1);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}
