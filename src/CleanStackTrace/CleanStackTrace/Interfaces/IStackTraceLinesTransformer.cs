namespace CleanStackTrace.Interfaces;

internal interface IStackTraceLinesTransformer
{
    /// <summary>
    /// Applies the transformation or filter to all lines of stacktrace.
    /// Returns an empty collection if all lines should be removed.
    /// </summary>
    IEnumerable<string> Apply(IEnumerable<string> lines);
}
