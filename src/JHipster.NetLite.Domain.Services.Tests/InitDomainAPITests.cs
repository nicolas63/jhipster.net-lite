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
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Domain.Services.Tests
{
    [TestClass]
    public class InitDomainApiTests
    {
        private IInitDomainApi domainApi;

        private ILogger<InitDomainService> loggerService = new NullLogger<InitDomainService>();

        private ILogger<InitDomainApi> loggerApi = new NullLogger<InitDomainApi>();

        private Fixture fixture = new Fixture();

        private Project project;

        public InitDomainApiTests()
        {
            domainApi = new InitDomainApi(new ProjectLocalRepository(loggerService), loggerApi);
            project = fixture.Create<Project>();
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange

            //Act
            Func<Task> task = async () => await domainApi.Init(project);

            //Assert
            await task.Should().NotThrowAsync();

            Directory.Delete(project.Folder, true);
        }


    }
}
