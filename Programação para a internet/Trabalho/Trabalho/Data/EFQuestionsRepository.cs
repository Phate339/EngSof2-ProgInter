using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFQuestionsRepository : IQuestionsRepository
    {
        private TrabalhoDbContext dbContext;

        public EFQuestionsRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Questions> Questions => dbContext.Questions;

    }
}
