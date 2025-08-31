using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Alterators;

/// <summary>
/// Simplifies fully qualified exception type names removing namespaces.
/// </summary>
public class SimplifyExceptionTypesTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// Shortens exception type names to their simple class name.
    /// Removes namespace prefixes for cleaner exception display.
    /// </summary>
    public string? Apply(string line)
        => RegexPatterns.ExceptionType().Replace(line, "$2");
}
