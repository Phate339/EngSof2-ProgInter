using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public interface IAns_For_QueRepository
    {

        IEnumerable<Ans_For_Que> Ans_For_Que { get; }
    }
}
