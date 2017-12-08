using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFType_ClientRepository : IType_ClientRepository
    {
        private TrabalhoDbContext dbContext;

        public EFType_ClientRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Type_Client> Type_Client => dbContext.Type_Client;


    }
}
