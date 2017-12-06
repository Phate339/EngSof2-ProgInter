using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFDifficultyRepository : IDifficultyRepository
    {
        private ApplicationDbContext dbContext;

        public EFDifficultyRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Difficulty> Difficulty => dbContext.Difficulty;
    }
}
