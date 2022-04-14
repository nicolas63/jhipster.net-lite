using FluentAssertions;
using JHipster.NetLite.Infrastucture.Repositories.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Infrastructure.Tests
{
    [TestClass]
    public class ExceptionsTests
    {

        public ExceptionsTests()
        {
        }

        [TestInitialize]
        public void InitTest()
        {
        }

        [TestMethod]
        public void Should_ThrowInvalidFileNameWithExtensionException_When_Throw()
        {
            //Arrange

            //Act
            Action act = () => throw new InvalidFileNameWithExtensionException();
            Action act2 = () => throw new InvalidFileNameWithExtensionException("message");
            Action act3 = () => throw new InvalidFileNameWithExtensionException("message", new Exception());

            //Assert
            act.Should().Throw<InvalidFileNameWithExtensionException>();
            act2.Should().Throw<InvalidFileNameWithExtensionException>();
            act3.Should().Throw<InvalidFileNameWithExtensionException>();

        }

        [TestMethod]
        public void Should_ThrowInvalidFolderException_When_Throw()
        {
            //Arrange

            //Act
            Action act = () => throw new InvalidFolderException();
            Action act2 = () => throw new InvalidFolderException("message");
            Action act3 = () => throw new InvalidFolderException("message", new Exception());

            //Assert
            act.Should().Throw<InvalidFolderException>();
            act2.Should().Throw<InvalidFolderException>();
            act3.Should().Throw<InvalidFolderException>();

        }

        [TestMethod]
        public void Should_ThrowInvalidNewPathFileException_When_Throw()
        {
            //Arrange


            //Act
            Action act = () => throw new InvalidNewPathFileException();
            Action act2 = () => throw new InvalidNewPathFileException("message");
            Action act3 = () => throw new InvalidNewPathFileException("message", new Exception());

            //Assert
            act.Should().Throw<InvalidNewPathFileException>();
            act2.Should().Throw<InvalidNewPathFileException>();
            act3.Should().Throw<InvalidNewPathFileException>();

        }

        [TestMethod]
        public void Should_ThrowInvalidNewPathNameExceptionException_When_Throw()
        {
            //Arrange


            ///Act
            Action act = () => throw new InvalidNewPathNameException();
            Action act2 = () => throw new InvalidNewPathNameException("message");
            Action act3 = () => throw new InvalidNewPathNameException("message", new Exception());

            //Assert
            act.Should().Throw<InvalidNewPathNameException>();
            act2.Should().Throw<InvalidNewPathNameException>();
            act3.Should().Throw<InvalidNewPathNameException>();

        }

        [TestMethod]
        public void Should_ThrowInvalidPathFileException_When_Throw()
        {
            //Arrange


            //Act
            Action act = () => throw new InvalidPathFileException();
            Action act2 = () => throw new InvalidPathFileException("message");
            Action act3 = () => throw new InvalidPathFileException("message", new Exception());

            //Assert
            act.Should().Throw<InvalidPathFileException>();
            act2.Should().Throw<InvalidPathFileException>();
            act3.Should().Throw<InvalidPathFileException>();

        }
    }
}
