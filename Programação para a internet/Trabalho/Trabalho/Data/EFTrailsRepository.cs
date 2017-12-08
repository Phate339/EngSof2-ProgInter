using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFTrailsRepository : ITrailsRepository
    {


        private TrabalhoDbContext dbContext;

        public EFTrailsRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Trails> Client => dbContext.Trails;
    }
}
