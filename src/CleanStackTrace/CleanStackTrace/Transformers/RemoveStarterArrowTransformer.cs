using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers;

internal class RemoveStarterArrowTransformer : IStackTraceLineTransformer
{
    public string? Apply(string line)
        => line.Replace(" ---> ", "");
}
