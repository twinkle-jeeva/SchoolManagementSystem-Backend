using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using StudentDemoAPI.Helpers;

namespace StudentDemoAPI.Middleware
{
    public class ModuleRoleMiddleware
    {
        private readonly RequestDelegate _next;

        public ModuleRoleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower() ?? "";
            var user = context.User;

            // Skip authentication check for login endpoints
            if (path.Contains("login") || path.Contains("register"))
            {
                await _next(context);
                return;
            }

            if (!user.Identity?.IsAuthenticated ?? true)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            var role = user.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(role))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden: No role found");
                return;
            }

            var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length < 2)
            {
                await _next(context);
                return;
            }

            var module = segments[1]; // api/students → students

            if (ModuleRoles.RolesPerModule.TryGetValue(module, out var allowedRoles))
            {
                if (!allowedRoles.Contains(role))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Forbidden: Access denied");
                    return;
                }
            }

            await _next(context);
        }
    }
}