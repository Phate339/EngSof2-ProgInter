using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Answer
    {

        public int AnswerID { get; set; }
        [Required(ErrorMessage = "Por favor indroduza uma resposta!")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Resposta Inválida")]
        public string PossibleAnswer { get; set; }


        public int QuestionsID { get; set; }
        [ForeignKey("QuestionsID")]
        public Questions Questions { get; set; }

        public int DifficultyID { get; set; }
        [ForeignKey("DifficultyID")]
        public Difficulty Difficulty { get; set; }


        public List<TuristAnswer> TuristAnswer { get; set; }



    }
}
