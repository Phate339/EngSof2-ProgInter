using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Que_Dis
    {

        public int Que_DisID { get; set; }
        public Boolean? YES_NO { get; set; }

        public int QuestionID { get; set; }
        [ForeignKey("QuestionID")]
        public Question Question { get; set; }

        public int DiseasesID { get; set; }
        [ForeignKey("DiseasesID ")]
        public Diseases Diseases { get; set; }
    }
}
