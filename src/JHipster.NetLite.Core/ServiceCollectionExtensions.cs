using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JHipster.NetLite.Web;

public static class ServiceCollectionExtensions
{
    public static IMvcBuilder AddJHipsterLite(this IMvcBuilder services)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddControllersAsServices().AddApplicationPart(assembly).AddControllersAsServices();
        services.Services.AddJHipsterLiteApplicationServices();
        services.Services.AddJHipsterLiteDomainServices();
        return services;
    }

    private static IServiceCollection AddJHipsterLiteApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IInitApplicationService, IInitApplicationService>();
        return services;
    }

    private static IServiceCollection AddJHipsterLiteDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IInitDomainService, IInitDomainService>();
        return services;
    }
}
