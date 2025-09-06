using CleanStackTrace.Transformers.Alterators;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Alterators;

public class CollapseGeneratedMethodNamesTransformerTests
{
    private readonly CollapseGeneratedMethodNamesTransformer _sut = new();

    [Theory]
    [InlineData
    (
        "at CleanStackTrace.WebApplicationExtensions.<>c__DisplayClass0_0.<AddToServiceCollection>b__0(string serviceName)",
        "at CleanStackTrace.WebApplicationExtensions.AddToServiceCollection(string serviceName)"
    )]
    [InlineData
    (
        "at MyApp.Services.DataFetcher.<>c__DisplayClass5_0.<<Fetch>b__0>d.MoveNext()",
        "at MyApp.Services.DataFetcher.Fetch()"
    )]
    [InlineData
    (
        "at MyNamespace.MyService.<>c__DisplayClass10_1.<DoWorkAsync>b__2()",
        "at MyNamespace.MyService.DoWorkAsync()"
    )]
    [InlineData
    (
        "at CleanStackTrace.Controllers.UserController.<GetUser>d__5.MoveNext() line 42",
        "at CleanStackTrace.Controllers.UserController.GetUser() line 42"
    )]
    [InlineData
    (
        "at MyNamespace.Controllers.OrderController.<PlaceOrderAsync>d__15.MoveNext()",
        "at MyNamespace.Controllers.OrderController.PlaceOrderAsync()"
    )]
    [InlineData
    (
        "at TestProject.Program+<RunIterator>d__3.MoveNext()",
        "at TestProject.Program.RunIterator()"
    )]
    [InlineData
    (
        "at Services.ProjectA.API.Extensions.WebApplicationExtensions.<>c.<<AutoOptionsMiddleware>b__2_0>d.MoveNext() in C:\\Users\\UserName\\Repositories\\Client\\Services\\ProjectA\\Extensions\\WebApplicationExtensions.cs:line 40",
        "at Services.ProjectA.API.Extensions.WebApplicationExtensions.AutoOptionsMiddleware() in C:\\Users\\UserName\\Repositories\\Client\\Services\\ProjectA\\Extensions\\WebApplicationExtensions.cs:line 40"
    )]
    [InlineData
    (
        "at CleanStackTrace.Program.Main(String[] args)",
        "at CleanStackTrace.Program.Main(String[] args)"
    )]
    public void Apply_ShouldCollapseGeneratedMethodNames(string input, string expected)
    {
        string? result = _sut.Apply(input);

        Assert.Equal(expected, result);
    }
}
