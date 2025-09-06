using CleanStackTrace.Transformers.Alterators;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Alterators;

public class AbbreviateFilePathsTransformerTests
{
    private readonly AbbreviateFilePathsTransformer _sut = new();

    [Theory]
    [InlineData
    (
        "   at MyNamespace.MyClass.MyMethod() in C:\\Projects\\Solution\\MyFile.cs:line 42",
        "   at MyClass.MyMethod() line 42"
    )]
    [InlineData
    (
        "Another.Namespace.Service.DoWork(Guid id) in /src/Service/DoWork.cs:line 10",
        "Service.DoWork(Guid id) line 10"
    )]
    [InlineData
    (
        "Another.Namespace.Service.DoWork() in /src/Service/DoWork.cs:line 10",
        "Service.DoWork() line 10"
    )]
    [InlineData
    (
        "lambda_method(Closure, object)",
        "lambda_method(Closure, object)"
    )]
    public void Apply_ShouldTransformLine_AsExpected(string input, string expected)
    {
        string? result = _sut.Apply(input);

        Assert.Equal(expected, result);
    }
}
