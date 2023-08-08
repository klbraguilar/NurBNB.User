using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Model.Users
{
    public class Staff
    {
        private User _user;
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public Staff() 
        {
            _user = new User();  
        }

        public Staff(User user)
        {
            _user = user;
        }
    }
}
