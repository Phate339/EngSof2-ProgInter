using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    // NEVER DO THIS !!!
    // This is only for demonstration/academic purposes
    public class Repository{
        private static List<SurveysResponse> responses = new List<SurveysResponse>();

        public static IEnumerable<SurveysResponse> Responses
        {
            get
            {
                return responses;
            }
        }

        public static void AddResponse(SurveysResponse response)
        {
            responses.Add(response);
        }
    }
}
