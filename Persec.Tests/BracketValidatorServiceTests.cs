using FluentAssertions;
using Persec.Console.Core.Interfaces;
using Persec.Console.Services;

namespace Persec.Tests;

public class BracketValidatorServiceTests
{
    private readonly IBracketValidatorService _service = new BracketValidatorService();

    [Fact]
    public void IsValid_ShouldThrow_WhenInputIsNull()
    {
        Action act = () => _service.IsValid(null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void IsValid_ShouldReturnTrue_ForEmptyString()
    {
        _service.IsValid(string.Empty).Should().BeTrue();
    }

    [Theory]
    [InlineData("()", true)]
    [InlineData("[]", true)]
    [InlineData("{}", true)]
    [InlineData("([{}])", true)]
    [InlineData("(([[{{}}]]))", true)]
    [InlineData("({[]})", true)]
    public void IsValid_ShouldReturnExpectedResult_ForBalancedInputs(string input, bool expected)
    {
        _service.IsValid(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("(", false)]
    [InlineData(")", false)]
    [InlineData("([)]", false)]
    [InlineData("([", false)]
    [InlineData("})", false)]
    [InlineData("(((()", false)]
    public void IsValid_ShouldReturnFalse_ForUnbalancedOrInvalidInputs(string input, bool expected)
    {
        _service.IsValid(input).Should().Be(expected);
    }
}
