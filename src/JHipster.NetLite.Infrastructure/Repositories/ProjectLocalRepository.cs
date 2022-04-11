using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Infrastructure.Helpers;
using JHipster.NetLite.Infrastucture.Repositories.Exceptions;
using Microsoft.Extensions.Logging;
using JHipster.NetLite.Domain.Services.Interfaces;

namespace JHipster.NetLite.Infrastructure.Repositories;

public class ProjectLocalRepository : IProjectRepository
{
    private const string DefaultExtension = ".mustache";

    private ILogger<IInitDomainService> _logger;

    public ProjectLocalRepository(ILogger<IInitDomainService> logger) => _logger = logger;

    public async Task add(string folder, string source, string sourceFilename)
    {
        await add(folder, source, sourceFilename, ".");
    }

    public async Task add(string folder, string source, string sourceFilename, string destination)
    {
        await add(folder, source, sourceFilename, destination, sourceFilename);
    }

    public async Task add(string folder, string source, string sourceFilename, string destination, string destinationFilename)
    {
        _logger.LogInformation("Adding file '{destinationFilename}'", destinationFilename);
        string destinationFolder = Path.Join(folder, destination);
        string sourcePath = Path.Join(folder, source);

        byte[] dataToCopy = await File.ReadAllBytesAsync(Path.Join(sourcePath, sourceFilename));

        Directory.CreateDirectory(Path.Join(destinationFolder));

        string destinationPath = Path.Join(destinationFolder, destinationFilename);
        await File.WriteAllBytesAsync(destinationPath, dataToCopy);
    }

    public async Task Template(string folder, string pathFile, string fileNameWithExtension)
    {
        await Template(folder, pathFile, fileNameWithExtension, pathFile, fileNameWithExtension);
    }

    public async Task Template(string folder, string pathFile, string fileNameWithExtension, string newPathFile)
    {
        await Template(folder, pathFile, fileNameWithExtension, newPathFile, fileNameWithExtension);
    }

    public async Task Template(string folder, string pathFile, string fileNameWithExtension, string newPathFile, string newPathName)
    {

        AssertRequiredTemplateParameters(folder, pathFile, fileNameWithExtension, newPathFile, newPathName);

        string pathFileToCopy = Path.Join(folder, pathFile, fileNameWithExtension + DefaultExtension);
        string pathFolderToCreate = Path.Join(folder, newPathFile);
        string pathFileToPaste = Path.Join(pathFolderToCreate, newPathName + DefaultExtension);
        var dataToCopy = await File.ReadAllTextAsync(pathFileToCopy);

        _logger.LogInformation("Starting templating '{pathFileToCopy}'", pathFileToCopy);

        Directory.CreateDirectory(pathFolderToCreate);

        File.Delete(pathFileToCopy);
        await File.WriteAllTextAsync(pathFileToPaste, dataToCopy);
        await File.WriteAllTextAsync(pathFileToPaste, await MustacheHelper.Template(pathFileToPaste, getMustacheContext()));

        _logger.LogInformation("Ending templating '{pathFileToPaste}'", pathFileToPaste);
    }

    private Object getMustacheContext()
    {
        return new
        {
            projectName = "JHipster.NetLite"
        };
    }

    private void AssertRequiredTemplateParameters(string folder, string pathFile, string fileNameWithExtension, string newPathFile, string newPathName)
    {
        if (String.IsNullOrEmpty(folder))
        {
            _logger.LogError("The folder '{folder}' is invalid", folder);
            throw new InvalidFolderException("The folder '" + folder + "' is invalid");
        }

        if (String.IsNullOrEmpty(pathFile))
        {
            _logger.LogError("The Readme's path '{pathFile}' is invalid", pathFile);
            throw new InvalidPathFileException("The Readme's path '" + pathFile + "' is invalid");
        }

        if (String.IsNullOrEmpty(fileNameWithExtension))
        {
            _logger.LogError("The file name with extension '{fileNameWithExtension}' is invalid", fileNameWithExtension);
            throw new InvalidFileNameWithExtensionException("The file name with extension '" + fileNameWithExtension + "' is invalid");
        }

        if (String.IsNullOrEmpty(newPathFile))
        {
            _logger.LogError("The new path file '{newPathFile}' is invalid", newPathFile);
            throw new InvalidNewPathFileException("The new path file '" + newPathFile + "' is invalid");
        }

        if (String.IsNullOrEmpty(newPathName))
        {
            _logger.LogError("The new path name '{newPathName}' is invalid", newPathName);
            throw new InvalidNewPathNameException("The new path name '" + newPathName + "' is invalid");
        }
    }
}