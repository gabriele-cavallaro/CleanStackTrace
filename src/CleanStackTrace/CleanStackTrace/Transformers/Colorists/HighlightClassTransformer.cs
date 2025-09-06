using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Colorists;

/// <summary>
/// Highlights class names color in stack traces with blue ANSI color codes.
/// </summary>
public class HighlightClassTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// ANSI escape sequence to start class name highlighting.
    /// Default: blue (\u001b[34m).
    /// </summary>
    public string ColorStart { get; init; } = "\u001b[34m";

    /// <summary>
    /// ANSI escape sequence to reset highlighting.
    /// </summary>
    public string ColorEnd { get; init; } = "\u001b[0m";

    /// <summary>
    /// Applies blue color highlighting to class names.
    /// Uses ANSI escape codes for terminal colorization.
    /// </summary>
    public string? Apply(string line)
        => RegexPatterns.ClassName().Replace(line, $"$1{ColorStart}$2{ColorEnd}");
}
