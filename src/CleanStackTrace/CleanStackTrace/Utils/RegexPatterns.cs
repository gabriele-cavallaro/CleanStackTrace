using System.Text.RegularExpressions;

namespace CleanStackTrace;

/// <summary>
/// Provides compiled regex patterns for stack trace processing.
/// Contains optimized patterns for common stack trace elements.
/// </summary>
public static partial class RegexPatterns
{
    [GeneratedRegex(@"in .*?:(line \d+)")]
    public static partial Regex FilePath();

    [GeneratedRegex(@"(?:[\w\.]+)\.(\w+\.\w+\(.*\))")]
    public static partial Regex NamespaceMethod();

    [GeneratedRegex(@"([\w\.]+)\.(\w+Exception:.*)")]
    public static partial Regex ExceptionType();

    [GeneratedRegex(@"([\w\.]+Exception)(:.*)")]
    public static partial Regex ExceptionName();

    [GeneratedRegex(@"\b([A-Z]\w+)(?=\.)")]
    public static partial Regex ClassName();

    [GeneratedRegex(@"\.(\w+\(.*?\))")]
    public static partial Regex FunctionSignature();

    [GeneratedRegex(@"\.<>c\.<<(\w+)>b__\d+_\d+>d\.(\w+)...(line \d+)?")]
    public static partial Regex GeneratedMethodNames();

    [GeneratedRegex(@"\bline\s+(\d+)\b")]
    public static partial Regex LineNumber();
}
