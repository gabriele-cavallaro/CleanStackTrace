using System.Text.RegularExpressions;
using CleanStackTrace.Interfaces;
using CleanStackTrace.Utils;

namespace CleanStackTrace;

/// <summary>
/// Provides extension methods for <see cref="Exception"/> to generate cleaned and colorized stack traces.
/// </summary>
/// <remarks>
/// These methods transform raw exception stack traces into more readable formats by removing noise
/// and adding colorization for better visual distinction during debugging.
/// </remarks>
public static class ExceptionExtensions
{
    /// <summary>
    /// Transforms an exception's stack trace into a cleaned, more readable format by applying standard transformations.
    /// </summary>
    /// <param name="exception">The exception to process. Cannot be null.</param>
    /// <returns>A cleaned stack trace with improved readability, removing compiler-generated methods and noise.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="exception"/> is null.</exception>
    public static string GetCleanStackTrace(this Exception exception)
        => StackTraceCleaner.CleanStackTrace
        (
            exception,
            TransformerCollections.StandardLinesTransformers,
            TransformerCollections.StandardLineTransformers
        );

    /// <summary>
    /// Transforms an exception's stack trace using custom transformers.
    /// Allows customized cleaning with user-defined transformation rules.
    /// </summary>
    /// <param name="exception">The exception to process. Cannot be null.</param>
    /// <param name="linesTransformers">Custom multiline transformers to apply.</param>
    /// <param name="lineTransformers">Custom single-line transformers to apply.</param>
    /// <returns>A cleaned stack trace using the specified transformation rules.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="exception"/> is null.</exception>
    public static string GetCleanStackTrace
    (
        this Exception exception,
        IEnumerable<IStackTraceLinesTransformer> linesTransformers,
        IEnumerable<IStackTraceLineTransformer> lineTransformers
    )
        => StackTraceCleaner.CleanStackTrace
        (
            exception,
            linesTransformers,
            lineTransformers
        );

    /// <summary>
    /// Transforms an exception's stack trace into a cleaned format with colorization for better visual distinction.
    /// </summary>
    /// <param name="exception">The exception to process. Cannot be null.</param>
    /// <returns>A colorized and cleaned stack trace with ANSI color codes or HTML spans for coloring.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="exception"/> is null.</exception>
    public static string GetColoredCleanStackTrace(this Exception exception)
        => StackTraceCleaner.CleanStackTrace
            (
                exception,
                TransformerCollections.StandardLinesTransformers,
                TransformerCollections.ColoredLineTransformers
            );

    public static string GetSingleLineStackTrace(this Exception ex)
    {
        string cleanStack = ex.GetCleanStackTrace();

        string[] lines = cleanStack
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        string exceptionType = ex.GetType().Name;
        string message = ex.Message;

        string? firstFrame = lines
            .Skip(1)
            .FirstOrDefault(l => !l.Contains("Exception"));

        if (firstFrame is null)
            return $"Encountered a {exceptionType} with message \"{message}\".";

        Match match = RegexPatterns.ClassMethodNameAndLineNumber().Match(firstFrame);
        if (!match.Success)
            return $"Encountered a {exceptionType} with message \"{message}\" while executing {firstFrame}.";

        string method = match.Groups["method"].Value.TrimStart();
        string line = match.Groups["line"].Success ? $" at line {match.Groups["line"].Value}" : string.Empty;

        return $"Encountered a {exceptionType} with message \"{message}\" while executing {method}{line}.";
    }
}
