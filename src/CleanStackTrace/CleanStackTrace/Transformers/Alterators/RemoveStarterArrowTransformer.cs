using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Alterators;

/// <summary>
/// Removes the starter arrow from inner exception lines.
/// </summary>
public class RemoveStarterArrowTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// Strips the "---> " prefix from inner exception markers.
    /// </summary>
    public string? Apply(string line)
        => line.Replace(" ---> ", "");
}
