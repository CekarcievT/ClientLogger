using ClientLogger.Business.Models;
using System.Collections.Generic;

namespace ClientLogger.Business.Interfaces
{
    public interface IClientService
    {
        public List<ClientFullInfo> GetAllCLients();
        public ClientFullInfo CreateClient(ClientFullInfo clientFullInfo);
        public void UpdateClient(ClientFullInfo clientFullInfo);
        public void DeleteClient(ClientFullInfo clientFullInfo);
    }
}
