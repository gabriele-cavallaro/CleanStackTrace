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
    public static string CleanStackTrace
    (
        string stackTrace,
        IEnumerable<IStackTraceLinesTransformer> linesTransformers,
        IEnumerable<IStackTraceLineTransformer> lineTransformers
    )
    {
        IEnumerable<string> lines = stackTrace
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        foreach (IStackTraceLinesTransformer transformer in linesTransformers)
            lines = transformer.Apply(lines);

        foreach (IStackTraceLineTransformer transformer in lineTransformers)
            lines = lines.Select(line => transformer.Apply(line))
                         .Where(line => line is not null)!;

        return string.Join(Environment.NewLine, lines);
    }

    /// <summary>
    /// Cleans and formats an exception's stack trace using provided transformers.
    /// Converts exception to string and applies cleaning transformations.
    /// </summary>
    public static string CleanStackTrace
    (
        Exception exception,
        IEnumerable<IStackTraceLinesTransformer> linesTransformers,
        IEnumerable<IStackTraceLineTransformer> lineTransformers
    )
        => CleanStackTrace(exception.ToString(), linesTransformers, lineTransformers);
}
