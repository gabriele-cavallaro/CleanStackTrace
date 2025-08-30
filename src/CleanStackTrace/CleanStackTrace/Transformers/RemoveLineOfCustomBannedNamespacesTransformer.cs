using CleanStackTrace.Interfaces;
using CleanStackTrace.Utils;

namespace CleanStackTrace.Transformers;

internal class RemoveLineOfCustomBannedNamespacesTransformer : IStackTraceLineTransformer
{
    public string? Apply(string line)
        => BannedNamespaces.CustomBannedNamespacesList.Any(ns => line.Contains(ns, StringComparison.Ordinal))
            ? null : line;
}
