namespace CleanStackTrace.Demo;

public class AWrongClass
{    
    public void DoSomething()
    {
        Method1();
    }

    public void Method1()
    {
        Method2();
    }

    private void Method2()
    {
        Method3();
    }

    private void Method3()
    {
        try
        {
            throw new InvalidOperationException("Inner level exception detail: something went wrong");
        }
        catch (Exception inner)
        {
            throw new ApplicationException("High level exception detail", inner);
        }
    }
}
