using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Survey
    {

        public int SurveyID { get; set; }
        public int Type_AnswerID { get; set; }
        public int DiseasesID { get; set; }
        public DateTime DateAnswer { get; set; }



        public int TuristID { get; set; }
        [ForeignKey("TuristID")]
        public Turist Turist { get; set; }


        public int QuestionID { get; set; }
        [ForeignKey("QuestionID")]
        public Question Question { get; set; }      



    }
}
