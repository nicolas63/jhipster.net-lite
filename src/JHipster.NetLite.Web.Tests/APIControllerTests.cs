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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Web.Tests
{
    [TestClass]
    public class APIControllerTests
    {
        private APIController ApiController { get; set; }
        public Mock<IInitApplicationAPI> ApplicationAPI { get; set; }

        private Fixture fixture = new Fixture();
        public IMapper Mapper { get; set; }
        public ILogger<APIController> Logger { get; set; } = new NullLogger<APIController>();

        public APIControllerTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(APIController)));
            Mapper = new Mapper(configuration);
        }

        [TestInitialize]
        public void InitTest()
        {
            ApplicationAPI = new Mock<IInitApplicationAPI>();
            ApiController = new APIController(Logger, ApplicationAPI.Object, Mapper);
        }

        [TestMethod]
        public async Task Should_ReturnBadRequest_When_Exception()
        {
            //Arrange
            ApplicationAPI.Setup(app => app.Init(It.IsAny<Project>()))
                .Throws(new Exception("test unitaire"));

            //Act 
            var result = await ApiController.Post(fixture.Create<ProjectDto>());

            //Assert 
            var statusResult = result as BadRequestObjectResult;
            statusResult.Should().NotBeNull();
            statusResult.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task Should_ReturnOkStatusCode_When_Call()
        {
            //Arrange

            //Act
            var result = await ApiController.Post(fixture.Create<ProjectDto>());

            //Assert
            var statusResult = result as OkResult;
            statusResult.Should().NotBeNull();
            statusResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}
