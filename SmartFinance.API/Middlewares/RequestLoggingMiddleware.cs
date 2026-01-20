using System.Text;

namespace SmartFinance.API.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Enable request body buffering
            context.Request.EnableBuffering();

            // Read request body
            var body = await ReadRequestBody(context.Request);

            _logger.LogInformation(
                "Request received at {Time}. Method: {Method}, Path: {Path}, Body: {Body}",
                DateTime.UtcNow,
                context.Request.Method,
                context.Request.Path,
                string.IsNullOrWhiteSpace(body) ? "<empty>" : body
            );
            
            // Reset stream position so controller can read it
            context.Request.Body.Position = 0;

            // Call next middleware
            await _next(context);
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            if (request.ContentLength == null || request.ContentLength == 0)
                return string.Empty;

            using var reader = new StreamReader(
                request.Body,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true);

            return await reader.ReadToEndAsync();
        }
    }
}
