using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFDiseasesRepository : DiseasesRepository
    {
        private ApplicationDbContext dbContext;

        public EFDiseasesRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Diseases> Diseases => dbContext.Diseases;

    }
}
