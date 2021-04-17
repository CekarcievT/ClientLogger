using ClientLogger.Business.Infrastructure;
using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientLogger.Business.Repository
{
    public class ClientRepository: IClientRepository
    {
        IServiceScopeFactory _scopeFactory;
        public ClientRepository(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public List<Client> GetAllClients()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                return context.Client.ToList();
            }
        }
        public void DeleteClient(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                var client = context.Client.ToList().Where(x => x.id == id).SingleOrDefault();
                context.Client.Remove(client);
                context.SaveChanges();
            }
        }
    }
}
