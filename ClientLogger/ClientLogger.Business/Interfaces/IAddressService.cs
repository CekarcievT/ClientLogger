using ClientLogger.Business.Models;
using System.Collections.Generic;

namespace ClientLogger.Business.Interfaces
{
    public interface IAddressService
    {
        public List<AddressAggregationDTO> GetCountryAggregations(string property);
    }
}
