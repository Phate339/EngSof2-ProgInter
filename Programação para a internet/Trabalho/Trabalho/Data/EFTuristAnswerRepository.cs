using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFTuristAnswerRepository : ITuristAnswerRepository
    {

        private TrabalhoDbContext dbContext;

        public EFTuristAnswerRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<TuristAnswer> TuristAnswer => dbContext.TuristAnswer;

    }
}
