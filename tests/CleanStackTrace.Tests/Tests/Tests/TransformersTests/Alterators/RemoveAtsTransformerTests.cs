using CleanStackTrace.Transformers.Alterators;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Alterators;

public class RemoveAtsTransformerTests
{
    private readonly RemoveAtsTransformer _sut = new();

    [Theory]
    [InlineData
    (
        "at CleanStackTrace.Program.Main(String[] args)",
        "CleanStackTrace.Program.Main(String[] args)"
    )]
    [InlineData
    (
        "at UserController.GetUser(Guid id) line 27",
        "UserController.GetUser(Guid id) line 27"
    )]
    [InlineData
    (
        "   at WebApplicationExtensions.AutoOptionsMiddleware() line 40",
        "   WebApplicationExtensions.AutoOptionsMiddleware() line 40"
    )]
    [InlineData
    (
        "Some text without prefix",
        "Some text without prefix"
    )]
    [InlineData
    (
        "Location at CleanStackTrace.Program",
        "Location at CleanStackTrace.Program"
    )]
    public void Apply_Should_RemoveAtPrefix(string input, string expected)
    {
        string? result = _sut.Apply(input);

        Assert.Equal(expected, result);
    }
}
