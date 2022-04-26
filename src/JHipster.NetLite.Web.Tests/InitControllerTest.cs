using AutoFixture;
using AutoMapper;
using FluentAssertions;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.Controllers.Projects;
using JHipster.NetLite.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;

namespace JHipster.NetLite.Web.Tests
{
    [TestClass]
    public class InitControllerTest
    {
        private InitController InitController { get; set; }
        public Mock<IInitApplicationService> ApplicationService { get; set; }
        private Fixture fixture = new Fixture();
        public IMapper Mapper { get; set; }
        public ILogger<InitController> Logger { get; set; } = new NullLogger<InitController>();
        
        public InitControllerTest()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(InitController)));
            Mapper = new Mapper(configuration);
            ApplicationService = new Mock<IInitApplicationService>();
            InitController = new InitController(Logger, ApplicationService.Object, Mapper);
        }

        [TestMethod]
        public async Task Should_ReturnBadRequest_When_Exception()
        {
            //Arrange
            ApplicationService.Setup(app => app.Init(It.IsAny<Project>()))
                .Throws(new Exception("test unitaire"));

            //Act 
            var result = await InitController.Post(new ProjectDto("","","",""));

            //Assert 
            var statusResult = result as BadRequestObjectResult;
            statusResult.Should().NotBeNull();
            statusResult.StatusCode.Should().Be((int) HttpStatusCode.BadRequest);

            //TODO cast ton resulkt en BadRequestResult https://docs.microsoft.com/fr-fr/dotnet/api/microsoft.aspnetcore.mvc.badrequestresult?view=aspnetcore-6.0
            // cette classe existe aussi mais elle est moins précise => https://docs.microsoft.com/fr-fr/dotnet/api/microsoft.aspnetcore.mvc.statuscoderesult?view=aspnetcore-6.0

            //TODO regarde les trois A en test 
        }

        [TestMethod]
        public async Task Should_ReturnOkStatusCode_When_Call()
        {
            //Arrange

            //Act
            var result = await InitController.Post(fixture.Create<ProjectDto>());

            //Assert
            var statusResult = result as OkResult;
            statusResult.Should().NotBeNull();
            statusResult.StatusCode.Should().Be((int) HttpStatusCode.OK);
        }
    }
}