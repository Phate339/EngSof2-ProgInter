using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFType_ClientRepository : Type_ClientRepository
    {
        private ApplicationDbContext dbContext;

        public EFType_ClientRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Type_Client> Type_Client => dbContext.Type_Client;


    }
}
