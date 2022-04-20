using HandlebarsDotNet;
using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Infrastructure.Helpers;

public static class MustacheHelper
{
    public static async Task<string> Template(string filePath, Project project)
    {
        var source = await File.ReadAllTextAsync(filePath);
        var template = Handlebars.Compile(source);
        return template(new
        {
            projectName = project.ProjectName,
            namespaceValue = project.Namespace
        }); 
    }
}
