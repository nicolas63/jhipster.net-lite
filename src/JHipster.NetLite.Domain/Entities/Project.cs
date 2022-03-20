namespace JHipster.NetLite.Domain.Entities;

public class Project
{
    public Project(string folder) => Folder = folder;

    public string Folder { get; set; }
}
