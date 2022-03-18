using Microsoft.Extensions.DependencyInjection;

namespace JHipster.NetLite.Core
{
    public static class IServiceCollectionExtensions
    {
        public static IMvcBuilder UseJHipsterLite(this IMvcBuilder services)
        {
            var assembly = typeof(IServiceCollectionExtensions).Assembly;
            services.AddControllersAsServices().AddApplicationPart(assembly).AddControllersAsServices();
            return services;
        }
    }
}
