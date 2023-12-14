using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Test.SharedKernel.Core
{
    public class MockValidRule : IBussinessRule
    {
        public string Message => "Rule is valid.";

        public bool IsValid() => true;
    }
}
