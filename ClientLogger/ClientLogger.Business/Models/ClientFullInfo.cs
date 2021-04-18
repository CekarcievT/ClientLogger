using System;

namespace ClientLogger.Business.Models
{
    public class ClientFullInfo
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string PostName { get; set; }
        public string PostNumber { get; set; }
        public string Country { get; set; }

        public ClientFullInfo(Client client, Address address)
        {
            id = client.id;
            FirstName = client.FirstName;
            LastName = client.LastName;
            Email = client.Email;
            BirthDate = client.BirthDate;
            AddressId = client.AddressId;
            Street = address.Street;
            PostName = address.PostName;
            PostNumber = address.PostNumber;
            Country = address.Country;
        }
        public ClientFullInfo() { }
    }
}
