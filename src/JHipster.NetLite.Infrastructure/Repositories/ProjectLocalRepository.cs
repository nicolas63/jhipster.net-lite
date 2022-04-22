using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Infrastructure.Helpers;
using JHipster.NetLite.Infrastucture.Repositories.Exceptions;
using Microsoft.Extensions.Logging;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Infrastructure.Utils;
using System.Text;
using System.Reflection;

namespace JHipster.NetLite.Infrastructure.Repositories;

public class ProjectLocalRepository : IProjectRepository
{
    public string DefaultFolder = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Templates");

    private ILogger<IInitDomainService> _logger;

    public ProjectLocalRepository(ILogger<IInitDomainService> logger) => _logger = logger;

    public async Task Add(string folder, string source, string sourceFilename)
    {
        await Add(folder, source, sourceFilename, ".");
    }

    public async Task Add(string folder, string source, string sourceFilename, string destination)
    {
        await Add(folder, source, sourceFilename, destination, sourceFilename);
    }

    public async Task Add(string folder, string source, string sourceFilename, string destination, string destinationFilename)
    {
        _logger.LogInformation("Adding file '{destinationFilename}'", destinationFilename);
        string destinationFolder = Path.Join(folder, destination);

        byte[] dataToCopy = await File.ReadAllBytesAsync(Path.Join(source, sourceFilename));

        Directory.CreateDirectory(Path.Join(destinationFolder));

        string destinationPath = Path.Join(destinationFolder, destinationFilename);
        await File.WriteAllBytesAsync(destinationPath, dataToCopy);
    }

    public async Task Template(Project project, string pathFile, string fileNameWithExtension)
    {
        await Template(project, pathFile, fileNameWithExtension, ".");
    }

    public async Task Template(Project project, string pathFile, string fileNameWithExtension, string newPathFile)
    {
        await Template(project, pathFile, fileNameWithExtension, newPathFile, fileNameWithExtension);
    }

    public async Task Template(Project project, string pathFile, string fileNameWithExtension, string newPathFile, string newPathName)
    {
        AssertRequiredTemplateParameters(project.Folder, pathFile, fileNameWithExtension, newPathFile, newPathName);

        var folders = pathFile.Split(Path.DirectorySeparatorChar);

        string pathFileToCopy = Path.Join(DefaultFolder, pathFile, MustacheHelper.WithExt(fileNameWithExtension));
        string pathFolderToCreate= Path.Join(project.Folder, newPathFile);
        string foldersPath = pathFolderToCreate;

        _logger.LogInformation("Starting templating '{pathFileToCopy}'", pathFileToCopy);

        Directory.CreateDirectory(pathFolderToCreate);
        if(folders.Length >= 2){
            for (int i = 1; i < folders.Length; i++)
            {
                foldersPath = Path.Join(foldersPath, folders[i]);
                Directory.CreateDirectory(foldersPath);
            }
        }
        string pathFileToPaste = Path.Join(foldersPath, newPathName);

        var dataToPast = await MustacheHelper.Template(pathFileToCopy, project);
        await File.WriteAllTextAsync(pathFileToPaste,dataToPast);

        _logger.LogInformation("Ending templating '{pathFileToPaste}'", pathFileToPaste);
    }

    public void GenerateSolution(Project project, string solutionName)
    {
        DotnetCLIWrapper dotnetCLIWrapper = new DotnetCLIWrapper(project.Folder, _logger);
        dotnetCLIWrapper.NewSln(solutionName, true);
    }

    private void AssertRequiredTemplateParameters(string folder, string pathFile, string fileNameWithExtension, string newPathFile, string newPathName)
    {
        if (String.IsNullOrEmpty(folder))
        {
            _logger.LogError("The folder '{folder}' is invalid", folder);
            throw new InvalidFolderException($"The folder '{folder}' is invalid");
        }

        if (String.IsNullOrEmpty(pathFile))
        {
            _logger.LogError("The Readme's path '{pathFile}' is invalid", pathFile);
            throw new InvalidPathFileException($"The Readme's path 'pathFile' is invalid");
        }

        if (String.IsNullOrEmpty(fileNameWithExtension))
        {
            _logger.LogError("The file name with extension '{fileNameWithExtension}' is invalid", fileNameWithExtension);
            throw new InvalidFileNameWithExtensionException($"The file name with extension 'fileNameWithExtension' is invalid");
        }

        if (String.IsNullOrEmpty(newPathFile))
        {
            _logger.LogError("The new path file '{newPathFile}' is invalid", newPathFile);
            throw new InvalidNewPathFileException($"The new path file 'newPathFile' is invalid");
        }

        if (String.IsNullOrEmpty(newPathName))
        {
            _logger.LogError("The new path name '{newPathName}' is invalid", newPathName);
            throw new InvalidNewPathNameException($"The new path name 'newPathName' is invalid");
        }
    }
}