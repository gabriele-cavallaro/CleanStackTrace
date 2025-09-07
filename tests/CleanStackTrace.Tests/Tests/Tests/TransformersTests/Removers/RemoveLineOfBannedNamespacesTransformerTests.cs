using CleanStackTrace.Transformers.Removers;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Removers;

public class RemoveLineOfBannedNamespacesTransformerTests
{
    private readonly RemoveLineOfBannedNamespacesTransformer _sut = new();

    [Theory]
    [InlineData("   at Microsoft.Extensions.Hosting.Host.Run()")]
    [InlineData("   at Microsoft.Extensions.Hosting.HostApplicationBuilder.Build()")]
    [InlineData("   at Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenerator.Generate()")]
    [InlineData("   at Autofac.Core.Container.ResolveComponent(IComponentRegistration registration, IEnumerable`1 parameters)")]
    [InlineData("   at Xunit.Sdk.AssertComparer`1.Equal(T x, T y)")]
    [InlineData("   at Moq.Mock`1.Setup[TResult](Expression`1 expression)")]
    public void Apply_ShouldRemove_BannedNamespaceLines(string input)
    {
        string? result = _sut.Apply(input);

        Assert.Null(result);
    }

    [Theory]
    [InlineData("   at InternalLib.Utils.Helper.DoSomething()")]
    [InlineData("   at CleanStackTrace.Program.Main(String[] args)")]
    [InlineData("   at MyCompany.MyApp.Services.UserService.GetUser()")]
    [InlineData("   at Controllers.HomeController.Index() line 12")]
    public void Apply_ShouldKeep_NonBannedNamespaceLines(string input)
    {
        string? result = _sut.Apply(input);

        Assert.Equal(input, result);
    }
}
