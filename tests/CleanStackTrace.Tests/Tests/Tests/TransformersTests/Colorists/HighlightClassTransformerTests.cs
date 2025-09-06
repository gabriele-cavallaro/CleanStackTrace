using CleanStackTrace.Transformers.Colorists;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Colorists;

public class HighlightClassTransformerTests
{
    private readonly HighlightClassTransformer _sut = new();

    [Theory]
    [InlineData
    (
        "UserController.GetUser(Guid id) line 27",
        "{ColorStart}UserController{ColorEnd}.GetUser(Guid id) line 27"
    )]
    [InlineData
    (
        "CleanStackTrace.Program.Main(String[] args)",
        "CleanStackTrace.{ColorStart}Program{ColorEnd}.Main(String[] args)"
    )]
    [InlineData
    (
        "CleanStackTrace.RandomNamespacePart.Class.Function()",
        "CleanStackTrace.RandomNamespacePart.{ColorStart}Class{ColorEnd}.Function()"
    )]
    [InlineData
    (
        "   WebApplicationExtensions.AutoOptionsMiddleware() line 40",
        "   {ColorStart}WebApplicationExtensions{ColorEnd}.AutoOptionsMiddleware() line 40"
    )]
    [InlineData
    (
        "lambda_method4(Closure, Object)",
        "lambda_method4(Closure, Object)"
    )]
    [InlineData
    (
        "NullReferenceException: Object reference not set",
        "NullReferenceException: Object reference not set"
    )]
    public void Apply_ShouldHighlightClassNames(string input, string expected)
    {
        expected = expected.Replace("{ColorStart}", _sut.ColorStart)
                           .Replace("{ColorEnd}", _sut.ColorEnd);

        string? result = _sut.Apply(input);

        Assert.Equal(expected, result);
    }
}
