﻿using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Model.Users
{
    public class User : AggregateRoot
    {
        public int Id { get; private set; } 
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public User() { }


    }
}
