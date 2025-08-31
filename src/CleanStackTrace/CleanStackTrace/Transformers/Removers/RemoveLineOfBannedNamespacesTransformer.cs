using CleanStackTrace.Interfaces;
using CleanStackTrace.Utils;

namespace CleanStackTrace.Transformers.Removers;

/// <summary>
/// Removes stack trace lines containing banned namespace references.
/// Filters out framework and system internal namespace noise.
/// </summary>
public class RemoveLineOfBannedNamespacesTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// Filters lines containing banned namespace patterns.
    /// Removes framework internals and system namespace clutter.
    /// </summary>
    public string? Apply(string line)
        => BannedNamespaces.BannedNamespacesList.Any(ns => line.Contains(ns, StringComparison.Ordinal))
            ? null : line;
}
