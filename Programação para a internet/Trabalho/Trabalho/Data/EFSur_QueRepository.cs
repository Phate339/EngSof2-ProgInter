using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFSur_QueRepository : ISur_QueRepository
    {
     
            private TrabalhoDbContext dbContext;

            public EFSur_QueRepository(TrabalhoDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public IEnumerable<Sur_Que> Sur_Que => dbContext.Sur_Que;

        

    }
}
