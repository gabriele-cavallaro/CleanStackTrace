using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Colorists;

/// <summary>
/// Highlights line number color in stack traces with yellow ANSI color codes.
/// </summary>
public class HighlightLineNumberTransformer : IStackTraceLineTransformer
{
    private const string ColorStart = "\u001b[33m";
    private const string ColorEnd = "\u001b[0m";

    /// <summary>
    /// Applies yellow color highlighting to line number.
    /// Uses ANSI escape codes to emphasize method calls.
    /// </summary>
    public string? Apply(string line)
        => string.IsNullOrEmpty(line) ? line :
            RegexPatterns.LineNumber().Replace(line, $"{ColorStart}line $1{ColorEnd}");
}
