using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Tasks.Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public Task Invoke(HttpContext httpContext)
        {
            try
            {
                return _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                _logger.LogError(ex, ex.Message);
                if (ex is ValidationException)
                {
                    return httpContext.Response.WriteAsync(ex.Message);
                }

                return httpContext.Response.WriteAsync("There is some errors occured. Please try again later.");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
