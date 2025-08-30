using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers;

internal class RemoveGeneratedLambdaTransformer : IStackTraceLineTransformer
{
    public string? Apply(string line)
        => line.Contains("lambda_", StringComparison.Ordinal) ? null : line;
}
