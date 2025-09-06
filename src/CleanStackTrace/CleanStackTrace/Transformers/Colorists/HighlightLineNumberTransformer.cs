using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Colorists;

/// <summary>
/// Highlights line number color in stack traces with yellow ANSI color codes.
/// </summary>
public class HighlightLineNumberTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// ANSI escape sequence to start line number color highlighting.
    /// Default: yellow (\u001b[33m).
    /// </summary>
    public string ColorStart { get; init; } = "\u001b[33m";

    /// <summary>
    /// ANSI escape sequence to reset highlighting.
    /// </summary>
    public string ColorEnd { get; init; } = "\u001b[0m";

    /// <summary>
    /// Applies yellow color highlighting to line number.
    /// Uses ANSI escape codes to emphasize method calls.
    /// </summary>
    public string? Apply(string line)
        => RegexPatterns.LineNumber().Replace(line, $"{ColorStart}line $1{ColorEnd}");
}
