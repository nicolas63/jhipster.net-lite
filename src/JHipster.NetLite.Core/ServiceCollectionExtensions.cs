using JHipster.NetLite.Application.Services;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JHipster.NetLite.Web;

public static class ServiceCollectionExtensions
{
    public static IMvcBuilder AddJHipsterLite(this IMvcBuilder builder)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        builder.AddControllersAsServices().AddApplicationPart(assembly).AddControllersAsServices();
        builder.Services.AddAutoMapper(assembly);
        builder.Services.AddJHipsterLiteApplicationServices()
                          .AddJHipsterLiteDomainServices()
                          .AddJHipsterLiteRepositories();
        return builder;
    }

    private static IServiceCollection AddJHipsterLiteApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IInitApplicationService, InitApplicationService>();
        return services;
    }
    private static IServiceCollection AddJHipsterLiteDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IInitDomainService, InitDomainService>();
        return services;
    }

    private static IServiceCollection AddJHipsterLiteRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProjectRepository, ProjectLocalRepository>();
        return services;
    }
}
