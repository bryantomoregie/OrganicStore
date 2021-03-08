﻿using System;
namespace OrganicStore.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Cart Cart { get; set; }
    }
}
