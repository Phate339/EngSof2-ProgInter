using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFAns_QueRepository : IAns_QueRepository
    {

            private TrabalhoDbContext dbContext;

            public EFAns_QueRepository(TrabalhoDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public IEnumerable<Ans_Que> Answer => dbContext.Ans_Que;


        }
}

