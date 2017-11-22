using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public interface Type_ClientRepository
    {

        IEnumerable<Type_Client> Type_Client { get; }
    }
}
