using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Question
    {

        public int QuestionID { get; set; }
        public string QuestionToClient { get; set; }
        public Boolean? QuestionState { get; set; }


    
        public List<Que_Dis> Que_Dis { get; set; }

        public List<Type_Answer> Type_Answer { get; set; }


    }
}
