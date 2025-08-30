using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers;

internal class HighlightClassTransformer : IStackTraceLineTransformer
{
    private const string ColorStart = "\u001b[34m";
    private const string ColorEnd = "\u001b[0m";

    public string? Apply(string line)
        => string.IsNullOrEmpty(line) ? line :
            RegexPatterns.ClassName().Replace(line, $"{ColorStart}$1{ColorEnd}");
}
