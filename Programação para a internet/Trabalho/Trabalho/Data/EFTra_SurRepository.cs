using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFTra_SurRepository : ITra_SurRepository
    {

        private TrabalhoDbContext dbContext;

        public EFTra_SurRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Tra_Sur> Tra_Sur => dbContext.Tra_Sur;
    }
}
