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
            
            // if (context.Turist.Any()) return;
           /* context.Turist.AddRange(
           //new Client { ClientName="Joao",Email="jelfreire@sapo.pt",Emergency_Contact=54343095,NIF=13231223,Genre=true }

            );
            context.SaveChanges();*/


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

            //manzarra adicionar questoes
            /* context.Questions.AddRange(
                 new Questions
                 {QuestionsState=true,QuestionsToClient="Qual é a sua Idade?"}
                 );
             context.Questions.AddRange(
                 new Questions
                 { QuestionsState = true,QuestionsToClient = "Qual é a sua Altura?"}
                 );
             context.Questions.AddRange(
                 new Questions
                 { QuestionsState = true, QuestionsToClient = "Qual é o seu Peso?" }
                 );
             context.SaveChanges();*/

            //manzarra adicionar respostas

            /*context.TypeAnswer.AddRange(
                new TypeAnswer { PossibleAnswer="Entre 9 e 20", QuestionsID=1 }
                );
            context.TypeAnswer.AddRange(
                new TypeAnswer { PossibleAnswer = "Entre 21 e 40", QuestionsID = 1 }
                );
            context.TypeAnswer.AddRange(
                new TypeAnswer { PossibleAnswer = "41 ou mais", QuestionsID = 1 }
                );
            context.TypeAnswer.AddRange(
                new TypeAnswer { PossibleAnswer = "Entre 1,50m e 1,70m", QuestionsID = 2 }
                );
            context.TypeAnswer.AddRange(
                new TypeAnswer { PossibleAnswer = "Entre 1,71m e 1,90m", QuestionsID = 2 }
                );
            context.TypeAnswer.AddRange(
                new TypeAnswer { PossibleAnswer = "Mais que 1,90m", QuestionsID = 2 }
                );
            context.TypeAnswer.AddRange(
                new TypeAnswer { PossibleAnswer = "Entre 40kg e 60 kg", QuestionsID = 3 }
                );
            context.TypeAnswer.AddRange(
                new TypeAnswer { PossibleAnswer = "Entre 61kg e 80kg", QuestionsID = 3 }
                );
            context.TypeAnswer.AddRange(
                new TypeAnswer { PossibleAnswer = "Mais que 81kg", QuestionsID = 3 }
                );
            context.SaveChanges();*/

            //mazarra adicionar dificuldades 

            /*context.Difficulty.AddRange(
                new Difficulty { DifficultyName="Fácil"});
            context.Difficulty.AddRange(
                new Difficulty { DifficultyName = "Médio" });
            context.Difficulty.AddRange(
                new Difficulty { DifficultyName = "Difícil" });
            context.SaveChanges();*/

            //manzarra adicionar Parametros

            /*context.Parameters.AddRange(
                new Parameters { AllowedAnswer=1,DifficultyID=2,QuestionsID=1});
            context.Parameters.AddRange(
                new Parameters { AllowedAnswer = 2, DifficultyID = 1, QuestionsID = 1 });
            context.Parameters.AddRange(
                new Parameters { AllowedAnswer = 3, DifficultyID = 3, QuestionsID = 1 });
            context.Parameters.AddRange(
                new Parameters { AllowedAnswer = 4, DifficultyID = 1, QuestionsID = 2 });
            context.Parameters.AddRange(
                new Parameters { AllowedAnswer = 5, DifficultyID = 2, QuestionsID = 2 });
            context.Parameters.AddRange(
                new Parameters { AllowedAnswer = 6, DifficultyID = 3, QuestionsID = 2 });
            context.Parameters.AddRange(
                new Parameters { AllowedAnswer = 7, DifficultyID = 2, QuestionsID = 3 });
            context.Parameters.AddRange(
                new Parameters { AllowedAnswer = 8, DifficultyID = 1, QuestionsID = 3 });
            context.Parameters.AddRange(
                new Parameters { AllowedAnswer = 9, DifficultyID = 3, QuestionsID = 3 });
            context.SaveChanges();*/


            //manzarra adicionar Trilhos

            /*context.Trails.AddRange(
              new Trails {Description="Um Percurso ao ar livre, pouco inclinado", DifficultyID=1,Distance=9,InitialDate=Convert.ToDateTime("01/08/2012 14:50:50.42"), TrailsName ="Percurso ao Ar Livre",TrailsState=true, FinalDate = Convert.ToDateTime("01/01/1999 14:50:50.42"), TrailsStateDate = Convert.ToDateTime("01/08/2012 14:50:50.42") });
            context.Trails.AddRange(
            new Trails { Description = "Um Percurso longo, alguma inclinação", DifficultyID = 2, Distance = 18, InitialDate = Convert.ToDateTime("21/06/2014 14:50:50.42"), TrailsName = "Percurso Longo ao Ar Livre", FinalDate = Convert.ToDateTime("01/01/1999 14:50:50.42"), TrailsState = true, TrailsStateDate = Convert.ToDateTime("21/06/2014 14:50:50.42") });
            context.Trails.AddRange(
            new Trails { Description = "Um Percurso longo, com passagens subterrâneas e cavernas", DifficultyID = 3, Distance = 21, InitialDate = Convert.ToDateTime("21/08/2016 14:50:50.42"), TrailsName = "Percurso Subterrâneo",FinalDate= Convert.ToDateTime("01/01/1999 14:50:50.42"), TrailsState = true, TrailsStateDate = Convert.ToDateTime("21 /08/2016 14:50:50.42") });
            context.SaveChanges();*/

            //manzarra adicionar Turista

            /*context.Turist.AddRange(
                new Turist { Birthday = Convert.ToDateTime("05/06/1995 14:50:50.42"),Email="filipegomes@gmail.com",EmergencyContact=915896325,Genre=true,NIF=123456789,Phone=916598365,TuristName="Filipe Gomes",TuristState=true }
                );
            context.Turist.AddRange(
                new Turist { Birthday = Convert.ToDateTime("03/02/1980 14:50:50.42"), Email = "marcopolo@gmail.com", EmergencyContact = 968964785, Genre = true, NIF = 987654321, Phone = 968742035, TuristName = "Marco Polo", TuristState = true }
                );
            context.Turist.AddRange(
                new Turist { Birthday = Convert.ToDateTime("01/03/1970 14:50:50.42"), Email = "susanagomes@gmail.com", EmergencyContact = 935697425, Genre = true, NIF = 548963257, Phone = 938569423, TuristName = "Susana Gomes", TuristState = true }
                );
            context.SaveChanges();*/

        }
    }
}
