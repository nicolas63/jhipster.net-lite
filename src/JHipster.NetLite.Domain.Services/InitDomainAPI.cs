using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Domain.Services;

public class InitDomainApi : IInitDomainApi
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<InitDomainApi> _logger;

    public InitDomainApi(IProjectRepository projectRepository, ILogger<InitDomainApi> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task Init(Project project)
    {
        await CreateAPI(project);
    }

    public async Task CreateAPI(Project project)
    {
        await _projectRepository.Template(project, "WebApiGeneration", "WeatherForecast.cs");
        await _projectRepository.Template(project, "WebApiGeneration", "Program.cs");
        await _projectRepository.Template(project, "WebApiGeneration", "appsettings.json");
        await _projectRepository.Template(project, "WebApiGeneration", "appsettings.Development.json");
        await _projectRepository.Template(project, Path.Join("WebApiGeneration", "Properties"), "launchSettings.json");
        await _projectRepository.Template(project, Path.Join("WebApiGeneration", "Controllers"), "WeatherForecastController.cs");
        _projectRepository.GenerateSolution(project, "projectName");
        await _projectRepository.Template(project, "WebApiGeneration", "projectName.csproj");
        _projectRepository.AddProjectsToSolution(project, "projectName", "projectName");
        await _projectRepository.Add(project.Folder, "WebApiGeneration", ".editorconfig");
        _projectRepository.StartUnitsTests(project);
    }
}
