namespace Library.Web.Infrastructure.Filters
{
    using Library.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Console;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    public class ExceptionHandler
    {
        private readonly ILogger logger;
        private readonly RequestDelegate next;
        private readonly IHostingEnvironment environment;

        public ExceptionHandler(RequestDelegate next, ILoggerFactory loggerFactory, IHostingEnvironment environment)
        {
            this.logger = loggerFactory.CreateLogger<ConsoleLogger>();
            this.environment = environment;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            this.LogError(exception);

            var response = context.Response;

            if (this.environment.IsDevelopment())
            {
                await this.SetDevelopmentResponse(exception, response);
            }
            else
            {
                response.Redirect("/Home/Error");
            }
        }

        private async Task SetDevelopmentResponse(Exception exception, HttpResponse response)
        {
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var error = JsonConvert.SerializeObject(new
            {
                error = new
                {
                    message = exception.Message,
                    exception = exception.GetType().Name,
                    stackTrace = exception.StackTrace
                }
            },
            Formatting.Indented);

            await response.WriteAsync(error);
        }

        private void LogError(Exception exception)
        {
            var exceptionType = exception.GetType().Name;
            var stackTrace = exception.StackTrace;

            var exceptionLog = $"{exceptionType} {Environment.NewLine}Stack Trace: {stackTrace}";
            this.logger.LogError(exceptionLog);
            this.logger.LogToFile(WebConstants.ExceptionLogFilePath, LogLevel.Error, exceptionLog);
        }
    }
}
