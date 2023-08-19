using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Model.Users
{
    public class Guest : Entity
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid UserID { get; private set; }

        private User _user;

        public Guest(string name, string lastName, string phoneNumber, Guid userId)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            UserID = userId;
        }
    }
}
