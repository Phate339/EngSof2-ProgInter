using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public interface ITra_SurRepository
    {


        IEnumerable<Tra_Sur> Tra_Sur { get; }

    }
}
