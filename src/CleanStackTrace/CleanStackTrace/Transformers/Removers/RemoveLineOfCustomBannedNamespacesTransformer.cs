using CleanStackTrace.Interfaces;
using CleanStackTrace.Utils;

namespace CleanStackTrace.Transformers.Removers;

/// <summary>
/// Removes stack trace lines containing custom banned namespace references.
/// Filters user-defined namespace patterns from stack trace output.
/// </summary>
public class RemoveLineOfCustomBannedNamespacesTransformer : IStackTraceLineTransformer
{
    /// <summary>
    /// Filters lines containing custom banned namespace patterns.
    /// Removes user-specified namespace clutter from stack traces.
    /// </summary>
    public string? Apply(string line)
        => BannedNamespaces.CustomBannedNamespacesList.Any(ns => line.Contains(ns, StringComparison.Ordinal))
            ? null : line;
}
