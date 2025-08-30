using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers;

internal class SimplifyExceptionTypesTransformer : IStackTraceLineTransformer
{
    public string? Apply(string line)
        => RegexPatterns.ExceptionType().Replace(line, "$2");
}
