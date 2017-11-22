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
            new Survey { SurveyID =1, Question = "Qual é a sua idade?",QuestionState = true  },
            new Survey { SurveyID = 2, Question = "Qual é o seu peso?", QuestionState = false }

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
