using System.Text.RegularExpressions;

namespace CleanStackTrace;

/// <summary>
/// Provides compiled regex patterns for stack trace processing.
/// Contains optimized patterns for common stack trace elements.
/// </summary>
public static partial class RegexPatterns
{
    [GeneratedRegex(@"in .*?:(line \d+)", RegexOptions.Compiled)]
    public static partial Regex FilePath();

    [GeneratedRegex(@"(?:^\s*)?(?:at\s*)?(\w*).", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    public static partial Regex NamespaceName();

    [GeneratedRegex(@"(?:[\w\.]+)\.(\w+\.\w+\(.*\))", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    public static partial Regex NamespaceMethod();

    [GeneratedRegex(@"([\w\.]+)\.(\w+Exception:.*)", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    public static partial Regex ExceptionType();

    [GeneratedRegex(@"([\w\.]+Exception)(.*)", RegexOptions.Compiled)]
    public static partial Regex ExceptionName();

    [GeneratedRegex(@"((?:[\w]+\.)*)([A-Z][\w]+)(?=\.\w+\()", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    public static partial Regex ClassName();

    [GeneratedRegex(@"(?<dot>\.)?(?<method>[A-Za-z_]\w*\(.*?\))", RegexOptions.Compiled)]
    public static partial Regex FunctionSignature();

    [GeneratedRegex(@"([\w\s\.]+)[.+].*<(\w+)>.+MoveNext(.+)", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    public static partial Regex AsyncStateMachine();

    [GeneratedRegex(@"(.+\.\w+\.)(<>\w*\.)<(\w*)>\w*\w*(\(.*\))", RegexOptions.Compiled)]
    public static partial Regex DisplayClassLambda();

    [GeneratedRegex(@"\blambda_method\d+\b", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    public static partial Regex LambdaGeneratedRegex();

    [GeneratedRegex(@"\.<>c\.<<(\w+)>b__\d+_\d+>d\.(\w+)...(line \d+)?", RegexOptions.Compiled)]
    public static partial Regex AnomalousGeneratedMethod();

    [GeneratedRegex(@"^(\s*)at\s+", RegexOptions.Compiled)]
    public static partial Regex LeadingAtRegex();

    [GeneratedRegex(@"\bline\s+(\d+)\b", RegexOptions.Compiled)]
    public static partial Regex LineNumber();
}
