using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers;

internal class HighlightLineNumberTransformer : IStackTraceLineTransformer
{
    private const string ColorStart = "\u001b[33m";
    private const string ColorEnd = "\u001b[0m";

    public string? Apply(string line)
        => string.IsNullOrEmpty(line) ? line :
            RegexPatterns.LineNumber().Replace(line, $"{ColorStart}line $1{ColorEnd}");
}
