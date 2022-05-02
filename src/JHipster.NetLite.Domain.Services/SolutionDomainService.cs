// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Domain.Services;

public class SolutionDomainService : ISolutionDomainService
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<SolutionDomainService> _logger;

    public SolutionDomainService(IProjectRepository projectRepository, ILogger<SolutionDomainService> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task Init(Project project)
    {
        await InitSolution(project);
    }

    private async Task InitSolution(Project project)
    {
        //Solution
        _projectRepository.GenerateSolution(project, "projectName");
        //csproj
        await _projectRepository.Template(project, "WebApiGeneration", "projectName.csproj");
        _projectRepository.AddProjectsToSolution(project, "projectName", "projectName");
    }
}
