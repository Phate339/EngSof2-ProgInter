using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.ViewModels
{
    public class QuestionListViewModel
    {
        public IEnumerable<Question> Question { get; set; }
        public IEnumerable<Diseases> Diseases { get; set; }
        public IEnumerable<Type_Answer> Type_Answer { get; set; }
    }
}
