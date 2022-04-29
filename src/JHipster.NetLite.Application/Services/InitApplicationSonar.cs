// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Application.Services;

public class InitApplicationSonar : IInitApplicationSonar
{
    private readonly IInitDomainSonar _initDomainSonar;

    private readonly ILogger<InitApplicationSonar> _logger;

    public InitApplicationSonar(IInitDomainSonar initDomainSonar, ILogger<InitApplicationSonar> logger)
    {
        _initDomainSonar = initDomainSonar;
        _logger = logger;
    }

    public async Task Init(Project project)
    {
        await _initDomainSonar.Init(project);
    }
}
