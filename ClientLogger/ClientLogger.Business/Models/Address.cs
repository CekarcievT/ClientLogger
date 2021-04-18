namespace ClientLogger.Business.Models
{
    public class Address
    {
        public int id { get; set; }
        public string Street { get; set; }
        public string PostName { get; set; }
        public string PostNumber { get; set; }
        public string Country { get; set; }

        public Address(ClientFullInfo clientFullInfo)
        {
            id = clientFullInfo.AddressId;
            Street = clientFullInfo.Street;
            PostName = clientFullInfo.PostName;
            PostNumber = clientFullInfo.PostNumber;
            Country = clientFullInfo.Country;
        }
        public Address() { }
    }
}
