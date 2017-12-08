using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public interface IAns_QueRepository
    {

        IEnumerable<Ans_Que> Ans_Que { get; }

    }
}
