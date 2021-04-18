using ClientLogger.Business.Models;
using System.Collections.Generic;

namespace ClientLogger.Business.Interfaces
{
    public interface IAddressRepository
    {
        public List<Address> GetAllAddresses();
    }
}
