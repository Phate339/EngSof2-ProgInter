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
            TrabalhoDbContext context = (TrabalhoDbContext)appServices.GetService(typeof(TrabalhoDbContext));
            
             if (context.Turist.Any()) return;
            context.Turist.AddRange(
           //new Client { ClientName="Joao",Email="jelfreire@sapo.pt",Emergency_Contact=54343095,NIF=13231223,Genre=true }

            );
            context.SaveChanges();

      
/*
            context.Answer.AddRange(
            new Answer { AnswerToClient = "21",  },
            new Answer { AnswerToClient = "79", }

            );
            */
            /*
            if (context.Answer.Any()) return;
            context.Answer.AddRange(

                entities: new Answer {Survey.Question="nsdfbdsif",AnswerToClient="21"}
                );
            context.SaveChanges();
            */
        }
    }
}
