using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class TypeAnswer
    {
        public int TypeAnswerID { get; set; }
        public string PossibleAnswer { get; set; }


        public int QuestionsID { get; set; }
        [ForeignKey("QuestionsID")]
        public Questions Questions { get; set; }


    }
}
