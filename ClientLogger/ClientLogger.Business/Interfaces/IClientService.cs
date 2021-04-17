using ClientLogger.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientLogger.Business.Interfaces
{
    public interface IClientService
    {
        List<Client> GetAllCLients();
    }
}
