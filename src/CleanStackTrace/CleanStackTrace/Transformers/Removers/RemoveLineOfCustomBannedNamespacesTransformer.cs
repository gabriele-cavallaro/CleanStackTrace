using System.Text.RegularExpressions;
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
    {
        Match match = RegexPatterns.NamespaceName().Match(line);

        if (match.Success && match.Groups[1].Captures.Count > 0)
        {
            string firstCapture = match.Groups[1].Captures[0].Value;
            if (BannedNamespaces.CustomBannedNamespacesList.Any(ns => firstCapture.Equals(ns, StringComparison.Ordinal)))
                return null;
        }

        return line;
    }
}
