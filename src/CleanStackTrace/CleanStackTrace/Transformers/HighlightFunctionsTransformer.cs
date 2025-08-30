using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers;

internal class HighlightFunctionsTransformer : IStackTraceLineTransformer
{
    private const string ColorStart = "\u001b[36m";
    private const string ColorEnd = "\u001b[0m";

    public string? Apply(string line)
        => string.IsNullOrEmpty(line) ? line :
            RegexPatterns.FunctionFirm().Replace(line, $".{ColorStart}$1{ColorEnd}");
}
