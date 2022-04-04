using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services.Interfaces;

namespace JHipster.NetLite.Application.Services;

public class InitApplicationService : IInitApplicationService
{
    private readonly IInitDomainService _initDomainService;

    public InitApplicationService(IInitDomainService initDomainService)
    {
        _initDomainService = initDomainService;
    }

    public void Init(Project project)
    {
        _initDomainService.Init(project);
    }
}
