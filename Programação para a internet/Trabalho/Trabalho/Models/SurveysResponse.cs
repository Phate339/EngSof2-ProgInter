using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Trabalho.Models{
    public class SurveysResponse{

        [Required(ErrorMessage = "Please enter your birthday")]
        public int Birthday { get; set; }

        [Required(ErrorMessage = "Please enter your wheight")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Please enter your height")]
        public int Height { get; set; }

        [Required(ErrorMessage = "Please specify if and what disease u have")]
        public string Diseases { get; set; }
        /*
         [Required(ErrorMessage = "Please specify if and what disease u have")]
         public bool? Diseases { get; set; }
         */
    }
}
