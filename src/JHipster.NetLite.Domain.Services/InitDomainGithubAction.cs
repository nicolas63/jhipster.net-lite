// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Domain.Services;

public class InitDomainGithubAction : IInitDomainGithubAction
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<InitDomainGithubAction> _logger;

    public InitDomainGithubAction(IProjectRepository projectRepository, ILogger<InitDomainGithubAction> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task Init(Project project)
    {
        await AddGithubAction(project);
    }

    private async Task AddGithubAction(Project project)
    {
        //Dotnet yml
        await _projectRepository.Add(project.Folder, Path.Join("GithubAction", ".github", "workflows"), "dotnet.yml");
    }
}
