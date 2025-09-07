using System;
using System.Diagnostics;
using CleanStackTrace.Interfaces;
using CleanStackTrace.Tests.Utils;
using CleanStackTrace.Transformers.Removers;
using CleanStackTrace.Utils;

namespace CleanStackTrace.Tests.Tests;

public class StackTraceCleanerTests
{
    public readonly string _nl = Environment.NewLine;

    [Fact]
    public void StackTraceCleaner_Should_ApplyTransformersInCorrectOrder()
    {
        string stackTrace = $"Line1{_nl}Line2{_nl}Line3";
        LambdaLinesTransformer linesTransformer = new (lines =>
            lines.Select(line => line.Replace("Line", "Processed")));
        LambdaLineTransformer lineTransformer = new (line =>
            line == "Processed2" ? null : line?.Replace("Processed", "Transformed"));

        LambdaLinesTransformer[] linesTransformers = [linesTransformer];
        LambdaLineTransformer[] lineTransformers = [lineTransformer];

        string result = StackTraceCleaner.CleanStackTrace(stackTrace, linesTransformers, lineTransformers);

        Assert.Equal($"Transformed1{_nl}Transformed3", result);
    }

    [Fact]
    public void StackTraceCleaner_Should_HandleEmptyLinesTransformerResult()
    {
        string stackTrace = $"Line{_nl}Line2";
        LambdaLinesTransformer linesTransformer = new (lines => []);
        LambdaLineTransformer lineTransformer = new (line => "ShouldNotBeCalled");

        string result = StackTraceCleaner.CleanStackTrace(stackTrace, [linesTransformer], [lineTransformer]);

        Assert.Empty(result);
    }

    [Fact]
    public void StackTraceCleaner_Should_HandleNullLineTransformerResults()
    {
        string stackTrace = $"Line1{_nl}Line2{_nl}Line3";
        LambdaLineTransformer lineTransformer = new (line =>
            line == "Line2" ? null : line.Replace("Line", "Transformed"));

        string result = StackTraceCleaner.CleanStackTrace(stackTrace, [], [lineTransformer]);

        Assert.Equal($"Transformed1{_nl}Transformed3", result);
    }

    [Fact]
    public void StackTraceCleaner_Should_HandleEmptyInput()
    {
        string emptyStackTrace = "";

        string result = StackTraceCleaner.CleanStackTrace(emptyStackTrace, [], []);

        Assert.Empty(result);
    }

    [Fact]
    public void StackTraceCleaner_Should_ThrowIfNullInput()
    {
        string? nullStackTrace = null;

        Assert.Throws<ArgumentNullException>
            (() => StackTraceCleaner.CleanStackTrace(nullStackTrace!, [], []));
    }

    [Fact]
    public void StackTraceCleaner_Should_CallToStringAndApplyTransformers()
    {
        InvalidOperationException exception = new ("Test exception");
        LambdaLineTransformer lineTransformer = new (line =>
            line?.Replace("InvalidOperationException", "TransformedException"));

        string result = StackTraceCleaner.CleanStackTrace(exception, [], [lineTransformer]);

        Assert.Contains("TransformedException", result);
    }

    [Fact]
    public void StackTraceCleaner_Should_ApplyMultipleTransformersInSequence()
    {
        string stackTrace = "OriginalLine";
        LambdaLineTransformer transformer1 = new (line => line?.Replace("Original", "FirstPass"));
        LambdaLineTransformer transformer2 = new (line => line?.Replace("FirstPass", "SecondPass"));

        string result = StackTraceCleaner.CleanStackTrace(stackTrace, [], [transformer1, transformer2]);

        Assert.Equal("SecondPassLine", result);
    }

    [Fact]
    public void StackTraceCleaner_Should_PreserveLineOrder()
    {
        string stackTrace = $"First{_nl}Second{_nl}Third";
        LambdaLineTransformer lineTransformer = new (line => line);

        string result = StackTraceCleaner.CleanStackTrace(stackTrace, [], [lineTransformer]);

        Assert.Equal($"First{_nl}Second{_nl}Third", result);
    }

    [Fact]
    public void StackTraceCleaner_Should_HandleMultipleLinesTransformers()
    {
        string stackTrace = $"Line1{_nl}Line2{_nl}Line3";
        LambdaLinesTransformer transformer1 = new (lines => lines.Take(2));
        LambdaLinesTransformer transformer2 = new (lines => lines.Reverse());

        string result = StackTraceCleaner.CleanStackTrace(stackTrace, [transformer1, transformer2], []);

        Assert.Equal($"Line2{_nl}Line1", result);
    }

    [Fact]
    public void StackTraceCleaner_Should_HandleMixedTransformers()
    {
        string stackTrace = $"Line1{_nl}Line2{_nl}Line3";
        LambdaLinesTransformer linesTransformer = new (lines =>
            lines.Select(line => line + "_processed"));
        LambdaLineTransformer lineTransformer = new (line =>
            line == "Line2_processed" ? null : line);

        string result = StackTraceCleaner.CleanStackTrace(stackTrace, [linesTransformer], [lineTransformer]);

        Assert.Equal($"Line1_processed{_nl}Line3_processed", result);
    }

    [Fact]
    public void StackTraceCleaner_WithRealTransformers_Should_RemoveBannedNamespaces()
    {
        string stackTrace = $"at System.Exception.ToString(){_nl}   at Microsoft.SomeClass.Method(){_nl}   at MyApp.ValidClass.Method()";
        List<IStackTraceLineTransformer> lineTransformers = [new RemoveLineOfBannedNamespacesTransformer()];

        string result = StackTraceCleaner.CleanStackTrace(stackTrace, [], lineTransformers);

        Assert.DoesNotContain("Microsoft.", result);
        Assert.Contains("MyApp.ValidClass.Method()", result);
    }

    [Fact]
    public void StackTraceCleaner_WithRealTransformers_Should_HandleRealExample()
    {
        (string input, string expectedResult) = DummyStackTraces.GetLongStackTrace;

        string result = StackTraceCleaner.CleanStackTrace
        (
            input,
            TransformerCollections.StandardLinesTransformers,
            TransformerCollections.StandardLineTransformers
        );

        Assert.Equal(expectedResult, result);
    }
}
