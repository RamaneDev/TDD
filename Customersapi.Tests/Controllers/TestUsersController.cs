using Customers.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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
            var sut = new UsersController();

            //Act
            var result = (OkObjectResult)await sut.Get();

            //Assert
            result.StatusCode.Should().Be(200);

        }
    }
}
