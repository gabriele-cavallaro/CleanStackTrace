using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Tests.Utils;

internal class LambdaLineTransformer(Func<string, string?> transformFunc) : IStackTraceLineTransformer
{
    private readonly Func<string, string?> _transformFunc = transformFunc;

    public string? Apply(string line) => _transformFunc(line);
}
