using HandlebarsDotNet;

namespace JHipster.NetLite.Infrastructure.Helpers;

public static class MustacheHelper
{
    public static async Task<string> Template(string filePath, object context)
    {
        var source = await File.ReadAllTextAsync(filePath);
        var template = Handlebars.Compile(source);
        return template(context); 
    }
}
