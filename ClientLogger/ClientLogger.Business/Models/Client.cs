using System;

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

        public Client(ClientFullInfo clientFullInfo)
        {
            id = clientFullInfo.id;
            FirstName = clientFullInfo.FirstName;
            LastName = clientFullInfo.LastName;
            Email = clientFullInfo.Email;
            BirthDate = clientFullInfo.BirthDate;
            AddressId = clientFullInfo.AddressId;
        }
        public Client() { }
    }
}
