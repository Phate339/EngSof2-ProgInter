using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Answer
    {
        public int AnswerID{ get; set; }

        [Required(ErrorMessage = "Please enter your answer!")]
        public string AnswerToClient { get; set; }

      
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public Client Client { get; set; }

        public int SurveyID { get; set; }
        [ForeignKey("SurveyID ")]
        public Survey Survey { get; set; }

        public List<Tra_An> Tra_An { get; set; }



    }
}
