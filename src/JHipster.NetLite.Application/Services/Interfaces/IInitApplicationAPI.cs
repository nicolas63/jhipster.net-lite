using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Application.Services.Interfaces;

public interface IInitApplicationApi
{
    Task Init(Project project);
}
