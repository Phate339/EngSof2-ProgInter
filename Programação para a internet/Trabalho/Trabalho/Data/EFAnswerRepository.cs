using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFAnswerRepository : IAnswerRepository
    {

        private TrabalhoDbContext dbContext;

        public EFAnswerRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Answer> Answer => dbContext.Answer;
    }
}
