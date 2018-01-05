using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Question
    {

        public int QuestionID { get; set; }
        public string QuestionToClient { get; set; }
        [Required(ErrorMessage = "Please select Yes or No")]
        public bool QuestionState { get; set; }


    
        public List<Que_Dis> Que_Dis { get; set; }
        public List<Ans_For_Que> Ans_For_Que { get; set; }
        public List<Survey> Survey { get; set; }    

    }
}
