using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Web.Tests
{
    [TestClass]
    public class ServiceCollectionExtensionsTests
    { 

        private WebApplicationBuilder builder { get; set; }

        public ServiceCollectionExtensionsTests()
        {
        }

        [TestInitialize]
        public void InitTest()
        {
            builder = WebApplication.CreateBuilder();
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Calling()
        {
            //Arrange


            //Act
            Action act = () => builder.Services.AddControllers().AddJHipsterLite();

            //Assert
            act.Should().NotThrow();
        }
    }
}
