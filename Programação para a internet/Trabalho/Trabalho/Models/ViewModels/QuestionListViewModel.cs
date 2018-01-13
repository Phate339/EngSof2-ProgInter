using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.ViewModels
{
    public class QuestionListViewModel
    {
       public IEnumerable<Questions> Questions { get; set; }
        public IEnumerable<Answer> Answer { get; set; }
        public IEnumerable<Difficulty> Difficulty { get; set; }
    }
}
