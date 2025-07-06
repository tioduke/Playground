using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication.Net.Helpers
{
    public class UrlHelperProxy : IUrlHelper
    {
        private readonly IUrlHelperFactory _factory;
        private readonly IActionContextAccessor _accessor;

        public UrlHelperProxy(IUrlHelperFactory factory, IActionContextAccessor accessor)
        {
            _factory = factory;
            _accessor = accessor;
        }

        public ActionContext ActionContext => UrlHelper.ActionContext;
        public string Action(UrlActionContext context) => UrlHelper.Action(context);
        public string Content(string contentPath) => UrlHelper.Content(contentPath);
        public bool IsLocalUrl(string url) => UrlHelper.IsLocalUrl(url);
        public string Link(string name, object values) => UrlHelper.Link(name, values);
        public string RouteUrl(UrlRouteContext context) => UrlHelper.RouteUrl(context);
        private IUrlHelper UrlHelper => _factory.GetUrlHelper(_accessor.ActionContext);
    }

    public static class UrlHelperProxyExtensions
    {
        public static IServiceCollection AddUrlHelperProxy(this IServiceCollection services)
        {
            services.AddSingleton<IUrlHelper, UrlHelperProxy>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            return services;
        }
    }
}
