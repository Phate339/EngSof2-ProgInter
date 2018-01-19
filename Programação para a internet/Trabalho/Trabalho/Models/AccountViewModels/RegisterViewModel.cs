using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.AccountViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Por favor indroduza o seu nome!")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Nome Inválido!")]
        public string TuristName { get; set; }

        [RegularExpression("^[92]{1}[1236]{1}[0-9]{1}[\\s|-]?[0-9]{3}[\\s|-]?[0-9]{3}", ErrorMessage = "Contacto Inválido!")]
        [Required(ErrorMessage = "Por favor indroduza o contacto!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Tem de seleccionar o género!")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Por favor indroduza a data de nascimento do turista!")]
        [DataType(DataType.Date) ]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Por favor indroduza o seu NIF!")]
        [RegularExpression(@"(\d{9})", ErrorMessage = "NIF Inválido")]
        public int NIF { get; set; }

        [Required(ErrorMessage = "Por favor indroduza o email!")]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})", ErrorMessage = "Email Inválido!")]
        public string Email { get; set; }


        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Contacto Inválido!")]
        [Required(ErrorMessage = "Por favor indroduza o contacto de emergencia")]
        public string EmergencyContact { get; set; }

        [Required( ErrorMessage = "Por favor introduza uma password!")]
        [StringLength(100, ErrorMessage = "A palavra passe deve conter no minimo 6 caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "A password e a confirmação não combinam!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Seleccione o tipo de utilizador!")]
        public string TypeTurist { get; set; }

        public Boolean? TuristState { get; set; }

    }
}
