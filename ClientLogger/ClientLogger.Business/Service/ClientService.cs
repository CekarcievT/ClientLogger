using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using System.Collections.Generic;

namespace ClientLogger.Business.Service
{
    public class ClientService: IClientService
    {
        readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository) {
            _clientRepository = clientRepository;
        }
        
        public List<ClientFullInfo> GetAllCLients()
        {
            var result = _clientRepository.GetAllClients();
            return result;
        }

        public ClientFullInfo CreateClient(ClientFullInfo clientFullInfo)
        {
            return _clientRepository.CreateClient(clientFullInfo);
        }

        public void UpdateClient(ClientFullInfo clientFullInfo)
        {
            _clientRepository.UpdateClient(clientFullInfo);
        }

        public void DeleteClient(ClientFullInfo clientFullInfo)
        {
            _clientRepository.DeleteClient(clientFullInfo);
        }
    }
}
