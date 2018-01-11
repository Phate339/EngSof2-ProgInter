using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Parameters
    {
        public int ParametersID { get; set; }

        public int AllowedAnswer { get; set; }

        public int QuestionsID { get; set; }
        [ForeignKey("QuestionsID")]
        public Questions Questions { get; set; }

        public int DifficultyID { get; set; }
        [ForeignKey("DifficultyID")]
        public Difficulty Difficulty { get; set; }

    }
}
