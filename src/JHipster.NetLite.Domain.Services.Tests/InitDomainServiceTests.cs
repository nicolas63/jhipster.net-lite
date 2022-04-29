using AutoFixture;
using FluentAssertions;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Domain.Services.Tests
{
    [TestClass]
    public class InitDomainServiceTests
    {
        private IInitDomainService domainService;

        private ILogger<InitDomainService> logger = new NullLogger<InitDomainService>();

        private Fixture fixture = new Fixture();

        private Project project;

        public InitDomainServiceTests()
        {
            domainService = new InitDomainService(new ProjectLocalRepository(logger), logger);
            project = fixture.Create<Project>();
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange

            //Act
            Func<Task> task = async () => await domainService.Init(project);

            //Assert
            await task.Should().NotThrowAsync();

            Directory.Delete(project.Folder, true);
        }


    }
}
