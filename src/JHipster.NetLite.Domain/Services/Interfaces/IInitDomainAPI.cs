using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Domain.Services.Interfaces;

public interface IInitDomainApi
{
    Task Init(Project project);
}
