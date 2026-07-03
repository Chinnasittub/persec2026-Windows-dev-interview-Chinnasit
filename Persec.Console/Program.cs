using Microsoft.Extensions.DependencyInjection;
using Persec.Console.Core.Interfaces;
using Persec.Console.Helpers;
using Persec.Console.Services;

namespace Persec.Console;

/// <summary>
/// Entry point for the assessment console application.
/// </summary>
public static class Program
{
    /// <summary>
    /// Configures dependency injection and runs the demonstration scenarios.
    /// </summary>
    public static void Main()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IBracketValidatorService, BracketValidatorService>();
        services.AddSingleton<ICustomStringSorterService, CustomStringSorterService>();
        services.AddSingleton<IAutocompleteService, AutocompleteService>();
        services.AddSingleton<IRomanNumeralService, RomanNumeralService>();
        services.AddSingleton<IDigitSorterService, DigitSorterService>();
        services.AddSingleton<ITribonacciService, TribonacciService>();
        services.AddSingleton<DemoRunner>();

        using var serviceProvider = services.BuildServiceProvider();

        var demoRunner = serviceProvider.GetRequiredService<DemoRunner>();
        demoRunner.Run();
    }
}
