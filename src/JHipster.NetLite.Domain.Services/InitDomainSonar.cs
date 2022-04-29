// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

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

public class InitDomainSonar : IInitDomainSonar
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<InitDomainSonar> _logger;

    public InitDomainSonar(IProjectRepository projectRepository, ILogger<InitDomainSonar> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task Init(Project project)
    {
        await AddSonar(project);
    }

    private async Task AddSonar(Project project)
    {
        await _projectRepository.Add(project.Folder, "Sonar", "SonarQube.Analysis.xml");
    }
}
