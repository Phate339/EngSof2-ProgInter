using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public string Question { get; set; }
        public Boolean ? QuestionState { get; set; }

        public List<Answer> Answer { get; set; }
        public List<Sur_Dis> Sur_Dis { get; set; }
    }
}
