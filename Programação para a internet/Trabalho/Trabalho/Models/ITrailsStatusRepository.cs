using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class ITrailsStatusRepository
    {
        IEnumerable<TrailsStatus> TrailsStatus { get; }
    }
}
