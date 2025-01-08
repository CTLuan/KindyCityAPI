using KindyCity.Shared.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KindyCity.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                string errorMessage = ErrorMessages.MESSAGE_ERROR_REQUEST_UNSPECIFIEDERRORHASOCCURRED;

                var modelState = context.ModelState;
                if (modelState != null && modelState.Count > 0 && modelState.Any(m => m.Value?.Errors?.Count > 0))
                {
                    errorMessage = modelState.Select(m => m.Value?.Errors?.FirstOrDefault()?.ErrorMessage)
                                             .FirstOrDefault(m => !string.IsNullOrEmpty(m))
                                  ?? ErrorMessages.MESSAGE_ERROR_REQUEST_UNSPECIFIEDERRORHASOCCURRED;
                }

                context.Result = new OkObjectResult(new BadRequestObjectResult(new
                {
                    Message = "Validation failed",
                    Errors = errorMessage
                }));
                context.HttpContext.Items["fluent_validation"] = "invalid";
                context.HttpContext.Items["fluent_message"] = errorMessage;
            }
            else
            {
                context.HttpContext.Items.Remove("fluent_validation");
                context.HttpContext.Items.Remove("fluent_message");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.Write(string.Empty);
        }
    }
}
