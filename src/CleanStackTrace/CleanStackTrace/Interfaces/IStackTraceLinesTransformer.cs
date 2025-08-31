namespace CleanStackTrace.Interfaces;

/// <summary>
/// Transforms or filters multiple stack trace lines.
/// Used to apply bulk operations on complete stack traces.
/// </summary>
public interface IStackTraceLinesTransformer
{
    /// <summary>
    /// Applies the transformation or filter to all lines of stacktrace.
    /// Returns an empty collection if all lines should be removed.
    /// </summary>
    IEnumerable<string> Apply(IEnumerable<string> lines);
}
