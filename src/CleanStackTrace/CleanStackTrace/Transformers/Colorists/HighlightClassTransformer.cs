using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Colorists;

/// <summary>
/// Highlights class names color in stack traces with blue ANSI color codes.
/// </summary>
public class HighlightClassTransformer : IStackTraceLineTransformer
{
    private const string ColorStart = "\u001b[34m";
    private const string ColorEnd = "\u001b[0m";

    /// <summary>
    /// Applies blue color highlighting to class names.
    /// Uses ANSI escape codes for terminal colorization.
    /// </summary>
    public string? Apply(string line)
        => RegexPatterns.ClassName().Replace(line, $"{ColorStart}$1{ColorEnd}");
}
