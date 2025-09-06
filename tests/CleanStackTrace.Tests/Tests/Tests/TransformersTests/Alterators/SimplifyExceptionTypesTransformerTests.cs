using CleanStackTrace.Transformers.Alterators;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Alterators;

public class SimplifyExceptionTypesTransformerTests
{
    private readonly SimplifyExceptionTypesTransformer _sut = new();

    [Theory]
    [InlineData
    (
        "System.NullReferenceException: Object reference not set",
        "NullReferenceException: Object reference not set"
    )]
    [InlineData
    (
        "System.ApplicationException: Error in the application.",
        "ApplicationException: Error in the application."
    )]
    [InlineData
    (
        "CleanStackTrace.Demo.CustomStackTraceException: Something went wrong",
        "CustomStackTraceException: Something went wrong"
    )]
    [InlineData
    (
        "CustomException: Already simple",
        "CustomException: Already simple"
    )]
    [InlineData
    (
        "   System.ArgumentException: Bad arg",
        "   ArgumentException: Bad arg"
    )]
    public void Apply_ShouldSimplifyExceptionTypeNames(string input, string expected)
    {
        string? result = _sut.Apply(input);

        Assert.Equal(expected, result);
    }
}
