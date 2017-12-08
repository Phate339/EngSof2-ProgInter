using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Sur_Que
    {

        public int Sur_QueID { get; set; }

        public int SurveyID { get; set; }
        [ForeignKey("SurveyID")]
        public Survey Survey { get; set; }

        public int QuestionID { get; set; }
        [ForeignKey("QuestionID")]
        public Question Question { get; set; }


    }
}
