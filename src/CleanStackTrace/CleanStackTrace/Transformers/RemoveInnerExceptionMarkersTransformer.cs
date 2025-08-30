using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers;

internal class RemoveInnerExceptionMarkersTransformer : IStackTraceLineTransformer
{
    public string? Apply(string line)
        => line.Contains("--- End", StringComparison.Ordinal) ? null : line;
}
