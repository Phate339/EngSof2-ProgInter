using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public interface IQue_DisRepository
    {
        IEnumerable<Que_Dis> Que_Dis { get; }
    }
}
