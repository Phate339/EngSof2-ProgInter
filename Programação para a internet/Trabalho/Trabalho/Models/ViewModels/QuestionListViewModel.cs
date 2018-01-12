using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.ViewModels
{
    public class QuestionListViewModel
    {
       public IEnumerable<Questions> Questions { get; set; }
        public IEnumerable<TypeAnswer> TypeAnswer { get; set; }
        public int QuestionSelected { get; set; }


       public string QuestionsName { get; set; }
    }
}
