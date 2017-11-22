using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Client
    {
        public int ID_Client { get; set; }
        public string ClientName { get; set; }
        public int PhoneNumber { get; set; }
        public Boolean? Genre { get; set; }
        public DateTime Birthday { get; set; }
        public int NIF { get; set; }
        public string Email { get; set; }
        public int Emergency_Contact { get; set; }
        public int ID_Type_Client { get; set; }
        public Boolean ? ClientState { get; set; }



    }
}
