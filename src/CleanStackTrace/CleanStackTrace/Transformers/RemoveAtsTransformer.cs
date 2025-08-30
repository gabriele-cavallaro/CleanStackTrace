using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers;

internal class RemoveAtsTransformer : IStackTraceLineTransformer
{
    public string? Apply(string line)
        => line.Replace("at ", "");
}
