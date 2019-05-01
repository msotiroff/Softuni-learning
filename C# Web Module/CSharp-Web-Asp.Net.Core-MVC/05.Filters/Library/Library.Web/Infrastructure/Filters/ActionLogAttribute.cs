namespace Library.Web.Infrastructure.Filters
{
    using Library.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;
    using System.Diagnostics;

    public class ActionLogAttribute : ActionFilterAttribute
    {
        private readonly ILogger logger;
        private readonly Stopwatch stopwatch;

        private string modelStateValidation;
        private string controllerName;
        private string actionName;
        private string httpMethod;

        public ActionLogAttribute(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<ConsoleLogger>();
            this.stopwatch = new Stopwatch();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.httpMethod = context.HttpContext.Request.Method;

            var routeValues = context.ActionDescriptor.RouteValues;
            routeValues.TryGetValue("action", out this.actionName);
            routeValues.TryGetValue("controller", out this.controllerName);

            this.modelStateValidation = context.ModelState.IsValid ? "valid" : "invalid";

            var routeLog = $"Executing {httpMethod} {controllerName}.{actionName}";           
            logger.LogInformation(routeLog);
            logger.LogToFile(WebConstants.ClientActiviryLogFilePath, LogLevel.Information, routeLog);

            var modelStateLog = $"Model state: [{modelStateValidation}]";
            logger.LogInformation(modelStateLog);
            logger.LogToFile(WebConstants.ClientActiviryLogFilePath, LogLevel.Information, modelStateLog);

            this.stopwatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            this.stopwatch.Stop();

            var milisecondsElapsed = this.stopwatch.ElapsedMilliseconds;
            var executedLog = $"Executed {httpMethod} {controllerName}.{actionName} in {milisecondsElapsed} ms.";

            logger.LogInformation(executedLog);
            logger.LogToFile(WebConstants.ClientActiviryLogFilePath, LogLevel.Information, executedLog);
        }
    }
}
