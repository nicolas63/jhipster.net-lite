using HandlebarsDotNet.Compiler;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Helpers;
using JHipster.NetLite.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Domain.Services;

public class InitDomainService : IInitDomainService
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<InitDomainService> _logger;

    public InitDomainService(IProjectRepository projectRepository, ILogger<InitDomainService> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public void Init(Project project)
    {
        AddReadme(project);
    }

    private void AddReadme(Project project)
    {
        //new FileUtils(_logger).add(project.Folder, "Init", "Readme.md.mustache", "test", "new.md.mustache"); --> test add

        new ProjectLocalRepository(_logger).Template(project.Folder, "Init", "Readme.md");
        //Template(project.Folder, "Init", "Readme.md", "Test/ReadMe/", "Toto.md"); 
        //MustacheHelper.Template(project.Folder); 
    }
}
