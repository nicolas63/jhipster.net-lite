using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CLIWrapper.Tests;

[TestClass]
public class CLIWrappTest
{
    private string testPath = Path.Join(Directory.GetCurrentDirectory(), "TestWrapper");

    private const string DefaultExtension = ".sln";

    private CLIWrapp cliWrapp;

    [TestInitialize]
    public void InitTest()
    {
        Directory.CreateDirectory(testPath);
        cliWrapp = new CLIWrapp(testPath);
    }

    [TestMethod]
    public void Should_CreateNewSln_When_Calling()
    {
        //Arrange
        var solutionName = "Test";

        //Act
        cliWrapp.NewSln(solutionName, false);

        //Assert
        File.Exists(Path.Join(testPath, solutionName + DefaultExtension)).Should().BeTrue();
    }

    [TestMethod]
    public void Should_NotThrow_When_Build()
    {
        //Arrange

        //Act
        cliWrapp.NewSln("Test", true);
        Action act = () => cliWrapp.Build();

        //Assert
        act.Should().NotThrow();
    }
}