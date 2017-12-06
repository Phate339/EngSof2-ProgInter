using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFTra_AnRepository : ITra_AnRepository
    {
        private ApplicationDbContext dbContext;

        public EFTra_AnRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Tra_An> Tra_An => dbContext.Tra_An;
    }
}
