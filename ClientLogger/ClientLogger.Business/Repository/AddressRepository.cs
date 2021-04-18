using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClientLogger.Business.Repository
{
    public class AddressRepository: IAddressRepository
    {
        private readonly GenericCRUDRepository _crud;

        public AddressRepository(GenericCRUDRepository crud)
        {
            _crud = crud;
        }

        public List<Address> GetAllAddresses()
        {
            return _crud.GetAllEntities<Address>().ToList();
        }
    }
}
