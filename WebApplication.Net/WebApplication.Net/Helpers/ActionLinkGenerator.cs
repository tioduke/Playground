using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication.Net.Helpers
{
    public class ActionLinkGenerator : IActionLinkGenerator
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public ActionLinkGenerator(LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor)
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }

        public string ActionLink(string action, string controller, object values)
        {
            _semaphore.Wait();
            try
            {
                return _linkGenerator.GetUriByAction(_httpContextAccessor.HttpContext, action, controller, values);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }

    public static class ActionLinkGeneratorExtensions
    {
        public static IServiceCollection AddActionLinkGenerator(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IActionLinkGenerator, ActionLinkGenerator>();

            return services;
        }
    }
}