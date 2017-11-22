using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFClientRepository : ClientRepository
    {

        private ApplicationDbContext dbContext;

        public EFClientRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Client> Client => dbContext.Client;
    }
}

