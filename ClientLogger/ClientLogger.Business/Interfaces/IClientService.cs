using ClientLogger.Business.Models;
using System.Collections.Generic;

namespace ClientLogger.Business.Interfaces
{
    public interface IClientService
    {
        public List<ClientFullInfo> GetAllCLients();
        public void CreateClient(ClientFullInfo clientFullInfo);
    }
}
