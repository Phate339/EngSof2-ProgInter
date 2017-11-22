using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Sur_Dis
    
    
    {
        public int Sur_DisID { get; set; }
        public Boolean ? YES_NO { get; set; }

        public int SurveyID { get; set; }
        [ForeignKey("SurveyID")]
        public Survey Survey { get; set; }

        public int DiseasesID { get; set; }
        [ForeignKey("DiseasesID ")]
        public Diseases Diseases { get; set; }

    }
}
