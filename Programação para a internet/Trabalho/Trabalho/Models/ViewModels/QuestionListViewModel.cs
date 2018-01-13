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
        public int QuestionSelected { get; set; }
        public int AnswerSelected { get; set; }

        public string QuestionsName { get; set; }
    }
}
