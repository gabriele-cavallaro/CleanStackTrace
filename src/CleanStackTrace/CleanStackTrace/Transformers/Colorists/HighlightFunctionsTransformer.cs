using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Colorists;

/// <summary>
/// Highlights function names color in stack traces with cyan ANSI color codes.
/// </summary>
public class HighlightFunctionsTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// ANSI escape sequence to start function names highlighting.
    /// Default: red (\u001b[36m).
    /// </summary>
    public string ColorStart { get; init; } = "\u001b[36m";

    /// <summary>
    /// ANSI escape sequence to reset highlighting.
    /// </summary>
    public string ColorEnd { get; init; } = "\u001b[0m";

    /// <summary>
    /// Applies cyan color highlighting to function names.
    /// Uses ANSI escape codes to emphasize method calls.
    /// </summary>
    public string? Apply(string line)
        => RegexPatterns.FunctionSignature().Replace(line, match =>
        {
            string dot = match.Groups["dot"].Success ? match.Groups["dot"].Value : "";
            string method = match.Groups["method"].Value;
            return $"{dot}{ColorStart}{method}{ColorEnd}";
        });
}
