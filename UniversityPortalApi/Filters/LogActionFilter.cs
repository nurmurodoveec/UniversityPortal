using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

public class LogActionFilter : IActionFilter
{
    private readonly ILogger<LogActionFilter> _logger;

    public LogActionFilter(ILogger<LogActionFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("Action {ActionName} is executing", context.ActionDescriptor.DisplayName);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation("Action {ActionName} has executed", context.ActionDescriptor.DisplayName);
    }
}
