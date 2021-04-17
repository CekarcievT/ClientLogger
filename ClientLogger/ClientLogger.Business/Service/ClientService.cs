using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using ClientLogger.Business.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientLogger.Business.Service
{
    public class ClientService: IClientService
    {
        readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository) {
            _clientRepository = clientRepository;
        }
        
        public List<Client> GetAllCLients()
        {
            var result = _clientRepository.GetAllClients();
            return result;
        }
    }
}
