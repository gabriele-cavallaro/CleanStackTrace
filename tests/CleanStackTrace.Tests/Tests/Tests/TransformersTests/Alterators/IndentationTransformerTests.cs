using CleanStackTrace.Transformers.Alterators;

namespace CleanStackTrace.Tests.Tests.TransformersTests.Alterators;

public class IndentationTransformerTests
{
    private readonly IndentationTransformer _sut = new();

    public static IEnumerable<object[]> GetIndentationCases()
    {
        yield return new object[]
        {
                new[]
                {
                    "System.Exception: Root error"
                },
                new[]
                {
                    "System.Exception: Root error"
                }
        };

        yield return new object[]
        {
                new[]
                {
                    "System.Exception: Root error",
                    "---> InnerException: something failed"
                },
                new[]
                {
                    "System.Exception: Root error",
                    "  ---> InnerException: something failed"
                }
        };

        yield return new object[]
        {
                new[]
                {
                    "System.Exception: Root error",
                    "---> FirstInner: failed",
                    "---> SecondInner: failed deeper",
                    "--- End of inner exception stack trace ---",
                    "at SomeMethod()"
                },
                new[]
                {
                    "System.Exception: Root error",
                    "  ---> FirstInner: failed",
                    "    ---> SecondInner: failed deeper",
                    "      --- End of inner exception stack trace ---",
                    "      at SomeMethod()"
                }
        };

        yield return new object[]
        {
                new[]
                {
                    "System.Exception: Root error",
                    "--- End of inner exception stack trace ---",
                    "--- End of inner exception stack trace ---"
                },
                new[]
                {
                    "System.Exception: Root error",
                    "  --- End of inner exception stack trace ---",
                    "    --- End of inner exception stack trace ---"
                }
        };
    }

    [Theory]
    [MemberData(nameof(GetIndentationCases))]
    public void Apply_Should_IndentCorrectly(IEnumerable<string> input, IEnumerable<string> expected)
    {
        IEnumerable<string> result = _sut.Apply(input);

        Assert.Equal(expected, result);
    }
}
