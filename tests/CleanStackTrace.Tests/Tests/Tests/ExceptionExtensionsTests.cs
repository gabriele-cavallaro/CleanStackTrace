using CleanStackTrace.Tests.Utils;

namespace CleanStackTrace.Tests.Tests;

public class ExceptionExtensionsTests
{
    [Fact]
    public void GetSingleLineStackTrace_ShouldHandle_ExceptionWithoutStackTrace()
    {
        Exception ex = new ("Something went wrong");

        string summary = ex.GetSingleLineStackTrace();

        Assert.Equal("Encountered a Exception with message \"Something went wrong\".", summary);
    }

    [Theory]
    [InlineData
    (
        "A wrong situation",
        """
        CustomStackTraceException: A wrong situation
          UserController.GetUser(Guid id) line 27
        """,
        "Encountered a CustomStackTraceException with message \"A wrong situation\" while executing UserController.GetUser(Guid id) at line 27."
    )]
    [InlineData
    (
        "Boom!",
        """
        CustomStackTraceException: Boom!
          Worker.DoWork()
        """,
        "Encountered a CustomStackTraceException with message \"Boom!\" while executing Worker.DoWork()."
    )]
    [InlineData
    (
        "Boom!",
        """
        CustomStackTraceException: Boom!
          Worker.DoWork(Guid id)
        """,
        "Encountered a CustomStackTraceException with message \"Boom!\" while executing Worker.DoWork(Guid id)."
    )]
    public void GetSingleLineStackTrace_ShouldInclude_MethodAndLine_WhenAvailable(string message, string stacktrace, string expectedResult)
    {
        CustomStackTraceException ex = new(message, stacktrace);

        string summary = ex.GetSingleLineStackTrace();

        Assert.Equal(expectedResult, summary);
    }
}
