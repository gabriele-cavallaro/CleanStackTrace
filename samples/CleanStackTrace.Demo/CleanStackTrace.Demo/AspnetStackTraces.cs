namespace CleanStackTrace.Demo;

public class AspnetStackTraces
{
    public static string GetShortStackTrace()
    {
        return """
            System.InvalidOperationException: Not Valid Operation
            at ProjectA.Services.InternalService.DoWork() in C:\Users\UserName\Repositories\Client\ProjectA\Services\InternalService.cs:line 42
            at ProjectA.Services.WorkerService.Execute() in C:\Users\UserName\Repositories\Client\ProjectA\Services\WorkerService.cs:line 21
            at ProjectA.Program.<Main>$(String[] args) in C:\Users\UserName\Repositories\Client\ProjectA\Program.cs:line 17
            --- End of stack trace from previous location ---
            at Microsoft.Extensions.Hosting.HostApplicationBuilder..ctor(HostApplicationBuilderSettings settings)
            at Microsoft.Extensions.Hosting.HostApplicationBuilder..ctor(HostApplicationBuilderSettings settings)
            at Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(String[] args)
            at Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run(IHost host)
            at Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync(IHost host, CancellationToken token)
            at ProjectA.Program.Main(String[] args) in C:\Users\UserName\Repositories\Client\ProjectA\Program.cs:line 35
            """;
    }

    public static string GetLongStackTrace()
    {
        return """
            System.NullReferenceException: Object reference not set to an instance of an object.
            at Services.ProjectA.API.Controllers.UserController.GetUser(Guid id) in C:\Users\UserName\Repositories\Client\Services\ProjectA\API\Controllers\UserController.cs:line 27
            at lambda_method4(Closure, Object)
            at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.TaskOfIActionResultExecutor.Execute(ActionContext actionContext, IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
            at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)
            at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
            at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
            at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
            at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeInnerFilterAsync>g__Awaited|13_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
            at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
            at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
            at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
            at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)
            at Services.ProjectA.API.Extensions.WebApplicationExtensions.<>c.<<AutoOptionsMiddleware>b__2_0>d.MoveNext() in C:\Users\UserName\Repositories\Client\Servicesoa\progetto\Extensions\WebApplicationExtensions.cs:line 40
            --- End of stack trace from previous location ---
            at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpcontext)
            at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
            at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.Invoke(HttpContext context)
            at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)
            """;
    }
}
