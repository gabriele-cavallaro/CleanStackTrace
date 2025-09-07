using CleanStackTrace.Transformers.Colorists;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Colorists;

public class HighlightExceptionTransformerTests
{
    private readonly HighlightExceptionTransformer _sut = new();

    [Theory]
    [InlineData
    (
        "NullReferenceException: Object reference not set",
        "{ColorStart}NullReferenceException{ColorEnd}: Object reference not set"
    )]
    [InlineData
    (
        "CustomStackTraceException: A wrong situation",
        "{ColorStart}CustomStackTraceException{ColorEnd}: A wrong situation"
    )]
    [InlineData
    (
        "ApplicationException",
        "{ColorStart}ApplicationException{ColorEnd}"
    )]
    [InlineData
    (
        "   ---> InvalidOperationException: Sequence contains no elements",
        "   ---> {ColorStart}InvalidOperationException{ColorEnd}: Sequence contains no elements"
    )]
    [InlineData
    (
        "SomeClass.SomeMethod() line 42",
        "SomeClass.SomeMethod() line 42"
    )]
    public void Apply_Should_HighlightExceptionNames(string input, string expected)
    {
        expected = expected.Replace("{ColorStart}", _sut.ColorStart)
                           .Replace("{ColorEnd}", _sut.ColorEnd);

        string? result = _sut.Apply(input);

        Assert.Equal(expected, result);
    }
}
