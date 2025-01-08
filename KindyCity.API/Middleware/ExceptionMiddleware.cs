using KindyCity.API.Exceptions;
using KindyCity.Shared.Exceptions;
using System.Net;
using System.Text.Json;

namespace KindyCity.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var apiException = new ApiException((int)code, "An unexpected error occurred.");

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    apiException = new ApiException((int)code, "Validation error", "One or more validation errors occurred.")
                    {
                        Errors = validationException.Errors
                    };
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    apiException = new ApiException((int)code, "Not Found", notFoundException.Message);
                    break;
                case UnauthorizedAccessException _:
                    code = HttpStatusCode.Unauthorized;
                    apiException = new ApiException((int)code, "Unauthorized", "You are not authorized to access this resource.");
                    break;
                case ForbiddenAccessException _:
                    code = HttpStatusCode.Forbidden;
                    apiException = new ApiException((int)code, "Forbidden", "You don't have permission to access this resource.");
                    break;
                case ConflictException conflictException:
                    code = HttpStatusCode.Conflict;
                    apiException = new ApiException((int)code, "Conflict", conflictException.Message);
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var result = JsonSerializer.Serialize(apiException, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return context.Response.WriteAsync(result);
        }
    }
}

