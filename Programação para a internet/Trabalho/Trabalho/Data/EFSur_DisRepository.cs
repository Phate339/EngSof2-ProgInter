using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFSur_DisRepository :Sur_DisRepository
    {

        private ApplicationDbContext dbContext;

        public EFSur_DisRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Sur_Dis> Sur_Dis => dbContext.Sur_Dis;


    }
}
