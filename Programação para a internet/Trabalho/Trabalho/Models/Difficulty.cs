using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Difficulty
    {

        public int DifficultyID { get; set; }
        public string DifficultyName { get; set; }

        public List<Trails> Trails { get; set; }
        public List<Answer> Answer { get; set; }
    }
}
