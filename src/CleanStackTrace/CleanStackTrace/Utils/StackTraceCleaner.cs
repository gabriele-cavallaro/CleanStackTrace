using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Utils;

/// <summary>
/// Provides core stack trace cleaning functionality.
/// Applies transformers to clean and format exception stack traces.
/// </summary>
public static class StackTraceCleaner
{
    /// <summary>
    /// Cleans and formats a stack trace string using provided transformers.
    /// Applies line and multiline transformations in sequence.
    /// </summary>
    /// <exception cref="ArgumentNullException">If stackTrace is null</exception>
    /// <returns>Cleaned stack trace string</returns>
    public static string CleanStackTrace
    (
        string stackTrace,
        IEnumerable<IStackTraceLinesTransformer> linesTransformers,
        IEnumerable<IStackTraceLineTransformer> lineTransformers
    )
    {
        ArgumentNullException.ThrowIfNull(stackTrace);

        IEnumerable<string> lines = stackTrace
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        foreach (IStackTraceLinesTransformer transformer in linesTransformers)
            lines = transformer.Apply(lines);

        foreach (IStackTraceLineTransformer transformer in lineTransformers)
            lines = lines.Select(line => transformer.Apply(line))
                         .Where(line => !string.IsNullOrEmpty(line))!;

        return string.Join(Environment.NewLine, lines);
    }

    /// <summary>
    /// Cleans and formats an exception's stack trace using provided transformers.
    /// </summary>
    /// <exception cref="ArgumentNullException">If stackTrace is null</exception>
    /// <returns>Cleaned stack trace string</returns>
    public static string CleanStackTrace
    (
        Exception exception,
        IEnumerable<IStackTraceLinesTransformer> linesTransformers,
        IEnumerable<IStackTraceLineTransformer> lineTransformers
    )
        => CleanStackTrace(exception.ToString(), linesTransformers, lineTransformers);
}
