using CleanStackTrace.Transformers.Colorists;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Colorists;

public class HighlightLineNumberTransformerTests
{
    private readonly HighlightLineNumberTransformer _sut = new();

    [Theory]
    [InlineData
    (
        "UserController.GetUser(Guid id) line 27",
        "UserController.GetUser(Guid id) {ColorStart}line 27{ColorEnd}"
    )]
    [InlineData
    (
        "   WebApplicationExtensions.AutoOptionsMiddleware() line 40",
        "   WebApplicationExtensions.AutoOptionsMiddleware() {ColorStart}line 40{ColorEnd}"
    )]
    [InlineData
    (
        "CleanStackTrace.Program.Main(String[] args) line 100",
        "CleanStackTrace.Program.Main(String[] args) {ColorStart}line 100{ColorEnd}"
    )]
    [InlineData
    (
        "CleanStackTrace.RandomNamespacePart.Class.Function(...) line 10",
        "CleanStackTrace.RandomNamespacePart.Class.Function(...) {ColorStart}line 10{ColorEnd}"
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
    public void Apply_Should_HighlightLineNumbers(string input, string expected)
    {
        expected = expected.Replace("{ColorStart}", _sut.ColorStart)
                           .Replace("{ColorEnd}", _sut.ColorEnd);

        string? result = _sut.Apply(input);

        Assert.Equal(expected, result);
    }
}
