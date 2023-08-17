using Customers.API.Models;
using Customers.API.Services;
using Customersapi.Tests.Fixtures;
using Customersapi.Tests.Helpers;
using FluentAssertions;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Customersapi.Tests.Services
{
    public class TestUserService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokeHttpGetRequest()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);

            //Act
            await sut.GetAllUsers();


            //Assert
            handlerMock.Protected()
                .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(rq => rq.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnListOfUsers()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);

            //Act
            var users = await sut.GetAllUsers();


            //Assert            
            users.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task GetAllUsers_WhenHits404_ReturnsEmptyListOfUsers()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);

            //Act
            var users = await sut.GetAllUsers();


            //Assert            
            users.Count.Should().Be(0);
        }
    }
}
