using AutoFixture;
using FluentAssertions;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Application.Services;
using JHipster.NetLite.Domain.Entities;
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
    public class InitApplicationApiTests
    {

        private IInitApplicationApi ApplicationApi { get; set; }
        public Mock<IInitDomainApi> DomainApi { get; set; }
        public ILogger<InitApplicationApi> Logger { get; set; } = new NullLogger<InitApplicationApi>();

        private Fixture fixture = new Fixture();

        public InitApplicationApiTests()
        {
            DomainApi = new Mock<IInitDomainApi>();
            ApplicationApi = new InitApplicationApi(DomainApi.Object, Logger);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange
            var project = fixture.Create<Project>();
            DomainApi.Setup(m => m.Init(project)).Returns(Task.FromResult(true));

            //Act
            Func<Task> task = async () => await ApplicationApi.Init(project);

            //Assert
            await task.Should().NotThrowAsync();
        }
    }
}
