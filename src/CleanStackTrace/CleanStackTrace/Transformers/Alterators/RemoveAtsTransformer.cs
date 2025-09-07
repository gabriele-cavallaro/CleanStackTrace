using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Alterators;

/// <summary>
/// Removes the "at " prefix from stack trace lines.
/// </summary>
public class RemoveAtsTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// Strips the "at " prefix from method location lines.
    /// </summary>
    public string? Apply(string line)
        => RegexPatterns.LeadingAtRegex().Replace(line, "$1");
}
