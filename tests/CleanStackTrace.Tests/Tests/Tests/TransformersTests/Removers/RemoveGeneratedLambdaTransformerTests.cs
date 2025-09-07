using CleanStackTrace.Transformers.Removers;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Removers;

public class RemoveGeneratedLambdaTransformerTests
{
    private readonly RemoveGeneratedLambdaTransformer _sut = new();

    [Theory]
    [InlineData("   at lambda_method1(Closure, Object)")]
    [InlineData("at lambda_method12()")]
    [InlineData("lambda_method99")]
    public void Apply_ShouldRemove_LambdaGeneratedMethods(string input)
    {
        string? result = _sut.Apply(input);

        Assert.Null(result);
    }

    [Theory]
    [InlineData("at UserController.GetUser(Guid id) line 27")]
    [InlineData("CleanStackTrace.Program.Main(String[] args)")]
    [InlineData("at Mylambda_Helper.SomeMethod()")]
    [InlineData("at Mymethod_Helper.SomeMethod()")]
    [InlineData("NullReferenceException: Object reference not set")]
    public void Apply_ShouldKeep_NormalLines(string input)
    {
        string? result = _sut.Apply(input);

        Assert.Equal(input, result);
    }
}
