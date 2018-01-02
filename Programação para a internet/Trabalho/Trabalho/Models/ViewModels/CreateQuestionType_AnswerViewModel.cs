using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.ViewModels
{
    public class CreateQuestionType_AnswerViewModel
    {
        public int Type_AnswerID { get; set; }
        public string PossibleAnswer { get; set; }
        public bool Assigned { get; set; }
    }
}
