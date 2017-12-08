using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFClientRepository : IClientRepository
    {

        private TrabalhoDbContext dbContext;

        public EFClientRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Client> Client => dbContext.Client;
    }
}

