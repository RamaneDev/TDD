using Customers.API.Controllers;
using Customers.API.Models;
using Customers.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xunit;

namespace Customersapi.Tests.Controllers
{
    public class TestUsersController
    {
        [Fact]
        public async Task Get_OnSuccess_ReurnsStatusCode200()
        {            
            //Arrange
            var mockUserService = new Mock<IUserService>();

            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUserService.Object);

            //Act
            var result = (OkObjectResult)await sut.Get();

            //Assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task Get_OnSuccess_InvokeUserServiceExactlyOnce()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();

            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());
                           

            var sut = new UsersController(mockUserService.Object);

            //Act

            var res = await sut.Get();


            //Assert
            mockUserService.Verify(service => service.GetAllUsers(), Times.Once);

        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfUsers()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();

            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());


            var sut = new UsersController(mockUserService.Object);

            //Act

            var res = await sut.Get();


            //Assert
           res.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)res;
           objectResult.Value.Should().BeOfType<List<User>>();

        }
    }
}
