using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Colorists;

/// <summary>
/// Highlights exception names color in stack traces with cyan ANSI color codes.
/// </summary>
public class HighlightFunctionsTransformer : IStackTraceLineTransformer
{
    private const string ColorStart = "\u001b[36m";
    private const string ColorEnd = "\u001b[0m";

    /// <summary>
    /// Applies cyan color highlighting to function names.
    /// Uses ANSI escape codes to emphasize method calls.
    /// </summary>
    public string? Apply(string line)
        => string.IsNullOrEmpty(line) ? line :
            RegexPatterns.FunctionFirm().Replace(line, $".{ColorStart}$1{ColorEnd}");
}
