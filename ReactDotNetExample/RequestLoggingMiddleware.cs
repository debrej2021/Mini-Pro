namespace ReactDotNetExample
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLoggingMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Handling request: " + context.Request.Path);
            await _next(context);
            _logger.LogInformation("Finished handling request.");
        }
    }
}
