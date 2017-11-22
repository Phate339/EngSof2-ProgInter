using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public interface IType_ClientRepository
    {

        IEnumerable<Type_Client> Type_Client { get; }
    }
}
