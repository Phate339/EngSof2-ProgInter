using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFTuristRepository : ITuristRepository
    {
      
            private TrabalhoDbContext dbContext;

            public EFTuristRepository(TrabalhoDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public IEnumerable<Turist> Turist => dbContext.Turist;
        


    }
}
