using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class EFSurveyRepository : ISurveyRepository
    {

        private TrabalhoDbContext dbContext;

        public EFSurveyRepository(TrabalhoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Survey> Survey => dbContext.Survey;
    }
}
