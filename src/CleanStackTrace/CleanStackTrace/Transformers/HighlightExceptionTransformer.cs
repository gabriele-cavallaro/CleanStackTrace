using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers;

internal class HighlightExceptionTransformer : IStackTraceLineTransformer
{
    private const string ColorStart = "\u001b[31m";
    private const string ColorEnd = "\u001b[0m";

    public string? Apply(string line)
        => string.IsNullOrEmpty(line) ? line :
            RegexPatterns.ExceptionName().Replace(line, $"{ColorStart}$1{ColorEnd}$2");
}
