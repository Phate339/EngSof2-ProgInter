using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFTypeAnswerRepository : ITypeAnswerRepository
    {
       
            private TrabalhoDbContext dbContext;

            public EFTypeAnswerRepository(TrabalhoDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public IEnumerable<TypeAnswer> TypeAnswer => dbContext.TypeAnswer;
        }
    
}
