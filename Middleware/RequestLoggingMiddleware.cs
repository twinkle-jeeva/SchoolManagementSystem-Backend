using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace StudentDemoAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();

            Console.WriteLine(
                $"[{DateTime.Now}] {context.Request.Method} {context.Request.Path} => {context.Response.StatusCode} in {stopwatch.ElapsedMilliseconds}ms"
            );
        }
    }
}