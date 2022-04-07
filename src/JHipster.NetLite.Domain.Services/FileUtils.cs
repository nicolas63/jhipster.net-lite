using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandlebarsDotNet;
using JHipster.NetLite.Domain.Services.Exceptions;
using JHipster.NetLite.Infrastructure.Helpers;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Domain.Services;

public class FileUtils
{
    private const string DEFAULT_EXTENSION = ".mustache";

    private ILogger<InitDomainService> _logger;

    public FileUtils(ILogger<InitDomainService> logger) => _logger = logger;

    public void add(string folder, string source, string sourceFilename)
    {
        add(folder, source, sourceFilename, ".");
    }

    public void add(string folder, string source, string sourceFilename, string destination)
    {
        add(folder, source, sourceFilename, destination, sourceFilename);
    }

    public void add(string folder, string source, string sourceFilename, string destination, string destinationFilename)
    {
        _logger.LogInformation("Adding file '{destinationFilename}'", destinationFilename);
        string destinationFolder = Path.Join(folder, destination);
        string sourcePath = Path.Join(folder, source);

        byte[] dataToCopy = File.ReadAllBytes(Path.Join(sourcePath, sourceFilename));

        Directory.CreateDirectory(Path.Join(destinationFolder));

        string destinationPath = Path.Join(destinationFolder, destinationFilename);
        File.WriteAllBytes(destinationPath, dataToCopy);
    }

    public void Template(string folder, string pathFile, string fileNameWithExtension)
    {
        Template(folder, pathFile, fileNameWithExtension, pathFile, fileNameWithExtension);
    }

    public void Template(string folder, string pathFile, string fileNameWithExtension, string newPathFile)
    {
        Template(folder, pathFile, fileNameWithExtension, newPathFile, fileNameWithExtension);
    }

    public void Template(string folder, string pathFile, string fileNameWithExtension, string newPathFile, string newPathName)
    {

        AssertRequiredTemplateParameters(folder, pathFile, fileNameWithExtension, newPathFile, newPathName);

        string pathFileToCopy = Path.Join(folder, pathFile, fileNameWithExtension + DEFAULT_EXTENSION);
        string pathFolderToCreate = Path.Join(folder, newPathFile);
        string pathFileToPaste = Path.Join(pathFolderToCreate, newPathName + DEFAULT_EXTENSION);
        var dataToCopy = File.ReadAllText(pathFileToCopy);

        _logger.LogInformation("Starting templating {pathFileToCopy}", pathFileToCopy);

        Directory.CreateDirectory(pathFolderToCreate);

        File.Delete(pathFileToCopy);
        File.WriteAllText(pathFileToPaste, dataToCopy);
        File.WriteAllText(pathFileToPaste, MustacheHelper.Template(pathFileToPaste, getMustacheContext()));

        _logger.LogInformation("Ending templating {pathFileToPaste}", pathFileToPaste);
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
            _logger.LogError("The folder {folder} is invalid", folder);
            throw new InvalidFolderException("The folder \"" + folder + "\" is invalid");
        }

        if (String.IsNullOrEmpty(pathFile))
        {
            _logger.LogError("The Readme's path {pathFile} is invalid", pathFile);
            throw new InvalidPathFileException("The Readme's path \"" + pathFile + "\" is invalid");
        }

        if (String.IsNullOrEmpty(fileNameWithExtension))
        {
            _logger.LogError("The file name with extension {fileNameWithExtension} is invalid", fileNameWithExtension);
            throw new InvalidFileNameWithExtensionException("The file name with extension \"" + fileNameWithExtension + "\" is invalid");
        }
        
        if (String.IsNullOrEmpty(newPathFile))
        {
            _logger.LogError("The new path file {newPathFile} is invalid", newPathFile);
            throw new InvalidNewPathFileException("The new path file \"" + newPathFile + "\" is invalid");
        }

        if (String.IsNullOrEmpty(newPathName))
        {
            _logger.LogError("The new path name {newPathName} is invalid", newPathName);
            throw new InvalidNewPathNameException("The new path name \"" + newPathName + "\" is invalid");
        }
    }
}
