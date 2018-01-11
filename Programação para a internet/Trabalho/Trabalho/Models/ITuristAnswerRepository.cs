using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public interface ITuristAnswerRepository
    {
        IEnumerable<TuristAnswer> TuristAnswer { get; }
    }
}
