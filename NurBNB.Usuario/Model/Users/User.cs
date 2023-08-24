using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Model.Users 
{
    public class User : AggregateRoot
    {
        public string? Username { get; private set; }
        public Email? Email { get; private set; }
        public string? Password { get; private set; }
        public User() { }
        public User(string username, string email, string password) 
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            Password = password;
        }

        public void Edit(string username)
        {
            Username = username;
        }


    }
}
