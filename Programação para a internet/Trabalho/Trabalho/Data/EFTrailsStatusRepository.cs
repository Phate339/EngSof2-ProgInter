using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFTrailsStatusRepository : ITrailsStatusRepository
    {

        private ApplicationDbContext dbContext;

        public EFTrailsStatusRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<TrailsStatus> TrailsStatus => dbContext.TrailsStatus;
    }
}
