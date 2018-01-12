using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class TuristAnswer
    {


        public int TuristAnswerID { get; set; }
        public int SurveyNumber { get; set; }
        public DateTime AnswerDate { get; set; }

       

        public int TuristID { get; set; }
        [ForeignKey("TuristID")]
        public Turist Turist { get; set; }

        public int AnswerID { get; set; }
        [ForeignKey("AnswerID")]
        public Answer Answer { get; set; }

    }
}
