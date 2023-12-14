using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Exceptions
{
    public class UsersCreationException : Exception
    {
        public UsersCreationException(string reason)
            : base("El usuario no puede ser creado porque " + reason) { }
    }
}
