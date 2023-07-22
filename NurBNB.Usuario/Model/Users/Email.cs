using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Model.Users
{
    public record Email : ValueObject
    {
        public string Value { get; init; }

        internal Email(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            Value = value;
        }

        public static implicit operator string(Email email) => email.Value;

        public static implicit operator Email(string email) => new(email);
    }
}
