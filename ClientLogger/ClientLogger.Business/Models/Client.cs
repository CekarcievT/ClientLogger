using System;
using System.Collections.Generic;
using System.Text;

namespace ClientLogger.Business.Models
{
    public class Client
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int AddressId { get; set; }
    }
}
