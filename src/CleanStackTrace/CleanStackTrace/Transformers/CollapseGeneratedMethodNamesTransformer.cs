using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers;

internal class CollapseGeneratedMethodNamesTransformer : IStackTraceLineTransformer
{
    public string? Apply(string line)
        => RegexPatterns.GeneratedMethodNames().Replace(line, ".$1() $3");
}
