namespace CleanStackTrace.Tests.Utils;

public class CustomStackTraceException(string message, string stack) : Exception(message)
{
    private readonly string _stack = stack;
    public override string StackTrace => _stack;
}
