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
    {
        IEnumerable<string> lines = exception.ToString()
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        foreach (IStackTraceLinesTransformer transformer in TransformerCollections.StandardLinesTransformers)
            lines = transformer.Apply(lines);

        foreach (IStackTraceLineTransformer transformer in TransformerCollections.StandardLineTransformers)
            lines = lines.Select(line => transformer.Apply(line))
                         .Where(line => line is not null)!;

        return string.Join(Environment.NewLine, lines);
    }

    /// <summary>
    /// Transforms an exception's stack trace into a cleaned format with colorization for better visual distinction.
    /// </summary>
    /// <param name="exception">The exception to process. Cannot be null.</param>
    /// <returns>A colorized and cleaned stack trace with ANSI color codes or HTML spans for coloring.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="exception"/> is null.</exception>
    public static string GetColoredCleanStackTrace(this Exception exception)
    {
        IEnumerable<string> lines = exception.ToString()
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        foreach (IStackTraceLinesTransformer transformer in TransformerCollections.StandardLinesTransformers)
            lines = transformer.Apply(lines);

        foreach (IStackTraceLineTransformer transformer in TransformerCollections.ColoredLineTransformers)
            lines = lines.Select(line => transformer.Apply(line))
                         .Where(line => line is not null)!;

        return string.Join(Environment.NewLine, lines);
    }
}
