using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Day3.Root.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var request = httpContext.Request;
            request.EnableBuffering();
            StreamReader reader = new StreamReader(request.Body);
            string body = await reader.ReadToEndAsync();
            request.Body.Position = 0;

            var requestInfo = @$"
Requested at: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}
Schema: {request.Scheme}
Host: {request.Host}
Path: {request.Path}
Query string: {request.QueryString}
Method: {request.Method}
Body: {body}
";
            _logger.LogInformation(requestInfo);

            await WriteToFile(requestInfo);

            await _next(httpContext);
        }

        private async Task WriteToFile(string requestInfo)
        {
            string dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var loggerDirPath = Path.Combine(dirPath, "logger");
            if (!Directory.Exists(loggerDirPath))
            {
                Directory.CreateDirectory(loggerDirPath);
            }
            var filePath = Path.Combine(dirPath, $"logger\\{DateTime.Now.ToString("ddMMyyyy")}.txt");
            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath))
                {
                    await fs.WriteAsync(Encoding.UTF8.GetBytes(requestInfo));
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    await sw.WriteLineAsync(requestInfo);
                }
            }
            return;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }

}
