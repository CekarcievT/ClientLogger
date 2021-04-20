using ClientLogger.Business.Models;
using System.Collections.Generic;

namespace ClientLogger.Business.Interfaces
{
    public interface IClientRepository
    {
        public List<ClientFullInfo> GetAllClients();
        public ClientFullInfo GetClientById(int id);
        public void UpdateClient(ClientFullInfo clientFullInfo);
        public ClientFullInfo CreateClient(ClientFullInfo clientFullInfo);
        public void DeleteClient(ClientFullInfo clientFullInfo);

    }
}
