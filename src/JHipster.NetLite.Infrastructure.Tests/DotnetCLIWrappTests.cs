using FluentAssertions;
using JHipster.NetLite.Infrastructure.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CLIWrapper.Tests;

[TestClass]
public class CLIWrappTest
{
    private string testPath = Path.Join(Directory.GetCurrentDirectory(), "TestWrapper");

    private const string DefaultExtension = ".sln";

    private DotnetCLIWrapper dotnetCliWrapp;

    [TestInitialize]
    public void InitTest()
    {
        if (Directory.Exists(testPath))
        {
            Directory.Delete(testPath, true);
        }
        Directory.CreateDirectory(testPath);
        dotnetCliWrapp = new DotnetCLIWrapper(testPath);
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