using Customers.API.Models;
using System.Collections.Generic;


namespace Customersapi.Tests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() => new()
        {
            new() {
                    Id = 1,
                    Name = "Diane",
                    Address = new Address
                    {
                        Street = "123 Main St",
                        City = "Strasbourg",
                        ZipCode = "54065"
                    },
                    Email = "Diane@exemple.com"
             },
            new() {
                    Id = 1,
                    Name = "Jane",
                    Address = new Address
                    {
                        Street = "34 Main St",
                        City = "Toulouse",
                        ZipCode = "56530"
                    },
                    Email = "Jane@exemple.com"
             },
            new() {
                    Id = 1,
                    Name = "Sara",
                    Address = new Address
                    {
                        Street = "43 Main St",
                        City = "Paris",
                        ZipCode = "39494"
                    },
                    Email = "Sara@exemple.com"
             },

        };
    }
}
