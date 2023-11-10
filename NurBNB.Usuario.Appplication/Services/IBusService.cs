using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Appplication.Services
{
    public interface IBusService
    {
        Task PublishAsync(object message);
    }
}
