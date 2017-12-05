using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFType_AnswerRepository : IType_AnswerRepository
    {

        private ApplicationDbContext dbContext;

        public EFType_AnswerRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Type_Answer> Type_Answer => dbContext.Type_Answer;

    }
}
