using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFParametersRepository :IParametersRepository
    {

        private TrabalhoDbContext dbContext;

        public EFParametersRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Parameters> Parameters => dbContext.Parameters;
    }
}
