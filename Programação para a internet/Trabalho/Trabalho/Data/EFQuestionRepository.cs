using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFQuestionRepository : IQuestionRepository
    {


            private TrabalhoDbContext dbContext;

            public EFQuestionRepository(TrabalhoDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public IEnumerable<Question> Question => dbContext.Question;


        
    }
}
