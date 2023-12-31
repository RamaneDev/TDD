﻿using System.Net.Sockets;

namespace Customers.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address{ get; set; }
    }
}
