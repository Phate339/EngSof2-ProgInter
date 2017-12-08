using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Ans_Que
    {

        public int Ans_QueID { get; set; }

        public string ResPer { get; set; }


        public int QuestionID { get; set; }
        [ForeignKey("QuestionID")]
        public Question Question { get; set; }


    }
}
