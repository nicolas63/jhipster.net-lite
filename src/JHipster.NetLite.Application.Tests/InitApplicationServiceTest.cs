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

namespace JHipster.NetLite.Web.Tests
{
    [TestClass]
    public class InitApplicationServiceTest
    {

        private IInitApplicationService ApplicationService { get; set; }
        public Mock<IInitDomainService> DomainService { get; set; }
        public ILogger<InitApplicationService> Logger { get; set; } = new NullLogger<InitApplicationService>();

        private Fixture fixture = new Fixture();

        public InitApplicationServiceTest()
        {
        }

        [TestInitialize]
        public void InitTest()
        {
            DomainService = new Mock<IInitDomainService>();
            ApplicationService = new InitApplicationService(DomainService.Object, Logger);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange
            var project = fixture.Create<Project>();
            DomainService.Setup(m => m.Init(project)).Returns(Task.FromResult(true));

            //Act
            Func<Task> task = async () => await ApplicationService.Init(project);

            //Assert
            await task.Should().NotThrowAsync();
        }
    }
}
