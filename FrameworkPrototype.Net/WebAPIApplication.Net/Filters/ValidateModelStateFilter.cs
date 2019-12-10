using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPIApplication.Net.Filters
{
    public sealed class ValidateModelStateFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext actionContext)
        {
            //noop
        }

        public void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Result = new BadRequestObjectResult(actionContext.ModelState);
            }
        }
    }
}
