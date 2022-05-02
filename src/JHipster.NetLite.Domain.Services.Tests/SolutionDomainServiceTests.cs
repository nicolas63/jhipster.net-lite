﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using AutoFixture;
using FluentAssertions;
using JHipster.NetLite.Domain.Entities;
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

namespace JHipster.NetLite.Domain.Services.Tests
{
    [TestClass]
    public class SolutionDomainServiceTests
    {
        private ISolutionDomainService _solutionDomainService;

        private ILogger<InitDomainService> _loggerInit = new NullLogger<InitDomainService>();

        private ILogger<SolutionDomainService> _loggerSolution = new NullLogger<SolutionDomainService>();

        private string _currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private string _projectFolder;

        private Fixture _fixture = new Fixture();

        private Project _project;

        public SolutionDomainServiceTests()
        {
            _solutionDomainService = new SolutionDomainService(new ProjectLocalRepository(_loggerInit), _loggerSolution);
            _project = _fixture.Create<Project>();
            _projectFolder = Path.Join(_currentFolder, _project.Folder);
            Directory.CreateDirectory(_projectFolder);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange

            //Act
            await _solutionDomainService.Init(_project);
            Func<Task> task = async () => await _solutionDomainService.Init(_project);

            //Assert
            await task.Should().NotThrowAsync();

            Directory.Delete(_project.Folder, true);
        }


    }
}
