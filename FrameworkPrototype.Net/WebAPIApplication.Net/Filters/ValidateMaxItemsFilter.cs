using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

using DataAccess.Net.Interfaces;
using WebAPIApplication.Net.Entities;
using WebAPIApplication.Net.Exceptions;

namespace WebAPIApplication.Net.Filters
{
    public sealed class ValidateMaxItemsFilter : IAsyncActionFilter
    {
        private readonly int _maxItems;
        private readonly IReadableRepository<Customer, CustomerCriteria> _customerReadableRepository;

        public ValidateMaxItemsFilter(IConfiguration configuration,
                                      IReadableRepository<Customer, CustomerCriteria> customerReadableRepository)
        {
            _maxItems = int.Parse(configuration["MaxItems"]);
            _customerReadableRepository = customerReadableRepository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
        {
            var criteria = new CustomerCriteria
            {
                CustomerCode = actionContext.GetArgumentValue("customerCode") as string
            };
            var count = await _customerReadableRepository.Count(criteria);
            if (count > _maxItems)
            {
                throw new TooManyResultsException("Too many results obtained.");
            }

            await next.Invoke();
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
