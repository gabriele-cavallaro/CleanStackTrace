using CleanStackTrace.Interfaces;
using CleanStackTrace.Utils;

namespace CleanStackTrace.Transformers;

internal class RemoveLineOfBannedNamespacesTransformer : IStackTraceLineTransformer
{
    public string? Apply(string line)
        => BannedNamespaces.BannedNamespacesList.Any(ns => line.Contains(ns, StringComparison.Ordinal))
            ? null : line;
}
