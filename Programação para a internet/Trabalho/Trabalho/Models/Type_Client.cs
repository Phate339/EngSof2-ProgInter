using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Type_Client
    {
        public int Type_ClientID { get; set; }
        public string TypeClient { get; set; }

        public List<Client> Client { get; set; }
    }
}
