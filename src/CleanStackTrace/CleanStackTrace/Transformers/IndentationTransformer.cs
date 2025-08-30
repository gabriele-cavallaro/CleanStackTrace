using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers;

internal class IndentationTransformer : IStackTraceLinesTransformer
{
    public IEnumerable<string> Apply(IEnumerable<string> lines)
    {
        int indentLevel = 0;

        foreach (string line in lines)
        {
            string result = line;

            if (line.Contains("---> ") || line.Contains("--- End"))
            {
                indentLevel += 2;
                result = new string(' ', indentLevel) + line;
            }
            else
            {
                result = new string(' ', indentLevel) + line;
            }

            yield return result;
        }
    }
}
