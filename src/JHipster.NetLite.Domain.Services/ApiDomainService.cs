using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Domain.Services;

public class ApiDomainService : IApiDomainService
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<ApiDomainService> _logger;

    public ApiDomainService(IProjectRepository projectRepository, ILogger<ApiDomainService> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task Init(Project project)
    {
        await CreateAPI(project);
    }

    private async Task CreateAPI(Project project)
    {
        //Web Api
        await _projectRepository.Template(project, "WebApiGeneration", "WeatherForecast.cs");
        await _projectRepository.Template(project, "WebApiGeneration", "Program.cs");
        await _projectRepository.Template(project, "WebApiGeneration", "appsettings.json");
        await _projectRepository.Template(project, "WebApiGeneration", "appsettings.Development.json");
        await _projectRepository.Template(project, Path.Join("WebApiGeneration", "Properties"), "launchSettings.json");
        await _projectRepository.Template(project, Path.Join("WebApiGeneration", "Controllers"), "WeatherForecastController.cs");
        //Editorconfig
        await _projectRepository.Add(project.Folder, "WebApiGeneration", ".editorconfig");
    }
}
