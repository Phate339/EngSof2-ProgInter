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
        public Boolean ? Genero { get; set; }
        public DateTime Birthday { get; set; }
        public int NIF { get; set; }
        public string Email { get; set; }
        public int emergency_contact { get; set; }
        public int ID_Type_Client { get; set; }
        public Boolean ? ClientState { get; set; }



    }
}
