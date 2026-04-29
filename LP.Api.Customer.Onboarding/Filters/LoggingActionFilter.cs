using Microsoft.AspNetCore.Mvc.Filters;

namespace LP.Api.Customer.Onboarding.Filters;

public class LoggingActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"[START] Executing {context.ActionDescriptor.DisplayName}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine($"[END] Executed {context.ActionDescriptor.DisplayName}");
    }
}