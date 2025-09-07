using CleanStackTrace.Transformers.Removers;
using CleanStackTrace.Utils;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Removers;

public class RemoveLineOfCustomBannedNamespacesTransformerTests
{
    private readonly RemoveLineOfCustomBannedNamespacesTransformer _sut = new();

    [Theory]
    [InlineData("MyCompany", "   at MyCompany.Services.OrderService.ProcessOrder()")]
    [InlineData("LegacyLib", "   at LegacyLib.Data.OldRepository.Execute()")]
    [InlineData("TempNamespace", "   at TempNamespace.TempHelper.DoStuff()")]
    public void Apply_ShouldRemove_CustomBannedNamespaceLines(string prefix, string input)
    {
        BannedNamespaces.AddCustomPrefix(prefix);

        string? result = _sut.Apply(input);

        Assert.Null(result);

        BannedNamespaces.RemoveCustomPrefix(prefix);
    }

    [Theory]
    [InlineData("   at CleanStackTrace.Program.Main(String[] args)")]
    [InlineData("   at ExternalLib.Controllers.UserController.GetUser()")]
    [InlineData("   at Microsoft.Extensions.Hosting.HostBuilder.Build()")]
    public void Apply_ShouldKeep_NonCustomBannedNamespaceLines(string input)
    {
        BannedNamespaces.AddCustomPrefix("Microfuf");
        BannedNamespaces.AddCustomPrefix("Clean");
        BannedNamespaces.AddCustomPrefix("Controllers");

        string? result = _sut.Apply(input);

        Assert.Equal(input, result);

        BannedNamespaces.RemoveCustomPrefix("Microfuf");
        BannedNamespaces.RemoveCustomPrefix("Clean");
        BannedNamespaces.RemoveCustomPrefix("Controllers");
    }
}
