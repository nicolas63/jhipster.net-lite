﻿using FluentAssertions;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Web.Tests
{
    [TestClass]
    public class ProjectLocalRepositoryTest
    {
        private const string PathFile = "Init";

        private const string FileNameWithExtension = "Readme.md";

        private const string DefaultExtension = ".mustache";

        private const string DataInitialisationToCopy = "Test text";

        private const string FileToCopy = "FileToCopy.txt";

        private string folder = Path.Join(Directory.GetCurrentDirectory(), "Test");

        private string sourceFolder = Path.Join(Directory.GetCurrentDirectory(), "Test", "Copy");

        private ProjectLocalRepository ProjectRepository { get; set; }

        private IInitDomainService DomainService { get; set; }

        public ILogger<InitDomainService> Logger { get; set; } = new NullLogger<InitDomainService>();

        public ProjectLocalRepositoryTest()
        {
        }

        [TestInitialize]
        public async Task InitTest()
        {
            ProjectRepository = new ProjectLocalRepository(Logger);
            DomainService = new InitDomainService(ProjectRepository, Logger);
            Directory.CreateDirectory(sourceFolder);
            await File.WriteAllTextAsync(Path.Join(sourceFolder, FileToCopy), DataInitialisationToCopy);
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public async Task Should_ThrowException_When_Call()
        {
            //Arrange

            //Act
            await DomainService.Init(new Project(Path.Join("NOTHING", folder),"","",""));

            //Assert
        }

        [TestMethod]
        public async Task Should_TemplateReadme_When_Call()
        {
            //Arrange
            var folderPathBeforeTemplating = Path.Join(Directory.GetCurrentDirectory(), "Templates");

            //Act
            var TextBeforeTemplating = await File.ReadAllTextAsync(Path.Join(folderPathBeforeTemplating, PathFile, FileNameWithExtension + DefaultExtension));
            await ProjectRepository.Template(new Project(folder, "", "", ""), PathFile, FileNameWithExtension);
            var TextAfterTemplating = await File.ReadAllTextAsync(Path.Join(folder, PathFile, FileNameWithExtension + DefaultExtension));

            //Assert
            TextBeforeTemplating.Should().NotBeEquivalentTo(TextAfterTemplating);
        }

        [TestMethod]
        public async Task Should_TemplateMoveReadme_When_Call()
        {
            //Arrange
            var newPathFile = "Redirect";

            //Act
            await ProjectRepository.Template(new Project(folder, "", "", ""), PathFile, FileNameWithExtension, newPathFile);

            //Assert
            File.Exists(Path.Join(folder, newPathFile, FileNameWithExtension + DefaultExtension)).Should().BeTrue();

        }

        [TestMethod]
        public async Task Should_TemplateMoveRenameReadme_When_Call()
        {
            //Arrange
            var newPathFile = "Redirect";
            var newPathName = "Suuuuu.md";

            //Act
            await ProjectRepository.Template(new Project(folder, "", "", ""), PathFile, FileNameWithExtension, newPathFile, newPathName);

            //Assert
            File.Exists(Path.Join(folder, newPathFile, newPathName + DefaultExtension)).Should().BeTrue();

        }

        [TestMethod]
        public async Task Should_CopyText_When_Call()
        {
            //Arrange
            var TextToCopy = await File.ReadAllTextAsync(Path.Join(sourceFolder, FileToCopy));

            //Act
            await ProjectRepository.Add(folder, sourceFolder, FileToCopy);

            //Assert
            TextToCopy.Should().BeEquivalentTo(await File.ReadAllTextAsync(Path.Join(folder, FileToCopy)));

        }

        [TestMethod]
        public async Task Should_MoveCopyText_When_Call()
        {
            //Arrange
            var destinationFolder = "Redirect";
            var TextToCopy = await File.ReadAllTextAsync(Path.Join(sourceFolder, FileToCopy));

            //Act
            await ProjectRepository.Add(folder, sourceFolder, FileToCopy, destinationFolder);

            //Assert
            Directory.Exists(Path.Join(folder, destinationFolder)).Should().BeTrue();
            TextToCopy.Should().BeEquivalentTo(await File.ReadAllTextAsync(Path.Join(folder, destinationFolder,FileToCopy)));

        }

        [TestMethod]
        public async Task Should_MoveCopyTextRename_When_Call()
        {
            //Arrange
            var destinationFolder = "Redirect";
            var destinationFileName = "Renamed.txt";
            var TextToCopy = await File.ReadAllTextAsync(Path.Join(sourceFolder, FileToCopy));

            //Act
            await ProjectRepository.Add(folder, sourceFolder, FileToCopy, destinationFolder, destinationFileName);

            //Assert
            Directory.Exists(Path.Join(folder, destinationFolder)).Should().BeTrue();
            File.Exists(Path.Join(folder, destinationFolder, destinationFileName)).Should().BeTrue();
            TextToCopy.Should().BeEquivalentTo(await File.ReadAllTextAsync(Path.Join(folder, destinationFolder, FileToCopy)));

        }
    }
}