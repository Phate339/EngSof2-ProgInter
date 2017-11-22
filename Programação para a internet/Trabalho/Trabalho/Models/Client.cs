using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int PhoneNumber { get; set; }
        public Boolean? Genre { get; set; }
        public DateTime Birthday { get; set; }
        public int NIF { get; set; }
        public string Email { get; set; }
        public int Emergency_Contact { get; set; }
        public int Type_ClientID { get; set; }
        public Boolean ? ClientState { get; set; }



        public List<Answer> Answer { get; set; }



    }
}
