namespace QuoteApi.Middleware
{
    public class GlobalLogging
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalLogging> _logger;

        public GlobalLogging(RequestDelegate next, ILogger<GlobalLogging> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log that the action is being entered
            _logger.LogInformation($"Entering {context.Request.Method} request for {context.Request.Path}");

            await _next(context);
        }
    }
}
