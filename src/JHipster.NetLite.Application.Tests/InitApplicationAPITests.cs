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

namespace JHipster.NetLite.Application.Tests
{
    [TestClass]
    public class InitApplicationApiTests
    {

        private IInitApplicationApi applicationApi;

        private Mock<IInitDomainApi> domainApi;

        private ILogger<InitApplicationApi> logger = new NullLogger<InitApplicationApi>();

        private Fixture fixture = new Fixture();

        public InitApplicationApiTests()
        {
            domainApi = new Mock<IInitDomainApi>();
            applicationApi = new InitApplicationApi(domainApi.Object, logger);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange
            var project = fixture.Create<Project>();
            domainApi.Setup(m => m.Init(project)).Returns(Task.FromResult(true));

            //Act
            Func<Task> task = async () => await applicationApi.Init(project);

            //Assert
            await task.Should().NotThrowAsync();
        }
    }
}
