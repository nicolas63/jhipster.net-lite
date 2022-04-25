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

public class InitApplicationApi : IInitApplicationApi
{
    private readonly IInitDomainApi _initDomainAPI;

    private readonly ILogger<InitApplicationApi> _logger;

    public InitApplicationApi(IInitDomainApi initDomainAPI, ILogger<InitApplicationApi> logger)
    {
        _initDomainAPI = initDomainAPI;
        _logger = logger;
    }
    public async Task Init(Project project)
    {
        await _initDomainAPI.Init(project);
    }
}
