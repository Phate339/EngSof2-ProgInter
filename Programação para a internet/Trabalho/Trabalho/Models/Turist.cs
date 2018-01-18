using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trabalho.Infrastructure;

namespace Trabalho.Models
{
    public class Turist
    {
        public int TuristID { get; set; }


        [Required(ErrorMessage = "Por favor indroduza o nome")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Nome Inválido")]
        public string TuristName { get; set; }

        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Contacto Inválido")]
        [Required(ErrorMessage = "Por favor indroduza o contacto")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Tem de seleccionar o genero")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Por favor indroduza a data de nascimento do turista")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Birthday { get; set; }

        [CodeNIF]
        public int NIF { get; set; }

        [Required(ErrorMessage = "Por favor indroduza o email")]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})", ErrorMessage = "Email Inválido")]
        public string Email { get; set; }


        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Contacto Inválido")]
        [Required(ErrorMessage = "Por favor indroduza o contacto de emergencia")]
        public string EmergencyContact { get; set; }


        public Boolean? TuristState { get; set; }

        public string TypeTurist { get; set; }


        public List<TuristAnswer> TuristAnswer { get; set; }


    }
}
