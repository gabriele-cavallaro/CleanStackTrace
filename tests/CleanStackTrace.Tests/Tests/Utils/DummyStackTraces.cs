namespace CleanStackTrace.Tests.Utils;

internal class DummyStackTraces
{
    public static (string input, string expectedResult) GetLongStackTrace =
            (
                """
                CleanStackTrace.Demo.CustomStackTraceException: A wrong situation
                 ---> System.ApplicationException: Error in the application.
                   --- End of inner exception stack trace ---
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
                """,
                """
                CustomStackTraceException: A wrong situation
                  ApplicationException: Error in the application.
                    NullReferenceException: Object reference not set to an instance of an object.
                    UserController.GetUser(Guid id) line 27
                    WebApplicationExtensions.AutoOptionsMiddleware() line 40
                """
            );
}
