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
        public string QuestionsToClient { get; set; }
        [Required(ErrorMessage = "Please select Yes or No")]
        public bool QuestionsState { get; set; }

        public List<TypeAnswer> TypeAnswer { get; set; }
        public List<Parameters> Parameters { get; set; }
        public List<TuristAnswer> TuristAnswer { get; set; }

       
    }
}
