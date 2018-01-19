using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Por favor indroduza o seu nome de login!")]
        //[EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor introduza a sua password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
