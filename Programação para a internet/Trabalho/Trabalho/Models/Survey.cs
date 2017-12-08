using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public Boolean? SurveyState { get; set; }

        public List<Sur_Que> Sur_Que { get; set; }


    }
}
