using HandlebarsDotNet.Compiler;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Domain.Services;

public class InitDomainService : IInitDomainService
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<InitDomainService> _logger;

    public InitDomainService(IProjectRepository projectRepository, ILogger<InitDomainService> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task Init(Project project)
    {
        await AddReadme(project);
        await InitSolution(project);
    }

    private async Task AddReadme(Project project)
    {
        await _projectRepository.Template(project, "Init", "Readme.md");
    }

    private async Task InitSolution(Project project)
    {
        //Solution
        _projectRepository.GenerateSolution(project, "projectName");
        //csproj
        await _projectRepository.Template(project, "WebApiGeneration", project.ProjectName + ".csproj");
        _projectRepository.AddProjectsToSolution(project, "projectName", project.ProjectName);
    }
}
