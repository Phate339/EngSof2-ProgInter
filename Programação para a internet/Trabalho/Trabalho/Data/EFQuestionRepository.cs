using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFQuestionRepository : IQuestionRepository
    {


            private ApplicationDbContext dbContext;

            public EFQuestionRepository(ApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public IEnumerable<Question> Question => dbContext.Question;


        
    }
}
