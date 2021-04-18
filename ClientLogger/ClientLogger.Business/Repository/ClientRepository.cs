using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClientLogger.Business.Repository
{
    public class ClientRepository: IClientRepository
    {
        private readonly GenericCRUDRepository _crud;

        public ClientRepository(GenericCRUDRepository crud)
        {
            _crud = crud;
        }

        public List<ClientFullInfo> GetAllClients()
        {
            return _crud.GetAllEntities<ClientFullInfo>().ToList();
        }
        public ClientFullInfo GetClientById(int id)
        {
            var client = _crud.GetEntityById<Client>(id);
            var address = _crud.GetEntityById<Address>(client.AddressId);

            ClientFullInfo result = new ClientFullInfo(client, address);

            return result;
        }
        public void UpdateClient(ClientFullInfo clientFullInfo)
        {
            var transaction = _crud.Context.Database.BeginTransaction();

            Client client = new Client(clientFullInfo);
            Address address = new Address(clientFullInfo);

            try
            {
                _crud.UpdateEntity<Address>(address);
                _crud.UpdateEntity<Client>(client);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }
        public void DeleteClient(ClientFullInfo clientFullInfo)
        {
            var transaction = _crud.Context.Database.BeginTransaction();

            Client client = new Client(clientFullInfo);
            Address address = new Address(clientFullInfo);

            try
            {
                _crud.DeleteEntity<Address>(address);
                _crud.DeleteEntity<Client>(client);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        public void CreateClient(ClientFullInfo clientFullInfo)
        {
            var transaction = _crud.Context.Database.BeginTransaction();

            Client client = new Client(clientFullInfo);
            Address address = new Address(clientFullInfo);

            try
            {
                _crud.CreateEntity<Client>(client);
                _crud.CreateEntity<Address>(address);

                transaction.Commit();
            } catch
            {
                transaction.Rollback();
            }
        }
    }
}
