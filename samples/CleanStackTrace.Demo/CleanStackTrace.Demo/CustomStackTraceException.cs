namespace CleanStackTrace.Demo;

public class CustomStackTraceException : Exception
{
    private readonly string _customStackTrace;

    public CustomStackTraceException(string message, Exception innerException, string customStackTrace)
        : base(message, innerException)
    {
        _customStackTrace = customStackTrace;
    }

    public override string StackTrace => _customStackTrace;
}

