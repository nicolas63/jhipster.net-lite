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

namespace JHipster.NetLite.Web.Tests
{
    [TestClass]
    public class IniteDomainServiceTest
    {
        private IInitDomainService DomainService { get; set; }
        private Project Project { get; set; }
        public ILogger<InitDomainService> Logger { get; set; } = new NullLogger<InitDomainService>();

        public IniteDomainServiceTest()
        {
        }

        [TestInitialize]
        public async Task InitTest()
        {
            Project = new Project(Path.Join(Directory.GetCurrentDirectory(), "Test"));
            DomainService = new InitDomainService(new ProjectLocalRepository(Logger), Logger);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange

            //Act
            Func<Task> task = async () => await DomainService.Init(Project);

            //Assert
            await task.Should().NotThrowAsync();
        }

        
    }
}
