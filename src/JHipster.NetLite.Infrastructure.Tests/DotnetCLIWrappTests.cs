using FluentAssertions;
using JHipster.NetLite.Domain.Services;
using JHipster.NetLite.Infrastructure.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace JHipster.NetLite.Web.Tests
{

    [TestClass]
    public class DotnetCliWrappTests
    {
        private string testPath = Path.Join(Directory.GetCurrentDirectory(), "TestWrapper");

        private const string DefaultExtension = ".sln";

        private DotnetCliWrapper? dotnetCliWrapp;

        private ILogger<InitDomainService> Logger { get; set; } = new NullLogger<InitDomainService>();

        [TestInitialize]
        public void InitTest()
        {
            if (Directory.Exists(testPath))
            {
                Directory.Delete(testPath, true);
            }
            Directory.CreateDirectory(testPath);
            dotnetCliWrapp = new DotnetCliWrapper(testPath, Logger);
        }

        [TestMethod]
        public void Should_CreateNewSln_When_Calling()
        {
            //Arrange
            var solutionName = "Test";

            //Act
            dotnetCliWrapp.NewSln(solutionName, false);

            //Assert
            File.Exists(Path.Join(testPath, solutionName + DefaultExtension)).Should().BeTrue();
        }

        [TestMethod]
        public void Should_NotThrow_When_Build()
        {
            //Arrange

            //Act
            dotnetCliWrapp.NewSln("Test", true);
            Action act = () => dotnetCliWrapp.Build();

            //Assert
            act.Should().NotThrow();
        }
    }
}
