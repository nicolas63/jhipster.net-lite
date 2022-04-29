// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Application.Services;

public class InitApplicationGithubAction : IInitApplicationGithubAction
{
    private readonly IInitDomainGithubAction _initDomainGithubAction;

    private readonly ILogger<InitApplicationGithubAction> _logger;

    public InitApplicationGithubAction(IInitDomainGithubAction initDomainGithubAction, ILogger<InitApplicationGithubAction> logger)
    {
        _initDomainGithubAction = initDomainGithubAction;
        _logger = logger;
    }

    public async Task Init(Project project)
    {
        await _initDomainGithubAction.Init(project);
    }
}
