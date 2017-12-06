using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public interface ITra_AnRepository
    {
        IEnumerable<Tra_An> Tra_An { get; }
    }
}
