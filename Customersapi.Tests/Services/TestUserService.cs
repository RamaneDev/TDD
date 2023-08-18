using Customers.API.Config;
using Customers.API.Models;
using Customers.API.Services;
using Customersapi.Tests.Fixtures;
using Customersapi.Tests.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var endpoint = "https://example.com/users";
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UsersApiOptions
            {
                Endpoint = endpoint
            });

            var sut = new UserService(httpClient, config);

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
            var endpoint = "https://example.com/users";
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UsersApiOptions
            {
                Endpoint = endpoint
            });


            var sut = new UserService(httpClient, config);

            //Act
            var users = await sut.GetAllUsers();


            //Assert            
            users.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task GetAllUsers_WhenHits404_ReturnsEmptyListOfUsers()
        {
            //Arrange
            var endpoint = "https://example.com/users";
            var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UsersApiOptions
            {
                Endpoint = endpoint
            });

            var sut = new UserService(httpClient, config);

            //Act
            var users = await sut.GetAllUsers();


            //Assert            
            users.Count.Should().Be(0);
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListOfUsersOfExpectedSize()
        {
            var endpoint = "https://example.com/users";
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse); ;
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UsersApiOptions
            {
                Endpoint = endpoint
            });

            var sut = new UserService(httpClient, config);

            //Act
            var users = await sut.GetAllUsers();


            //Assert            
            users.Count.Should().Be(users.Count);
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var endpoint = "https://example.com/users";
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UsersApiOptions
            {
                Endpoint = endpoint
            });
            var sut = new UserService(httpClient, config);

            //Act
            var result  = await sut.GetAllUsers();


            var Uri = new Uri(endpoint);


            //Assert
                handlerMock.Protected()
                .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(rq => rq.Method == HttpMethod.Get && rq.RequestUri.Equals(Uri)),
                ItExpr.IsAny<CancellationToken>());


           

        }
    }
}
