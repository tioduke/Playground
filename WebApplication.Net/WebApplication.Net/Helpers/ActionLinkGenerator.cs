using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication.Net.Helpers
{
    public class ActionLinkGenerator : IActionLinkGenerator
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ActionLinkGenerator(LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor)
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }

        public string ActionLink(string action, string controller, object values)
        {
            return _linkGenerator.GetUriByAction(_httpContextAccessor.HttpContext, action, controller, values);
        }
    }

    public static class ActionLinkGeneratorExtensions
    {
        public static IServiceCollection AddActionLinkGenerator(this IServiceCollection services)
        {
            services.AddSingleton<IActionLinkGenerator, ActionLinkGenerator>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}