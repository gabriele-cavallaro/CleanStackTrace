using CleanStackTrace.Interfaces;
using CleanStackTrace.Transformers.Alterators;
using CleanStackTrace.Transformers.Colorists;
using CleanStackTrace.Transformers.Removers;

namespace CleanStackTrace.Utils;

public static class TransformerCollections
{
    public static readonly IReadOnlyList<IStackTraceLineTransformer> StandardLineTransformers =
        [
            new RemoveInnerExceptionMarkersTransformer(),
            new RemoveLineOfBannedNamespacesTransformer(),
            new RemoveLineOfCustomBannedNamespacesTransformer(),
            new RemoveGeneratedLambdaTransformer(),
            new CollapseGeneratedMethodNamesTransformer(),
            new AbbreviateFilePathsTransformer(),
            new SimplifyExceptionTypesTransformer(),
            new RemoveStarterArrowTransformer(),
            new RemoveAtsTransformer()
        ];

    public static readonly IReadOnlyList<IStackTraceLineTransformer> ColoredLineTransformers =
        [
            new RemoveInnerExceptionMarkersTransformer(),
            new RemoveLineOfBannedNamespacesTransformer(),
            new RemoveLineOfCustomBannedNamespacesTransformer(),
            new RemoveGeneratedLambdaTransformer(),
            new CollapseGeneratedMethodNamesTransformer(),
            new AbbreviateFilePathsTransformer(),
            new SimplifyExceptionTypesTransformer(),
            new RemoveStarterArrowTransformer(),
            new RemoveAtsTransformer(),
            new HighlightLineNumberTransformer(),
            new HighlightExceptionTransformer(),
            new HighlightClassTransformer(),
            new HighlightFunctionsTransformer()
        ];

    public static readonly IReadOnlyList<IStackTraceLinesTransformer> StandardLinesTransformers =
        [
            new IndentationTransformer()
        ];
}
