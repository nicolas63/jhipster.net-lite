using JHipster.NetLite.Application.Services;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Repositories;
using JHipster.NetLite.Web.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
        //ILogger _logger = builder.Services.BuildServiceProvider().GetService<ILogger>();
        //LogAssciText(_logger);
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

    private static void LogAssciText(ILogger logger)
    {
        logger.LogInformation(@$"  
  {AnsiColor.GREEN}      ██╗{AnsiColor.RED} ██╗   ██╗ ████████╗ ███████╗   ██████╗ ████████╗ ████████╗ ███████╗ {AnsiColor.MAGENTA}   ███╗   ██╗███████╗████████╗
  {AnsiColor.GREEN}      ██║{AnsiColor.RED} ██║   ██║ ╚══██╔══╝ ██╔═══██╗ ██╔════╝ ╚══██╔══╝ ██╔═════╝ ██╔═══██╗{AnsiColor.MAGENTA}   ████╗  ██║██╔════╝╚══██╔══╝
  {AnsiColor.GREEN}      ██║{AnsiColor.RED} ████████║    ██║    ███████╔╝ ╚█████╗     ██║    ██████╗   ███████╔╝{AnsiColor.MAGENTA}   ██╔██╗ ██║█████╗     ██║   
  {AnsiColor.GREEN}██╗   ██║{AnsiColor.RED} ██╔═══██║    ██║    ██╔════╝   ╚═══██╗    ██║    ██╔═══╝   ██╔══██║ {AnsiColor.MAGENTA}   ██║╚██╗██║██╔══╝     ██║   
  {AnsiColor.GREEN}╚██████╔╝{AnsiColor.RED} ██║   ██║ ████████╗ ██║       ██████╔╝    ██║    ████████╗ ██║  ╚██╗{AnsiColor.MAGENTA}██╗██║ ╚████║███████╗   ██║   
  {AnsiColor.GREEN} ╚═════╝ {AnsiColor.RED} ╚═╝   ╚═╝ ╚═══════╝ ╚═╝       ╚═════╝     ╚═╝    ╚═══════╝ ╚═╝   ╚═╝{AnsiColor.MAGENTA}╚═╝╚═╝  ╚═══╝╚══════╝   ╚═╝   
  {AnsiColor.WHITE}█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
  {AnsiColor.BRIGHT_BLUE}:: JHipster.Net 🤓  :: Running ASP.Net Core 'The best version' ::
:: http://jhipster.github.io ::{AnsiColor.DEFAULT}");
    }
}
