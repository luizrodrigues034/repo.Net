using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceStack.Validation;

namespace DevFreelaAPI.Filters
{

    public class ValidationFilters : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var message = context.ModelState.SelectMany(e => e.Value.Errors).Select(p => p.ErrorMessage);
                context.Result =  new BadRequestObjectResult(message);
            }
        }
    }
}
