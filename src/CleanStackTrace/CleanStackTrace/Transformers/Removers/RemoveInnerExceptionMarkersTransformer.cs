using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Removers;

/// <summary>
/// Removes inner exception end markers from stack traces.
/// </summary>
public class RemoveInnerExceptionMarkersTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// Filters out "--- End of inner exception" or similar marker lines.
    /// </summary>
    public string? Apply(string line)
        => line.Contains("--- End", StringComparison.Ordinal) ? null : line;
}
