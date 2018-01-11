using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Trails
    {
        public int TrailsID { get; set; }
        public string TrailsName { get; set; }
        public string Description { get; set; }
        public int Distance { get; set; }
        public Boolean TrailsState { get; set; }
        public DateTime TrailsStateDate { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }    



        public int DifficultyID { get; set; }
        [ForeignKey("DifficultyID")]
        public Difficulty Difficulty { get; set; }


    }
}
