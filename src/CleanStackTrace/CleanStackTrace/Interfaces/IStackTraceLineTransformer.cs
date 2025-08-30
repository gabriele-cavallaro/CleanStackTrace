namespace CleanStackTrace.Interfaces;

internal interface IStackTraceLineTransformer
{
    /// <summary>
    /// Applies the transformation or filter to a line of stacktract.
    /// Returns null if the line should be removed.
    /// </summary>
    string? Apply(string line);
}
