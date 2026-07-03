using FluentAssertions;
using Persec.Console.Core.Interfaces;
using Persec.Console.Services;

namespace Persec.Tests;

public class RomanNumeralServiceTests
{
    private readonly IRomanNumeralService _service = new RomanNumeralService();

    [Theory]
    [InlineData(1, "I")]
    [InlineData(4, "IV")]
    [InlineData(9, "IX")]
    [InlineData(40, "XL")]
    [InlineData(90, "XC")]
    [InlineData(400, "CD")]
    [InlineData(900, "CM")]
    [InlineData(3999, "MMMCMXCIX")]
    public void ToRoman_ShouldConvertExpectedValues(int value, string expected)
    {
        _service.ToRoman(value).Should().Be(expected);
    }

    [Theory]
    [InlineData("I", 1)]
    [InlineData("IV", 4)]
    [InlineData("IX", 9)]
    [InlineData("XL", 40)]
    [InlineData("XC", 90)]
    [InlineData("CD", 400)]
    [InlineData("CM", 900)]
    [InlineData("MMMCMXCIX", 3999)]
    public void FromRoman_ShouldConvertExpectedValues(string roman, int expected)
    {
        _service.FromRoman(roman).Should().Be(expected);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(4000)]
    public void ToRoman_ShouldThrow_WhenValueIsOutOfRange(int value)
    {
        Action act = () => _service.ToRoman(value);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData("IIII")]
    [InlineData("VX")]
    [InlineData("IC")]
    [InlineData("MCMC")]
    [InlineData("")]
    public void FromRoman_ShouldThrow_WhenValueIsInvalid(string roman)
    {
        Action act = () => _service.FromRoman(roman);

        act.Should().Throw<ArgumentException>();
    }
}
