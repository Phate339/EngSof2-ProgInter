using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Type_Answer
    {

        public int Type_AnswerID { get; set; }
        public Boolean? Type { get; set; }

        public int QuestionID { get; set; }
        [ForeignKey("QuestionID")]
        public Question Question { get; set; }

        public int AnswerID { get; set; }
        [ForeignKey("AnswerID")]
        public Answer Answer { get; set; }

    }
}
