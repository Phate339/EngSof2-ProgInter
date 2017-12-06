using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class TrailsStatus
    {
        public int TrailsStatusID { get; set; }
        public int StatusID { get; set; }
        [ForeignKey("StatusID")]
        public Question Status { get; set; }

        public int TrailsID { get; set; }
        [ForeignKey("TrailsID")]
        public Question Trails { get; set; }
        public DateTime Date_Start { get; set; }
        public DateTime Date_End { get; set; }

    }
}
