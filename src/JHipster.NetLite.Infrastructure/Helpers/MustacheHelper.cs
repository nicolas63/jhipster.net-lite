using HandlebarsDotNet;

namespace JHipster.NetLite.Infrastructure.Helpers;

public static class MustacheHelper
{
    public static string Template(string filePath, object context)
    {
        var source = File.ReadAllText(filePath);
        var template = Handlebars.Compile(source);
        return template(context); 
    }
}
