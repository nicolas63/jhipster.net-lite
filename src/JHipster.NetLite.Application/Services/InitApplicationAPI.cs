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

public class InitApplicationAPI : IInitApplicationAPI
{
    private readonly IInitDomainAPI _initDomainAPI;

    private readonly ILogger<InitApplicationAPI> _logger;

    public InitApplicationAPI(IInitDomainAPI initDomainAPI, ILogger<InitApplicationAPI> logger)
    {
        _initDomainAPI = initDomainAPI;
        _logger = logger;
    }
    public async Task Init(Project project)
    {
        await _initDomainAPI.Init(project);
    }
}
