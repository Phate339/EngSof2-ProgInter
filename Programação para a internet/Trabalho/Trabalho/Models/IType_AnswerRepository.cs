using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public interface IType_AnswerRepository
    {

        IEnumerable<Type_Answer> Type_Answer { get; }
    }
}
