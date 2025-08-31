using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Removers;

/// <summary>
/// Removes the "at " prefix from stack trace lines.
/// </summary>
public class RemoveAtsTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// Strips the "at " prefix from method location lines.
    /// </summary>
    public string? Apply(string line)
        => line.Replace("at ", "");
}
