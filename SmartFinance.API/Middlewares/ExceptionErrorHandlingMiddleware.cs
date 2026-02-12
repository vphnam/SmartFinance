using SmartFinance.Application.Contracts.Shared.Dto;

namespace SmartFinance.API.Middlewares
{
    public class ExceptionErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static async Task HandleException(HttpContext context, Exception ex)
        {
            var (status, message) = ex switch
            {
                InvalidOperationException => (StatusCodes.Status400BadRequest, ex.Message),
                UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, ex.Message),
                KeyNotFoundException => (StatusCodes.Status404NotFound, ex.Message),

                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
            };

            context.Response.StatusCode = status;
            context.Response.ContentType = "application/json";

            var response = ApiResponse<object>.Failure(status, message);

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
