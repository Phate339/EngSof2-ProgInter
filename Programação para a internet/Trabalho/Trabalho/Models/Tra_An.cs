using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Tra_An
    {
        public int Tra_AnID { get; set; }
        public int TrailsID { get; set; }
        [ForeignKey("TrailsID")]
        public Question Trails { get; set; }
        public int AnswerID { get; set; }
        [ForeignKey("AnswerID")]
        public Question Answer { get; set; }
        public string Recomendation { get; set; }

    }
}
