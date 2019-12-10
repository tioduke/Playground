using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

using DataAccess.Net.Interfaces;
using WebAPIApplication.Net.Entities;
using WebAPIApplication.Net.Mvc;

namespace WebAPIApplication.Net.Filters
{
    public sealed class ValidateMaxItemsFilter : IActionFilter
    {
        private readonly int _maxItems;
        private readonly IReadableRepository<Customer, CustomerCriteria> _customerReadableRepository;

        public ValidateMaxItemsFilter(IConfiguration configuration,
                                      IReadableRepository<Customer, CustomerCriteria> customerReadableRepository)
        {
            _maxItems = int.Parse(configuration["MaxItems"]);
            _customerReadableRepository = customerReadableRepository;
        }

        public void OnActionExecuted(ActionExecutedContext actionContext)
        {
            //noop
        }

        public void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var criteria = new CustomerCriteria
            {
                CustomerCode = actionContext.GetArgumentValue("customerCode") as string
            };
            var count = _customerReadableRepository.Count(criteria);
            if (count > _maxItems)
            {
                actionContext.Result = new PayloadTooLargeResult("Too many results obtained.");
            }
        }
    }

    #region ActionExecutingContextExtensions

    internal static class ActionExecutingContextExtensions
    {
        internal static object GetArgumentValue(this ActionExecutingContext actionContext, string argumentName)
        {
            object value = null;
            actionContext.ActionArguments.TryGetValue(argumentName, out value);
            return value;
        }
    }

    #endregion
}
