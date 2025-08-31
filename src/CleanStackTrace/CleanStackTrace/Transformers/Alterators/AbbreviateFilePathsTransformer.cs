using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Alterators;

/// <summary>
/// Removes full directory paths, namespaces and simplifies method names in stack trace lines.
/// </summary>
public class AbbreviateFilePathsTransformer : IStackTraceLineTransformer
{
    private static bool IsPrefixChar(char c)
        => c is ' ' or '>' or '-' or 'a';

    /// <summary>
    /// Shortens file paths and simplifies namespace references.
    /// Preserves line prefixes while cleaning up the content.
    /// </summary>
    public string? Apply(string line)
    {
        int prefixLength = line.TakeWhile(IsPrefixChar).Count();
        string prefix = line[..prefixLength];
        string body = line[prefixLength..];

        body = RegexPatterns.FilePath().Replace(body, "$1");
        body = RegexPatterns.NamespaceMethod().Replace(body, "$1");

        return prefix + body;
    }
}
