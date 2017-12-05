using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFQues_DisRepository : IQue_DisRepository
    {
        private ApplicationDbContext dbContext;

        public EFQues_DisRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Que_Dis> Que_Dis => dbContext.Que_Dis;

    }
}
