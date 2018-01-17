using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Trabalho.Models.ManageViewModels
{
    public class IndexViewModel
    {


        [Required]
        [EmailAddress]
        public string Email { get; set; }

       

        public string StatusMessage { get; set; }
    }
}
