namespace JHipster.NetLite.Domain.Repositories.Interfaces;

public interface IProjectRepository
{
    Task add(string folder, string source, string sourceFilename);

    Task add(string folder, string source, string sourceFilename, string destination);

    Task add(string folder, string source, string sourceFilename, string destination, string destinationFilename);

    Task Template(string folder, string pathFile, string fileNameWithExtension);

    Task Template(string folder, string pathFile, string fileNameWithExtension, string newPathFile);

    Task Template(string folder, string pathFile, string fileNameWithExtension, string newPathFile, string newPathName);
}
