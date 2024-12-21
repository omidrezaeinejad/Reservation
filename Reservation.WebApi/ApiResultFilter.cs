using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace Reservation.WebApi
{
    public class ApiResultFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var result = await next();

            var exception = result.Exception;

            if (exception is ValidationException validationException)
            {
                result.ExceptionHandled = true;

                result.Result = new ObjectResult(new
                {
                    Message = validationException.Message,
                })
                {
                    StatusCode = (int)StatusCodes.Status400BadRequest,
                };
            }
        }
    }
}
