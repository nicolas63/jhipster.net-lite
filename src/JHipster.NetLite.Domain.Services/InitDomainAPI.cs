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

public class InitDomainAPI : IInitDomainAPI
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<InitDomainAPI> _logger;

    public InitDomainAPI(IProjectRepository projectRepository, ILogger<InitDomainAPI> logger)
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
        _projectRepository.GenerateSolution("Test");
    }
}
