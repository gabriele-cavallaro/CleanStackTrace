using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers;

internal class AbbreviateFilePathsTransformer : IStackTraceLineTransformer
{
    private static bool IsPrefixChar(char c)
        => c is ' ' or '>' or '-' or 'a';

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
