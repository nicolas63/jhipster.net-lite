using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using JHipster.NetLite.Application.Services;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JHipster.NetLite.Application.Tests
{
    [TestClass]
    public class InitApplicationServiceTests
    {

        private IInitApplicationService applicationService;

        private Mock<IInitDomainService> domainService;

        private ILogger<InitApplicationService> logger = new NullLogger<InitApplicationService>();

        private Fixture fixture = new Fixture();

        public InitApplicationServiceTests()
        {
            domainService = new Mock<IInitDomainService>();
            applicationService = new InitApplicationService(domainService.Object, logger);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange
            var project = fixture.Create<Project>();
            domainService.Setup(m => m.Init(project)).Returns(Task.FromResult(true));

            //Act
            Func<Task> task = async () => await applicationService.Init(project);

            //Assert
            await task.Should().NotThrowAsync();
        }
    }
}
