namespace Persec.Console.Core.Interfaces;

/// <summary>
/// Validates whether a string contains properly nested and ordered brackets.
/// </summary>
public interface IBracketValidatorService
{
    /// <summary>
    /// Determines whether the supplied input contains valid bracket ordering.
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <returns><see langword="true"/> when the bracket sequence is valid; otherwise, <see langword="false"/>.</returns>
    bool IsValid(string input);
}
