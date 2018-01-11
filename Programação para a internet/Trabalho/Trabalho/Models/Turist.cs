using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Turist
    {
        public int TuristID { get; set; }
        public string TuristName { get; set; }
        public int Phone { get; set; }
        public Boolean? Genre { get; set; }
        public DateTime Birthday { get; set; }
        public int NIF { get; set; }
        public string Email { get; set; }
        public int EmergencyContact { get; set; }
        public Boolean? TuristState { get; set; }


        public List<TuristAnswer> TuristAnswer { get; set; }


    }
}
