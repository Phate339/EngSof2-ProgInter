using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFSurveyRepository : ISurveyRepository
    {

        private ApplicationDbContext dbContext;

        public EFSurveyRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Survey> Survey => dbContext.Survey;
    }
}

