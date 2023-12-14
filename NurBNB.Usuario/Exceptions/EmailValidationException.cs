using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Exceptions
{
    public class EmailValidationException : Exception
    {
        public EmailValidationException(string reason)
            : base("Debe verificar que el correo cuente con la siguiente caracteristica " + reason) { }
    }
}
