using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFDifficultyRepository : IDifficultyRepository
    {
        private TrabalhoDbContext dbContext;

        public EFDifficultyRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Difficulty> Difficulty => dbContext.Difficulty;
    }
}
