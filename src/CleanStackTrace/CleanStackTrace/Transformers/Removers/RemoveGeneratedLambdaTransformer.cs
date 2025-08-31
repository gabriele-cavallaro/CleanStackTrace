using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Removers;

/// <summary>
/// Filters out compiler-generated lambda method lines from stack traces.
/// Removes noise from anonymous function compiler implementations.
/// </summary>
public class RemoveGeneratedLambdaTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// Removes lines containing lambda compiler-generated methods.
    /// </summary>
    public string? Apply(string line)
        => line.Contains("lambda_", StringComparison.Ordinal) ? null : line;
}
