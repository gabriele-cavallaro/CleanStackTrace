using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Colorists;

/// <summary>
/// Highlights exception names color in stack traces with red ANSI color codes.
/// </summary>
public class HighlightExceptionTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// ANSI escape sequence to start exception name highlighting.
    /// Default: red (\u001b[31m).
    /// </summary>
    public string ColorStart { get; init; } = "\u001b[31m";

    /// <summary>
    /// ANSI escape sequence to reset highlighting.
    /// </summary>
    public string ColorEnd { get; init; } = "\u001b[0m";

    /// <summary>
    /// Applies red color highlighting to exception type names.
    /// Uses ANSI escape codes to make exceptions stand out.
    /// </summary>
    public string? Apply(string line)
        => RegexPatterns.ExceptionName().Replace(line, $"{ColorStart}$1{ColorEnd}$2");
}
