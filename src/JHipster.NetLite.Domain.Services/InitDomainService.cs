using HandlebarsDotNet.Compiler;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Helpers;

namespace JHipster.NetLite.Domain.Services;

public class InitDomainService : IInitDomainService
{
    private readonly IProjectRepository _projectRepository;

    public InitDomainService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public void Init(Project project)
    {
        AddReadme(project);
    }

    private void AddReadme(Project project)
    {

        //Template(project.Folder, "Init", "Readme.md", "Test/ReadMe/", "Toto.md"); 
        //MustacheHelper.Template(project.Folder); 
    }
}
