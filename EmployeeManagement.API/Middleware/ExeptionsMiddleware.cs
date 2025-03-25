using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.API.Middleware
{
    public class ExeptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthorizationMiddleware> _logger;

        public ExeptionsMiddleware(RequestDelegate next, ILogger<AuthorizationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // מגדירים את המנגנון שיתפוס את הסיום של הבקשה
            context.Response.OnCompleted(() =>
            {
                // אם הסטטוס של התשובה הוא 200 OK, נדע שהבקשה הצליחה
                if (context.Response.StatusCode == StatusCodes.Status200OK)
                {
                    _logger.LogInformation("הבקשה התקבלה בהצלחה.");
                    // לדוגמה, אפשר להוסיף header או תוצאה נוספת בתשובה
                    context.Response.Headers.Add("X-Success-Message", "הבקשה התקבלה בהצלחה.");
                }
                return Task.CompletedTask;
            });

            // בודקים אם המשתמש מאומת ומורשה לבצע את הפעולה
            var isAuthorized = context.User.Identity.IsAuthenticated;

            if (!isAuthorized)
            {
                _logger.LogWarning("לא מורשה - אין הרשאה לבצע את הפעולה.");
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("לא מורשה לבצע את הפעולה.");
                return;
            }

            // אם המשתמש מורשה, ממשיכים עם הבקשה
            await _next(context);
        }
    }
}
