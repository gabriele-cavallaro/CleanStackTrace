using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Colorists;

/// <summary>
/// Highlights exception names color in stack traces with red ANSI color codes.
/// </summary>
public class HighlightExceptionTransformer : IStackTraceLineTransformer
{
    private const string ColorStart = "\u001b[31m";
    private const string ColorEnd = "\u001b[0m";

    /// <summary>
    /// Applies red color highlighting to exception type names.
    /// Uses ANSI escape codes to make exceptions stand out.
    /// </summary>
    public string? Apply(string line)
        => string.IsNullOrEmpty(line) ? line :
            RegexPatterns.ExceptionName().Replace(line, $"{ColorStart}$1{ColorEnd}$2");
}
