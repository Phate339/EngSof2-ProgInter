using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.ViewModels
{
    public class CreateQuestionDiseasesViewModel
    {
        public int DiseasesID { get; set; }
        public string DiseasesName { get; set; }
        public bool Assigned { get; set; }
    }
}
