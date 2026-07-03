using Persec.Console.Core.Interfaces;

namespace Persec.Console.Helpers;

/// <summary>
/// Runs the assessment demonstrations for each implemented question.
/// </summary>
public sealed class DemoRunner
{
    private readonly IBracketValidatorService _bracketValidatorService;
    private readonly ICustomStringSorterService _customStringSorterService;
    private readonly IAutocompleteService _autocompleteService;
    private readonly IRomanNumeralService _romanNumeralService;
    private readonly IDigitSorterService _digitSorterService;
    private readonly ITribonacciService _tribonacciService;

    public DemoRunner(
        IBracketValidatorService bracketValidatorService,
        ICustomStringSorterService customStringSorterService,
        IAutocompleteService autocompleteService,
        IRomanNumeralService romanNumeralService,
        IDigitSorterService digitSorterService,
        ITribonacciService tribonacciService)
    {
        _bracketValidatorService = bracketValidatorService;
        _customStringSorterService = customStringSorterService;
        _autocompleteService = autocompleteService;
        _romanNumeralService = romanNumeralService;
        _digitSorterService = digitSorterService;
        _tribonacciService = tribonacciService;
    }

    public void Run()
    {
        PrintSection("Question 1 - Bracket Validation");
        var bracketInput = "([{}])";
        System.Console.WriteLine($"Input: {bracketInput}");
        System.Console.WriteLine($"Is valid: {_bracketValidatorService.IsValid(bracketInput)}");

        PrintSection("Question 2 - Custom String Sorting");
        var sortItems = new[] { "TH19", "TH2", "TH3Netflix", "SG20" };
        System.Console.WriteLine($"Input: {string.Join(", ", sortItems)}");
        System.Console.WriteLine($"Sorted: {string.Join(", ", _customStringSorterService.Sort(sortItems))}");

        PrintSection("Question 3 - Autocomplete Search");
        var searchItems = new[] { "Alpha", "Alpine", "Albatross", "Beta", "Gamma" };
        System.Console.WriteLine("Search: al");
        System.Console.WriteLine($"Results: {string.Join(", ", _autocompleteService.Search("al", searchItems, 5))}");

        PrintSection("Question 4 - Roman Numerals");
        var value = 3999;
        var roman = _romanNumeralService.ToRoman(value);
        System.Console.WriteLine($"{value} -> {roman}");
        System.Console.WriteLine($"{roman} -> {_romanNumeralService.FromRoman(roman)}");

        PrintSection("Question 5 - Digit Sorting");
        var digitValue = 3008;
        System.Console.WriteLine($"{digitValue} -> {_digitSorterService.SortDescending(digitValue)}");

        PrintSection("Question 6 - Tribonacci Generation");
        var tribonacci = _tribonacciService.Generate(new[] { 1, 2, 3 }, 10);
        System.Console.WriteLine($"Sequence: {string.Join(", ", tribonacci)}");
    }

    private static void PrintSection(string title)
    {
        System.Console.WriteLine();
        System.Console.WriteLine(new string('-', 60));
        System.Console.WriteLine(title);
        System.Console.WriteLine(new string('-', 60));
    }
}
