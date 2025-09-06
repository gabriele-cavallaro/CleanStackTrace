using CleanStackTrace.Transformers.Alterators;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Alterators;

public class RemoveStarterArrowTransformerTests
{
    private readonly RemoveStarterArrowTransformer _sut = new();

    [Theory]
    [InlineData(" ---> System.Exception: Something bad", "System.Exception: Something bad")]
    [InlineData("System.Exception: Root cause", "System.Exception: Root cause")]
    [InlineData(" --->  ---> Nested ---> Exception", "NestedException")]
    [InlineData(">Something that should not be touched!", ">Something that should not be touched!")]
    [InlineData("   ", "   ")]
    [InlineData("", "")]
    public void Apply_ShouldRemoveStarterArrow(string input, string expected)
    {
        string? result = _sut.Apply(input);

        Assert.Equal(expected, result);
    }
}
