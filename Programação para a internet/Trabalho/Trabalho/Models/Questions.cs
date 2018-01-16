using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Questions
    {

        public int QuestionsID { get; set; }
        [Required(ErrorMessage = "Por favor indroduza uma pergunta!")]
        public string QuestionsToClient { get; set; }

        [Required(ErrorMessage = "Ative ou Desative a pergunta!")]
        public bool QuestionsState { get; set; }

        public List<Answer> Answer { get; set; }
      

       
    }
}
