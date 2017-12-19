using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Tra_Sur
    {
        public int Tra_SurID { get; set; }
        public Boolean? Recommended { get; set; }

        public int TrailsID { get; set; }
        [ForeignKey("TrailsID")]
        public Trails Trails { get; set; }

        public int SurveyID { get; set; }
        [ForeignKey("SurveyID")]
        public Survey Survey { get; set; }

    }
}
