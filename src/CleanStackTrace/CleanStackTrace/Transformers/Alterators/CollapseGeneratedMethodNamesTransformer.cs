using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Alterators;

/// <summary>
/// Collapses compiler-generated method names in stack traces.
/// Simplifies lambda methods and state machine generated code.
/// </summary>
public class CollapseGeneratedMethodNamesTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// Replaces complex generated method names with simplified versions.
    /// Removes compiler-specific noise from stack trace lines.
    /// </summary>
    public string? Apply(string line)
        => RegexPatterns.GeneratedMethodNames().Replace(line, ".$1() $3");
}
