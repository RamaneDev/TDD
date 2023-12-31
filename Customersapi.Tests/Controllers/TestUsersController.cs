﻿using Customers.API.Controllers;
using Customers.API.Models;
using Customers.API.Services;
using Customersapi.Tests.Fixtures;
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
        public async Task Get_OnSuccess_ReurnsStatusCode200()     // success
        {            
            //Arrange
            var mockUserService = new Mock<IUserService>();

            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());

            var sut = new UsersController(mockUserService.Object);

            //Act
            var result = (OkObjectResult)await sut.Get();

            //Assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task Get_OnSuccess_InvokeUserServiceExactlyOnce()   // success
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
        public async Task Get_OnSuccess_ReturnsListOfUsers()   // success
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();

            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());


            var sut = new UsersController(mockUserService.Object);

            //Act

            var res = await sut.Get();


            //Assert
           res.Should().BeOfType<OkObjectResult>();
           var objectResult = (OkObjectResult)res;
           objectResult.Value.Should().BeOfType<List<User>>();

        }

        [Fact]
        public async Task Get_OnNoUsersFound_Returns404()   // success
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
            res.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)res;
            objectResult.StatusCode.Should().Be(404);
        }
    }
}
