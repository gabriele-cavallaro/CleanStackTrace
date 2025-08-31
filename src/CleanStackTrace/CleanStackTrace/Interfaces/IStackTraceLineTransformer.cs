namespace CleanStackTrace.Interfaces;

/// <summary>
/// Transforms or filters individual stack trace lines.
/// Used for per-line processing and cleanup operations.
/// </summary>
public interface IStackTraceLineTransformer
{
    /// <summary>
    /// Applies the transformation or filter to a line of stacktract.
    /// Returns null if the line should be removed.
    /// </summary>
    string? Apply(string line);
}
