namespace JHipster.NetLite.Domain.Repositories.Interfaces;

public interface IProjectRepository
{
    void add(string folder, string source, string sourceFilename);

    void add(string folder, string source, string sourceFilename, string destination);

    void add(string folder, string source, string sourceFilename, string destination, string destinationFilename);

    void Template(string folder, string pathFile, string fileNameWithExtension);

    void Template(string folder, string pathFile, string fileNameWithExtension, string newPathFile);

    void Template(string folder, string pathFile, string fileNameWithExtension, string newPathFile, string newPathName);
}
