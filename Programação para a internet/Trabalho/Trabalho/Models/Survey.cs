using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Trabalho.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }
        [Required(ErrorMessage = "Please enter your question!")]
        //[StringLength(MinimumLength = 4)]
      
          //  [RegularExpression("[a-zA-Z0-9?]{3,}", ErrorMessage = "Invalid License Plate")]
        public string Question { get; set; }
        public Boolean ? QuestionState { get; set; }

        public List<Answer> Answer { get; set; }
        public List<Sur_Dis> Sur_Dis { get; set; }
    }
}
