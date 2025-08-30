using CleanStackTrace;
using CleanStackTrace.Demo;

Console.WriteLine("=== First Example ===");
Console.WriteLine();
try
{
    AWrongClass aWrongClass = new ();
    aWrongClass.DoSomething();
}
catch (Exception ex)
{
    Console.WriteLine("=== Original StackTrace ===");
    Console.WriteLine(ex.ToString());
    Console.WriteLine();
    Console.WriteLine("=== Cleaned StackTrace ===");
    Console.WriteLine(ex.GetCleanStackTrace());
}

Console.WriteLine();
Console.WriteLine("=== Second Example ===");
Console.WriteLine();

CustomStackTraceException testException = new ("A wrong situation", new ApplicationException(), AspnetStackTraces.GetLongStackTrace());
Console.WriteLine("=== Original StackTrace ===");
Console.WriteLine(testException);
Console.WriteLine();
Console.WriteLine("=== Cleaned StackTrace ===");
Console.WriteLine(testException.GetCleanStackTrace());

Console.WriteLine();
Console.WriteLine("=== Third Example ===");
Console.WriteLine();

testException = new("A wrong situation", new ApplicationException(), AspnetStackTraces.GetLongStackTrace());
Console.WriteLine("=== Original StackTrace ===");
Console.WriteLine(testException);
Console.WriteLine();
Console.WriteLine("=== Cleaned StackTrace ===");
Console.WriteLine(testException.GetColoredCleanStackTrace());