using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.ViewModels
{
    public class Ty_DiViewModel
    {
        IEnumerable<Question> Question { get; }
        IEnumerable<Type_Answer> Type_Answer { get; }

    }
}
