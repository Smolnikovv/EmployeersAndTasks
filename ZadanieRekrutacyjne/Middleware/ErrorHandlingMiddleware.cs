using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using EmployersAndTasks.Exception;

namespace EmployersAndTasks.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        async Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(BadRequestException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}
