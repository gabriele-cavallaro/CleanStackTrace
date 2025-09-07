using System.Text.RegularExpressions;
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
    {
        Match match = RegexPatterns.NamespaceName().Match(line);

        if (match.Success && match.Groups[1].Captures.Count > 0)
        {
            string firstCapture = match.Groups[1].Captures[0].Value;
            if (BannedNamespaces.BannedNamespacesList.Any(ns => firstCapture.Equals(ns, StringComparison.Ordinal)))
                return null;
        }

        return line;
    }
}
