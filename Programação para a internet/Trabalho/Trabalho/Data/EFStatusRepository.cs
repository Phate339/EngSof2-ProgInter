using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFStatusRepository : IStatusRepository
    {
        private TrabalhoDbContext dbContext;

        public EFStatusRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Status> Status => dbContext.Status;

    }
}
