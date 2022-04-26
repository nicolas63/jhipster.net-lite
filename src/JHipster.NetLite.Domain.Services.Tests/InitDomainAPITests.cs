using AutoFixture;
using FluentAssertions;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Web.Tests
{
    [TestClass]
    public class InitDomainApiTests
    {
        private IInitDomainApi DomainApi { get; set; }
        public ILogger<InitDomainService> LoggerService { get; set; } = new NullLogger<InitDomainService>();
        public ILogger<InitDomainApi> LoggerApi { get; set; } = new NullLogger<InitDomainApi>();

        private Fixture fixture = new Fixture();

        public InitDomainApiTests()
        {
            DomainApi = new InitDomainApi(new ProjectLocalRepository(LoggerService), LoggerApi);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange

            //Act
            Func<Task> task = async () => await DomainApi.Init(fixture.Create<Project>());

            //Assert
            await task.Should().NotThrowAsync();
        }


    }
}
