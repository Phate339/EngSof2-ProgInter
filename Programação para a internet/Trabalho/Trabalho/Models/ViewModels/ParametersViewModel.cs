using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.ViewModels
{
    public class ParametersViewModel
    {
       public IEnumerable<Questions> Questions { get; set; }

        public IEnumerable<Difficulty> Difficulty { get; set; }

        public IEnumerable<TypeAnswer> TypeAnswer { get; set; }

        public IEnumerable<Parameters> Parameters { get; set; }

    }
}
