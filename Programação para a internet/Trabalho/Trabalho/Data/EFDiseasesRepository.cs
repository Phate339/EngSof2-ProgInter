using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFDiseasesRepository : IDiseasesRepository
    {
        private TrabalhoDbContext dbContext;

        public EFDiseasesRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Diseases> Diseases => dbContext.Diseases;

    }
}
