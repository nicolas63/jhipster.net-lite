namespace JHipster.NetLite.Domain.Repositories.Interfaces;

public interface IProjectRepository
{
    Task Add(string folder, string source, string sourceFilename);

    Task Add(string folder, string source, string sourceFilename, string destination);

    Task Add(string folder, string source, string sourceFilename, string destination, string destinationFilename);

    Task Template(string folder, string pathFile, string fileNameWithExtension);

    Task Template(string folder, string pathFile, string fileNameWithExtension, string newPathFile);

    Task Template(string folder, string pathFile, string fileNameWithExtension, string newPathFile, string newPathName);
}
