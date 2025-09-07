using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Tests.Utils;

internal class LambdaLinesTransformer(Func<IEnumerable<string>, IEnumerable<string>> transformFunc) : IStackTraceLinesTransformer
{
    private readonly Func<IEnumerable<string>, IEnumerable<string>> _transformFunc = transformFunc;

    public IEnumerable<string> Apply(IEnumerable<string> lines) => _transformFunc(lines);
}
