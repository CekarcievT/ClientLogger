using ClientLogger.Business.Infrastructure;
using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientLogger.Business.Service
{
    public class AddressService: IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public List<AddressAggregationDTO> AggregateByField(string field)
        {
            List<RuleViolation> ruleViolations = new List<RuleViolation>();

            List<AddressAggregationDTO> result = new List<AddressAggregationDTO>();

            var selectedProperty = typeof(Address).GetProperties()
                .Where(x=>x.Name == field);

            // checking if the inputed field exists in the entity
            if (selectedProperty.Count() < 1)
            {
                ruleViolations.Add(new RuleViolation("This field doesn't exist"));
            }

            if (ruleViolations.Count > 0)
            {
                throw new RuleViolationException(ruleViolations);
            }
            try { 
                // aggregating addresses by the field sent as input parameter
                // The field parameter name must be the same as in the database
                result = _addressRepository.GetAllAddresses()
                    .GroupBy(address => address.GetType().GetProperty(field).GetValue(address,null))
                    .Select(address => new AddressAggregationDTO
                    {
                        Name = address.Key.ToString(),
                        Count = address.Count()
                    }).ToList();
                return result;
            } catch (Exception ex)
            {
                ruleViolations.Add(new RuleViolation(ex));
                throw new RuleViolationException(ruleViolations);
            }
        }
    }
}
