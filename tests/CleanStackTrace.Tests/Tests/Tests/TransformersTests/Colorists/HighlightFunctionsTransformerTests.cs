using CleanStackTrace.Transformers.Colorists;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Colorists;

public class HighlightFunctionsTransformerTests
{
    private readonly HighlightFunctionsTransformer _sut = new();

    [Theory]
    [InlineData
    (
        "UserController.GetUser(Guid id) line 27",
        "UserController.{ColorStart}GetUser(Guid id){ColorEnd} line 27"
    )]
    [InlineData
    (
        "CleanStackTrace.Program.Main(String[] args)",
        "CleanStackTrace.Program.{ColorStart}Main(String[] args){ColorEnd}"
    )]
    [InlineData
    (
        "CleanStackTrace.RandomNamespacePart.Class.Function()",
        "CleanStackTrace.RandomNamespacePart.Class.{ColorStart}Function(){ColorEnd}"
    )]
    [InlineData
    (
        "CleanStackTrace.RandomNamespacePart.Class.Function(...)",
        "CleanStackTrace.RandomNamespacePart.Class.{ColorStart}Function(...){ColorEnd}"
    )]
    [InlineData
    (
        "   WebApplicationExtensions.AutoOptionsMiddleware() line 40",
        "   WebApplicationExtensions.{ColorStart}AutoOptionsMiddleware(){ColorEnd} line 40"
    )]
    [InlineData
    (
        "lambda_method4(Closure, Object)",
        "{ColorStart}lambda_method4(Closure, Object){ColorEnd}"
    )]
    [InlineData
    (
        "NullReferenceException: Object reference not set",
        "NullReferenceException: Object reference not set"
    )]
    public void Apply_Should_HighlightClassNames(string input, string expected)
    {
        expected = expected.Replace("{ColorStart}", _sut.ColorStart)
                           .Replace("{ColorEnd}", _sut.ColorEnd);

        string? result = _sut.Apply(input);

        Assert.Equal(expected, result);
    }
}
