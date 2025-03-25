using Microsoft.AspNetCore.Http;
using NLog;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Middleware
{
    public class LoggingMiddleware
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // רישום כניסת API
            Logger.Info($"Entering {context.Request.Method} {context.Request.Path} at {DateTime.UtcNow}");

            try
            {
                await _next(context); // המשך לפעולה הבאה ב-Middleware pipeline

                // רישום קוד הסטטוס של התגובה
                Logger.Info($"Response Status Code: {context.Response.StatusCode}");
            }
            catch (Exception ex)
            {
                // רישום שגיאות (Exceptions)
                Logger.Error(ex, "An unhandled exception has occurred.");
                throw; // מאפשר לשגיאה להתפשט הלאה
            }
        }
    }

}
