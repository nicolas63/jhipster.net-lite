using HandlebarsDotNet.Compiler;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace JHipster.NetLite.Domain.Services;

public class InitDomainService : IInitDomainService
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<InitDomainService> _logger;

    private const string CsprojName = "ProjectName";

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
        _projectRepository.GenerateSolution(project, project.ProjectName);
        //csproj
        await _projectRepository.Template(project, "WebApiGeneration", CsprojName + ".csproj");
        _projectRepository.AddProjectsToSolution(project, project.ProjectName, CsprojName);
    }
}
