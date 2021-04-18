using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientLogger.Business.Service
{
    public class AddressService: IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public List<AddressAggregationDTO> GetCountryAggregations(string property)
        {
            List<AddressAggregationDTO> result = new List<AddressAggregationDTO>();
            result = _addressRepository.GetAllAddresses()
                .GroupBy(address => address.GetType().GetProperty(property).GetValue(address,null))
                .Select(address => new AddressAggregationDTO
                {
                    Name = address.Key.ToString(),
                    Count = address.Count()
                }).ToList();
            return result;
        }
    }
}
