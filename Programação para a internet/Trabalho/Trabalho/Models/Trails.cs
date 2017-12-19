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
        public DateTime Initial_Date { get; set; }
        public DateTime Final_Date { get; set; }    



        public int DifficultyID { get; set; }
        [ForeignKey("DifficultyID")]
        public Difficulty Difficulty { get; set; }


        public List<Tra_Sur> Tra_Sur { get; set; }


    }
}
