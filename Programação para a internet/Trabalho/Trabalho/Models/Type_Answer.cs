using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Type_Answer
    {
        public int Type_AnswerID { get; set; }
        public string PossibleAnswer { get; set; }



        public List<Ans_For_Que> Ans_For_Que { get; set; }
    }
}
