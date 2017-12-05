using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFStatusRepository
    {
        private ApplicationDbContext dbContext;

        public EFStatusRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Status> Status => dbContext.Status;

    }
}
