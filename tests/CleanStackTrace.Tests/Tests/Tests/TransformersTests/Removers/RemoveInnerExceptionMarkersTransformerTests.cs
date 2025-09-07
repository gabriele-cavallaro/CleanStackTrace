using CleanStackTrace.Transformers.Removers;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Removers;

public class RemoveInnerExceptionMarkersTransformerTests
{
    private readonly RemoveInnerExceptionMarkersTransformer _sut = new();

    [Theory]
    [InlineData("--- End of inner exception stack trace ---")]
    [InlineData("   --- End of inner exception ---")]
    [InlineData("--- End")]
    public void Apply_ShouldRemove_EndMarkers(string input)
    {
        string? result = _sut.Apply(input);

        Assert.Null(result);
    }

    [Theory]
    [InlineData("System.NullReferenceException: Object reference not set")]
    [InlineData("   at CleanStackTrace.Program.Main(String[] args)")]
    [InlineData("UserController.GetUser(Guid id) line 27")]
    [InlineData("Inner exception: InvalidOperationException")]
    public void Apply_ShouldKeep_NormalLines(string input)
    {
        string? result = _sut.Apply(input);

        Assert.Equal(input, result);
    }
}
