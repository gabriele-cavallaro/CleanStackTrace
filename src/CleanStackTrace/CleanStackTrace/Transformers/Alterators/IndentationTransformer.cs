using CleanStackTrace.Interfaces;

namespace CleanStackTrace.Transformers.Alterators;

/// <summary>
/// Adds indentation to nested exception stack traces.
/// </summary>
public class IndentationTransformer : IStackTraceLinesTransformer
{
    /// <summary>
    /// Applies progressive indentation to nested exception lines and their end markers.
    /// </summary>
    public IEnumerable<string> Apply(IEnumerable<string> lines)
    {
        int indentLevel = 0;

        string result;
        foreach (string line in lines)
        {
            if (line.Contains("---> ") || line.Contains("--- End"))
                indentLevel += 2;

            result = new string(' ', indentLevel) + line;

            yield return result;
        }
    }
}
