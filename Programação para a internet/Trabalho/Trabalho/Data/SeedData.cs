using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IServiceProvider appServices)
        {
            ApplicationDbContext context = (ApplicationDbContext)appServices.GetService(typeof(ApplicationDbContext));
            if (context.Survey.Any()) return;
            context.Survey.AddRange(
            new Survey { Question = "Qual é a sua data de nascimento?",QuestionState = true  },
            new Survey { Question = "Qual é o seu peso?", QuestionState = false }







            );
            context.SaveChanges();
        }
    }
}
