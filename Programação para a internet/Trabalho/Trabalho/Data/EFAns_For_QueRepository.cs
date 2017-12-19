using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFAns_For_QueRepository : IAns_For_QueRepository
    {

        private TrabalhoDbContext dbContext;

        public EFAns_For_QueRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Ans_For_Que> Ans_For_Que => dbContext.Ans_For_Que;
    }
}
