using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Application.Services.Interfaces;

public interface IInitApplicationAPI
{
    Task Init(Project project);
}
